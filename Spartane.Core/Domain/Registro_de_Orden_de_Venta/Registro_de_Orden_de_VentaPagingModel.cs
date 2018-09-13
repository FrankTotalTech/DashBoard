using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Registro_de_Orden_de_Venta
{
    public class Registro_de_Orden_de_VentaPagingModel
    {
        public List<Spartane.Core.Domain.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta> Registro_de_Orden_de_Ventas { set; get; }
        public int RowCount { set; get; }
    }
}
