using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class ClienteModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_Completo { get; set; }

    }
	
	public class Cliente_Datos_GeneralesModel
    {
        [Required]
        public int Clave { get; set; }
        public string Nombre_Completo { get; set; }

    }


}

