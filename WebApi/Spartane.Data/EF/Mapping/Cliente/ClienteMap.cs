using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Cliente
{
    public partial class ClienteMap : EntityTypeConfiguration<Spartane.Core.Classes.Cliente.Cliente>
    {
        public ClienteMap()
        {
            this.ToTable("Cliente");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
