using EDS.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace EDS.MVC.ViewModels
{
    public class LivroAssuntoViewModel
    {
        [Key]
        public int LivroAssuntoId { get; set; } //Identity

        [Display(Name = "Livros:")]
        [Required(ErrorMessage = "*campo obrigatório!")]
        public int LivroId { get; set; } // Livro_CodId

        [Display(Name = "Assuntos:")]
        [Required(ErrorMessage = "*campo obrigatório!")]
        public int AssuntoId { get; set; } // Autor_CodAs

        [ScaffoldColumn(false)]
        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Ativo { get; set; }

        public virtual Assunto Assunto { get; set; }

        public virtual Livro Livro { get; set; }
    }
}