using System;
using Spartane.Core.Classes.Detalle_Valor_de_Variable;
using System.Collections.Generic;


namespace Spartane.Services.Detalle_Valor_de_Variable
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Valor_de_VariableService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity);
        Int32 Update(Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity);
        IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_VariablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity);

    }
}
