using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json;
using ProjetoC_.Security;

namespace ProjetoC_.Service
{
    public class DatabaseService
    {
        // 1. Instância estática do HttpClient (Melhor prática para performance)
        private static readonly HttpClient _client = new HttpClient();
        private readonly string _urlApi;

        public DatabaseService()
        {
            // Idealmente, isso viria de um arquivo de configuração, mas por enquanto:
            _urlApi = "http://localhost:5288/api/database/executar";
        }

        // 2. Método Genérico <T>: Funciona para Operador, Produto, Cliente, etc.
        public async Task<List<T>> ExecutarConsultaAsync<T>(string query, Dictionary<string, object> parametros = null)
        {
            try
            {

                string queryCriptografada = Criptografia.Criptografar(query);

                // Monta o objeto que a API espera
                var pacoteEnvio = new
                {
                    Query = queryCriptografada, // Certifique-se que o nome bate com a API (Query ou SqlQuery)
                    Parametros = parametros ?? new Dictionary<string, object>()
                };

                // Envia
                var response = await _client.PostAsJsonAsync(_urlApi, pacoteEnvio);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResposta = await response.Content.ReadAsStringAsync();

                    // Configuração para ignorar maiúsculas/minúsculas (ex: CODIGO vs Codigo)
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };

                    // Transforma o JSON na lista do tipo T (ex: List<Operador>)
                    return JsonSerializer.Deserialize<List<T>>(jsonResposta, options);
                }
                else
                {
                    // Você pode optar por lançar erro ou retornar null
                    var erroMsg = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Erro na API ({response.StatusCode}): {erroMsg}");
                }
            }
            catch (Exception ex)
            {
                // Repassa o erro para quem chamou tratar (ex: mostrar MessageBox)
                throw new Exception($"Falha na comunicação: {ex.Message}");
            }
        }
    }
}
