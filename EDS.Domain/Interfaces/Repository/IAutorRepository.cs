using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository.Base;
using System.Collections.Generic;

namespace EDS.Domain.Interfaces.Repository
{
    public interface IAutorRepository : IRepositoryBase<Autor>
    {
        IEnumerable<Autor> GetAllForAtivo();
    }
}
