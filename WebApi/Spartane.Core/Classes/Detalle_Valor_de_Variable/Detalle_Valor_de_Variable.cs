using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spartane.Core.Classes.Variable;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Detalle_Valor_de_Variable
{
    /// <summary>
    /// Detalle_Valor_de_Variable table
    /// </summary>
    public class Detalle_Valor_de_Variable: BaseEntity
    {
        public int Folio { get; set; }
        public int? Variable { get; set; }
        public string Valor { get; set; }
        public int? Peso { get; set; }

        [ForeignKey("Variable")]
        public virtual Spartane.Core.Classes.Variable.Variable Variable_Variable { get; set; }

    }
}

