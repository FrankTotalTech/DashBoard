using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Cliente;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Cliente
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class ClienteService : IClienteService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Cliente.Cliente> _ClienteRepository;
        #endregion

        #region Ctor
        public ClienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Cliente.Cliente> ClienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ClienteRepository = ClienteRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Cliente.Cliente> SelAll(bool ConRelaciones)
        {
            return this._ClienteRepository.Table.ToList();
        }

        public IList<Core.Domain.Cliente.Cliente> SelAllComplete(bool ConRelaciones)
        {
            return this._ClienteRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Cliente.Cliente> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ClienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Cliente.Cliente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ClienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Cliente.Cliente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ClienteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Cliente.ClientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            ClientePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Cliente.Cliente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ClienteRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Cliente.Cliente GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Cliente.Cliente result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData ClienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Cliente.Cliente entity, Spartane.Core.Domain.User.GlobalData ClienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Cliente.Cliente entity, Spartane.Core.Domain.User.GlobalData ClienteInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

