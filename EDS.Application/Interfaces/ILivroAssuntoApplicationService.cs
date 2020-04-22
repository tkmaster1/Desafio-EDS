using EDS.Application.Interfaces.Base;
using EDS.Domain.Entities;
using System.Collections.Generic;

namespace EDS.Application.Interfaces
{
    public interface ILivroAssuntoApplicationService : IApplicationServiceBase<LivroAssunto>
    {
        IEnumerable<LivroAssunto> GetAllForAtivo();
        List<LivroAssunto> GetForLivroAssuntoIdLivro(int livroId);
        List<LivroAssunto> GetForLivroIdAssuntoId(int livroId, int assuntoId);
    }
}
