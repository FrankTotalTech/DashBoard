using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Domain.Data;
using Spartane.Web.Areas.WebApiConsumer.ResponseHelpers;

namespace Spartane.Web.Areas.WebApiConsumer.Registro_de_Orden_de_Venta
{
    public interface IRegistro_de_Orden_de_VentaApiConsumer
    {
        void SetAuthHeader(string token);
        Int32 SelCount();
        ApiResponse<IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>> SelAll(Boolean ConRelaciones);
        ApiResponse<IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>> SelAllComplete(Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> GetByKey(int Key, Boolean ConRelaciones);
        ApiResponse<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_VentaPagingModel> GetByKeyComplete(int Key);
        ApiResponse<bool> Delete(int Key, Spartane.Core.Domain.User.GlobalData Registro_de_Orden_de_VentaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Insert(Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta entity, Spartane.Core.Domain.User.GlobalData Registro_de_Orden_de_VentaInformation, DataLayerFieldsBitacora DataReference);
        ApiResponse<Int32> Update(Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta entity, Spartane.Core.Domain.User.GlobalData Registro_de_Orden_de_VentaInformation, DataLayerFieldsBitacora DataReference);

        ApiResponse<IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        ApiResponse<IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>> SelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        ApiResponse<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_VentaPagingModel> ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        ApiResponse<IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>> ListaSelAll(Boolean ConRelaciones, string Where);
		ApiResponse<int> GenerateID();
		ApiResponse<int> Update_Datos_Generales(Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta_Datos_Generales entity);
		ApiResponse<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta_Datos_Generales> Get_Datos_Generales(string Key);


    }
}

