using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallCliente_Complete : BaseEntity
    {
        public int Clave { get; set; }
        public string Nombre_Completo { get; set; }

    }
}
