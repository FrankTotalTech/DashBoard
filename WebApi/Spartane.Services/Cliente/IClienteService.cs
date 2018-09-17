using System;
using Spartane.Core.Classes.Cliente;
using System.Collections.Generic;


namespace Spartane.Services.Cliente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IClienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Classes.Cliente.Cliente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Cliente.Cliente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Classes.Cliente.Cliente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Classes.Cliente.Cliente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key);
        Int32 Insert(Spartane.Core.Classes.Cliente.Cliente entity);
        Int32 Update(Spartane.Core.Classes.Cliente.Cliente entity);
        IList<Spartane.Core.Classes.Cliente.Cliente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Classes.Cliente.Cliente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Classes.Cliente.ClientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Classes.Cliente.Cliente> ListaSelAll(Boolean ConRelaciones, string Where);
              int Update_Datos_Generales(Spartane.Core.Classes.Cliente.Cliente entity);

    }
}
