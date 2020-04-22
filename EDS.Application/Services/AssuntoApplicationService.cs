using EDS.Application.Interfaces;
using EDS.Application.Services.Base;
using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace EDS.Application.Services
{
    public class AssuntoApplicationService : ApplicationServiceBase<Assunto>, IAssuntoApplicationService
    {
        private readonly IAssuntoService _assuntoService;

        public AssuntoApplicationService(IAssuntoService assuntoService)
            : base(assuntoService)
        {
            _assuntoService = assuntoService;
        }

        public IEnumerable<Assunto> GetAllForAtivo()
        {
            return _assuntoService.GetAllForAtivo();
        }
    }
}
