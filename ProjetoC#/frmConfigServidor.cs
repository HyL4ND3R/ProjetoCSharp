using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace ProjetoC_
{
    public partial class frmConfigServidor : Form
    {
        public frmConfigServidor()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abre o arquivo de configuração do executável atual
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                // Remove a chave atual e adiciona a nova com o valor do TextBox
                config.AppSettings.Settings.Remove("UrlApi");
                config.AppSettings.Settings.Add("UrlApi", txtUrl.Text.Trim());

                // Salva as alterações fisicamente no arquivo .config
                config.Save(ConfigurationSaveMode.Modified);

                // Atualiza a seção em memória para que o sistema use o novo valor imediatamente
                ConfigurationManager.RefreshSection("appSettings");

                MessageBox.Show("Configuração salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao salvar configuração: " + ex.Message);
            }
        }

        private void frmConfigServidor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) {
                e.Handled = true;
                this.Close();
            }
        }

        private void txtUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {
                btnSalvar.Focus();
                e.SuppressKeyPress = true; // impede que o controle tente processar a tecla
                e.Handled = true; // Avisa que o evento foi tratado
            }
        }
    }
}
