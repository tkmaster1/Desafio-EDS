using System;
using System.ComponentModel.DataAnnotations;

namespace EDS.Domain.Entities
{
    public class LivroAutor
    {
        [Key]
        public int LivroAutorId { get; set; } //Identity
       
        public int LivroId { get; set; } // Livro_CodId

        public int AutorId { get; set; } // Autor_CodAu

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Ativo { get; set; }

        public virtual Autor Autor { get; set; }

        public virtual Livro Livro { get; set; }
    }
}
