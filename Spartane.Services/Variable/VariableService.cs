using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Variable;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Variable
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class VariableService : IVariableService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Variable.Variable> _VariableRepository;
        #endregion

        #region Ctor
        public VariableService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Variable.Variable> VariableRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._VariableRepository = VariableRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Variable.Variable> SelAll(bool ConRelaciones)
        {
            return this._VariableRepository.Table.ToList();
        }

        public IList<Core.Domain.Variable.Variable> SelAllComplete(bool ConRelaciones)
        {
            return this._VariableRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Variable.Variable> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._VariableRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Variable.Variable> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._VariableRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Variable.Variable> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._VariableRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Variable.VariablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            VariablePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Variable.Variable> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._VariableRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Variable.Variable GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Variable.Variable result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData VariableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Variable.Variable entity, Spartane.Core.Domain.User.GlobalData VariableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Variable.Variable entity, Spartane.Core.Domain.User.GlobalData VariableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

