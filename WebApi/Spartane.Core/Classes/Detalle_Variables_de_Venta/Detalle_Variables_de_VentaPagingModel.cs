using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Detalle_Variables_de_Venta
{
    public class Detalle_Variables_de_VentaPagingModel
    {
        public List<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta> Detalle_Variables_de_Ventas { set; get; }
        public int RowCount { set; get; }
    }
}
