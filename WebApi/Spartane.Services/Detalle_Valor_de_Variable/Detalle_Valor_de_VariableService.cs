using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Valor_de_Variable;
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
        private readonly IRepository<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> _Detalle_Valor_de_VariableRepository;
        #endregion

        #region Ctor
        public Detalle_Valor_de_VariableService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> Detalle_Valor_de_VariableRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Valor_de_VariableRepository = Detalle_Valor_de_VariableRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Valor_de_VariableRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>("sp_SelAllDetalle_Valor_de_Variable");
        }

        public IList<Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Valor_de_Variable_Complete>("sp_SelAllComplete_Detalle_Valor_de_Variable");
            return data.Select(m => new Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable
            {
                Folio = m.Folio
                ,Variable = m.Variable
                ,Valor = m.Valor
                ,Peso = m.Peso


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Valor_de_Variable>("sp_ListSelCount_Detalle_Valor_de_Variable", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Valor_de_Variable>("sp_ListSelAll_Detalle_Valor_de_Variable", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable
                {
                    Folio = m.Detalle_Valor_de_Variable_Folio,
                    Variable = m.Detalle_Valor_de_Variable_Variable,
                    Valor = m.Detalle_Valor_de_Variable_Valor,
                    Peso = m.Detalle_Valor_de_Variable_Peso,

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

        public IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_VariablePagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Valor_de_Variable>("sp_ListSelAll_Detalle_Valor_de_Variable", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Valor_de_VariablePagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Valor_de_VariablePagingModel
                {
                    Detalle_Valor_de_Variables =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable
                {
                    Folio = m.Detalle_Valor_de_Variable_Folio
                    ,Variable = m.Detalle_Valor_de_Variable_Variable
                    ,Valor = m.Detalle_Valor_de_Variable_Valor
                    ,Peso = m.Detalle_Valor_de_Variable_Peso

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Valor_de_VariableRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>("sp_GetDetalle_Valor_de_Variable", padreKey).SingleOrDefault();
        }

        public bool Delete(int Key)
        {
            var rta = true;
            try
            {
                var padreKey = _dataProvider.GetParameter();
                padreKey.ParameterName = "Folio";
                padreKey.DbType = DbType.Int32;
                padreKey.Value = Key;

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Valor_de_Variable>("sp_DelDetalle_Valor_de_Variable", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreVariable = _dataProvider.GetParameter();
                padreVariable.ParameterName = "Variable";
                padreVariable.DbType = DbType.Int32;
                padreVariable.Value = (object)entity.Variable ?? DBNull.Value;
                var padreValor = _dataProvider.GetParameter();
                padreValor.ParameterName = "Valor";
                padreValor.DbType = DbType.String;
                padreValor.Value = (object)entity.Valor ?? DBNull.Value;
                var padrePeso = _dataProvider.GetParameter();
                padrePeso.ParameterName = "Peso";
                padrePeso.DbType = DbType.Int32;
                padrePeso.Value = (object)entity.Peso ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Valor_de_Variable>("sp_InsDetalle_Valor_de_Variable" , padreVariable
, padreValor
, padrePeso
).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);

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

        public int Update(Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdVariable = _dataProvider.GetParameter();
                paramUpdVariable.ParameterName = "Variable";
                paramUpdVariable.DbType = DbType.Int32;
                paramUpdVariable.Value = (object)entity.Variable ?? DBNull.Value;
                var paramUpdValor = _dataProvider.GetParameter();
                paramUpdValor.ParameterName = "Valor";
                paramUpdValor.DbType = DbType.String;
                paramUpdValor.Value = (object)entity.Valor ?? DBNull.Value;
                var paramUpdPeso = _dataProvider.GetParameter();
                paramUpdPeso.ParameterName = "Peso";
                paramUpdPeso.DbType = DbType.Int32;
                paramUpdPeso.Value = (object)entity.Peso ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Valor_de_Variable>("sp_UpdDetalle_Valor_de_Variable" , paramUpdFolio , paramUpdVariable , paramUpdValor , paramUpdPeso ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable Detalle_Valor_de_VariableDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdVariable = _dataProvider.GetParameter();
                paramUpdVariable.ParameterName = "Variable";
                paramUpdVariable.DbType = DbType.Int32;
                paramUpdVariable.Value = (object)entity.Variable ?? DBNull.Value;
                var paramUpdValor = _dataProvider.GetParameter();
                paramUpdValor.ParameterName = "Valor";
                paramUpdValor.DbType = DbType.String;
                paramUpdValor.Value = (object)entity.Valor ?? DBNull.Value;
                var paramUpdPeso = _dataProvider.GetParameter();
                paramUpdPeso.ParameterName = "Peso";
                paramUpdPeso.DbType = DbType.Int32;
                paramUpdPeso.Value = (object)entity.Peso ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Valor_de_Variable>("sp_UpdDetalle_Valor_de_Variable" , paramUpdFolio , paramUpdVariable , paramUpdValor , paramUpdPeso ).FirstOrDefault();

                rta = Convert.ToInt32(empEntity.Folio);
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

