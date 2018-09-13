using System;
using Spartane.Core.Domain.Cliente;
using System.Collections.Generic;
using Spartane.Core.Domain.Data;

namespace Spartane.Services.Cliente
{
    /// <summary>
    /// Authentificated Service
    /// </summary>
    public partial interface IClienteService
    {
        Int32 SelCount();
        IList<Spartane.Core.Domain.Cliente.Cliente> SelAll(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Cliente.Cliente> SelAllComplete(Boolean ConRelaciones);
        IList<Spartane.Core.Domain.Cliente.Cliente> SelAll(Boolean ConRelaciones, Int32 CurrentRecordInt32, Int32 RecordsDisplayedInt32);
        Spartane.Core.Domain.Cliente.Cliente GetByKey(int Key, Boolean ConRelaciones);
        bool Delete(int Key, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Insert(Spartane.Core.Domain.Cliente.Cliente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        Int32 Update(Spartane.Core.Domain.Cliente.Cliente entity, Spartane.Core.Domain.User.GlobalData EmpleadoInformation, DataLayerFieldsBitacora DataReference);
        IList<Spartane.Core.Domain.Cliente.Cliente> SelAll(Boolean ConRelaciones, string Where, string Order);
        IList<Spartane.Core.Domain.Cliente.Cliente> ListaSelAll(Boolean ConRelaciones, string Where, string Order);
        Spartane.Core.Domain.Cliente.ClientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order);
        int ListaSelAllCount(string Where);
        IList<Spartane.Core.Domain.Cliente.Cliente> ListaSelAll(Boolean ConRelaciones, string Where);
    }
}
