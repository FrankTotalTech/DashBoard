using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Variables_de_Venta
{
    public partial class Detalle_Variables_de_VentaMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Variables_de_Venta.Detalle_Variables_de_Venta>
    {
        public Detalle_Variables_de_VentaMap()
        {
            this.ToTable("Detalle_Variables_de_Venta");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
