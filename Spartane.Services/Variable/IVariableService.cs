using System;
using Spartane.Core.Domain.Variable;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Variable
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IVariableService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Variable.Variable> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Variable.Variable> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Variable.Variable> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Variable.Variable GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Variable.Variable entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Variable.Variable entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Variable.Variable> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Variable.Variable> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Variable.VariablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Variable.Variable> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
