using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Domain.Interfaces.Services;
using EDS.Domain.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Services
{
    public class LivroAssuntoService : ServiceBase<LivroAssunto>, ILivroAssuntoService
    {
        private readonly ILivroAssuntoRepository _livroAssuntoRepository;

        public LivroAssuntoService(ILivroAssuntoRepository livroAssuntoRepository)
            : base(livroAssuntoRepository)
        {
            _livroAssuntoRepository = livroAssuntoRepository;
        }

        public IEnumerable<LivroAssunto> GetAllForAtivo()
        {
            return _livroAssuntoRepository.GetAllForAtivo();
        }

        public List<LivroAssunto> GetForLivroAssuntoIdLivro(int livroId)
        {
            return _livroAssuntoRepository.GetForLivroAssuntoIdLivro(livroId);
        }

        public List<LivroAssunto> GetForLivroIdAssuntoId(int LivroId, int AssuntoId)
        {
            return _livroAssuntoRepository.GetForLivroIdAssuntoId(LivroId, AssuntoId);
        }
    }
}
