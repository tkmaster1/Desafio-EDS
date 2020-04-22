using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Interfaces.Services
{
    public interface ILivroService : IServiceBase<Livro>
    {
        IEnumerable<Livro> GetAllForAtivo();
        List<Livro> GetAllForRelatorioPDF();
        Livro GetAllDescending();
        Livro GetForLivroId(int CodId);
    }
}
