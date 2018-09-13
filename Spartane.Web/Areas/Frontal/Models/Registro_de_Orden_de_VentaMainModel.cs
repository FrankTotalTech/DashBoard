using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class Registro_de_Orden_de_VentaMainModel
    {
        public Registro_de_Orden_de_VentaModel Registro_de_Orden_de_VentaInfo { set; get; }
        public Detalle_Variables_de_VentaGridModelPost Detalle_Variables_de_VentaGridInfo { set; get; }

    }

    public class Detalle_Variables_de_VentaGridModelPost
    {
        public int Folio { get; set; }
        public int? Variable { get; set; }
        public int? Valor { get; set; }

        public bool Removed { set; get; }
    }



}

