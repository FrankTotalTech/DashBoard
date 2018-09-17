using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallDetalle_Valor_de_Variable_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public int Variable { get; set; }
        public string Valor { get; set; }
        public int? Peso { get; set; }

    }
}
