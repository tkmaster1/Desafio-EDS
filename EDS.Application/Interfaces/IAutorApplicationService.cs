using EDS.Application.Interfaces.Base;
using EDS.Domain.Entities;
using System.Collections.Generic;

namespace EDS.Application.Interfaces
{
    public interface IAutorApplicationService : IApplicationServiceBase<Autor>
    {
        IEnumerable<Autor> GetAllForAtivo();
    }
}
