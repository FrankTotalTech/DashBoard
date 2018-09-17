using System;
using Spartane.Core.Classes.Variable;
using System.Collections.Generic;


namespace Spartane.Services.Variable
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IVariableService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Variable.Variable> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Variable.Variable> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Variable.Variable> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Variable.Variable GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Variable.Variable entity);
        Int32 Update(Spartane.Core.Classes.Variable.Variable entity);
        IList<Spartane.Core.Classes.Variable.Variable> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Variable.Variable> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Variable.VariablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Variable.Variable> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Variable.Variable entity);

    }
}
