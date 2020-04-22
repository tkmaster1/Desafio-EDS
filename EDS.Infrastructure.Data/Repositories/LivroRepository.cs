using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Infrastructure.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace EDS.Infrastructure.Data.Repositories
{
    public class LivroRepository : RepositoryBase<Livro>, ILivroRepository
    {
        public IEnumerable<Livro> GetAllForAtivo()
        {
            return Db.Livros.Where(p => p.Ativo == "S");
        }

        public List<Livro> GetAllForRelatorioPDF()
        {
            return Db.Livros.Where(p => p.Ativo == "S").OrderBy(p => p.LivroId).ToList();
        }

        public Livro GetAllDescending()
        {
            return Db.Livros.Where(p => p.Ativo == "S").OrderByDescending(p => p.LivroId).FirstOrDefault();
        }

        public Livro GetForLivroId(int CodId)
        {
            var query = (from t in Db.Livros
                         where t.Ativo == "S" && t.LivroId == CodId
                         select t).ToList();

            foreach (var item in query)
            {
                item.LivroAssuntos = (from q in Db.LivroAssuntos
                                      select q
                                    ).Where(q => q.LivroId == CodId).ToList();

                item.LivroAutores = (from q in Db.LivroAutores
                                     where q.LivroId == CodId
                                     select q
                                    ).Where(q => q.LivroId == CodId)
                                     .ToList();
            }

            return (query).ToList().FirstOrDefault();
        }
    }
}
