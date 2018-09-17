using System.Data.Entity.ModelConfiguration;

namespace Spartane.Data.EF.Mapping.Detalle_Valor_de_Variable
{
    public partial class Detalle_Valor_de_VariableMap : EntityTypeConfiguration<Spartane.Core.Classes.Detalle_Valor_de_Variable.Detalle_Valor_de_Variable>
    {
        public Detalle_Valor_de_VariableMap()
        {
            this.ToTable("Detalle_Valor_de_Variable");
            this.Ignore(a => a.Id);
            this.HasKey(a => a.Folio);
        }
    }
}
