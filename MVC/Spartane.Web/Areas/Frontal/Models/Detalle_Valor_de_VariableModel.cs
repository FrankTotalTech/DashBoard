using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Valor_de_VariableModel
    {
        [Required]
        public int Folio { get; set; }
        public string Valor { get; set; }
        [Range(0, 9999999999)]
        public int? Peso { get; set; }

    }
	
	public class Detalle_Valor_de_Variable_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public string Valor { get; set; }
        [Range(0, 9999999999)]
        public int? Peso { get; set; }

    }


}

