using MinhaAppMvcCompleta.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> ObterProdutoPorFornecedor(Guid fornecedorId);
        Task<IEnumerable<Produto>> ObterProdutoFornecedores();
        Task<Produto> ObterProdutoFornecedor(Guid id);
    }
}
