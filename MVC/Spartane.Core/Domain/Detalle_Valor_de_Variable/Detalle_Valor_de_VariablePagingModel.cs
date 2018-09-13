using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Detalle_Valor_de_Variable
{
    public class Detalle_Valor_de_VariablePagingModel
    {
        public List<Spartane.Core.Domain.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable> Detalle_Valor_de_Variables { set; get; }
        public int RowCount { set; get; }
    }
}
