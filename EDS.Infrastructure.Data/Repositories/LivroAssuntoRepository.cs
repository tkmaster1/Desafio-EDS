using EDS.Domain.Entities;
using EDS.Domain.Interfaces.Repository;
using EDS.Infrastructure.Data.Repositories.Base;
using System.Collections.Generic;
using System.Linq;

namespace EDS.Infrastructure.Data.Repositories
{
    public class LivroAssuntoRepository : RepositoryBase<LivroAssunto>, ILivroAssuntoRepository
    {
        public IEnumerable<LivroAssunto> GetAllForAtivo()
        {
            return Db.LivroAssuntos.Where(p => p.Ativo == "S");
        }

        /// <summary>
        /// Método que realiza uma consulta de acordo com Id do Livro vinculado e ativo
        /// </summary>
        /// <param name="livroId"></param>
        /// <returns>Retorna uma lista do tipo LivroAssunto pesquisado</returns>
        public List<LivroAssunto> GetForLivroAssuntoIdLivro(int livroId)
        {
            return Db.LivroAssuntos.Where(p => p.LivroId == livroId && p.Ativo == "S").ToList();
        }

        /// <summary>
        /// Método que realiza uma consulta de acordo com Id do Livro vinculado a um assunto especifico e ativo
        /// </summary>
        /// <param name="livroId"></param>
        /// <param name="assuntoId"></param>
        /// <returns></returns>
        public List<LivroAssunto> GetForLivroIdAssuntoId(int livroId, int assuntoId)
        {
            return Db.LivroAssuntos.Where(p => p.LivroId == livroId && p.AssuntoId == assuntoId && p.Ativo == "S").ToList();
        }
    }
}
