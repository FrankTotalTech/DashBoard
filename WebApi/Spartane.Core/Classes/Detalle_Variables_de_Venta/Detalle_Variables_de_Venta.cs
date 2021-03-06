﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Registro_de_Orden_de_Venta;
using Spartane.Core.Classes.Variable;
using Spartane.Core.Classes.Detalle_Valor_de_Variable;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Variables_de_Venta
{
    /// <summary>
    /// Detalle_Variables_de_Venta table
    /// </summary>
    public class Detalle_Variables_de_Venta: BaseEntity
    {
        public int Folio { get; set; }
        public int? Venta { get; set; }
        public int? Variable { get; set; }
        public int? Valor { get; set; }

        [ForeignKey("Venta")]
        public virtual Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta Venta_Registro_de_Orden_de_Venta { get; set; }
        [ForeignKey("Variable")]
        public virtual Spartane.Core.Classes.Variable.Variable Variable_Variable { get; set; }
        [ForeignKey("Valor")]
        public virtual Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable Valor_Detalle_Valor_de_Variable { get; set; }

    }
}

