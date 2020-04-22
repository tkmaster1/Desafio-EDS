using EDS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EDS.Infrastructure.Data.EntityConfig
{
    public class LivroAssuntoConfiguration : EntityTypeConfiguration<LivroAssunto>
    {
        public LivroAssuntoConfiguration()
        {
            // Primary Key
            HasKey(c => c.LivroAssuntoId);

            Property(c => c.Ativo)
                .HasMaxLength(1);

            HasRequired(p => p.Assunto)
               .WithMany()
               .HasForeignKey(p => p.AssuntoId);

            HasRequired(p => p.Livro)
              .WithMany()
              .HasForeignKey(p => p.LivroId);
        }
    }
}
