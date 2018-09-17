using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.Variable
{
    public class VariablePagingModel
    {
        public List<Spartane.Core.Classes.Variable.Variable> Variables { set; get; }
        public int RowCount { set; get; }
    }
}
