using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EDS.Domain.Entities
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        public string Titulo { get; set; }

        public string Editora { get; set; }

        public int Edicao { get; set; }

        public string AnoPublicacao { get; set; }

        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Ativo { get; set; }

        public virtual IEnumerable<LivroAutor> LivroAutores { get; set; }
        public virtual IEnumerable<LivroAssunto> LivroAssuntos { get; set; }
    }
}
