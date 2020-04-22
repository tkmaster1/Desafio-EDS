using EDS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EDS.Infrastructure.Data.EntityConfig
{
    public class LivroAutorConfiguration : EntityTypeConfiguration<LivroAutor>
    {
        public LivroAutorConfiguration()
        {
            // Primary Key
            HasKey(c => c.LivroAutorId);

            Property(c => c.Ativo)
                .HasMaxLength(1);

            HasRequired(p => p.Autor)
               .WithMany()
               .HasForeignKey(p => p.AutorId);

            HasRequired(p => p.Livro)
              .WithMany()
              .HasForeignKey(p => p.LivroId);
        }
    }
}
