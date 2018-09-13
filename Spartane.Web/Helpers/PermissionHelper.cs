using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Spartane.Core.Domain.Permission;
using Spartane.Core.Domain.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.SpartaneFunction;
using Spartane.Web.Areas.WebApiConsumer.SpartaneUserRoleObjectFunction;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Phases;
using Spartane.Web.Areas.WebApiConsumer.Spartan_WorkFlow_Roles_by_State;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Metadata;

namespace Spartane.Web.Helpers
{

    public static class PermissionHelper
    {
        private static readonly ISpartaneUserRoleObjectFunctionApiConsumer _spartaneUserRoleObjectFunctionApiConsumer;
        private static readonly ISpartaneFunctionApiConsumer _spartaneFunctionApiConsumer;
        private static readonly ITokenManager _tokenManager;
        //WorkFlows Permissions
        private static readonly ISpartan_WorkFlowApiConsumer _Spartan_WorkFlowApiConsumer;
        private static readonly ISpartan_WorkFlow_PhasesApiConsumer _Spartan_WorkFlow_PhasesApiConsumer;
        private static readonly ISpartan_WorkFlow_Roles_by_StateApiConsumer _Spartan_WorkFlow_Roles_by_StateApiConsumer;

        private static readonly ISpartan_MetadataApiConsumer _ISpartan_MetadataApiConsumer;
        static PermissionHelper()
        {
            _tokenManager = DependencyResolver.Current.GetService<ITokenManager>();
            _spartaneUserRoleObjectFunctionApiConsumer = DependencyResolver.Current.GetService<ISpartaneUserRoleObjectFunctionApiConsumer>();
            _spartaneFunctionApiConsumer = DependencyResolver.Current.GetService<ISpartaneFunctionApiConsumer>();
            //WorkFlows Permissions
            _Spartan_WorkFlowApiConsumer = DependencyResolver.Current.GetService<ISpartan_WorkFlowApiConsumer>();
            _Spartan_WorkFlow_PhasesApiConsumer = DependencyResolver.Current.GetService<ISpartan_WorkFlow_PhasesApiConsumer>();
            _Spartan_WorkFlow_Roles_by_StateApiConsumer = DependencyResolver.Current.GetService<ISpartan_WorkFlow_Roles_by_StateApiConsumer>();
            _ISpartan_MetadataApiConsumer = DependencyResolver.Current.GetService<ISpartan_MetadataApiConsumer>();
        }

        /// <summary>
        /// Used to get the Permission for Role Object
        /// </summary>
        /// <param name="roleId"></param>
        /// <param name="objectId"></param>
        /// <returns></returns>
        public static Permission GetRoleObjectPermission(int roleId, int objectId = 0, int moduleId = 0, int attributeId = 0)
        {
            try
            {
                if (!_tokenManager.GenerateToken("admin", "admin"))
                    throw new ArgumentException("Unable to Authorize the application");

                if (objectId == 0 && attributeId != 0)
                {
                    _ISpartan_MetadataApiConsumer.SetAuthHeader(_tokenManager.Token);
                    var resultMeta = _ISpartan_MetadataApiConsumer.GetByKey(attributeId, false).Resource;
                    objectId = Convert.ToInt32(resultMeta.Related_Object_Id);
					 moduleId = 0;
                }


                _spartaneUserRoleObjectFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
                _spartaneFunctionApiConsumer.SetAuthHeader(_tokenManager.Token);
                string where = "spartan_user_rule_object_function.Object_Id=" + objectId +
                    " AND spartan_user_rule_object_function.Spartan_User_Rule=" + roleId;
                if (moduleId != 0)
                {
                    where += " AND spartan_user_rule_object_function.Module_Id=" + moduleId;
                }
                var userRoleObjectFunctions = _spartaneUserRoleObjectFunctionApiConsumer.ListaSelAll(1, int.MaxValue, where, "").Resource;

                if (userRoleObjectFunctions == null ||
                    userRoleObjectFunctions.Spartan_User_Rule_Object_Functions == null)
                    return new Permission();

                var spartaneFuctions = new List<SpartaneFunction>();

                foreach (var userRoleObjectFunction in userRoleObjectFunctions.Spartan_User_Rule_Object_Functions)
                {
                    spartaneFuctions.Add(_spartaneFunctionApiConsumer.GetByKey(userRoleObjectFunction.Fuction_Id, true).Resource);
                }

                Permission ObjectPermissions = GetSpartanePermission(spartaneFuctions);
                //WorkFlows Permissions
                #region WorkFlows Permissions
                if (System.Web.HttpContext.Current.Session != null)
                {
                    if (System.Web.HttpContext.Current.Session["Phase"] != null)
                    {
                        if (System.Web.HttpContext.Current.Session["Phase"].ToString() != "")
                        {
                            //Consult if the object has workflow assigned
                            _Spartan_WorkFlowApiConsumer.SetAuthHeader(_tokenManager.Token);
                            var workflowObject = _Spartan_WorkFlowApiConsumer.ListaSelAll(1, int.MaxValue, "spartan_workflow.object = " + objectId.ToString() + " and spartan_workflow.status=1", "").Resource;
                            if (workflowObject != null)
                            {
                                if (workflowObject.Spartan_WorkFlows.Count != 0)
                                {
                                    //Consultar id de Fase
                                    _Spartan_WorkFlow_PhasesApiConsumer.SetAuthHeader(_tokenManager.Token);
                                    var phaseObject = _Spartan_WorkFlow_PhasesApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_WorkFlow_Phases.WorkFlow=" + workflowObject.Spartan_WorkFlows[0].WorkFlowId.ToString() + " and Spartan_WorkFlow_Phases.Phase_Number=" + System.Web.HttpContext.Current.Session["Phase"].ToString() + " and Spartan_WorkFlow_Phases.phase_status=1", "").Resource;
                                    if (phaseObject != null)
                                    {
                                        if (phaseObject.Spartan_WorkFlow_Phasess.Count != 0)
                                        {
                                            //Consultar Permisos
                                            _Spartan_WorkFlow_Roles_by_StateApiConsumer.SetAuthHeader(_tokenManager.Token);
                                            var rolesObject = _Spartan_WorkFlow_Roles_by_StateApiConsumer.ListaSelAll(1, int.MaxValue, "Spartan_WorkFlow_Roles_by_State.Spartan_WorkFlow=" + workflowObject.Spartan_WorkFlows[0].WorkFlowId.ToString() + " and Spartan_WorkFlow_Roles_by_State.Phase=" + phaseObject.Spartan_WorkFlow_Phasess[0].PhasesId.ToString() + " and Spartan_WorkFlow_Roles_by_State.User_Role=" + roleId.ToString(), "").Resource;
                                            if (rolesObject != null)
                                            {
                                                if (rolesObject.Spartan_WorkFlow_Roles_by_States.Count != 0)
                                                {
                                                    if (rolesObject.Spartan_WorkFlow_Roles_by_States[0].Permission_To_New == false)
                                                        ObjectPermissions.New = false;

                                                    if (rolesObject.Spartan_WorkFlow_Roles_by_States[0].Permission_To_Modify == false)
                                                        ObjectPermissions.Edit = false;

                                                    if (rolesObject.Spartan_WorkFlow_Roles_by_States[0].Permission_to_Delete == false)
                                                        ObjectPermissions.Delete = false;

                                                    if (rolesObject.Spartan_WorkFlow_Roles_by_States[0].Permission_To_Export == false)
                                                        ObjectPermissions.Export = false;

                                                    if (rolesObject.Spartan_WorkFlow_Roles_by_States[0].Permission_To_Print == false)
                                                        ObjectPermissions.Print = false;

                                                    if (rolesObject.Spartan_WorkFlow_Roles_by_States[0].Permission_Settings == false)
                                                        ObjectPermissions.Configure = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                #endregion
                return ObjectPermissions;
            }
            catch (ArgumentException)
            {
                return new Permission();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private static Permission GetSpartanePermission(IEnumerable<SpartaneFunction> spartaneFunctions)
        {
            var permission = new Permission();
            try
            {



                foreach (var spartaneFunction in spartaneFunctions)
                {
                    if (spartaneFunction.Status == 1)
                        switch (spartaneFunction.Description.ToUpper())
                        {
                            case "CONSULT": permission.Consult = true;
                                break;
                            case "NEW": permission.New = true;
                                break;
                            case "EDIT": permission.Edit = true;
                                break;
                            case "DELETE": permission.Delete = true;
                                break;
                            case "EXPORT": permission.Export = true;
                                break;
                            case "PRINT": permission.Print = true;
                                break;
                            case "CONFIGURE": permission.Configure = true;
                                break;

                        }
                }
                return permission;
            }
            catch (Exception)
            {
                return permission;
            }
        }
    }
}
