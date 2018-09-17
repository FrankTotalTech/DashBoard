using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Variables_de_Venta_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Venta { get; set; }
        public int? Variable { get; set; }
        public string Variable_Descripcion { get; set; }
        public int? Valor { get; set; }
        public string Valor_Valor { get; set; }

    }
}
