using System;
using Spartane.Core.Domain.Detalle_Variables_de_Venta;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Variables_de_Venta
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Variables_de_VentaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_VentaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
