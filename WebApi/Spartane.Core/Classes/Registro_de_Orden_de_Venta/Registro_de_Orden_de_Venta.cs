﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Cliente;
using Spartane.Core.Classes.Estatus;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Registro_de_Orden_de_Venta
{
    /// <summary>
    /// Registro_de_Orden_de_Venta table
    /// </summary>
    public class Registro_de_Orden_de_Venta: BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Cliente { get; set; }
        public int? Estatus { get; set; }
        public string Observaciones { get; set; }

        [ForeignKey("Cliente")]
        public virtual Spartane.Core.Classes.Cliente.Cliente Cliente_Cliente { get; set; }
        [ForeignKey("Estatus")]
        public virtual Spartane.Core.Classes.Estatus.Estatus Estatus_Estatus { get; set; }

    }
}

