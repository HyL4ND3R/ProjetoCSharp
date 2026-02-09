using Microsoft.VisualBasic;
using ProjetoC_.Classes;
using ProjetoC_.Service;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json; // Para PostAsJsonAsync
using System.Text.Json;     // Para lidar com o JSON
using System.Threading.Tasks;
using System.Windows.Forms; // Se for WPF, remova isso

namespace ProjetoC_
{
    public partial class Login : Form
    {

        // Instancia o serviço
        private readonly DatabaseService _dbService;

        public Login()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            // 1. Validação Visual
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha usuário e senha.");
                return;
            }

            try
            {
                // 2. Prepara os dados (Apenas SQL e Parametros)
                string query = "SELECT Codigo, Nome FROM Operador WHERE Codigo = @Usuario AND Senha = @Senha";
                
                var parametros = new Dictionary<string, object>
                {
                    { "@Usuario", txtLogin.Text },
                    { "@Senha", txtSenha.Text }
                };

                // 3. UI: Feedback visual (opcional)
                btnEntrar.Enabled = false;
                btnEntrar.Text = "Verificando...";

                // 4. A Mágica: Uma única linha chama o serviço
                // Note o <Operador>: Isso diz ao serviço para devolver uma lista de Operadores
                List<Operador> resultado = await _dbService.ExecutarConsultaAsync<Operador>(query, parametros);

                // 5. Verifica o resultado
                if (resultado != null && resultado.Count > 0)
                {
                    var operador = resultado[0];
                    MessageBox.Show($"Bem-vindo, {operador.Nome}!");
                    
                    // this.Hide();
                    // new FormPrincipal().Show();
                }
                else
                {
                    MessageBox.Show("Usuário ou senha inválidos.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // Restaura o botão mesmo se der erro
                btnEntrar.Enabled = true;
                btnEntrar.Text = "Entrar";
            }
        }
    }
}
