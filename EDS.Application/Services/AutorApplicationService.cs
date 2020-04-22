using EDS.Application.Interfaces;
using EDS.Application.Services.Base;
using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace EDS.Application.Services
{
    public class AutorApplicationService : ApplicationServiceBase<Autor>, IAutorApplicationService
    {
        private readonly IAutorService _autorService;

        public AutorApplicationService(IAutorService autorService)
            : base(autorService)
        {
            _autorService = autorService;
        }

        public IEnumerable<Autor> GetAllForAtivo()
        {
            return _autorService.GetAllForAtivo();
        }
    }
}
