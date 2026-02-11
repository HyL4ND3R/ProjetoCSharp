using ProjetoC_.Classes;
using ProjetoC_.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Service
{
    public class OperadorService
    {

        private readonly DatabaseService _dbService = new DatabaseService();

        public async Task<List<Operador>> CarregarOperadores()
        {

            String query = "Select * from Operador Order By Codigo Asc";
            var parametros = new Dictionary<string, object>();

            List<Operador> resultado = await _dbService.ExecutarConsultaAsync<Operador>(query, parametros);

            return resultado;
        }

        public async Task<Operador> BuscarOperadorPorCodigo(int codigo)
        {

            String query = "Select * from Operador Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>()
            {
                {"@Codigo",codigo}
            };

            List<Operador> resultado = await _dbService.ExecutarConsultaAsync<Operador>(query, parametros);

            return resultado[0];
        }

        public async Task<int> InserirOperador(Operador operador)
        {
            String query = "Insert into Operador (Nome, Senha, Admin, Inativo) Values (@Nome, @Senha, @Admin, @Inativo)";
            var parametros = new Dictionary<string, object>
            {
                { "@Nome", operador.Nome },
                { "@Senha", operador.Senha },
                { "@Admin", operador.Admin},
                { "@Inativo", operador.Inativo}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null ? resultado.NovoId : 0;
        }
        public async Task<bool> AlterarOperador(Operador operador)
        {
            String query = "UPDATE Operador Set Nome = @Nome, Senha = @Senha, Admin = @Admin, Inativo = @Inativo " +
                    "Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>
            {
                { "@Nome", operador.Nome },
                { "@Senha", operador.Senha },
                { "@Admin", operador.Admin},
                { "@Inativo", operador.Inativo},
                { "@Codigo", operador.Codigo}
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }

        public async Task<bool> ExcluirOperador(int codigo)
        {
            String query = "Delete from Operador Where Codigo = @Codigo";
            var parametros = new Dictionary<string, object>
            {
                { "@Codigo", codigo }
            };
            var resultado = await _dbService.ExecutarComandoAsync<RespostaComando>(query, parametros);

            return resultado != null && resultado.LinhasAfetadas > 0;
        }
    }
}