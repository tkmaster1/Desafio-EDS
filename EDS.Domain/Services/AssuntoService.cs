using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Domain.Interfaces.Services;
using EDS.Domain.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Services
{
    public class AssuntoService : ServiceBase<Assunto>, IAssuntoService
    {
        private readonly IAssuntoRepository _assuntoRepository;

        public AssuntoService(IAssuntoRepository assuntoRepository)
            : base(assuntoRepository)
        {
            _assuntoRepository = assuntoRepository;
        }

        public IEnumerable<Assunto> GetAllForAtivo()
        {
            return _assuntoRepository.GetAllForAtivo();
        }
    }
}
