using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Spartane.Core.Domain.Cliente
{
    /// <summary>
    /// Cliente table
    /// </summary>
    public class Cliente: BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_Completo { get; set; }


    }
	
	public class Cliente_Datos_Generales
    {
                public int Clave { get; set; }
        public string Nombre_Completo { get; set; }

		
    }


}

