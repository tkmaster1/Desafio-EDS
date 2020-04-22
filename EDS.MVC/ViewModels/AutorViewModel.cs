using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EDS.MVC.ViewModels
{
    public class AutorViewModel
    {
        [Key]
        public int AutorId { get; set; } //CodAu

        [Required(ErrorMessage = "*Preencha o campo Nome")]
        [MaxLength(40, ErrorMessage = "Máximo 40 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo 2 caracteres")]
        [DisplayName("Nome:")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataInclusao { get; set; }

        public DateTime? DataAlteracao { get; set; }

        public DateTime? DataExclusao { get; set; }

        public string Ativo { get; set; }

        public string Mensagem { get; set; }

        public virtual IEnumerable<LivroViewModel> Livros { get; set; }
    }
}
