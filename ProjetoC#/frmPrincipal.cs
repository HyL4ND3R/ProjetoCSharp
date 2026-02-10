using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoC_
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        // Método genérico para abrir qualquer formulário dentro do pai
        private void AbrirFormFilho<T>() where T : Form, new()
        {
            // Verifica se o formulário já está aberto
            Form fh = Application.OpenForms.OfType<T>().FirstOrDefault();

            if (fh == null)
            {
                // Se não estiver aberto, cria uma nova instância
                fh = new T();
                fh.MdiParent = this; // Define este FormPrincipal como o 'Pai'
                fh.FormBorderStyle = FormBorderStyle.None; // Remove as bordas
                fh.Dock = DockStyle.Fill; // Faz ele preencher todo o fundo cinza
                fh.Show();
            }
            else
            {
                // Se já estiver aberto, apenas traz para a frente
                fh.BringToFront();
            }
        }

        private void menuOperadores_Click(object sender, EventArgs e)
        {
            AbrirFormFilho<frmOperadores>();
        }
    }
}