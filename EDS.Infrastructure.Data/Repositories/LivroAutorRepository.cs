using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Infrastructure.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace EDS.Infrastructure.Data.Repositories
{
    public class LivroAutorRepository : RepositoryBase<LivroAutor>, ILivroAutorRepository
    {
        public IEnumerable<LivroAutor> GetAllForAtivo()
        {
            return Db.LivroAutores.Where(p => p.Ativo == "S");
        }

        /// <summary>
        /// Método que realiza uma consulta de acordo com Id do Livro vinculado e ativo
        /// </summary>
        /// <param name="livroId"></param>
        /// <returns>Retorna uma lista do tipo LivroAutor pesquisado</returns>
        public List<LivroAutor> GetForLivroAutorIdLivro(int livroId)
        {
            return Db.LivroAutores.Where(p => p.LivroId == livroId && p.Ativo == "S").ToList();
        }

        public List<LivroAutor> GetForLivroIdAutorId(int livroId, int autorId)
        {
            return Db.LivroAutores.Where(p => p.LivroId == livroId && p.AutorId == autorId && p.Ativo == "S").ToList();
        }
    }
}
