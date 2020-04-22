using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDS.Domain.Entities
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; } //CodAu/CodId

        public string Nome { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Ativo { get; set; }

        public virtual IEnumerable<LivroAutor> LivroAutores { get; set; }
    }
}
