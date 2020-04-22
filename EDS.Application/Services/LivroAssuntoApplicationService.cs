using EDS.Application.Interfaces;
using EDS.Application.Services.Base;
using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace EDS.Application.Services
{
    public class LivroAssuntoApplicationService : ApplicationServiceBase<LivroAssunto>, ILivroAssuntoApplicationService
    {
        private readonly ILivroAssuntoService _livroAssuntoService;

        public LivroAssuntoApplicationService(ILivroAssuntoService livroAssuntoService)
            : base(livroAssuntoService)
        {
            _livroAssuntoService = livroAssuntoService;
        }

        public IEnumerable<LivroAssunto> GetAllForAtivo()
        {
            return _livroAssuntoService.GetAllForAtivo();
        }

        public List<LivroAssunto> GetForLivroAssuntoIdLivro(int livroId)
        {
            return _livroAssuntoService.GetForLivroAssuntoIdLivro(livroId);
        }

        public List<LivroAssunto> GetForLivroIdAssuntoId(int livroId, int assuntoId)
        {
            return _livroAssuntoService.GetForLivroIdAssuntoId(livroId, assuntoId);
        }
    }
}
