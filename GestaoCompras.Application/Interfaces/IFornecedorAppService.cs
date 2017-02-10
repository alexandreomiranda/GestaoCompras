using GestaoCompras.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoCompras.Application.Interfaces
{
    public interface IFornecedorAppService : IDisposable
    {
        FornecedorContatoViewModel Adicionar(FornecedorContatoViewModel fornecedorContatoViewModel);
        IEnumerable<FornecedorViewModel> ObterTodos();
        FornecedorViewModel Atualizar(FornecedorContatoViewModel fornecedorContatoViewModel);
        void Remover(int id);
        ContatoViewModel AdicionarContato(ContatoViewModel contatoViewModel);
        ContatoViewModel AtualizarContato(ContatoViewModel contatoViewModel);
        ContatoViewModel ObterContatoPorId(int id);
        void RemoverContato(int id);
    }
}
