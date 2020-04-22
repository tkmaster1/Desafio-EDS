using EDS.Application.Interfaces.Base;
using EDS.Domain.Entities;
using System.Collections.Generic;

namespace EDS.Application.Interfaces
{
    public interface ILivroAutorApplicationService : IApplicationServiceBase<LivroAutor>
    {
        IEnumerable<LivroAutor> GetAllForAtivo();
        List<LivroAutor> GetForLivroAutorIdLivro(int livroId);
        List<LivroAutor> GetForLivroIdAutorId(int livroId, int autorId);
    }
}
