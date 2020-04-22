using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Infrastructure.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace EDS.Infrastructure.Data.Repositories
{
    public class AutorRepository : RepositoryBase<Autor>, IAutorRepository
    {
        public IEnumerable<Autor> GetAllForAtivo()
        {
            return Db.Autores.Where(p => p.Ativo == "S").OrderBy(p => p.Nome);
        }
    }
}
