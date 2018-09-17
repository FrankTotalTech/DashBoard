using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Registro_de_Orden_de_Venta
{
    public partial class Registro_de_Orden_de_VentaMap : EntityTypeConfiguration<Spartane.Core.Classes.Registro_de_Orden_de_Venta.Registro_de_Orden_de_Venta>
    {
        public Registro_de_Orden_de_VentaMap()
        {
            this.ToTable("Registro_de_Orden_de_Venta");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
