using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllDetalle_Valor_de_Variable : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Detalle_Valor_de_Variable_Folio { get; set; }
        public int Detalle_Valor_de_Variable_Variable { get; set; }
        public string Detalle_Valor_de_Variable_Valor { get; set; }
        public int? Detalle_Valor_de_Variable_Peso { get; set; }

    }
}
