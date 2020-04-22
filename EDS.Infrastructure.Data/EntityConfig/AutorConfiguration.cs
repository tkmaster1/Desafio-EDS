using EDS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EDS.Infrastructure.Data.EntityConfig
{
    public class AutorConfiguration : EntityTypeConfiguration<Autor>
    {
        public AutorConfiguration()
        {
            // Primary Key
            HasKey(c => c.AutorId);

            // Properties
            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(40);

            Property(c => c.Ativo)
                .HasMaxLength(1);

            //// Table & Column Mappings
            //ToTable("Autor");
            //Property(t => t.AutorId).HasColumnName("CodId");
        }
    }
}
