using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Variable;
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
        private readonly IRepository<Spartane.Core.Classes.Variable.Variable> _VariableRepository;
        #endregion

        #region Ctor
        public VariableService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Variable.Variable> VariableRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._VariableRepository = VariableRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._VariableRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Variable.Variable> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Variable.Variable>("sp_SelAllVariable");
        }

        public IList<Core.Classes.Variable.Variable> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallVariable_Complete>("sp_SelAllComplete_Variable");
            return data.Select(m => new Core.Classes.Variable.Variable
            {
                Clave = m.Clave
                ,Descripcion = m.Descripcion
                ,Peso_de_Variable = m.Peso_de_Variable


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Variable>("sp_ListSelCount_Variable", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Variable.Variable> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllVariable>("sp_ListSelAll_Variable", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Variable.Variable
                {
                    Clave = m.Variable_Clave,
                    Descripcion = m.Variable_Descripcion,
                    Peso_de_Variable = m.Variable_Peso_de_Variable,

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

        public IList<Spartane.Core.Classes.Variable.Variable> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._VariableRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Variable.Variable> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._VariableRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Variable.VariablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllVariable>("sp_ListSelAll_Variable", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            VariablePagingModel result = null;

            if (data != null)
            {
                result = new VariablePagingModel
                {
                    Variables =
                        data.Select(m => new Spartane.Core.Classes.Variable.Variable
                {
                    Clave = m.Variable_Clave
                    ,Descripcion = m.Variable_Descripcion
                    ,Peso_de_Variable = m.Variable_Peso_de_Variable

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Variable.Variable> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._VariableRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Variable.Variable GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Clave";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Variable.Variable>("sp_GetVariable", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelVariable>("sp_DelVariable", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Variable.Variable entity)
        {
            int rta;
            try
            {

		var padreClave = _dataProvider.GetParameter();
                padreClave.ParameterName = "Clave";
                padreClave.DbType = DbType.Int32;
                padreClave.Value = (object)entity.Clave ?? DBNull.Value;
                var padreDescripcion = _dataProvider.GetParameter();
                padreDescripcion.ParameterName = "Descripcion";
                padreDescripcion.DbType = DbType.String;
                padreDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var padrePeso_de_Variable = _dataProvider.GetParameter();
                padrePeso_de_Variable.ParameterName = "Peso_de_Variable";
                padrePeso_de_Variable.DbType = DbType.Int32;
                padrePeso_de_Variable.Value = (object)entity.Peso_de_Variable ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsVariable>("sp_InsVariable" , padreDescripcion
, padrePeso_de_Variable
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

        public int Update(Spartane.Core.Classes.Variable.Variable entity)
        {
            int rta;
            try
            {

                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdPeso_de_Variable = _dataProvider.GetParameter();
                paramUpdPeso_de_Variable.ParameterName = "Peso_de_Variable";
                paramUpdPeso_de_Variable.DbType = DbType.Int32;
                paramUpdPeso_de_Variable.Value = (object)entity.Peso_de_Variable ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdVariable>("sp_UpdVariable" , paramUpdClave , paramUpdDescripcion , paramUpdPeso_de_Variable ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Variable.Variable entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Variable.Variable VariableDB = GetByKey(entity.Clave, false);
                var paramUpdClave = _dataProvider.GetParameter();
                paramUpdClave.ParameterName = "Clave";
                paramUpdClave.DbType = DbType.Int32;
                paramUpdClave.Value = (object)entity.Clave ?? DBNull.Value;
                var paramUpdDescripcion = _dataProvider.GetParameter();
                paramUpdDescripcion.ParameterName = "Descripcion";
                paramUpdDescripcion.DbType = DbType.String;
                paramUpdDescripcion.Value = (object)entity.Descripcion ?? DBNull.Value;
                var paramUpdPeso_de_Variable = _dataProvider.GetParameter();
                paramUpdPeso_de_Variable.ParameterName = "Peso_de_Variable";
                paramUpdPeso_de_Variable.DbType = DbType.Int32;
                paramUpdPeso_de_Variable.Value = (object)entity.Peso_de_Variable ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdVariable>("sp_UpdVariable" , paramUpdClave , paramUpdDescripcion , paramUpdPeso_de_Variable ).FirstOrDefault();

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

