using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace EDS.Domain.Interfaces.Repository
{
    public interface ILivroAutorRepository : IRepositoryBase<LivroAutor>
    {
        IEnumerable<LivroAutor> GetAllForAtivo();
        List<LivroAutor> GetForLivroAutorIdLivro(int livroId);
        List<LivroAutor> GetForLivroIdAutorId(int livroId, int autorId);
    }
}
