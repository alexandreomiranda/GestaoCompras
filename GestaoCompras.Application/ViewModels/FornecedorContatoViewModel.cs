using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Application.ViewModels
{
    public class FornecedorContatoViewModel
    {
        public int FornecedorId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [Display(Name = "Razão Social")]
        public string NomeFornecedor { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasiaFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string Website { get; set; }
        public bool Ativo { get; set; }

        public int ContatoId { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        public string Nome { get; set; }
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        public string Email { get; set; }
        public string Telefone1 { get; set; }
        public string Telefone2 { get; set; }
        public string Telefone3 { get; set; }
    }
}
