using System;
using System.ComponentModel.DataAnnotations;

namespace EDS.Domain.Entities
{
    public class LivroAssunto
    {
        [Key]
        public int LivroAssuntoId { get; set; } //Identity

        public int LivroId { get; set; } // Livro_CodId

        public int AssuntoId { get; set; } // Assunto_CodAs

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Ativo { get; set; }

        public virtual Assunto Assunto { get; set; }

        public virtual Livro Livro { get; set; }
    }
}
