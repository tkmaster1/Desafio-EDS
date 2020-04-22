using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace EDS.Domain.Interfaces.Repository
{
    public interface ILivroRepository : IRepositoryBase<Livro>
    {
        IEnumerable<Livro> GetAllForAtivo();
        List<Livro> GetAllForRelatorioPDF();
        Livro GetAllDescending();
        Livro GetForLivroId(int CodId);
    }
}
