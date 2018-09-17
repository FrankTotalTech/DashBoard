using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Detalle_Variables_de_Venta;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Detalle_Variables_de_Venta
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Detalle_Variables_de_VentaService : IDetalle_Variables_de_VentaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> _Detalle_Variables_de_VentaRepository;
        #endregion

        #region Ctor
        public Detalle_Variables_de_VentaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> Detalle_Variables_de_VentaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Detalle_Variables_de_VentaRepository = Detalle_Variables_de_VentaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Detalle_Variables_de_VentaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta>("sp_SelAllDetalle_Variables_de_Venta");
        }

        public IList<Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallDetalle_Variables_de_Venta_Complete>("sp_SelAllComplete_Detalle_Variables_de_Venta");
            return data.Select(m => new Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta
            {
                Folio = m.Folio
                ,Venta = m.Venta
                ,Variable_Variable = new Core.Classes.Variable.Variable() { Clave = m.Variable.GetValueOrDefault(), Descripcion = m.Variable_Descripcion }
                ,Valor_Detalle_Valor_de_Variable = new Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable() { Folio = m.Valor.GetValueOrDefault(), Valor = m.Valor_Valor }


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Detalle_Variables_de_Venta>("sp_ListSelCount_Detalle_Variables_de_Venta", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Variables_de_Venta>("sp_ListSelAll_Detalle_Variables_de_Venta", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta
                {
                    Folio = m.Detalle_Variables_de_Venta_Folio,
                    Venta = m.Detalle_Variables_de_Venta_Venta,
                    Variable = m.Detalle_Variables_de_Venta_Variable,
                    Valor = m.Detalle_Variables_de_Venta_Valor,

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

        public IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Detalle_Variables_de_VentaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Detalle_Variables_de_VentaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_VentaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllDetalle_Variables_de_Venta>("sp_ListSelAll_Detalle_Variables_de_Venta", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Detalle_Variables_de_VentaPagingModel result = null;

            if (data != null)
            {
                result = new Detalle_Variables_de_VentaPagingModel
                {
                    Detalle_Variables_de_Ventas =
                        data.Select(m => new Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta
                {
                    Folio = m.Detalle_Variables_de_Venta_Folio
                    ,Venta = m.Detalle_Variables_de_Venta_Venta
                    ,Variable = m.Detalle_Variables_de_Venta_Variable
                    ,Variable_Variable = new Core.Classes.Variable.Variable() { Clave = m.Detalle_Variables_de_Venta_Variable.GetValueOrDefault(), Descripcion = m.Detalle_Variables_de_Venta_Variable_Descripcion }
                    ,Valor = m.Detalle_Variables_de_Venta_Valor
                    ,Valor_Detalle_Valor_de_Variable = new Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable() { Folio = m.Detalle_Variables_de_Venta_Valor.GetValueOrDefault(), Valor = m.Detalle_Variables_de_Venta_Valor_Valor }

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Detalle_Variables_de_VentaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta>("sp_GetDetalle_Variables_de_Venta", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelDetalle_Variables_de_Venta>("sp_DelDetalle_Variables_de_Venta", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreVenta = _dataProvider.GetParameter();
                padreVenta.ParameterName = "Venta";
                padreVenta.DbType = DbType.Int32;
                padreVenta.Value = (object)entity.Venta ?? DBNull.Value;
                var padreVariable = _dataProvider.GetParameter();
                padreVariable.ParameterName = "Variable";
                padreVariable.DbType = DbType.Int32;
                padreVariable.Value = (object)entity.Variable ?? DBNull.Value;

                var padreValor = _dataProvider.GetParameter();
                padreValor.ParameterName = "Valor";
                padreValor.DbType = DbType.Int32;
                padreValor.Value = (object)entity.Valor ?? DBNull.Value;

 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsDetalle_Variables_de_Venta>("sp_InsDetalle_Variables_de_Venta" , padreVenta
, padreVariable
, padreValor
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

        public int Update(Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdVenta = _dataProvider.GetParameter();
                paramUpdVenta.ParameterName = "Venta";
                paramUpdVenta.DbType = DbType.Int32;
                paramUpdVenta.Value = (object)entity.Venta ?? DBNull.Value;
                var paramUpdVariable = _dataProvider.GetParameter();
                paramUpdVariable.ParameterName = "Variable";
                paramUpdVariable.DbType = DbType.Int32;
                paramUpdVariable.Value = (object)entity.Variable ?? DBNull.Value;

                var paramUpdValor = _dataProvider.GetParameter();
                paramUpdValor.ParameterName = "Valor";
                paramUpdValor.DbType = DbType.Int32;
                paramUpdValor.Value = (object)entity.Valor ?? DBNull.Value;



                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Variables_de_Venta>("sp_UpdDetalle_Variables_de_Venta" , paramUpdFolio , paramUpdVenta , paramUpdVariable , paramUpdValor ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta Detalle_Variables_de_VentaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdVenta = _dataProvider.GetParameter();
                paramUpdVenta.ParameterName = "Venta";
                paramUpdVenta.DbType = DbType.Int32;
                paramUpdVenta.Value = (object)entity.Venta ?? DBNull.Value;
		var paramUpdVariable = _dataProvider.GetParameter();
                paramUpdVariable.ParameterName = "Variable";
                paramUpdVariable.DbType = DbType.Int32;
                paramUpdVariable.Value = (object)entity.Variable ?? DBNull.Value;
		var paramUpdValor = _dataProvider.GetParameter();
                paramUpdValor.ParameterName = "Valor";
                paramUpdValor.DbType = DbType.Int32;
                paramUpdValor.Value = (object)entity.Valor ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdDetalle_Variables_de_Venta>("sp_UpdDetalle_Variables_de_Venta" , paramUpdFolio , paramUpdVenta , paramUpdVariable , paramUpdValor ).FirstOrDefault();

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

