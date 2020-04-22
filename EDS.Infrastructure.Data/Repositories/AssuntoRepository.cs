using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Infrastructure.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace EDS.Infrastructure.Data.Repositories
{
    public class AssuntoRepository : RepositoryBase<Assunto>, IAssuntoRepository
    {
        public IEnumerable<Assunto> GetAllForAtivo()
        {
            return Db.Assuntos.Where(p => p.Ativo == "S").OrderBy(p=> p.Descricao);
        }
    }
}
