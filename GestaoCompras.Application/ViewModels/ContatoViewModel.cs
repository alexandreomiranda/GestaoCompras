using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Application.ViewModels
{
    public class ContatoViewModel
    {
        public int ContatoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string Nome { get; set; }
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
        [ScaffoldColumn(false)]
        public int FornecedorId { get; set; }
    }
}
