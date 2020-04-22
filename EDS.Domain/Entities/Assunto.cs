using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDS.Domain.Entities
{
    public class Assunto
    {
        [Key]
        public int AssuntoId { get; set; } //CodAs/CodId

        public string Descricao { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Ativo { get; set; }

        public virtual IEnumerable<LivroAssunto> LivroAssuntos { get; set; }
        public virtual IEnumerable<Livro> Livros { get; set; }
    }
}
