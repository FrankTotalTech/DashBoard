using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Detalle_Valor_de_Variable;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Valor_de_Variable
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Valor_de_VariableService : IDetalle_Valor_de_VariableService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> _Detalle_Valor_de_VariableRepository;
        #endregion

        #region Ctor
        public Detalle_Valor_de_VariableService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> Detalle_Valor_de_VariableRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Valor_de_VariableRepository = Detalle_Valor_de_VariableRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(bool ConRelaciones)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.ToList();
        }

        public IList<Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAllComplete(bool ConRelaciones)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_VariablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Detalle_Valor_de_VariablePagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Detalle_Valor_de_VariableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity, Spartane.Core.Domain.User.GlobalData Detalle_Valor_de_VariableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity, Spartane.Core.Domain.User.GlobalData Detalle_Valor_de_VariableInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

