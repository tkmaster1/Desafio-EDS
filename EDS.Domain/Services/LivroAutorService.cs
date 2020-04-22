using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Domain.Interfaces.Services;
using EDS.Domain.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Services
{
    public class LivroAutorService : ServiceBase<LivroAutor>, ILivroAutorService
    {
        private readonly ILivroAutorRepository _livroAutorRepository;

        public LivroAutorService(ILivroAutorRepository livroAutorRepository)
            : base(livroAutorRepository)
        {
            _livroAutorRepository = livroAutorRepository;
        }

        public IEnumerable<LivroAutor> GetAllForAtivo()
        {
            return _livroAutorRepository.GetAllForAtivo();
        }

        public List<LivroAutor> GetForLivroAutorIdLivro(int livroId)
        {
            return _livroAutorRepository.GetForLivroAutorIdLivro(livroId);
        }

        public List<LivroAutor> GetForLivroIdAutorId(int livroId, int autorId)
        {
            return _livroAutorRepository.GetForLivroIdAutorId(livroId, autorId);
        }
    }
}
