using EDS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EDS.Infrastructure.Data.EntityConfig
{
    public class AssuntoConfiguration : EntityTypeConfiguration<Assunto>
    {
        public AssuntoConfiguration()
        {
            // Primary Key
            HasKey(c => c.AssuntoId);

            // Properties
            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(20);

            Property(c => c.Ativo)
                .HasMaxLength(1);

            //// Table & Column Mappings
            //ToTable("Assunto");
            //Property(t => t.AssuntoId).HasColumnName("CodId");
        }
    }
}
