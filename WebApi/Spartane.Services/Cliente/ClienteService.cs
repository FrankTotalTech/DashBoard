using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Cliente;
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
        private readonly IRepository<Spartane.Core.Classes.Cliente.Cliente> _ClienteRepository;
        #endregion

        #region Ctor
        public ClienteService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Cliente.Cliente> ClienteRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._ClienteRepository = ClienteRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._ClienteRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Cliente.Cliente> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Cliente.Cliente>("sp_SelAllCliente");
        }

        public IList<Core.Classes.Cliente.Cliente> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallCliente_Complete>("sp_SelAllComplete_Cliente");
            return data.Select(m => new Core.Classes.Cliente.Cliente
            {
                Clave = m.Clave
                ,Nombre_Completo = m.Nombre_Completo


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Cliente>("sp_ListSelCount_Cliente", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Cliente.Cliente> SelAll(bool ConRelaciones, string Where, string Order)
        {
            try
            {
                var padreWhere = _dataProvider.GetParameter();
                padreWhere.ParameterName = "Where";
                padreWhere.DbType = DbType.String;

                padreWhere.Value = Where;

                var padreOrderBy = _dataProvider.GetParameter();
                padreOrderBy.ParameterName = "Order";
                padreOrderBy.DbType = DbType.String;
                padreOrderBy.Value = Order;


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCliente>("sp_ListSelAll_Cliente", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Cliente.Cliente
                {
                    Clave = m.Cliente_Clave,
                    Nombre_Completo = m.Cliente_Nombre_Completo,

                    //Id = m.Id,
                }).ToList();
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

        }

        public IList<Spartane.Core.Classes.Cliente.Cliente> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._ClienteRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Cliente.Cliente> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._ClienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Cliente.ClientePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            var padstartRowIndex = _dataProvider.GetParameter();
            padstartRowIndex.ParameterName = "startRowIndex";
            padstartRowIndex.DbType = DbType.Int32;
            padstartRowIndex.Value = startRowIndex;

            var padmaximumRows = _dataProvider.GetParameter();
            padmaximumRows.ParameterName = "maximumRows";
            padmaximumRows.DbType = DbType.Int32;
            padmaximumRows.Value = maximumRows;

            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var padOrder = _dataProvider.GetParameter();
            padOrder.ParameterName = "Order";
            padOrder.DbType = DbType.String;
            padOrder.Value = Order;

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllCliente>("sp_ListSelAll_Cliente", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            ClientePagingModel result = null;

            if (data != null)
            {
                result = new ClientePagingModel
                {
                    Clientes =
                        data.Select(m => new Spartane.Core.Classes.Cliente.Cliente
                {
                    Clave = m.Cliente_Clave
                    ,Nombre_Completo = m.Cliente_Nombre_Completo

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Cliente.Cliente> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._ClienteRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Cliente.Cliente GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Cliente.Cliente>("sp_GetCliente", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Clave";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelCliente>("sp_DelCliente", padreKey).FirstOrDefault();
                if (padreResult != null)
                    rta = padreResult.Result.ToString() == "1";
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Insert(Spartane.Core.Classes.Cliente.Cliente entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreNombre_Completo = _dataProvider.GetParameter();
                padreNombre_Completo.ParameterName = "Nombre_Completo";
                padreNombre_Completo.DbType = DbType.String;
                padreNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsCliente>("sp_InsCliente" , padreNombre_Completo
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);

            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }

        public int Update(Spartane.Core.Classes.Cliente.Cliente entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCliente>("sp_UpdCliente" , paramUpdClave , paramUpdNombre_Completo ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }
		public int Update_Datos_Generales(Spartane.Core.Classes.Cliente.Cliente entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Cliente.Cliente ClienteDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdNombre_Completo = _dataProvider.GetParameter();
                paramUpdNombre_Completo.ParameterName = "Nombre_Completo";
                paramUpdNombre_Completo.DbType = DbType.String;
                paramUpdNombre_Completo.Value = (object)entity.Nombre_Completo ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdCliente>("sp_UpdCliente" , paramUpdClave , paramUpdNombre_Completo ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Clave);
            }
            catch (ExceptionBase ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ServiceException(ex.Message, ex);
            }

            return rta;
        }


        #endregion
    }
}

