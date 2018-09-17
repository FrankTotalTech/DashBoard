using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Variable
{
    /// <summary>
    /// Variable table
    /// </summary>
    public class Variable: BaseEntity
    {
        public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Peso_de_Variable { get; set; }


    }
}

