using EDS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EDS.MVC.ViewModels
{
    public class LivroAutorViewModel
    {
        [Key]
        public int CodId { get; set; } //Identity

        [Display(Name = "Livros:")]
        [Required(ErrorMessage = "*campo obrigatório!")]
        public int LivroId { get; set; } // Livro_CodId

        [Display(Name = "Autores:")]
        [Required(ErrorMessage = "*campo obrigatório!")]
        public int AutorId { get; set; } // Autor_CodAu

        [ScaffoldColumn(false)]
        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Ativo { get; set; }

        public virtual Autor Autor { get; set; }

        public virtual Livro Livro { get; set; }
    }
}