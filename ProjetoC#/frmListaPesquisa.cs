using ProjetoC_.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoC_
{
    public partial class frmListaPesquisa : Form
    {
        public object ObjetoSelecionado { get; private set; }
        private List<object> _listaPesquisa;

        public frmListaPesquisa(List<object> lista)
        {
            InitializeComponent();
            FuncoesUI.AdicionarSelecaoAoFoco(this);
            _listaPesquisa = lista;
            dgvListaPesquisa.DataSource = _listaPesquisa;
            ConfigurarGrade();
            txtFiltro.Focus();
        }

        private void ConfigurarGrade()
        {
            dgvListaPesquisa.ReadOnly = true;
            dgvListaPesquisa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListaPesquisa.MultiSelect = false;
            dgvListaPesquisa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvListaPesquisa.Columns.Contains("Senha"))
                dgvListaPesquisa.Columns["Senha"].Visible = false;

            if (dgvListaPesquisa.Columns.Contains("Admin"))
                dgvListaPesquisa.Columns["Admin"].HeaderText = "Adminstrador";

            if (dgvListaPesquisa.Columns.Contains("Controle"))
                dgvListaPesquisa.Columns["Controle"].Visible = false; 

            dgvListaPesquisa.CellFormatting += dgvListaPesquisa_CellFormatting;
        }

        private void dgvListaPesquisa_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string nomeColuna = dgvListaPesquisa.Columns[e.ColumnIndex].Name;

            if (nomeColuna == "Admin" || nomeColuna == "Inativo")
            {
                if (e.Value != null)
                {
                    string valor = e.Value.ToString();
                    e.Value = (valor == "1") ? "Sim" : "Não";
                    e.FormattingApplied = true;
                }
            }
        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            if (dgvListaPesquisa.SelectedRows.Count > 0)
            {
                // Pega o objeto que está vinculado à linha selecionada no momento
                ObjetoSelecionado = dgvListaPesquisa.CurrentRow.DataBoundItem;
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Selecione um item da lista.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void dgvListaPesquisa_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int index = e.RowIndex;
                ObjetoSelecionado = _listaPesquisa[index];
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtFiltro.Text.ToLower();
            var listaFiltrada = _listaPesquisa.FindAll(item => item.ToString().ToLower().Contains(filtro));
            dgvListaPesquisa.DataSource = listaFiltrada;
        }

        private void frmListaPesquisa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                btnSelecionar_Click(sender, e);
            }
            else if (e.KeyCode == Keys.Escape)
            {
                e.Handled = true;
                btnCancelar_Click(sender, e);
            }
        }
    }
}