using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Services.Base;
using System.Collections.Generic;

namespace EDS.Domain.Interfaces.Services
{
    public interface IAutorService : IServiceBase<Autor>
    {
        IEnumerable<Autor> GetAllForAtivo();
    }
}
