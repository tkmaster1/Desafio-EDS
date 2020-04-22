using EDS.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EDS.Infrastructure.Data.EntityConfig
{
    public class LivroConfiguration : EntityTypeConfiguration<Livro>
    {
        public LivroConfiguration()
        {
            // Primary Key
            HasKey(c => c.LivroId);

            // Properties
            Property(c => c.Titulo)
                .IsRequired()
                .HasMaxLength(40);

            Property(c => c.Editora)
                .HasMaxLength(40);

            Property(c => c.AnoPublicacao)
                .HasMaxLength(4);

            Property(c => c.Ativo)
                .HasMaxLength(1);           
        }
    }
}
