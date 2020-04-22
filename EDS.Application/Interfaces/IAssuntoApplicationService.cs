using EDS.Application.Interfaces.Base;
using EDS.Domain.Entities;
using System.Collections.Generic;

namespace EDS.Application.Interfaces
{
    public interface IAssuntoApplicationService : IApplicationServiceBase<Assunto>
    {
        IEnumerable<Assunto> GetAllForAtivo();
    }
}
