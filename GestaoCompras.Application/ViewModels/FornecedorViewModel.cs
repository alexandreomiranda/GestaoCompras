using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace GestaoCompras.Application.ViewModels
{
    public class FornecedorViewModel
    {
        public FornecedorViewModel()
        {
            Contatos = new List<ContatoViewModel>();
        }
        [Key]
        public int FornecedorId { get; set; }
        
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [Display(Name = "Razão Social")]
        public string NomeFornecedor { get; set; }
        [Display(Name = "Nome Fantasia")]
        public string NomeFantasiaFornecedor { get; set; }
        public string CNPJ { get; set; }
        public string Website { get; set; }
        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }
        public ICollection<ContatoViewModel> Contatos { get; set; }
    }
}
