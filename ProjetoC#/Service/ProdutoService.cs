using ProjetoC_.Classes;
using ProjetoC_.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Service
{
    internal class ProdutoService
    {

        private readonly DatabaseService _dbService = new DatabaseService();

        public async Task<List<Produto>> CarregarProdutos()
        {
            String query = "Select * from Produto Order By Codigo Asc";
            var parametros = new Dictionary<string, object>();

            List<Produto> resultado = await _dbService.ExecutarConsultaAsync<Produto>(query, parametros);

            return resultado;
        }

        public async Task<Produto> BuscarProdutoPorCodigo(int codigo)
        {

            String query = "Select * from Produto Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>()
            {
                {"@Codigo",codigo}
            };

            List<Produto> resultado = await _dbService.ExecutarConsultaAsync<Produto>(query, parametros);

            return resultado[0];
        }

        public async Task<int> InserirProduto(Produto produto)
        {
            String query = "Insert into Produto (Nome, Valor, Inativo) Values (@Nome, @Valor, @Inativo)";
            var parametros = new Dictionary<string, object>
            {
                { "@Nome", produto.Nome},
                { "@Valor", produto.Valor},
                { "@Inativo", produto.Inativo}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null ? resultado.NovoId : 0;
        }
        public async Task<bool> AlterarProduto(Produto produto)
        {
            String query = "UPDATE Produto Set Nome = @Nome, Valor = @Valor, Inativo = @Inativo " +
                    "Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>
            {
                { "@Nome", produto.Nome},
                { "@Valor", produto.Valor},
                { "@Inativo", produto.Inativo},
                { "@Codigo", produto.Codigo}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }

        public async Task<bool> ExcluirProduto(int codigo)
        {
            String query = "Delete from Produto Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>
            {
                { "@Codigo", codigo }
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }
    }
}
