using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
    public class Sp_SelallRegistro_de_Orden_de_Venta_Complete : BaseEntity
    {
        public int Folio { get; set; }
        public DateTime? Fecha_de_Registro { get; set; }
        public string Hora_de_Registro { get; set; }
        public int? Cliente { get; set; }
        public string Cliente_Nombre_Completo { get; set; }
        public int? Estatus { get; set; }
        public string Estatus_Descripcion { get; set; }
        public string Observaciones { get; set; }

    }
}
