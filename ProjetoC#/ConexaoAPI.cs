using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json; // .NET 5+
using System.Text.Json;
using iText.Commons.Actions;
using Microsoft.Identity.Client;
using System.Configuration;

namespace ProjetoC_
{
    public class ConexaoAPI
    {
        // Método Exemplo
        public async Task CarregarDados(String query = "")
        {
            var dadosEnvio = new { query };

            using (HttpClient client = new HttpClient())
            {
                string url = Global.UrlApi;

                try
                {
                    var response = await client.PostAsJsonAsync(url, dadosEnvio);

                    if (response.IsSuccessStatusCode)
                    {
                        string jsonResposta = await response.Content.ReadAsStringAsync();
                        // Aqui você pode deserializar o JSON para uma DataTable ou Lista de Objetos
                        // Exemplo: var lista = JsonSerializer.Deserialize<List<MinhaClasse>>(jsonResposta);
                        MessageBox.Show("Dados recebidos: " + jsonResposta);
                    }
                    else
                    {
                        MessageBox.Show("Erro: " + response.ReasonPhrase);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro de conexão: " + ex.Message);
                }
            }
        }
    }

    public static class Global
    {
        public static string UrlApi
        {
            get
            {
                string url = ConfigurationManager.AppSettings["UrlApi"];
                url += "/api/database/executar";
                return string.IsNullOrEmpty(url) ? "http://localhost:5288/api/database/executar" : url;
            }
        }
    }
}