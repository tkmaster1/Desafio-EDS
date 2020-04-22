using EDS.Application.Interfaces.Base;
using EDS.Domain.Entities;
using System.Collections.Generic;

namespace EDS.Application.Interfaces
{
    public interface ILivroApplicationService : IApplicationServiceBase<Livro>
    {
        IEnumerable<Livro> GetAllForAtivo();
        List<Livro> GetAllForRelatorioPDF();
        Livro GetAllDescending();
        Livro GetForLivroId(int CodId);
    }
}
