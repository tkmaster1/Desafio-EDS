using EDS.Domain.Entities;
using EDS.Infrastructure.Data.EntityConfig;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace EDS.Infrastructure.Data.Contexto
{
    public class ModelContext : DbContext
    {
        public ModelContext() : base("ModeloDDDContexto")
        {
        }

        public DbSet<Assunto> Assuntos { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<LivroAssunto> LivroAssuntos { get; set; }
        public DbSet<LivroAutor> LivroAutores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties()
               .Where(p => p.Name == p.ReflectedType.Name + "Id")
               .Configure(p => p.IsKey());

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(250));

            // ModelConfiguration
            modelBuilder.Configurations.Add(new AssuntoConfiguration());
            modelBuilder.Configurations.Add(new AutorConfiguration());
            modelBuilder.Configurations.Add(new LivroAssuntoConfiguration());
            modelBuilder.Configurations.Add(new LivroAutorConfiguration());
            modelBuilder.Configurations.Add(new LivroConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInclusao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInclusao").CurrentValue = DateTime.Now;
                    entry.Property("Ativo").CurrentValue = "S";
                    entry.Property("DataAlteracao").IsModified = false;
                    entry.Property("DataExclusao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInclusao").IsModified = false;

                    if (entry.Property("Ativo").CurrentValue.ToString() != "N")
                    {
                        entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                        entry.Property("DataExclusao").IsModified = false;
                    }
                    else
                    {
                        entry.Property("DataAlteracao").IsModified = false;
                        entry.Property("DataExclusao").CurrentValue = DateTime.Now;
                    }
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInclusao").IsModified = false;
                    entry.Property("DataAlteracao").IsModified = false;
                    entry.Property("DataExclusao").IsModified = false;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInclusao").IsModified = false;

                    if (entry.Property("Ativo").CurrentValue.ToString() != "N")
                    {
                        entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                        entry.Property("DataExclusao").IsModified = false;
                    }
                    else
                    {
                        entry.Property("DataAlteracao").IsModified = false;
                        entry.Property("DataExclusao").CurrentValue = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}
