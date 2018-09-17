using System;
using Spartane.Core.Classes.Detalle_Variables_de_Venta;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Variables_de_Venta
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Variables_de_VentaService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta entity);
        IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_VentaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta entity);

    }
}
