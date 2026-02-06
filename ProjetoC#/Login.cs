using Microsoft.VisualBasic;
using System.Net.Http;
using System.Net.Http.Json; // Para PostAsJsonAsync
using System.Text.Json;     // Para lidar com o JSON
using System.Threading.Tasks;
using System.Windows.Forms; // Se for WPF, remova isso
using System.Collections.Generic;

namespace ProjetoC_
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            // 1. Validar se digitou algo
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha usuário e senha.");
                return;
            }

            // 1. Observe que usamos @Usuario e @Senha no lugar dos valores reais
            string sqlSegura = "SELECT Id, Nome FROM Usuarios WHERE Login = @Usuario AND Senha = @Senha";

            // 2. Criamos o pacote com os parâmetros separados
            var pacoteEnvio = new
            {
                sqlQuery = sqlSegura,
                parametros = new Dictionary<string, object>
        {
            { "@Usuario", txtLogin.Text }, // O valor real vai aqui
            { "@Senha", txtSenha.Text }    // O valor real vai aqui
        }
            };

            using (HttpClient client = new HttpClient())
            {
                string urlApi = "http://localhost:5000/api/database/executar";

                // O envio continua igual
                var response = await client.PostAsJsonAsync(urlApi, pacoteEnvio);

                // ... resto do código de tratamento da resposta
            }
        }
    }
}
