using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Variable
{
    public partial class VariableMap : EntityTypeConfiguration<Spartane.Core.Classes.Variable.Variable>
    {
        public VariableMap()
        {
            this.ToTable("Variable");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Clave);
        }
    }
}
