using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using Spartane.Core.Domain.Registro_de_Orden_de_Venta;
using Spartane.Core.Domain.Cliente;
using Spartane.Core.Domain.Detalle_Variables_de_Venta;
using Spartane.Core.Domain.Variable;
using Spartane.Core.Domain.Detalle_Valor_de_Variable;

using Spartane.Core.Domain.Estatus;

using Spartane.Core.Enums;
using Spartane.Core.Domain.Spartane_File;
using Spartane.Core.Exceptions.Service;
using Spartane.Services.Registro_de_Orden_de_Venta;
using Spartane.Web.Areas.Frontal.Models;
using Spartane.Web.Areas.WebApiConsumer;
using Spartane.Web.Areas.WebApiConsumer.Spartane_File;
using Spartane.Web.Areas.WebApiConsumer.ApiAuthentication;
using Spartane.Web.Areas.WebApiConsumer.Registro_de_Orden_de_Venta;
using Spartane.Web.Areas.WebApiConsumer.Cliente;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Variables_de_Venta;
using Spartane.Web.Areas.WebApiConsumer.Variable;
using Spartane.Web.Areas.WebApiConsumer.Detalle_Valor_de_Variable;

using Spartane.Web.Areas.WebApiConsumer.Estatus;

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

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format;
using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Permissions;
using Spartane.Web.Areas.WebApiConsumer.GeneratePDF;
using Spartane.Web.Areas.WebApiConsumer.Spartan_User;

using Spartane.Web.Areas.WebApiConsumer.Spartan_Format_Related;
using Spartane.Core.Domain.Spartan_Format;
using iTextSharp.text.pdf;


namespace Spartane.Web.Areas.Frontal.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, VaryByParam = "*")]
    public class Registro_de_Orden_de_VentaController : Controller
    {
        #region "variable declaration"

        private IRegistro_de_Orden_de_VentaService service = null;
        private IRegistro_de_Orden_de_VentaApiConsumer _IRegistro_de_Orden_de_VentaApiConsumer;
        private IClienteApiConsumer _IClienteApiConsumer;
        private IDetalle_Variables_de_VentaApiConsumer _IDetalle_Variables_de_VentaApiConsumer;
        private IVariableApiConsumer _IVariableApiConsumer;
        private IDetalle_Valor_de_VariableApiConsumer _IDetalle_Valor_de_VariableApiConsumer;

        private IEstatusApiConsumer _IEstatusApiConsumer;

        private ISpartan_Business_RuleApiConsumer _ISpartan_Business_RuleApiConsumer;
        private ISpartan_BR_Process_Event_DetailApiConsumer _ISpartan_BR_Process_Event_DetailApiConsumer;
        private ISpartane_FileApiConsumer _ISpartane_FileApiConsumer;
        private IAuthenticationApiConsumer _IAuthenticationApiConsumer = null;
        private Spartane_Credential _userCredential = null;
        private ITokenManager _tokenManager = null;
        private IGeneratePDFApiConsumer _IGeneratePDFApiConsumer;
        private ISpartan_FormatApiConsumer _ISpartan_FormatApiConsumer;
        private ISpartan_Format_PermissionsApiConsumer _ISpartan_Format_PermissionsApiConsumer;
		private ISpartan_Format_RelatedApiConsumer _ISpartan_FormatRelatedApiConsumer;

        #endregion "variable declaration"

        #region "Constructor Declaration"

        
        public Registro_de_Orden_de_VentaController(IRegistro_de_Orden_de_VentaService service,ITokenManager tokenManager, IAuthenticationApiConsumer authenticationApiConsumer, IRegistro_de_Orden_de_VentaApiConsumer Registro_de_Orden_de_VentaApiConsumer, ISpartane_FileApiConsumer Spartane_FileApiConsumer, ISpartan_Business_RuleApiConsumer Spartan_Business_RuleApiConsumer, ISpartan_BR_Process_Event_DetailApiConsumer Spartan_BR_Process_Event_DetailApiConsumer, ISpartan_FormatApiConsumer Spartan_FormatApiConsumer, ISpartan_Format_PermissionsApiConsumer Spartan_Format_PermissionsApiConsumer, IGeneratePDFApiConsumer GeneratePDFApiConsumer, ISpartan_Format_RelatedApiConsumer Spartan_Format_RelatedApiConsumer , IClienteApiConsumer ClienteApiConsumer , IDetalle_Variables_de_VentaApiConsumer Detalle_Variables_de_VentaApiConsumer , IVariableApiConsumer VariableApiConsumer , IDetalle_Valor_de_VariableApiConsumer Detalle_Valor_de_VariableApiConsumer  , IEstatusApiConsumer EstatusApiConsumer )
        {
            this.service = service;
            this._IAuthenticationApiConsumer = authenticationApiConsumer;
            this._IRegistro_de_Orden_de_VentaApiConsumer = Registro_de_Orden_de_VentaApiConsumer;
            this._userCredential = SessionHelper.UserCredential;
            this._tokenManager = tokenManager;
            this._ISpartane_FileApiConsumer = Spartane_FileApiConsumer;
            this._ISpartan_Business_RuleApiConsumer = Spartan_Business_RuleApiConsumer;
            this._ISpartan_BR_Process_Event_DetailApiConsumer = Spartan_BR_Process_Event_DetailApiConsumer;
            this._ISpartan_FormatApiConsumer = Spartan_FormatApiConsumer;
            this._ISpartan_Format_PermissionsApiConsumer = Spartan_Format_PermissionsApiConsumer;
            this._IGeneratePDFApiConsumer = GeneratePDFApiConsumer;
			this._ISpartan_FormatRelatedApiConsumer = Spartan_Format_RelatedApiConsumer;
            this._IClienteApiConsumer = ClienteApiConsumer;
            this._IDetalle_Variables_de_VentaApiConsumer = Detalle_Variables_de_VentaApiConsumer;
            this._IVariableApiConsumer = VariableApiConsumer;
            this._IDetalle_Valor_de_VariableApiConsumer = Detalle_Valor_de_VariableApiConsumer;

            this._IEstatusApiConsumer = EstatusApiConsumer;

        }

        #endregion "Constructor Declaration"

        #region "Controller Methods"

        // GET: Frontal/Registro_de_Orden_de_Venta
        [ObjectAuth(ObjectId = (ModuleObjectId)40121, PermissionType = PermissionTypes.Consult)]
        public ActionResult Index(int ModuleId=0)
        {
			if (Session["AdvanceReportFilter"] != null)
            {
                Session["AdvanceReportFilter"] = null;
                Session["AdvanceSearch"] = null;
            }
			if (ModuleId == 0)
            {
                ModuleId = Convert.ToInt32(Session["CurrentModuleId"]);
                if (ModuleId == 0)
                {
                    Response.Redirect("~/");
                }
            }
            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40121, ModuleId);
            ViewBag.Permission = permission;
            ViewBag.AdvanceSearch = Session["AdvanceSearch"] != null;
			          
            return View();
        }

        // GET: Frontal/Registro_de_Orden_de_Venta/Create
          [ObjectAuth(ObjectId = (ModuleObjectId)40121, PermissionType = PermissionTypes.New,
            OptionalParameter = "Id", OptionalPermissionType = PermissionTypes.Edit, OptionalPermissionTypeConsult = PermissionTypes.Consult)]
        public ActionResult Create(int Id = 0,  int consult = 0, int ModuleId=0)
        {
                       if(ModuleId == 0)
                       {
			    ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
                       }
                       else
                            Session["CurrentModuleId"] = ModuleId;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40121, ModuleId);
           if ((!permission.New && Id.ToString() == "0") || (!permission.Edit && Id.ToString() != "0" && (!permission.Consult && consult == 1)))
            {
                Response.Redirect("~/");
            }
            ViewBag.Permission = permission;
            var varRegistro_de_Orden_de_Venta = new Registro_de_Orden_de_VentaModel();
			varRegistro_de_Orden_de_Venta.Folio = Id;
			
            ViewBag.ObjectId = "40121";
			ViewBag.Operation = "New";
			
			ViewBag.IsNew = true;

            var permissionDetalle_Variables_de_Venta = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40122, ModuleId);
            ViewBag.PermissionDetalle_Variables_de_Venta = permissionDetalle_Variables_de_Venta;


            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short))&& Id.ToString() != "0"))
            {
				ViewBag.IsNew = false;
				ViewBag.Operation = "Update";
				
				_tokenManager.GenerateToken();
				_ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var Registro_de_Orden_de_VentasData = _IRegistro_de_Orden_de_VentaApiConsumer.ListaSelAll(0, 1000, "Registro_de_Orden_de_Venta.Folio=" + Id, "").Resource.Registro_de_Orden_de_Ventas;
				
				if (Registro_de_Orden_de_VentasData != null && Registro_de_Orden_de_VentasData.Count > 0)
                {
					var Registro_de_Orden_de_VentaData = Registro_de_Orden_de_VentasData.First();
					varRegistro_de_Orden_de_Venta= new Registro_de_Orden_de_VentaModel
					{
						Folio  = Registro_de_Orden_de_VentaData.Folio 
	                    ,Fecha_de_Registro = (Registro_de_Orden_de_VentaData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Registro_de_Orden_de_VentaData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Registro_de_Orden_de_VentaData.Hora_de_Registro
                    ,Cliente = Registro_de_Orden_de_VentaData.Cliente
                    ,ClienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Orden_de_VentaData.Cliente), "Cliente") ??  (string)Registro_de_Orden_de_VentaData.Cliente_Cliente.Nombre_Completo
                    ,Estatus = Registro_de_Orden_de_VentaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Orden_de_VentaData.Estatus), "Estatus") ??  (string)Registro_de_Orden_de_VentaData.Estatus_Estatus.Descripcion
                    ,Observaciones = Registro_de_Orden_de_VentaData.Observaciones

					};
				}
				
				
				
            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IClienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Clientes_Cliente = _IClienteApiConsumer.SelAll(true);
            if (Clientes_Cliente != null && Clientes_Cliente.Resource != null)
                ViewBag.Clientes_Cliente = Clientes_Cliente.Resource.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cliente", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            ViewBag.Consult = consult == 1;
			if (consult == 1)
                ViewBag.Operation = "Consult";
				
			var isPartial = false;
            var isMR = false;
            var nameMR = string.Empty;
            var nameAttribute = string.Empty;

	        if (Request.QueryString["isPartial"]!= null)
                isPartial = Convert.ToBoolean(Request.QueryString["isPartial"]);

            if (Request.QueryString["isMR"] != null)
                isMR = Convert.ToBoolean(Request.QueryString["isMR"]);

            if (Request.QueryString["nameMR"] != null)
                nameMR = Request.QueryString["nameMR"].ToString();

            if (Request.QueryString["nameAttribute"] != null)
                nameAttribute = Request.QueryString["nameAttribute"].ToString();
				
			ViewBag.isPartial=isPartial;
			ViewBag.isMR=isMR;
			ViewBag.nameMR=nameMR;
			ViewBag.nameAttribute=nameAttribute;

				
            return View(varRegistro_de_Orden_de_Venta);
        }
		
	[HttpGet]
        public ActionResult AddRegistro_de_Orden_de_Venta(int rowIndex = 0, int functionMode = 0, string id = "0")
        {
			int ModuleId = (Session["CurrentModuleId"] != null) ? Convert.ToInt32(Session["CurrentModuleId"]) : 0;
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            ViewBag.Consult = false;
            var permission = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40121);
            ViewBag.Permission = permission;
			if (!_tokenManager.GenerateToken())
                return null;
           _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
			Registro_de_Orden_de_VentaModel varRegistro_de_Orden_de_Venta= new Registro_de_Orden_de_VentaModel();
            var permissionDetalle_Variables_de_Venta = PermissionHelper.GetRoleObjectPermission(SessionHelper.Role, 40122, ModuleId);
            ViewBag.PermissionDetalle_Variables_de_Venta = permissionDetalle_Variables_de_Venta;


            if (id.ToString() != "0")
            {
                var Registro_de_Orden_de_VentasData = _IRegistro_de_Orden_de_VentaApiConsumer.ListaSelAll(0, 1000, "Registro_de_Orden_de_Venta.Folio=" + id, "").Resource.Registro_de_Orden_de_Ventas;
				
				if (Registro_de_Orden_de_VentasData != null && Registro_de_Orden_de_VentasData.Count > 0)
                {
					var Registro_de_Orden_de_VentaData = Registro_de_Orden_de_VentasData.First();
					varRegistro_de_Orden_de_Venta= new Registro_de_Orden_de_VentaModel
					{
						Folio  = Registro_de_Orden_de_VentaData.Folio 
	                    ,Fecha_de_Registro = (Registro_de_Orden_de_VentaData.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(Registro_de_Orden_de_VentaData.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
                    ,Hora_de_Registro = Registro_de_Orden_de_VentaData.Hora_de_Registro
                    ,Cliente = Registro_de_Orden_de_VentaData.Cliente
                    ,ClienteNombre_Completo = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Orden_de_VentaData.Cliente), "Cliente") ??  (string)Registro_de_Orden_de_VentaData.Cliente_Cliente.Nombre_Completo
                    ,Estatus = Registro_de_Orden_de_VentaData.Estatus
                    ,EstatusDescripcion = CultureHelper.GetTraduction(Convert.ToString(Registro_de_Orden_de_VentaData.Estatus), "Estatus") ??  (string)Registro_de_Orden_de_VentaData.Estatus_Estatus.Descripcion
                    ,Observaciones = Registro_de_Orden_de_VentaData.Observaciones

					};
				}

            }
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IClienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Clientes_Cliente = _IClienteApiConsumer.SelAll(true);
            if (Clientes_Cliente != null && Clientes_Cliente.Resource != null)
                ViewBag.Clientes_Cliente = Clientes_Cliente.Resource.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cliente", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return PartialView("AddRegistro_de_Orden_de_Venta", varRegistro_de_Orden_de_Venta);
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
        public ActionResult GetClienteAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IClienteApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IClienteApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cliente", "Nombre_Completo")?? m.Nombre_Completo,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetEstatusAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IEstatusApiConsumer.SelAll(false).Resource;
                
                return Json(result.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                     Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion")?? m.Descripcion,
                    Value = Convert.ToString(m.Clave)
                }).ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        [HttpPost]
        public JsonResult ClearAdvanceFilter()
        {
            Session["AdvanceSearch"] = null;
            return Json(new { result = Session["AdvanceSearch"] == null }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ShowAdvanceFilter(Registro_de_Orden_de_VentaAdvanceSearchModel model, int idFilter = -1)
        {
            if (ModelState.IsValid)
            {
                Session["AdvanceSearch"] = model;
				if (idFilter != -1)
                {
                    Session["AdvanceReportFilter"] = GetAdvanceFilter(model);
                    return RedirectToAction("Index", "Report", new { id = idFilter });
                }
                return RedirectToAction("Index");
            }
            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},
            };
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IClienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Clientes_Cliente = _IClienteApiConsumer.SelAll(true);
            if (Clientes_Cliente != null && Clientes_Cliente.Resource != null)
                ViewBag.Clientes_Cliente = Clientes_Cliente.Resource.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cliente", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            return View(model);  
        }

        [HttpGet]
        public ActionResult ShowAdvanceFilter(string previousFilters = "")
        {
            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);

            _IClienteApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Clientes_Cliente = _IClienteApiConsumer.SelAll(true);
            if (Clientes_Cliente != null && Clientes_Cliente.Resource != null)
                ViewBag.Clientes_Cliente = Clientes_Cliente.Resource.OrderBy(m => m.Nombre_Completo).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Cliente", "Nombre_Completo") ?? m.Nombre_Completo.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();
            _IEstatusApiConsumer.SetAuthHeader(_tokenManager.Token);
            var Estatuss_Estatus = _IEstatusApiConsumer.SelAll(true);
            if (Estatuss_Estatus != null && Estatuss_Estatus.Resource != null)
                ViewBag.Estatuss_Estatus = Estatuss_Estatus.Resource.OrderBy(m => m.Descripcion).Select(m => new SelectListItem
                {
                    Text = CultureHelper.GetTraduction(Convert.ToString(m.Clave), "Estatus", "Descripcion") ?? m.Descripcion.ToString(), Value = Convert.ToString(m.Clave)
                }).ToList();


            var previousFiltersObj = new Registro_de_Orden_de_VentaAdvanceSearchModel();
            if (previousFilters != "")
            {
                previousFiltersObj = (Registro_de_Orden_de_VentaAdvanceSearchModel)(Session["AdvanceSearch"] ?? new Registro_de_Orden_de_VentaAdvanceSearchModel());
            }

            ViewBag.Filter = new List<SelectListItem>
            {
                new SelectListItem() {Text = Resources.Resources.BeginWith, Value = "1"},
                new SelectListItem() {Text = Resources.Resources.EndWith, Value = "2"},
                new SelectListItem() {Text = Resources.Resources.Contains, Value = "4"},
                new SelectListItem() {Text = Resources.Resources.Exact, Value = "3"},

            };

            return View(previousFiltersObj);
        }

        public ActionResult Get()
        {
            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetConfiguration(filter, new Registro_de_Orden_de_VentaPropertyMapper());

            var pageSize = Convert.ToInt32(filter["pageSize"]);
            var pageIndex = Convert.ToInt32(filter["pageIndex"]);
            var result = _IRegistro_de_Orden_de_VentaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize, configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_de_Orden_de_Ventas == null)
                result.Registro_de_Orden_de_Ventas = new List<Registro_de_Orden_de_Venta>();

            return Json(new
            {
                data = result.Registro_de_Orden_de_Ventas.Select(m => new Registro_de_Orden_de_VentaGridModel
                    {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,ClienteNombre_Completo = CultureHelper.GetTraduction(m.Cliente_Cliente.Clave.ToString(), "Nombre_Completo") ?? (string)m.Cliente_Cliente.Nombre_Completo
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Observaciones = m.Observaciones

                    }).ToList(),
                itemsCount = result.RowCount
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Get List of Registro_de_Orden_de_Venta from Web API.
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="start"></param>
        /// <param name="length"></param>
        /// <returns>Return List of Registro_de_Orden_de_Venta Entity</returns>
        public ActionResult GetRegistro_de_Orden_de_VentaList(UrlParametersModel param)
        {
			 int sEcho = param.sEcho;
            int iDisplayStart = param.iDisplayStart;
            int iDisplayLength = param.iDisplayLength;
            string where = param.where;
            string order = param.order;

            where = HttpUtility.UrlEncode(where);
            int sortColumn = -1;
            string sortDirection = "asc";
            if (iDisplayLength == -1)
            {
                //length = TOTAL_ROWS;
                iDisplayLength = Int32.MaxValue;
            }
            // note: we only sort one column at a time
            if (param.sortColumn != null)
            {
                sortColumn = int.Parse(param.sortColumn);
            }
            if (param.sortDirection != null)
            {
                sortDirection = param.sortDirection;
            }


            if (!_tokenManager.GenerateToken())
                return null;
            _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

          
            NameValueCollection filter = HttpUtility.ParseQueryString(param.filters);

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfigurationNew(param, new Registro_de_Orden_de_VentaPropertyMapper());
				
			if (!String.IsNullOrEmpty(where))
            {
                 configuration.WhereClause = configuration.WhereClause == "" ? where : "(" + configuration.WhereClause + " AND " + where + ")";
            }
            if (!String.IsNullOrEmpty(order))
            {
                configuration.OrderByClause = order;
            }
            //Adding Advance Search
            if (param.AdvanceSearch != null && param.AdvanceSearch == true && Session["AdvanceSearch"] != null)            
            {
				if (Session["AdvanceSearch"].GetType() == typeof(Registro_de_Orden_de_VentaAdvanceSearchModel))
                {
					var advanceFilter =
                    (Registro_de_Orden_de_VentaAdvanceSearchModel)Session["AdvanceSearch"];
					configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
				}
				else
                {    
					Session.Remove("AdvanceSearch");
                }
            }

            Registro_de_Orden_de_VentaPropertyMapper oRegistro_de_Orden_de_VentaPropertyMapper = new Registro_de_Orden_de_VentaPropertyMapper();
			if (String.IsNullOrEmpty(order))
            {
                 if (sortColumn != -1)
                    configuration.OrderByClause = oRegistro_de_Orden_de_VentaPropertyMapper.GetPropertyName(param.columns[sortColumn].name) + " " + sortDirection;
            }

            var pageSize = iDisplayLength;
            var pageIndex = (iDisplayStart / iDisplayLength) + 1;
            var result = _IRegistro_de_Orden_de_VentaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_de_Orden_de_Ventas == null)
                result.Registro_de_Orden_de_Ventas = new List<Registro_de_Orden_de_Venta>();

            return Json(new
            {
                aaData = result.Registro_de_Orden_de_Ventas.Select(m => new Registro_de_Orden_de_VentaGridModel
            {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,ClienteNombre_Completo = CultureHelper.GetTraduction(m.Cliente_Cliente.Clave.ToString(), "Nombre_Completo") ?? (string)m.Cliente_Cliente.Nombre_Completo
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Observaciones = m.Observaciones

                }).ToList(),
                iTotalRecords = result.RowCount,
                iTotalDisplayRecords = result.RowCount,
                sEcho = sEcho
            }, JsonRequestBehavior.AllowGet);
        }


//Grid GetAutoComplete






        [NonAction]
        public string GetAdvanceFilter(Registro_de_Orden_de_VentaAdvanceSearchModel filter)
        {
            var where = "";
            if (!string.IsNullOrEmpty(filter.FromFolio) || !string.IsNullOrEmpty(filter.ToFolio))
            {
                if (!string.IsNullOrEmpty(filter.FromFolio))
                    where += " AND Registro_de_Orden_de_Venta.Folio >= " + filter.FromFolio;
                if (!string.IsNullOrEmpty(filter.ToFolio))
                    where += " AND Registro_de_Orden_de_Venta.Folio <= " + filter.ToFolio;
            }

            if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro) || !string.IsNullOrEmpty(filter.ToFecha_de_Registro))
            {
                var Fecha_de_RegistroFrom = DateTime.ParseExact(filter.FromFecha_de_Registro, ConfigurationProperty.DateFormat,
                    CultureInfo.InvariantCulture as IFormatProvider);
                var Fecha_de_RegistroTo = DateTime.ParseExact(filter.ToFecha_de_Registro, ConfigurationProperty.DateFormat,
                  CultureInfo.InvariantCulture as IFormatProvider);

                if (!string.IsNullOrEmpty(filter.FromFecha_de_Registro))
                    where += " AND Registro_de_Orden_de_Venta.Fecha_de_Registro >= '" + Fecha_de_RegistroFrom.ToString("MM-dd-yyyy") + "'";
                if (!string.IsNullOrEmpty(filter.ToFecha_de_Registro))
                    where += " AND Registro_de_Orden_de_Venta.Fecha_de_Registro <= '" + Fecha_de_RegistroTo.ToString("MM-dd-yyyy") + "'";
            }

            if (!string.IsNullOrEmpty(filter.FromHora_de_Registro) || !string.IsNullOrEmpty(filter.ToHora_de_Registro))
            {
                if (!string.IsNullOrEmpty(filter.FromHora_de_Registro))
                    where += " AND Convert(TIME,Registro_de_Orden_de_Venta.Hora_de_Registro) >='" + filter.FromHora_de_Registro + "'";
                if (!string.IsNullOrEmpty(filter.ToHora_de_Registro))
                    where += " AND Convert(TIME,Registro_de_Orden_de_Venta.Hora_de_Registro) <='" + filter.ToHora_de_Registro + "'";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceCliente))
            {
                switch (filter.ClienteFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Cliente.Nombre_Completo LIKE '" + filter.AdvanceCliente + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Cliente.Nombre_Completo LIKE '%" + filter.AdvanceCliente + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Cliente.Nombre_Completo = '" + filter.AdvanceCliente + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Cliente.Nombre_Completo LIKE '%" + filter.AdvanceCliente + "%'";
                        break;
                }
            }
            else if (filter.AdvanceClienteMultiple != null && filter.AdvanceClienteMultiple.Count() > 0)
            {
                var ClienteIds = string.Join(",", filter.AdvanceClienteMultiple);

                where += " AND Registro_de_Orden_de_Venta.Cliente In (" + ClienteIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.AdvanceEstatus))
            {
                switch (filter.EstatusFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Estatus.Descripcion LIKE '" + filter.AdvanceEstatus + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Estatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Estatus.Descripcion = '" + filter.AdvanceEstatus + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Estatus.Descripcion LIKE '%" + filter.AdvanceEstatus + "%'";
                        break;
                }
            }
            else if (filter.AdvanceEstatusMultiple != null && filter.AdvanceEstatusMultiple.Count() > 0)
            {
                var EstatusIds = string.Join(",", filter.AdvanceEstatusMultiple);

                where += " AND Registro_de_Orden_de_Venta.Estatus In (" + EstatusIds + ")";
            }

            if (!string.IsNullOrEmpty(filter.Observaciones))
            {
                switch (filter.ObservacionesFilter)
                {
                    case Models.Filters.BeginWith:
                        where += " AND Registro_de_Orden_de_Venta.Observaciones LIKE '" + filter.Observaciones + "%'";
                        break;

                    case Models.Filters.EndWith:
                        where += " AND Registro_de_Orden_de_Venta.Observaciones LIKE '%" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Exact:
                        where += " AND Registro_de_Orden_de_Venta.Observaciones = '" + filter.Observaciones + "'";
                        break;

                    case Models.Filters.Contains:
                        where += " AND Registro_de_Orden_de_Venta.Observaciones LIKE '%" + filter.Observaciones + "%'";
                        break;
                }
            }


            where = new Regex(Regex.Escape("AND ")).Replace(where, "", 1);
            return where;
        }

        [NonAction]
        public Grid_File ConvertSpartane_FileToGridFile(Spartane.Core.Domain.Spartane_File.Spartane_File file)
        {
            return file == null ? new Grid_File { FileId = 0, FileSize = 0, FileName = "" } : new Grid_File { FileId = file.File_Id, FileName = file.Description, FileSize = file.File_Size ?? 0, };
        }

        public ActionResult GetDetalle_Variables_de_Venta(int draw, int start, int length, string RelationId = "0")
        {
            if (RelationId == "0")
            {
                return Json(new { recordsTotal = 0, recordsFiltered = 0, data = new List<Detalle_Variables_de_VentaGridModel>() }, JsonRequestBehavior.AllowGet);
            }

            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var pageSize = length;
            var pageIndex = start + 1;
            string where = "Detalle_Variables_de_Venta.Venta=" + RelationId;
            if("int" == "string")
            {
	           where = "Detalle_Variables_de_Venta.Venta='" + RelationId + "'";
            }
            var result = _IDetalle_Variables_de_VentaApiConsumer.ListaSelAll(start, pageSize, where,"").Resource;
            if (result.Detalle_Variables_de_Ventas == null)
                result.Detalle_Variables_de_Ventas = new List<Detalle_Variables_de_Venta>();

            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);

            var jsonResult = Json(new
            {
                data = result.Detalle_Variables_de_Ventas.Select(m => new Detalle_Variables_de_VentaGridModel
                {
                    Folio = m.Folio
                        ,Variable = m.Variable
                        ,VariableDescripcion = CultureHelper.GetTraduction(m.Variable_Variable.Clave.ToString(), "Descripcion") ??(string)m.Variable_Variable.Descripcion
                        ,Valor = m.Valor
                        ,ValorValor = CultureHelper.GetTraduction(m.Valor_Detalle_Valor_de_Variable.Folio.ToString(), "Valor") ??(string)m.Valor_Detalle_Valor_de_Variable.Valor

                }).ToList(),
                recordsTotal = result.RowCount,
                recordsFiltered = result.RowCount,
            }, JsonRequestBehavior.AllowGet);

            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
        public List<Detalle_Variables_de_VentaGridModel> GetDetalle_Variables_de_VentaData(string Id, int start, int length, out int RowCount)
        {
            RowCount = 0;
            var pageSize = length;
            var pageIndex = start + 1;
            List<Detalle_Variables_de_VentaGridModel> resultData = new List<Detalle_Variables_de_VentaGridModel>();
            string where = "Detalle_Variables_de_Venta.Venta=" + Id;
            if("int" == "string")
            {
                where = "Detalle_Variables_de_Venta.Venta='" + Id + "'";
            }
            if (!_tokenManager.GenerateToken())
                return null;
            _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
            var result = _IDetalle_Variables_de_VentaApiConsumer.ListaSelAll(start, pageSize, where, "").Resource;
            _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
            if (result.Detalle_Variables_de_Ventas != null)
            {
                resultData = result.Detalle_Variables_de_Ventas.Select(m => new Detalle_Variables_de_VentaGridModel
                    {
                        Folio = m.Folio
                        ,Variable = m.Variable
                        ,VariableDescripcion = CultureHelper.GetTraduction(m.Variable_Variable.Clave.ToString(), "Descripcion") ??(string)m.Variable_Variable.Descripcion
                        ,Valor = m.Valor
                        ,ValorValor = CultureHelper.GetTraduction(m.Valor_Detalle_Valor_de_Variable.Folio.ToString(), "Valor") ??(string)m.Valor_Detalle_Valor_de_Variable.Valor


                    }).ToList();
                RowCount = result.RowCount;
            }
            return resultData;
        }


        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

                Registro_de_Orden_de_Venta varRegistro_de_Orden_de_Venta = null;
                if (id.ToString() != "0")
                {
                        string where = "";
                    _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    where = "Detalle_Variables_de_Venta.Venta=" + id;
                    if("int" == "string")
                    {
	                where = "Detalle_Variables_de_Venta.Venta='" + id + "'";
                    }
                    var Detalle_Variables_de_VentaInfo =
                        _IDetalle_Variables_de_VentaApiConsumer.ListaSelAll(1, int.MaxValue, where,"").Resource;

                    if (Detalle_Variables_de_VentaInfo.Detalle_Variables_de_Ventas.Count > 0)
                    {
                        var resultDetalle_Variables_de_Venta = true;
                        //Removing associated job history with attachment
                        foreach (var Detalle_Variables_de_VentaItem in Detalle_Variables_de_VentaInfo.Detalle_Variables_de_Ventas)
                            resultDetalle_Variables_de_Venta = resultDetalle_Variables_de_Venta
                                              && _IDetalle_Variables_de_VentaApiConsumer.Delete(Detalle_Variables_de_VentaItem.Folio, null,null).Resource;

                        if (!resultDetalle_Variables_de_Venta)
                            return Json(false, JsonRequestBehavior.AllowGet);
                    }

                }
                var result = _IRegistro_de_Orden_de_VentaApiConsumer.Delete(id, null, null).Resource;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Post(bool IsNew, Registro_de_Orden_de_VentaModel varRegistro_de_Orden_de_Venta)
        {
            try
            {
				//if (ModelState.IsValid)
				//{
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);
                    _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);



                    
                    var result = "";
                    var Registro_de_Orden_de_VentaInfo = new Registro_de_Orden_de_Venta
                    {
                        Folio = varRegistro_de_Orden_de_Venta.Folio
                        ,Fecha_de_Registro = (!String.IsNullOrEmpty(varRegistro_de_Orden_de_Venta.Fecha_de_Registro)) ? DateTime.ParseExact(varRegistro_de_Orden_de_Venta.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varRegistro_de_Orden_de_Venta.Hora_de_Registro
                        ,Cliente = varRegistro_de_Orden_de_Venta.Cliente
                        ,Estatus = varRegistro_de_Orden_de_Venta.Estatus
                        ,Observaciones = varRegistro_de_Orden_de_Venta.Observaciones

                    };

                    result = !IsNew ?
                        _IRegistro_de_Orden_de_VentaApiConsumer.Update(Registro_de_Orden_de_VentaInfo, null, null).Resource.ToString() :
                         _IRegistro_de_Orden_de_VentaApiConsumer.Insert(Registro_de_Orden_de_VentaInfo, null, null).Resource.ToString();
					Session["KeyValueInserted"] = result;
                    return Json(result, JsonRequestBehavior.AllowGet);
				//}
				//return Json(false, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [NonAction]
        public bool CopyDetalle_Variables_de_Venta(int MasterId, int referenceId, List<Detalle_Variables_de_VentaGridModelPost> Detalle_Variables_de_VentaItems)
        {
            try
            {
                if (referenceId <= 0)
                    return true;

                if (!_tokenManager.GenerateToken())
                    return false;

                _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

                var Detalle_Variables_de_VentaData = _IDetalle_Variables_de_VentaApiConsumer.ListaSelAll(1, int.MaxValue, "Detalle_Variables_de_Venta.Venta=" + referenceId,"").Resource;
                if (Detalle_Variables_de_VentaData == null || Detalle_Variables_de_VentaData.Detalle_Variables_de_Ventas.Count == 0)
                    return true;

                var result = true;

                Detalle_Variables_de_VentaGridModelPost modelDataToChange = null;
                //var insertId = 0;
                foreach (var varDetalle_Variables_de_Venta in Detalle_Variables_de_VentaData.Detalle_Variables_de_Ventas)
                {
                    if (!result)
                        return result;

                    //Initialization
                    //insertId = 0;
                    modelDataToChange = null;
                    Detalle_Variables_de_Venta Detalle_Variables_de_Venta1 = varDetalle_Variables_de_Venta;

                    if (Detalle_Variables_de_VentaItems != null && Detalle_Variables_de_VentaItems.Any(m => m.Folio == Detalle_Variables_de_Venta1.Folio))
                    {
                        modelDataToChange = Detalle_Variables_de_VentaItems.FirstOrDefault(m => m.Folio == Detalle_Variables_de_Venta1.Folio);
                    }
                    //Chaning Id Value
                    varDetalle_Variables_de_Venta.Venta = MasterId;
                    var insertId = _IDetalle_Variables_de_VentaApiConsumer.Insert(varDetalle_Variables_de_Venta,null,null).Resource;
                    if (insertId > 0 && modelDataToChange != null)
                        modelDataToChange.Folio = insertId;

                    result = insertId > 0;
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpPost]
        public ActionResult PostDetalle_Variables_de_Venta(List<Detalle_Variables_de_VentaGridModelPost> Detalle_Variables_de_VentaItems, int MasterId, string referenceId)
        {
            try
            {
                bool result = true;

                //if (referenceId > 0 && MasterId != referenceId)
                //    if (!CopyDetalle_Variables_de_Venta(MasterId, referenceId, Detalle_Variables_de_VentaItems))
                //        return Json(false, JsonRequestBehavior.AllowGet);

                if (Detalle_Variables_de_VentaItems != null && Detalle_Variables_de_VentaItems.Count > 0)
                {
                    //Generating token
                    if (!_tokenManager.GenerateToken())
                        return Json(null, JsonRequestBehavior.AllowGet);

                    _ISpartane_FileApiConsumer.SetAuthHeader(_tokenManager.Token);
                    _IDetalle_Variables_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

                    foreach (var Detalle_Variables_de_VentaItem in Detalle_Variables_de_VentaItems)
                    {

                        //Removal Request
                        if (Detalle_Variables_de_VentaItem.Removed)
                        {
                            result = result && _IDetalle_Variables_de_VentaApiConsumer.Delete(Detalle_Variables_de_VentaItem.Folio, null,null).Resource;
                            continue;
                        }
						if (referenceId.ToString() != MasterId.ToString())
							Detalle_Variables_de_VentaItem.Folio = 0;

                        var Detalle_Variables_de_VentaData = new Detalle_Variables_de_Venta
                        {
                            Venta = MasterId
                            ,Folio = Detalle_Variables_de_VentaItem.Folio
                            ,Variable = (Convert.ToInt32(Detalle_Variables_de_VentaItem.Variable) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Variables_de_VentaItem.Variable))
                            ,Valor = (Convert.ToInt32(Detalle_Variables_de_VentaItem.Valor) == 0 ? (Int32?)null : Convert.ToInt32(Detalle_Variables_de_VentaItem.Valor))

                        };

                        var resultId = Detalle_Variables_de_VentaItem.Folio > 0
                           ? _IDetalle_Variables_de_VentaApiConsumer.Update(Detalle_Variables_de_VentaData,null,null).Resource
                           : _IDetalle_Variables_de_VentaApiConsumer.Insert(Detalle_Variables_de_VentaData,null,null).Resource;

                        result = result && resultId != -1;
                    }
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult GetDetalle_Variables_de_Venta_VariableAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IVariableApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IVariableApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Clave), "Variable", "Descripcion");
                  item.Descripcion= trans??item.Descripcion;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult GetDetalle_Variables_de_Venta_Detalle_Valor_de_VariableAll()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IDetalle_Valor_de_VariableApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IDetalle_Valor_de_VariableApiConsumer.SelAll(false).Resource;
                foreach (var item in result)
                {
				  var trans = CultureHelper.GetTraduction(Convert.ToString(item.Folio), "Detalle_Valor_de_Variable", "Valor");
                  item.Valor= trans??item.Valor;
                }
                return Json(result.ToArray(), JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
        }



        /// <summary>
        /// Write Element Array of Registro_de_Orden_de_Venta script
        /// </summary>
        /// <param name="oRegistro_de_Orden_de_VentaElements"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult WriteScriptSettings(CustomElementsNew Registro_de_Orden_de_VentaModuleAttributeList)
        {
            for (int i = 0; i < Registro_de_Orden_de_VentaModuleAttributeList.CustomModuleAttributeList.Count - 1; i++)
            {
                if (string.IsNullOrEmpty(Registro_de_Orden_de_VentaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue))
                {
                    Registro_de_Orden_de_VentaModuleAttributeList.CustomModuleAttributeList[i].DefaultValue = string.Empty;
                }
                if (string.IsNullOrEmpty(Registro_de_Orden_de_VentaModuleAttributeList.CustomModuleAttributeList[i].HelpText))
                {
                    Registro_de_Orden_de_VentaModuleAttributeList.CustomModuleAttributeList[i].HelpText = string.Empty;
                }
            }
			if (Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList != null)
            {
				for (int i = 0; i < Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList.Count - 1; i++)
				{
					for (int j = 0; j < Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList[i].elements.Count; j++)
					{
						if (string.IsNullOrEmpty(Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue))
						{
							Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList[i].elements[j].DefaultValue = string.Empty;
						}
						if (string.IsNullOrEmpty(Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText))
						{
							Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList[i].elements[j].HelpText = string.Empty;
						}
					}
				}
			}
            string strRegistro_de_Orden_de_VentaScript = string.Empty;
            using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Registro_de_Orden_de_Venta.js")))
            {
                strRegistro_de_Orden_de_VentaScript = r.ReadToEnd();
            }

            JavaScriptSerializer jsSerialize = new JavaScriptSerializer();

            // get json string of change Registro_de_Orden_de_Venta element attributes
            string userChangeJson = jsSerialize.Serialize(Registro_de_Orden_de_VentaModuleAttributeList.CustomModuleAttributeList);

            int indexOfArray = strRegistro_de_Orden_de_VentaScript.IndexOf("inpuElementArray");
            string splittedString = strRegistro_de_Orden_de_VentaScript.Substring(indexOfArray, strRegistro_de_Orden_de_VentaScript.Length - indexOfArray);
            int indexOfMainElement = splittedString.IndexOf('[');
            int endIndexOfMainElement = splittedString.IndexOf(']') + 1;

            // get json string of change job history element attributes
            string childUserChangeJson = jsSerialize.Serialize(Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList);
			int indexOfArrayHistory = 0;
            string splittedStringHistory = "";
            int indexOfMainElementHistory = 0;
            int endIndexOfMainElementHistory = 0;
			if (Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList != null)
            {
				indexOfArrayHistory = strRegistro_de_Orden_de_VentaScript.IndexOf("});");
				if(indexOfArrayHistory != -1)
				{
					splittedStringHistory = strRegistro_de_Orden_de_VentaScript.Substring(indexOfArrayHistory, strRegistro_de_Orden_de_VentaScript.Length - indexOfArrayHistory);
					indexOfMainElementHistory = splittedStringHistory.IndexOf('[');
					endIndexOfMainElementHistory = splittedStringHistory.IndexOf(']') + 1;
				}
			}
			string finalResponse = strRegistro_de_Orden_de_VentaScript.Substring(0, indexOfArray + indexOfMainElement) + userChangeJson + strRegistro_de_Orden_de_VentaScript.Substring(endIndexOfMainElement + indexOfArray, strRegistro_de_Orden_de_VentaScript.Length - (endIndexOfMainElement + indexOfArray));
           
		   var ResponseChild = string.Empty;
            if (Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList != null && indexOfArrayHistory != -1)
            {
                foreach (var item in Registro_de_Orden_de_VentaModuleAttributeList.ChildModuleAttributeList)
                {
				if (item!= null && item.elements != null  && item.elements.Count>0)
                    ResponseChild += "\r\n  \n\r function set" + item.table + "Validation() { " +
                                    " \r\n var inpuElementChildArray =" + jsSerialize.Serialize(item.elements) + ";" +
                                    "  \r\n setInputEntityAttributes(inpuElementChildArray, \".\", 0);" +
                                    "  \r\n setDynamicRenderElement(); \n\r } ";

                }
            }
            finalResponse = finalResponse.Substring(0, finalResponse.IndexOf("});") + 4) +  "\n\r";
            finalResponse += ResponseChild;
          

            using (StreamWriter w = new StreamWriter(Server.MapPath("~/Uploads/Scripts/Registro_de_Orden_de_Venta.js")))
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

            if (System.IO.File.Exists(Server.MapPath("~/Uploads/Scripts/Registro_de_Orden_de_Venta.js")))
            {
                using (StreamReader r = new StreamReader(Server.MapPath("~/Uploads/Scripts/Registro_de_Orden_de_Venta.js")))
                {
                    strCustomScript = r.ReadToEnd();
                
                }

                int indexOfArray = strCustomScript.IndexOf("inpuElementArray");
                string splittedString = strCustomScript.Substring(indexOfArray, strCustomScript.Length - indexOfArray);                
                int indexOfMainElement = splittedString.IndexOf('[');                
                int endIndexOfMainElement = splittedString.IndexOf(']') + 1;                
                string mainJsonArray = splittedString.Substring(indexOfMainElement, endIndexOfMainElement - indexOfMainElement);

                int indexOfChildArray = strCustomScript.IndexOf("function set");
                string childJsonArray = "[";
                if (indexOfChildArray != -1)
                {
                    string splittedChildString = strCustomScript.Substring(indexOfChildArray, strCustomScript.Length - indexOfChildArray);

                    var funcionsValidations = splittedChildString.Split(new string[] { "function" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var str in funcionsValidations)
                    {
                        var tabla = str.Substring(0, str.IndexOf('('));
                        tabla = tabla.Trim().Replace("set", string.Empty).Replace("Validation", string.Empty);
                        childJsonArray += "{ \"table\": \"" + tabla + "\", \"elements\":";
                        int indexOfChildElement = str.IndexOf('[');
                        int endIndexOfChildElement = str.IndexOf(']') + 1;
                        childJsonArray += str.Substring(indexOfChildElement, endIndexOfChildElement - indexOfChildElement) + "},";
                    }
                }
                childJsonArray = childJsonArray.TrimEnd(',') + "]";
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
        public ActionResult Registro_de_Orden_de_VentaPropertyBag()
        {
            return PartialView("Registro_de_Orden_de_VentaPropertyBag", "Registro_de_Orden_de_Venta");
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

        [HttpGet]
        public ActionResult AddDetalle_Variables_de_Venta(int rowIndex = 0, int functionMode = 0)
        {
            ViewBag.currentRowIndex = rowIndex;
            ViewBag.functionMode = functionMode;
            return PartialView("../Detalle_Variables_de_Venta/AddDetalle_Variables_de_Venta");
        }



        #endregion "Controller Methods"

        #region "Custom methods"
		
		[HttpGet]
        public FileStreamResult PrintFormats(int idFormat, string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            _IGeneratePDFApiConsumer.SetAuthHeader(_tokenManager.Token);
            _ISpartan_FormatRelatedApiConsumer.SetAuthHeader(_tokenManager.Token);

            MemoryStream ms = new MemoryStream();
           
            //Buscar los Formatos Relacionados
            var relacionados = _ISpartan_FormatRelatedApiConsumer.ListaSelAll(0, 5000, "Spartan_Format_Related.FormatId = " + idFormat, "").Resource.Spartan_Format_Relateds.OrderBy(r => r.Order).ToList();
            if (relacionados.Count > 0)
            {
                var outputDocument = new iTextSharp.text.Document();
                var writer = new PdfCopy(outputDocument, ms);
                outputDocument.Open();
                foreach (var spartan_Format_Related in relacionados)
                {
                    var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(Convert.ToInt32(spartan_Format_Related.FormatId_Related), RecordId).Resource;
                    var reader = new PdfReader(bytePdf);
                    for (var j = 1; j <= reader.NumberOfPages; j++)
                    {
                        writer.AddPage(writer.GetImportedPage(reader, j));
                    }
                    writer.FreeReader(reader);
                    reader.Close();
                }
                writer.Close();
                outputDocument.Close();
                var allPagesContent = ms.GetBuffer();
                ms.Flush();
            }
            else {
                var bytePdf = _IGeneratePDFApiConsumer.GeneratePDF(idFormat, RecordId);
                ms.Write(bytePdf.Resource, 0, bytePdf.Resource.Length);           
            }
                
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Formatos.pdf");
            Response.Buffer = true;
            Response.Clear();
            Response.OutputStream.Write(ms.GetBuffer(), 0, ms.GetBuffer().Length);
            Response.OutputStream.Flush();
            Response.End();

            return new FileStreamResult(Response.OutputStream, "application/pdf");
        }
		
		
		
		[HttpGet]
        public ActionResult GetFormats(string RecordId)
        {
            if (!_tokenManager.GenerateToken())
                return null;

            var formatList = new List<SelectListItem>();

            if (!_tokenManager.GenerateToken())
                return Json(null, JsonRequestBehavior.AllowGet);
            _ISpartan_Format_PermissionsApiConsumer.SetAuthHeader(_tokenManager.Token);
           _ISpartan_FormatApiConsumer.SetAuthHeader(_tokenManager.Token);

            var whereClause = " Spartan_Format_Permissions.Spartan_User_Role = " + SessionHelper.Role + " AND Spartan_Format_Permissions.Permission_Type = 1 AND Apply=1 ";
            var formatsPermisions = _ISpartan_Format_PermissionsApiConsumer.ListaSelAll(0, 500, whereClause, string.Empty).Resource;
            if (formatsPermisions.RowCount > 0)
            {
                var formats = string.Join(",", formatsPermisions.Spartan_Format_Permissionss.Select(f => f.Format).ToArray());
                var whereClauseFormat = "Object = 40121 AND FormatId in (" + formats + ")";
                var Spartan_Formats = _ISpartan_FormatApiConsumer.ListaSelAll(0, 1000, whereClauseFormat, string.Empty);


                if (Spartan_Formats != null && Spartan_Formats.Resource != null && Spartan_Formats.Resource.Spartan_Formats != null)
                {
                    _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
                    foreach (Spartan_Format format in Spartan_Formats.Resource.Spartan_Formats)
                    {

                        if (format.Filter != null && format.Filter.Trim() != string.Empty)
                        {
                            var where = Helper.ReplaceGlobal(format.Filter).Trim() + " And Folio= " + RecordId;
                            var result = _IRegistro_de_Orden_de_VentaApiConsumer.ListaSelAll(0, 1000, where, string.Empty);
                            if (result != null && result.Resource != null && result.Resource.RowCount > 0)
                            {
                                formatList.Add(new SelectListItem
                                {
                                    Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                    Value = Convert.ToString(format.FormatId)
                                });
                            }
                        }
                        else
                        {
                            formatList.Add(new SelectListItem
                            {
                                Text =  CultureHelper.GetTraductionAdd(format.FormatId.ToString(), "Format", format.Format_Name),
                                Value = Convert.ToString(format.FormatId)
                            });
                        }


                    }
                }
            }
            return Json(formatList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public void Export(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return;

            _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;
            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Registro_de_Orden_de_VentaPropertyMapper());
			
            //Adding Advance Search
            if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Registro_de_Orden_de_VentaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }
			string sortDirection = "asc";

            Registro_de_Orden_de_VentaPropertyMapper oRegistro_de_Orden_de_VentaPropertyMapper = new Registro_de_Orden_de_VentaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRegistro_de_Orden_de_VentaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRegistro_de_Orden_de_VentaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_de_Orden_de_Ventas == null)
                result.Registro_de_Orden_de_Ventas = new List<Registro_de_Orden_de_Venta>();

            var data = result.Registro_de_Orden_de_Ventas.Select(m => new Registro_de_Orden_de_VentaGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,ClienteNombre_Completo = CultureHelper.GetTraduction(m.Cliente_Cliente.Clave.ToString(), "Nombre_Completo") ?? (string)m.Cliente_Cliente.Nombre_Completo
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Observaciones = m.Observaciones

            }).ToList();

            switch (exportFormatType)
            {
                case ExportFormatType.PDF:
                    PdfConverter.ExportToPdf(data.ToDataTable(), "Registro_de_Orden_de_VentaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.EXCEL:
                    ExcelConverter.ExportToExcel(data.ToDataTable(), "Registro_de_Orden_de_VentaList_" + DateTime.Now.ToString());
                    break;

                case ExportFormatType.CSV:
                    CsvConverter.ExportToCSV(data.ToDataTable(), "Registro_de_Orden_de_VentaList_" + DateTime.Now.ToString());
                    break;
            }
        }

        [HttpGet]
        //[ObjectAuth(ObjectId = ModuleObjectId.EMPLEADOS_OBJECT, PermissionType = PermissionTypes.Export)]
        public ActionResult Print(string format, int pageIndex, int pageSize, string iSortCol, string sSortDir)
        {
            var exportFormatType = (ExportFormatType)Enum.Parse(
                                          typeof(ExportFormatType), format, true);

            if (!_tokenManager.GenerateToken())
                return null;

            _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);

            NameValueCollection filter = Request.QueryString;

            var configuration = new GridConfiguration() { OrderByClause = "", WhereClause = "" };
            if (filter != null)
                configuration = GridQueryHelper.GetDataTableConfiguration(filter, new Registro_de_Orden_de_VentaPropertyMapper());
			if (Session["AdvanceSearch"] != null && pageSize != 0)
            {
                var advanceFilter =
                    (Registro_de_Orden_de_VentaAdvanceSearchModel)Session["AdvanceSearch"];
                configuration.WhereClause = configuration.WhereClause == "" ? GetAdvanceFilter(advanceFilter) : configuration.WhereClause + " AND " + GetAdvanceFilter(advanceFilter);
            }

            string sortDirection = "asc";

            Registro_de_Orden_de_VentaPropertyMapper oRegistro_de_Orden_de_VentaPropertyMapper = new Registro_de_Orden_de_VentaPropertyMapper();
            if (Request.QueryString["sSortDir"] != null)
            {
                sortDirection = Request.QueryString["sSortDir"];
            }
            configuration.OrderByClause =  oRegistro_de_Orden_de_VentaPropertyMapper.GetPropertyName(iSortCol)  + " " + sortDirection;
            pageSize = pageSize == 0 ? int.MaxValue : pageSize;

            var result = _IRegistro_de_Orden_de_VentaApiConsumer.ListaSelAll((pageIndex * pageSize) - pageSize + 1, pageSize + ((pageIndex * pageSize) - pageSize), configuration.WhereClause, configuration.OrderByClause ?? "").Resource;
            if (result.Registro_de_Orden_de_Ventas == null)
                result.Registro_de_Orden_de_Ventas = new List<Registro_de_Orden_de_Venta>();

            var data = result.Registro_de_Orden_de_Ventas.Select(m => new Registro_de_Orden_de_VentaGridModel
            {
                Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,ClienteNombre_Completo = CultureHelper.GetTraduction(m.Cliente_Cliente.Clave.ToString(), "Nombre_Completo") ?? (string)m.Cliente_Cliente.Nombre_Completo
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Observaciones = m.Observaciones

            }).ToList();

            return PartialView("_Print", data);
        }

        #endregion "Custom methods"
		
		[HttpGet]
        public JsonResult CreateID()
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var result = _IRegistro_de_Orden_de_VentaApiConsumer.GenerateID().Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpPost]
        public ActionResult Post_Datos_Generales(Registro_de_Orden_de_Venta_Datos_GeneralesModel varRegistro_de_Orden_de_Venta)
        {
            try
            {
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
				
                var result = "";
                var Registro_de_Orden_de_Venta_Datos_GeneralesInfo = new Registro_de_Orden_de_Venta_Datos_Generales
                {
                    Folio = varRegistro_de_Orden_de_Venta.Folio
                                            ,Fecha_de_Registro = (!String.IsNullOrEmpty(varRegistro_de_Orden_de_Venta.Fecha_de_Registro)) ? DateTime.ParseExact(varRegistro_de_Orden_de_Venta.Fecha_de_Registro, ConfigurationProperty.DateFormat, CultureInfo.InvariantCulture as IFormatProvider) : (DateTime?)null
                        ,Hora_de_Registro = varRegistro_de_Orden_de_Venta.Hora_de_Registro
                        ,Cliente = varRegistro_de_Orden_de_Venta.Cliente
                        ,Estatus = varRegistro_de_Orden_de_Venta.Estatus
                        ,Observaciones = varRegistro_de_Orden_de_Venta.Observaciones
                    
                };

                result = _IRegistro_de_Orden_de_VentaApiConsumer.Update_Datos_Generales(Registro_de_Orden_de_Venta_Datos_GeneralesInfo).Resource.ToString();
                Session["KeyValueInserted"] = result;
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch (ServiceException ex)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }
		
		[HttpGet]
        public JsonResult Get_Datos_Generales(string Id)
        {     
            if ((Id.GetType() == typeof(string) && Id.ToString() != "") || ((Id.GetType() == typeof(int) || Id.GetType() == typeof(Int16) || Id.GetType() == typeof(Int32) || Id.GetType() == typeof(Int64) || Id.GetType() == typeof(short)) && Id.ToString() != "0"))
            {                
                if (!_tokenManager.GenerateToken())
                    return Json(null, JsonRequestBehavior.AllowGet);
                _IRegistro_de_Orden_de_VentaApiConsumer.SetAuthHeader(_tokenManager.Token);
                var m = _IRegistro_de_Orden_de_VentaApiConsumer.Get_Datos_Generales(Id).Resource;
                if (m == null)
                    return Json(null, JsonRequestBehavior.AllowGet);
				                int RowCount_Detalle_Variables_de_Venta;
                var Detalle_Variables_de_VentaData = GetDetalle_Variables_de_VentaData(Id.ToString(), 0, 10, out RowCount_Detalle_Variables_de_Venta);

                var result = new Registro_de_Orden_de_Venta_Datos_GeneralesModel
                {
                    Folio = m.Folio
                        ,Fecha_de_Registro = (m.Fecha_de_Registro == null ? string.Empty : Convert.ToDateTime(m.Fecha_de_Registro).ToString(ConfigurationProperty.DateFormat))
			,Hora_de_Registro = m.Hora_de_Registro
                        ,Cliente = m.Cliente
                        ,ClienteNombre_Completo = CultureHelper.GetTraduction(m.Cliente_Cliente.Clave.ToString(), "Nombre_Completo") ?? (string)m.Cliente_Cliente.Nombre_Completo
                        ,Estatus = m.Estatus
                        ,EstatusDescripcion = CultureHelper.GetTraduction(m.Estatus_Estatus.Clave.ToString(), "Descripcion") ?? (string)m.Estatus_Estatus.Descripcion
			,Observaciones = m.Observaciones

                    
                };
				var resultData = new
                {
                    data = result
                    ,Valores = Detalle_Variables_de_VentaData

                };
                return Json(resultData, JsonRequestBehavior.AllowGet);
            }
            return Json(null, JsonRequestBehavior.AllowGet);            
        }


    }
}

