using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Classes;
using Spartane.Core.Data;
using Spartane.Core.Classes.StoredProcedure;
using Spartane.Data.EF;
using Spartane.Core.Classes.Registro_de_Orden_de_Venta;
using System.Collections.Generic;
using System.Linq;
using Spartane.Core.Exceptions;
using Spartane.Core.Exceptions.Service;
using System.Linq.Dynamic;

namespace Spartane.Services.Registro_de_Orden_de_Venta
{
    /// <summary>
    /// Authentication Service
    /// </summary>
    public partial class Registro_de_Orden_de_VentaService : IRegistro_de_Orden_de_VentaService
    {
        #region Fields
        private readonly IDataProvider _dataProvider;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> _Registro_de_Orden_de_VentaRepository;
        #endregion

        #region Ctor
        public Registro_de_Orden_de_VentaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> Registro_de_Orden_de_VentaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_de_Orden_de_VentaRepository = Registro_de_Orden_de_VentaRepository;


        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.Count();
        }

        public IList<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> SelAll(bool ConRelaciones)
        {
            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>("sp_SelAllRegistro_de_Orden_de_Venta");
        }

        public IList<Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> SelAllComplete(bool ConRelaciones)
        {
            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.Sp_SelallRegistro_de_Orden_de_Venta_Complete>("sp_SelAllComplete_Registro_de_Orden_de_Venta");
            return data.Select(m => new Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta
            {
                Folio = m.Folio
                ,Fecha_de_Registro = m.Fecha_de_Registro
                ,Hora_de_Registro = m.Hora_de_Registro
                ,Cliente_Cliente = new Core.Classes.Cliente.Cliente() { Clave = m.Cliente.GetValueOrDefault(), Nombre_Completo = m.Cliente_Nombre_Completo }
                ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Estatus.GetValueOrDefault(), Descripcion = m.Estatus_Descripcion }
                ,Observaciones = m.Observaciones


            }).ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            var padWhere = _dataProvider.GetParameter();
            padWhere.ParameterName = "Where";
            padWhere.DbType = DbType.String;
            padWhere.Value = Where;

            var rowCountData = _dbContext.ExecuteStoredProcedureList<Sp_ListSelCount_Registro_de_Orden_de_Venta>("sp_ListSelCount_Registro_de_Orden_de_Venta", padWhere);
            int rowCount = 0;
            if (rowCountData != null && rowCountData.Any())
                rowCount = rowCountData.FirstOrDefault().RowCount;
            return rowCount;
        }


        public IList<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> SelAll(bool ConRelaciones, string Where, string Order)
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


                var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Orden_de_Venta>("sp_ListSelAll_Registro_de_Orden_de_Venta", padreWhere, padreOrderBy);

                return data.Select(m => new Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta
                {
                    Folio = m.Registro_de_Orden_de_Venta_Folio,
                    Fecha_de_Registro = m.Registro_de_Orden_de_Venta_Fecha_de_Registro,
                    Hora_de_Registro = m.Registro_de_Orden_de_Venta_Hora_de_Registro,
                    Cliente = m.Registro_de_Orden_de_Venta_Cliente,
                    Estatus = m.Registro_de_Orden_de_Venta_Estatus,
                    Observaciones = m.Registro_de_Orden_de_Venta_Observaciones,

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

        public IList<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_VentaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
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

            var data = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.SpListSelAllRegistro_de_Orden_de_Venta>("sp_ListSelAll_Registro_de_Orden_de_Venta", padWhere, padOrder, padstartRowIndex, padmaximumRows);

            Registro_de_Orden_de_VentaPagingModel result = null;

            if (data != null)
            {
                result = new Registro_de_Orden_de_VentaPagingModel
                {
                    Registro_de_Orden_de_Ventas =
                        data.Select(m => new Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta
                {
                    Folio = m.Registro_de_Orden_de_Venta_Folio
                    ,Fecha_de_Registro = m.Registro_de_Orden_de_Venta_Fecha_de_Registro
                    ,Hora_de_Registro = m.Registro_de_Orden_de_Venta_Hora_de_Registro
                    ,Cliente = m.Registro_de_Orden_de_Venta_Cliente
                    ,Cliente_Cliente = new Core.Classes.Cliente.Cliente() { Clave = m.Registro_de_Orden_de_Venta_Cliente.GetValueOrDefault(), Nombre_Completo = m.Registro_de_Orden_de_Venta_Cliente_Nombre_Completo }
                    ,Estatus = m.Registro_de_Orden_de_Venta_Estatus
                    ,Estatus_Estatus = new Core.Classes.Estatus.Estatus() { Clave = m.Registro_de_Orden_de_Venta_Estatus.GetValueOrDefault(), Descripcion = m.Registro_de_Orden_de_Venta_Estatus_Descripcion }
                    ,Observaciones = m.Registro_de_Orden_de_Venta_Observaciones

                    //,Id = m.Id
                }).ToList()
                };
            }
            return result;

        }

        public IList<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.Where(Where).ToList();
        }

        public Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta GetByKey(int Key, bool ConRelaciones)
        {
            var padreKey = _dataProvider.GetParameter();
            padreKey.ParameterName = "Folio";
            padreKey.DbType = DbType.Int32;
            padreKey.Value = Key;

            return _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>("sp_GetRegistro_de_Orden_de_Venta", padreKey).SingleOrDefault();
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

                var padreResult = _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_DelRegistro_de_Orden_de_Venta>("sp_DelRegistro_de_Orden_de_Venta", padreKey).FirstOrDefault();
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

        public int Insert(Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta entity)
        {
            int rta;
            try
            {

		var padreFolio = _dataProvider.GetParameter();
                padreFolio.ParameterName = "Folio";
                padreFolio.DbType = DbType.Int32;
                padreFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var padreFecha_de_Registro = _dataProvider.GetParameter();
                padreFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                padreFecha_de_Registro.DbType = DbType.DateTime;
                padreFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var padreHora_de_Registro = _dataProvider.GetParameter();
                padreHora_de_Registro.ParameterName = "Hora_de_Registro";
                padreHora_de_Registro.DbType = DbType.String;
                padreHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var padreCliente = _dataProvider.GetParameter();
                padreCliente.ParameterName = "Cliente";
                padreCliente.DbType = DbType.Int32;
                padreCliente.Value = (object)entity.Cliente ?? DBNull.Value;

                var padreEstatus = _dataProvider.GetParameter();
                padreEstatus.ParameterName = "Estatus";
                padreEstatus.DbType = DbType.Int32;
                padreEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var padreObservaciones = _dataProvider.GetParameter();
                padreObservaciones.ParameterName = "Observaciones";
                padreObservaciones.DbType = DbType.String;
                padreObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;
 

                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_InsRegistro_de_Orden_de_Venta>("sp_InsRegistro_de_Orden_de_Venta" , padreFecha_de_Registro
, padreHora_de_Registro
, padreCliente
, padreEstatus
, padreObservaciones
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

        public int Update(Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta entity)
        {
            int rta;
            try
            {

                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;

                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
                var paramUpdCliente = _dataProvider.GetParameter();
                paramUpdCliente.ParameterName = "Cliente";
                paramUpdCliente.DbType = DbType.Int32;
                paramUpdCliente.Value = (object)entity.Cliente ?? DBNull.Value;

                var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;

                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_de_Orden_de_Venta>("sp_UpdRegistro_de_Orden_de_Venta" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdCliente , paramUpdEstatus , paramUpdObservaciones ).FirstOrDefault();

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
		public int Update_Datos_Generales(Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta entity)
        {
            int rta;
            try
            {
                Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta Registro_de_Orden_de_VentaDB = GetByKey(entity.Folio, false);
                var paramUpdFolio = _dataProvider.GetParameter();
                paramUpdFolio.ParameterName = "Folio";
                paramUpdFolio.DbType = DbType.Int32;
                paramUpdFolio.Value = (object)entity.Folio ?? DBNull.Value;
                var paramUpdFecha_de_Registro = _dataProvider.GetParameter();
                paramUpdFecha_de_Registro.ParameterName = "Fecha_de_Registro";
                paramUpdFecha_de_Registro.DbType = DbType.DateTime;
                paramUpdFecha_de_Registro.Value = (object)entity.Fecha_de_Registro ?? DBNull.Value;
                var paramUpdHora_de_Registro = _dataProvider.GetParameter();
                paramUpdHora_de_Registro.ParameterName = "Hora_de_Registro";
                paramUpdHora_de_Registro.DbType = DbType.String;
                paramUpdHora_de_Registro.Value = (object)entity.Hora_de_Registro ?? DBNull.Value;
		var paramUpdCliente = _dataProvider.GetParameter();
                paramUpdCliente.ParameterName = "Cliente";
                paramUpdCliente.DbType = DbType.Int32;
                paramUpdCliente.Value = (object)entity.Cliente ?? DBNull.Value;
		var paramUpdEstatus = _dataProvider.GetParameter();
                paramUpdEstatus.ParameterName = "Estatus";
                paramUpdEstatus.DbType = DbType.Int32;
                paramUpdEstatus.Value = (object)entity.Estatus ?? DBNull.Value;
                var paramUpdObservaciones = _dataProvider.GetParameter();
                paramUpdObservaciones.ParameterName = "Observaciones";
                paramUpdObservaciones.DbType = DbType.String;
                paramUpdObservaciones.Value = (object)entity.Observaciones ?? DBNull.Value;


                var empEntity =
                    _dbContext.ExecuteStoredProcedureList<Spartane.Core.Classes.StoredProcedure.sp_UpdRegistro_de_Orden_de_Venta>("sp_UpdRegistro_de_Orden_de_Venta" , paramUpdFolio , paramUpdFecha_de_Registro , paramUpdHora_de_Registro , paramUpdCliente , paramUpdEstatus , paramUpdObservaciones ).FirstOrDefault();

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

