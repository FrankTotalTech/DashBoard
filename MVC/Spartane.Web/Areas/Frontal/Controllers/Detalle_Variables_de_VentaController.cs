using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Detalle_Variables_de_Venta;
using Spartane.Core.Domain.Variable;
using Spartane.Core.Domain.Detalle_Valor_de_Variable;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Detalle_Variables_de_Venta;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Variables_de_Venta;
using Spartane.Web.Areas.WebApiConsumer.Variable;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Valor_de_Variable;

using Spartane.Web.AuthFilters;
using Spartane.Web.Helpers;
using Spartane.Web.Models;
using Spartane.Web.SqlModelMapper;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using Spartane.Core.Domain.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Business_Rule;
using Spartane.Web.Areas.WebApiConsumer.Spartan_BR_Process_Event_Detail;

namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Detalle_Variables_de_VentaController : Controller
    {
        #region "variable declaration"

        private IDetalle_Variables_de_VentaService service = null;
        private IDetalle_Variables_de_VentaApiConsumer _IDetalle_Variables_de_VentaApiConsumer;
        private IVariableApiConsumer _IVariableApiConsumer;
        private IDetalle_Valor_de_VariableApiConsumer _IDetalle_Valor_de_VariableApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Detalle_Variables_de_VentaController(IDetalle_Variables_de_VentaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IDetalle_Variables_de_VentaApiConsumer Detalle_Variables_de_VentaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer , IVariableApiConsumer VariableApiConsumer , IDetalle_Valor_de_VariableApiConsumer Detalle_Valor_de_VariableApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IDetalle_Variables_de_VentaApiConsumer = Detalle_Variables_de_VentaApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._IVariableApiConsumer = VariableApiConsumer;
            this._IDetalle_Valor_de_VariableApiConsumer = Detalle_Valor_de_VariableApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Detalle_Variables_de_Venta
        [ObjectAuth(ObjectId = (ModuleObjectId)40122, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index()
        {
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40122);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
            return View();
        }

        // GET: Frontal/Detalle_Variables_de_Venta/Create
        [ObjectAuth(ObjectId = (ModuleObjectId)40122, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit)]
        public ActionResult Create(int Id = 0,  int consult = 0)
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40122);
            ViewBag.Permission = permission;
            var varDetalle_Variables_de_Venta = new Detalle_Variables_de_VentaModel();
			
            ViewBag.ObjectId = "40122";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;



            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Detalle_Variables_de_VentaData = _IDetalle_Variables_de_VentaApiConsumer.GetByKeyComplete(Id).Resource.Detalle_Variables_de_Ventas[0];
                if (Detalle_Variables_de_VentaData == null)
                    return HttpNotFound();

                varDetalle_Variables_de_Venta = new Detalle_Variables_de_VentaModel
                {
                    Folio = (int)Detalle_Variables_de_VentaData.Folio
                    ,Variable = Detalle_Variables_de_VentaData.Variable
                    ,VariableDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Variables_de_VentaData.Variable), "Variable") ??  (string)Detalle_Variables_de_VentaData.Variable_Variable.Descripcion
                    ,Valor = Detalle_Variables_de_VentaData.Valor
                    ,ValorValor = CultureHelper.GetTraduction(Convert.ToString(Detalle_Variables_de_VentaData.Valor), "Detalle_Valor_de_Variable") ??  (string)Detalle_Variables_de_VentaData.Valor_Detalle_Valor_de_Variable.Valor

                };

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IVariableApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Variables_Variable = _IVariableApiConsumer.SelAll(true);
            if (Variables_Variable != null && Variables_Variable.Resource != null)
                ViewBag.Variables_Variable = Variables_Variable.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Variable", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDetalle_Valor_de_VariableApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Valor_de_Variables_Valor = _IDetalle_Valor_de_VariableApiConsumer.SelAll(true);
            if (Detalle_Valor_de_Variables_Valor != null && Detalle_Valor_de_Variables_Valor.Resource != null)
                ViewBag.Detalle_Valor_de_Variables_Valor = Detalle_Valor_de_Variables_Valor.Resource.OrderBy(m => m.Valor).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Valor_de_Variable", "Valor") ?? m.Valor.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
            return View(varDetalle_Variables_de_Venta);
        }
		
	[HttpGet]
        public ActionResult AddDetalle_Variables_de_Venta(int rowIndex = 0, int functionMode = 0, int id = 0)
        {
            int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40122);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
			Detalle_Variables_de_VentaModel varDetalle_Variables_de_Venta= new Detalle_Variables_de_VentaModel();


            if (id.ToString() != "0")
            {
                var Detalle_Variables_de_VentasData = _IDetalle_Variables_de_VentaApiConsumer.ListaSelAll(0, 1000, "Detalle_Variables_de_Venta.Folio=" + id, "").Resource.Detalle_Variables_de_Ventas;
				
				if (Detalle_Variables_de_VentasData != null && Detalle_Variables_de_VentasData.Count > 0)
                {
					var Detalle_Variables_de_VentaData = Detalle_Variables_de_VentasData.First();
					varDetalle_Variables_de_Venta= new Detalle_Variables_de_VentaModel
					{
						Folio  = Detalle_Variables_de_VentaData.Folio 
	                    ,Variable = Detalle_Variables_de_VentaData.Variable
                    ,VariableDescripcion = CultureHelper.GetTraduction(Convert.ToString(Detalle_Variables_de_VentaData.Variable), "Variable") ??  (string)Detalle_Variables_de_VentaData.Variable_Variable.Descripcion
                    ,Valor = Detalle_Variables_de_VentaData.Valor
                    ,ValorValor = CultureHelper.GetTraduction(Convert.ToString(Detalle_Variables_de_VentaData.Valor), "Detalle_Valor_de_Variable") ??  (string)Detalle_Variables_de_VentaData.Valor_Detalle_Valor_de_Variable.Valor

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IVariableApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Variables_Variable = _IVariableApiConsumer.SelAll(true);
            if (Variables_Variable != null && Variables_Variable.Resource != null)
                ViewBag.Variables_Variable = Variables_Variable.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Variable", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IDetalle_Valor_de_VariableApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Detalle_Valor_de_Variables_Valor = _IDetalle_Valor_de_VariableApiConsumer.SelAll(true);
            if (Detalle_Valor_de_Variables_Valor != null && Detalle_Valor_de_Variables_Valor.Resource != null)
                ViewBag.Detalle_Valor_de_Variables_Valor = Detalle_Valor_de_Variables_Valor.Resource.OrderBy(m => m.Valor).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Valor_de_Variable", "Valor") ?? m.Valor.ToString(), Value = Convert.ToString(m.Folio)
                }).ToList();


            return PartialView("AddDetalle_Variables_de_Venta", varDetalle_Variables_de_Venta);
        }


        [HttpGet]
        public FileResult GetFile(int id)
        {

            if (!_tokenManager.GenerateToken())
                return null;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var fileInfo = _ISpartane_FileApiConsumer.GetByKey(id).Resource;
            if (fileInfo == null)
                return null;
            return File(fileInfo.File, System.Net.Mime.MediaTypeNames.Application.Octet, fileInfo.Description);
        }

        [HttpGet]
        public ActionResult GetVariableAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVariableApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IVariableApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Variable", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Valor_de_VariableAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Valor_de_VariableApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_Valor_de_VariableApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Valor).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Folio), "Detalle_Valor_de_Variable", "Valor")?? m.Valor,
                    Value = Convert.ToString(m.Folio)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Variables_de_VentaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IDetalle_Variables_de_VentaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Variables_de_Ventas == null)
                result.Detalle_Variables_de_Ventas = new List<Detalle_Variables_de_Venta>();

            return Json(new
            {
                data = result.Detalle_Variables_de_Ventas.Select(m => new Detalle_Variables_de_VentaGridModel
                    {
                    Folio = m.Folio
                        ,VariableDescripcion = CultureHelper.GetTraduction(m.Variable_Variable.Clave.ToString(), "Descripcion") ?? (string)m.Variable_Variable.Descripcion
                        ,ValorValor = CultureHelper.GetTraduction(m.Valor_Detalle_Valor_de_Variable.Folio.ToString(), "Valor") ?? (string)m.Valor_Detalle_Valor_de_Variable.Valor

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }







       

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Detalle_Variables_de_Venta varDetalle_Variables_de_Venta = null;
                if (id.ToString() != "0")
                {
                        string where = "";

                }
                var result = _IDetalle_Variables_de_VentaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Detalle_Variables_de_VentaModel varDetalle_Variables_de_Venta)
        {
            try
            {
				if (ModelState.IsValid)
				{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Detalle_Variables_de_VentaInfo = new Detalle_Variables_de_Venta
                    {
                        Folio = varDetalle_Variables_de_Venta.Folio
                        ,Variable = varDetalle_Variables_de_Venta.Variable
                        ,Valor = varDetalle_Variables_de_Venta.Valor

                    };

                    result = !IsNew ?
                        _IDetalle_Variables_de_VentaApiConsumer.Update(Detalle_Variables_de_VentaInfo, null, null).Resource.ToString() :
                         _IDetalle_Variables_de_VentaApiConsumer.Insert(Detalle_Variables_de_VentaInfo, null, null).Resource.ToString();

                    return Json(result, JsonRequestBehavior.AllowGet);
				}
				return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Detalle_Variables_de_Venta script
        /// </summary>
        /// <param name="oDetalle_Variables_de_VentaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElements Detalle_Variables_de_VentaModuleAttributeList)
        {
            for (int i = 0; i < Detalle_Variables_de_VentaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Detalle_Variables_de_VentaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Detalle_Variables_de_VentaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Detalle_Variables_de_VentaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Detalle_Variables_de_VentaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					if (string.IsNullOrEmpty(Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue))
					{
						Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList[i].DefaultValue = string.Empty;
					}
					if (string.IsNullOrEmpty(Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList[i].HelpText))
					{
						Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList[i].HelpText = string.Empty;
					}
				}
			}
            string strDetalle_Variables_de_VentaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Variables_de_Venta.js")))
            {
                strDetalle_Variables_de_VentaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Detalle_Variables_de_Venta element attributes
            string userChangeJson = jsSerialize.Serialize(Detalle_Variables_de_VentaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strDetalle_Variables_de_VentaScript.IndexOf("inpuElementArray");
            string splittedString = strDetalle_Variables_de_VentaScript.Substring(indexOfArray, strDetalle_Variables_de_VentaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strDetalle_Variables_de_VentaScript.IndexOf("inpuElementChildArray");
				splittedStringHistory = strDetalle_Variables_de_VentaScript.Substring(indexOfArrayHistory, strDetalle_Variables_de_VentaScript.Length - indexOfArrayHistory);
				indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
				endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
			}
			string finalResponse = strDetalle_Variables_de_VentaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strDetalle_Variables_de_VentaScript.Substring(endIndexOfMainElement + indexOfArray, strDetalle_Variables_de_VentaScript.Length - (endIndexOfMainElement + indexOfArray));
            if (Detalle_Variables_de_VentaModuleAttributeList.ChildModuleAttributeList != null)
            {
				finalResponse = strDetalle_Variables_de_VentaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson
                + strDetalle_Variables_de_VentaScript.Substring(endIndexOfMainElement + indexOfArray, (indexOfMainElementHistory + indexOfArrayHistory) - (endIndexOfMainElement + indexOfArray)) + childUserChangeJson
                + strDetalle_Variables_de_VentaScript.Substring(endIndexOfMainElementHistory + indexOfArrayHistory, strDetalle_Variables_de_VentaScript.Length - (endIndexOfMainElementHistory + indexOfArrayHistory));
			}
            
            

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Detalle_Variables_de_Venta.js")))
            {
                w.WriteLine(finalResponse);
            }
            
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult ReadScriptSettings()
        {
            string strCustomScript = string.Empty;
            
            CustomElementAttribute oCustomElementAttribute = new CustomElementAttribute();

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Detalle_Variables_de_Venta.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Detalle_Variables_de_Venta.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("inpuElementChildArray");
				string childJsonArray = "";
                if (indexOfChildArray != -1)
                {
					string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);
					int indexOfChildElement = splittedChildString.IndexOf('[');
					int endIndexOfChildElement = splittedChildString.IndexOf(']') + 1;
					childJsonArray = splittedChildString.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement);
				}
                var MainElementList = JsonConvert.DeserializeObject(mainJsonArray);
                var ChildElementList = JsonConvert.DeserializeObject(childJsonArray);

                oCustomElementAttribute.MainElement = MainElementList.ToString();
				if (indexOfChildArray != -1)
                {
					oCustomElementAttribute.ChildElement = ChildElementList.ToString();
				}
            }
            else
            {
                oCustomElementAttribute.MainElement = string.Empty;
                oCustomElementAttribute.ChildElement = string.Empty;
            }        
            return Json(oCustomElementAttribute, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Detalle_Variables_de_VentaPropertyBag()
        {
            return PartialView("Detalle_Variables_de_VentaPropertyBag", "Detalle_Variables_de_Venta");
        }
		
		public List<Spartan_Business_Rule> GetBusinessRules(int ObjectId, int Attribute)
        {
            if (!_tokenManager.GenerateToken())
                return null;
            List<Spartan_Business_Rule> result = new List<Spartan_Business_Rule>();
            _ISpartan_Business_RuleApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (Attribute != 0)
            {
                result = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId + " AND Attribute = " + Attribute, "").Resource.Spartan_Business_Rules;
            }
            else
            {
                List<Spartan_Business_Rule> partialResult = _ISpartan_Business_RuleApiConsumer.ListaSelAll(0, 1000, "Object = " + ObjectId, "").Resource.Spartan_Business_Rules;
                foreach (var item in partialResult)
                {
                    if (item.Attribute == Attribute)
                    {
                        result.Add(item);
                    }
                    else//Busco las reglas con el event process en cuestion
                    {
                        _ISpartan_BR_Process_Event_DetailApiConsumer.SetAuthHeader(_tokenManager.Token);
                        var eventProcess = _ISpartan_BR_Process_Event_DetailApiConsumer.ListaSelAll(0, 1000, "Business_Rule = " + item.BusinessRuleId, "").Resource;
                        if (Attribute == 0 && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 1).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 2) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 2 || x.Process_Event == 3).Count() > 0)
                        {
                            result.Add(item);
                        }
                        if ((Attribute == 3) && eventProcess.Spartan_BR_Process_Event_Details.Where(x => x.Process_Event == 4 || x.Process_Event == 5).Count() > 0)
                        {
                            result.Add(item);
                        }
                        //TODO Faltan en la base de datos cuando creas una row de grilla
                    }
                }
            }
            return result;
        }



        #endregion "Controller Methods"

        #region "Custom methods"

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Variables_de_VentaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Variables_de_VentaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Variables_de_Ventas == null)
                result.Detalle_Variables_de_Ventas = new List<Detalle_Variables_de_Venta>();

            var data = result.Detalle_Variables_de_Ventas.Select(m => new Detalle_Variables_de_VentaGridModel
            {
                Folio = m.Folio
                ,VariableDescripcion = (string)m.Variable_Variable.Descripcion
                ,ValorValor = (string)m.Valor_Detalle_Valor_de_Variable.Valor

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Detalle_Variables_de_VentaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Detalle_Variables_de_VentaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "EmployeeList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Detalle_Variables_de_VentaPropertyMapper());

            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IDetalle_Variables_de_VentaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Detalle_Variables_de_Ventas == null)
                result.Detalle_Variables_de_Ventas = new List<Detalle_Variables_de_Venta>();

            var data = result.Detalle_Variables_de_Ventas.Select(m => new Detalle_Variables_de_VentaGridModel
            {
                Folio = m.Folio
                ,VariableDescripcion = (string)m.Variable_Variable.Descripcion
                ,ValorValor = (string)m.Valor_Detalle_Valor_de_Variable.Valor

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
    }
}
