using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Registro_de_Orden_de_VentaGridModel
    {
        public int Folio { get; set; }
        public string Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Cliente { get; set; }
        public string ClienteNombre_Completo { get; set; }
        public int? Estatus { get; set; }
        public string EstatusDescripcion { get; set; }
        public string Observaciones { get; set; }
        
    }
}

