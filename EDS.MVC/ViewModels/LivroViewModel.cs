using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EDS.MVC.ViewModels
{
    public class LivroViewModel
    {
        [Key]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "*Preencha o campo Título")]
        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo 2 caracteres")]
        [DisplayName("Título:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "*Preencha o campo Editora")]
        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [DisplayName("Editora:")]
        public string Editora { get; set; }

        [Required(ErrorMessage = "*Preencha o campo Edição")]
        [DisplayName("Edição:")]
        public int Edicao { get; set; }

        [Required(ErrorMessage = "*Preencha o campo Ano de Publicação")]
        [MaxLength(4, ErrorMessage = "Máximo 4 caracteres")]
        [MinLength(4, ErrorMessage = "Mínimo 4 caracteres")]
        [DisplayName("Ano de Publicação:")]
        public string AnoPublicacao { get; set; }

        public string Ativo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Mensagem { get; set; }

        [DisplayName("Autores:")]
        public int AutorId { get; set; } // Autor_CodAu
        public virtual IEnumerable<LivroAutorViewModel> LivroAutores { get; set; }

        [DisplayName("Assuntos:")]
        public int AssuntoId { get; set; } // CodAs
        public virtual IEnumerable<LivroAssuntoViewModel> LivroAssuntos { get; set; }
    }
}
