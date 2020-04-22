using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Domain.Interfaces.Services;
using EDS.Domain.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Services
{
    public class AutorService : ServiceBase<Autor>, IAutorService
    {
        private readonly IAutorRepository _autorRepository;

        public AutorService(IAutorRepository autorRepository)
            : base(autorRepository)
        {
            _autorRepository = autorRepository;
        }

        public IEnumerable<Autor> GetAllForAtivo()
        {
            return _autorRepository.GetAllForAtivo();
        }
    }
}
