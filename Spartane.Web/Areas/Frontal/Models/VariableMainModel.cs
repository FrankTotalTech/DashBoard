using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Spartane.Web.Areas.Frontal.Models
{
    public class VariableMainModel
    {
        public VariableModel VariableInfo { set; get; }
        public Detalle_Valor_de_VariableGridModelPost Detalle_Valor_de_VariableGridInfo { set; get; }

    }

    public class Detalle_Valor_de_VariableGridModelPost
    {
        public int Folio { get; set; }
        public string Valor { get; set; }
        public int? Peso { get; set; }

        public bool Removed { set; get; }
    }



}

