using System;
using Spartane.Core.Domain.Detalle_Valor_de_Variable;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Detalle_Valor_de_Variable
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IDetalle_Valor_de_VariableService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_VariablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
