using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Domain.Interfaces.Services;
using EDS.Domain.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Services
{
    public class LivroService
         : ServiceBase<Livro>, ILivroService
    {
        private readonly ILivroRepository _livroRepository;

        public LivroService(ILivroRepository livroRepository)
            : base(livroRepository)
        {
            _livroRepository = livroRepository;
        }

        public IEnumerable<Livro> GetAllForAtivo()
        {
            return _livroRepository.GetAllForAtivo();
        }

        public List<Livro> GetAllForRelatorioPDF()
        {
            return _livroRepository.GetAllForRelatorioPDF();
        }

        public Livro GetAllDescending()
        {
            return _livroRepository.GetAllDescending();
        }

        public Livro GetForLivroId(int CodId)
        {
            return _livroRepository.GetForLivroId(CodId);
        }
    }
}
