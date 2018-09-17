using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Spartane.Core.Classes.Cliente
{
    /// <summary>
    /// Cliente table
    /// </summary>
    public class Cliente: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_Completo { get; set; }


    }
}

