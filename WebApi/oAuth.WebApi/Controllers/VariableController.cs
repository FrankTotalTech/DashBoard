using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.ModelBinding;
using Spartane.Core.Exceptions.Service;
using System.Web;
using Spartane.Core.Classes.Variable;
using Spartane.Services.Variable;
using System.Data;
using System.Web.Script.Serialization;
using oAuth.WebAPI.Consumer;
using oAuth.WebApi.Helpers;
using System.Configuration;
using System.Text;

using Spartane.Services.Spartan_Bitacora_SQL;
using Spartane.Core.Classes.Spartan_Bitacora_SQL;

namespace Spartane.WebApi.Controllers
{
    
    public class VariableController : BaseApiController
    {
        #region Variables
        private IVariableService service = null;
        public  static string ApiControllerUrl { get; set; }
		private ISpartan_Bitacora_SQLService serviceBitacora = null;
		private static int object_id = 40118;
        public string baseApi;
        #endregion Variables

        #region Constructor
        //TODO: Global Data y Data Rerence tienen que estar en un controlador base
        public VariableController(IVariableService service,ISpartan_Bitacora_SQLService bitacoraService)
        {
            this.service = service;
			serviceBitacora = bitacoraService;
            baseApi = ConfigurationManager.AppSettings["DBBaseURL"].ToString();
            ApiControllerUrl = "api/Variable";
            
        }
        #endregion Constructor


        #region API Methods
        [Authorize]
        public HttpResponseMessage Get(int id)
        {
            var entity = this.service.GetByKey(id, false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAll()
        {
            var entity = this.service.SelAll(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage ListaSelAll(int startRowIndex, int maximumRows, string where = "", string order = "")
        {
            var entity = this.service.ListaSelAll(startRowIndex, maximumRows, where, order);
            entity.RowCount = this.service.ListaSelAllCount(where);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAllComplete()
        {
            var entity = this.service.SelAllComplete(false);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage GetAll(string where, string order)
        {
            var entity = this.service.SelAll(false, where, order);
            return Request.CreateResponse(HttpStatusCode.OK, entity, Configuration.Formatters.JsonFormatter);
        }

        [Authorize]
        public HttpResponseMessage Post(Variable varVariable)
        {
            if (ModelState.IsValid)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Insert(varVariable));
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_InsVariable" , new JavaScriptSerializer().Serialize(varVariable), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
					var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsVariable", new JavaScriptSerializer().Serialize(varVariable), true);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
                var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_InsVariable",new JavaScriptSerializer().Serialize(varVariable), false, errors.ToString());
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }

        [Authorize]
        [HttpPut]
        public HttpResponseMessage Put(int id, Variable varVariable)
        {
            if (ModelState.IsValid && id == varVariable.Clave)
            {
                var data = "-1";
                try
                {
                    data = Convert.ToString(this.service.Update(varVariable));
					 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdVariable", new JavaScriptSerializer().Serialize(varVariable), true);
                    serviceBitacora.Insert(bitacora);
                }
                catch (ServiceException ex)
                {
				    var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdVariable", new JavaScriptSerializer().Serialize(varVariable), false, ex.Message);
                    serviceBitacora.Insert(bitacora);
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }

                return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
            }
            else
            {
               var errors= ModelState.SelectMany(m => m.Value.Errors.Select(err => err.ErrorMessage != string.Empty ? err.ErrorMessage : err.Exception.Message).ToList()).ToList();                
               var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.UPDATE, "sp_UpdVariable", new JavaScriptSerializer().Serialize(varVariable), false, String.Join(",", errors.ToArray()));
               serviceBitacora.Insert(bitacora);
               return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }
        }
		
		[Authorize]
        [HttpPut]
        public HttpResponseMessage Put_Datos_Generales(Variable varVariable_Datos_Generales)
        {
            var data = "-1";
			try
			{
				data = Convert.ToString(this.service.Update_Datos_Generales(varVariable_Datos_Generales));
				 var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varVariable_Datos_Generales.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdVariable", new JavaScriptSerializer().Serialize(varVariable_Datos_Generales), true);
				serviceBitacora.Insert(bitacora);
			}
			catch (ServiceException ex)
			{
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, varVariable_Datos_Generales.Clave, BitacoraHelper.TypeSql.UPDATE, "sp_UpdVariable", new JavaScriptSerializer().Serialize(varVariable_Datos_Generales), false, ex.Message);
				serviceBitacora.Insert(bitacora);
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
			}

			return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }
		
		[Authorize]
        public HttpResponseMessage Get_Datos_Generales(int id)
        {
            Variable entity = this.service.ListaSelAll(1, 1, "Variable.Clave='" + id.ToString() + "'", "").Variables.First();
            Variable result = new Variable();
			result.Clave = entity.Clave;
result.Descripcion = entity.Descripcion;
result.Peso_de_Variable = entity.Peso_de_Variable;

            return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }


		
	[Authorize]
        [HttpGet]
        public HttpResponseMessage VariableGenerateID()
        {
            Variable varVariable = new Variable();
            var data = "-1";
            try
            {
                data = Convert.ToString(this.service.Insert(varVariable));
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, Convert.ToInt32(data), BitacoraHelper.TypeSql.INSERT, "sp_VariableGenerateID", new JavaScriptSerializer().Serialize(varVariable), true);
                serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
                var bitacora = BitacoraHelper.GetBitacora(Request, object_id, 0, BitacoraHelper.TypeSql.INSERT, "sp_VariableGenerateID", new JavaScriptSerializer().Serialize(varVariable), true);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, data, Configuration.Formatters.JsonFormatter);
        }	
        [Authorize]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            Variable varVariable = this.service.GetByKey(id, false);
            bool result = false;
            if (varVariable == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            try
            {
              result=  this.service.Delete(id);//, globalData, dataReference);
			  var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelVariable", new JavaScriptSerializer().Serialize(varVariable), result);
              serviceBitacora.Insert(bitacora);
            }
            catch (ServiceException ex)
            {
				var bitacora = BitacoraHelper.GetBitacora(Request, object_id, id, BitacoraHelper.TypeSql.DELETE, "sp_DelVariable", new JavaScriptSerializer().Serialize(varVariable), result, ex.Message);
                serviceBitacora.Insert(bitacora);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion API Methods

        #region TunnelMethod

        /// <summary>
        /// WebAPI GetALLTunnel
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetAllTunnel(string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/GetAll");
                var VariableDataTable = new JavaScriptSerializer().Deserialize<List<Variable>>(result);
                return Request.CreateResponse(HttpStatusCode.OK, VariableDataTable, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// WebAPI GET
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage GetTunnel(int id,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/Get?id=" + id);
                var VariableResult = new JavaScriptSerializer().Deserialize<Variable>(result);
                return Request.CreateResponse(HttpStatusCode.OK, VariableResult, Configuration.Formatters.JsonFormatter);            
        }

        /// <summary>
        /// WebAPI ListaSelAllTunnel
        /// </summary>
        /// <param name="startRowIndex"></param>
        /// <param name="maximumRows"></param>
        /// <param name="Where"></param>
        /// <param name="Order"></param>
        /// <returns></returns>
        [HttpGet]
        public HttpResponseMessage ListaSelAllTunnel(int startRowIndex, int maximumRows, string Where, string Order,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Encoding = Encoding.UTF8;
                var result = client.DownloadString(baseApi + ApiControllerUrl + "/ListaSelAll?startRowIndex=" + startRowIndex +
                        "&maximumRows=" + maximumRows +
                        (string.IsNullOrEmpty(Where) ? "" : "&Where=" + Where) +
                         (string.IsNullOrEmpty(Order) ? "" : "&Order=" + Order));
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Content = new StringContent(result, System.Text.Encoding.UTF8, "text/plain");
                return resp;
        }

        /// <summary>
        /// WebAPI PostTunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPost]
        public HttpResponseMessage PostTunnel(Variable emp,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);

                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Post"), "POST",
                    dataString);

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);            
        }

        /// <summary>
        /// WebAPI put tunnel
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        [HttpPut]
        public HttpResponseMessage PutTunnel(Variable emp, string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var dataString = new JavaScriptSerializer().Serialize(emp);

                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Put?Id=" + emp.Clave), "PUT"
                , dataString);

                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        /// <summary>
        /// WebAPI Delete Tunnel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public HttpResponseMessage DeleteTunnel(int id,string user, string password)
        {
                var client = new System.Net.WebClient();
                client.Headers = TokenManager.GetAuthenticationHeader(user,password);
                client.Headers["Content-Type"] = "application/json";
                var result = client.UploadString(new Uri(baseApi + ApiControllerUrl + "/Delete?id=" + id), "DELETE"
                );
                return Request.CreateResponse(HttpStatusCode.OK, result, Configuration.Formatters.JsonFormatter);
        }

        #endregion TunnelMethod

    }
}

