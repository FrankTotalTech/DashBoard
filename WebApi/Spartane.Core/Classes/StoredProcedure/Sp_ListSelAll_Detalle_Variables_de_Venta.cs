using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Variables_de_Venta : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Variables_de_Venta_Folio { get; set; }
        public int Detalle_Variables_de_Venta_Venta { get; set; }
        public int? Detalle_Variables_de_Venta_Variable { get; set; }
        public string Detalle_Variables_de_Venta_Variable_Descripcion { get; set; }
        public int? Detalle_Variables_de_Venta_Valor { get; set; }
        public string Detalle_Variables_de_Venta_Valor_Valor { get; set; }

    }
}
