using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spartane.Core.Classes.StoredProcedure
{
   public class SpListSelAllRegistro_de_Orden_de_Venta : BaseEntity
    {
        public Int64 RowNumber { get; set; }
        public int Registro_de_Orden_de_Venta_Folio { get; set; }
        public DateTime? Registro_de_Orden_de_Venta_Fecha_de_Registro { get; set; }
        public string Registro_de_Orden_de_Venta_Hora_de_Registro { get; set; }
        public int? Registro_de_Orden_de_Venta_Cliente { get; set; }
        public string Registro_de_Orden_de_Venta_Cliente_Nombre_Completo { get; set; }
        public int? Registro_de_Orden_de_Venta_Estatus { get; set; }
        public string Registro_de_Orden_de_Venta_Estatus_Descripcion { get; set; }
        public string Registro_de_Orden_de_Venta_Observaciones { get; set; }

    }
}
