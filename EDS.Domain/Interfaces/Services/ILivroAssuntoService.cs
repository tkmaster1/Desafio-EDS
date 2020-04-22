using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Interfaces.Services
{
    public interface ILivroAssuntoService : IServiceBase<LivroAssunto>
    {
        IEnumerable<LivroAssunto> GetAllForAtivo();
        List<LivroAssunto> GetForLivroAssuntoIdLivro(int livroId);
        List<LivroAssunto> GetForLivroIdAssuntoId(int livroId, int assuntoId);
    }
}
