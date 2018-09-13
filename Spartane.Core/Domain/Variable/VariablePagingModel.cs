using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Domain.Variable
{
    public class VariablePagingModel
    {
        public List<Spartane.Core.Domain.Variable.Variable> Variables { set; get; }
        public int RowCount { set; get; }
    }
}
