﻿using System;
using System.Data;
using Spartane.Core;
using Spartane.Core.Data;
using Spartane.Data.EF;
using Spartane.Core.Domain.Registro_de_Orden_de_Venta;
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
        private readonly IRepository<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> _Registro_de_Orden_de_VentaRepository;
        #endregion

        #region Ctor
        public Registro_de_Orden_de_VentaService(IDataProvider dataProvider, IDbContext dbContext, IRepository<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> Registro_de_Orden_de_VentaRepository)
        {
            this._dataProvider = dataProvider;
            this._dbContext = dbContext;
            this._Registro_de_Orden_de_VentaRepository = Registro_de_Orden_de_VentaRepository;
        }
        #endregion

        #region CRUD Operations
        public int SelCount()
        {
            return 0;
        }

        public IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> SelAll(bool ConRelaciones)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.ToList();
        }

        public IList<Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> SelAllComplete(bool ConRelaciones)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.ToList();
        }

        public int ListaSelAllCount(string Where)
        {
            return 0;
        }


        public IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> SelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> SelAll(bool ConRelaciones, int CurrentRecordInt32, int RecordsDisplayedInt32)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.ToList();
        }

        public IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> ListaSelAll(bool ConRelaciones, string Where, string Order)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_VentaPagingModel ListaSelAll(int startRowIndex, int maximumRows, string Where, string Order)
        {
            Registro_de_Orden_de_VentaPagingModel result = null;
            return result;
        }

        public IList<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> ListaSelAll(bool ConRelaciones, string Where)
        {
            return this._Registro_de_Orden_de_VentaRepository.Table.ToList();
        }

        public Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta GetByKey(int Key, bool ConRelaciones)
        {
            Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta result=null;
            return result;
        }

        public bool Delete(int Key, Spartane.Core.Domain.User.GlobalData Registro_de_Orden_de_VentaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            var rta = true;
            return rta;
        }

        public int Insert(Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta entity, Spartane.Core.Domain.User.GlobalData Registro_de_Orden_de_VentaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }

        public int Update(Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta entity, Spartane.Core.Domain.User.GlobalData Registro_de_Orden_de_VentaInformation, Core.Domain.Data.DataLayerFieldsBitacora DataReference)
        {
            int rta = Convert.ToInt32("0");
            return rta;
        }
        #endregion
    }
}

