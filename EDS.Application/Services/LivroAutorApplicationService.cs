using EDS.Application.Interfaces;
using EDS.Application.Services.Base;
using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace EDS.Application.Services
{
    public class LivroAutorApplicationService : ApplicationServiceBase<LivroAutor>, ILivroAutorApplicationService
    {
        private readonly ILivroAutorService _livroAutorService;

        public LivroAutorApplicationService(ILivroAutorService livroAutorService)
            : base(livroAutorService)
        {
            _livroAutorService = livroAutorService;
        }

        public IEnumerable<LivroAutor> GetAllForAtivo()
        {
            return _livroAutorService.GetAllForAtivo();
        }

        public List<LivroAutor> GetForLivroAutorIdLivro(int livroId)
        {
            return _livroAutorService.GetForLivroAutorIdLivro(livroId);
        }

        public List<LivroAutor> GetForLivroIdAutorId(int livroId, int autorId)
        {
            return _livroAutorService.GetForLivroIdAutorId(livroId, autorId);
        }
    }
}
