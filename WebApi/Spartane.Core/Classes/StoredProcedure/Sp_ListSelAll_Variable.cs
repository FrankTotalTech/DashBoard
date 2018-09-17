using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllVariable : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Variable_Clave { get; set; }
        public string Variable_Descripcion { get; set; }
        public int? Variable_Peso_de_Variable { get; set; }

    }
}
