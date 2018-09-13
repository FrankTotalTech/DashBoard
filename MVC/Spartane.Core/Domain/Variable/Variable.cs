using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Variable
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
	
	public class Variable_Datos_Generales
    {
                public int Clave { get; set; }
        public string Descripcion { get; set; }
        public int? Peso_de_Variable { get; set; }

		
    }


}

