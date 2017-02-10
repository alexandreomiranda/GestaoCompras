using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Application.ViewModels
{
    public class UnidadeViewModel
    {
        [Key]
        public int UnidadeId { get; set; }

        [Required(ErrorMessage = "Preencha o campo Unidade de Medida")]
        [Display(Name = "Unidade de Medida")]
        public string NomeUnidade { get; set; }
    }
}
