using EDS.Application.Interfaces;
using EDS.Application.Services.Base;
using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace EDS.Application.Services
{
    public class LivroApplicationService : ApplicationServiceBase<Livro>, ILivroApplicationService
    {
        private readonly ILivroService _livroService;

        public LivroApplicationService(ILivroService livroService)
            : base(livroService)
        {
            _livroService = livroService;
        }

        public IEnumerable<Livro> GetAllForAtivo()
        {
            return _livroService.GetAllForAtivo();
        }

        public List<Livro> GetAllForRelatorioPDF()
        {
            return _livroService.GetAllForRelatorioPDF();
        }

        public Livro GetAllDescending()
        {
            return _livroService.GetAllDescending();
        }

        public Livro GetForLivroId(int CodId)
        {
            return _livroService.GetForLivroId(CodId);
        }
    }
}
