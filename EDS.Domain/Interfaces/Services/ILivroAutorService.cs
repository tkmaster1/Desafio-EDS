using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Interfaces.Services
{
    public interface ILivroAutorService : IServiceBase<LivroAutor>
    {
        IEnumerable<LivroAutor> GetAllForAtivo();
        List<LivroAutor> GetForLivroAutorIdLivro(int livroId);
        List<LivroAutor> GetForLivroIdAutorId(int livroId, int autorId);
    }
}
