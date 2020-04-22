using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace EDS.Domain.Interfaces.Repository
{
    public interface ILivroAssuntoRepository : IRepositoryBase<LivroAssunto>
    {
        IEnumerable<LivroAssunto> GetAllForAtivo();
        List<LivroAssunto> GetForLivroAssuntoIdLivro(int livroId);
        List<LivroAssunto> GetForLivroIdAssuntoId(int LivroId, int AssuntoId);
    }
}
