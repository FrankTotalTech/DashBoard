using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Detalle_Variables_de_VentaModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Variable { get; set; }
        public string VariableDescripcion { get; set; }
        public int? Valor { get; set; }
        public string ValorValor { get; set; }

    }
	
	public class Detalle_Variables_de_Venta_Datos_GeneralesModel
    {
        [Required]
        public int Folio { get; set; }
        public int? Variable { get; set; }
        public string VariableDescripcion { get; set; }
        public int? Valor { get; set; }
        public string ValorValor { get; set; }

    }


}

