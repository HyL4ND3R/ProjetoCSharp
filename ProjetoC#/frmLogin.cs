using Microsoft.VisualBasic;
using ProjetoC_.Classes;
using ProjetoC_.Service;
using ProjetoC_.Utils;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json; // Para PostAsJsonAsync
using System.Text.Json;     // Para lidar com o JSON
using System.Threading.Tasks;
using System.Windows.Forms; // Se for WPF, remova isso

namespace ProjetoC_
{
    public partial class frmLogin : Form
    {

        // Instancia o serviço
        private readonly DatabaseService _dbService;
        public static Operador operadorLogado { get; private set; } = null;

        public frmLogin()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            FuncoesUI.AdicionarSelecaoAoFoco(this);
        }

        private async void btnEntrar_Click(object sender, EventArgs e)
        {
            // 1. Validação Visual
            if (string.IsNullOrWhiteSpace(txtLogin.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
            {
                MessageBox.Show("Preencha usuário e senha.");
                return;
            }
            else if (int.TryParse(txtLogin.Text, out int codigo) == false)
            {
                MessageBox.Show("Login Inválido.");
                return;
            }

            try
            {
                // 2. Prepara os dados (Apenas SQL e Parametros)
                string query = "SELECT Codigo, Nome FROM Operador WHERE Codigo = @Usuario AND Senha = @Senha";

                var parametros = new Dictionary<string, object>
                {
                    { "@Usuario", int.Parse(txtLogin.Text) },
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
                    this.Hide(); // Esconde o login
                    frmPrincipal principal = new frmPrincipal();
                    principal.ShowDialog(); // Abre o principal
                    this.Close(); // Fecha o login de vez ao sair do principal
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

        private void txtLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite apenas números e controle (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora a tecla pressionada
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtSenha.Focus(); // Move o foco para a senha
                e.Handled = true; // Evita o som de "beep"
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnEntrar.Focus(); // Move o foco para a senha
                e.Handled = true; // Evita o som de "beep"
            }
        }
    }
}
