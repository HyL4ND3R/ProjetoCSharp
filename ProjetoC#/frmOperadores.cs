using ProjetoC_.Classes;
using ProjetoC_.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoC_
{
    public partial class frmOperadores : Form
    {

        private List<Operador> _listaOperadores;
        // Índice para controle de navegação, -1 indica que não há registro posicionado
        private int _indiceAtual = -1;

        public frmOperadores()
        {
            InitializeComponent();
        }

        private async void frmOperadores_Load(object sender, EventArgs e)
        {
            modoConsulta();

            try
            {
                OperadorService operador = new OperadorService();

                // Carrega os operadores usando o serviço
                _listaOperadores = await operador.CarregarOperadores();

                if (_listaOperadores.Count > 0)
                {
                    _indiceAtual = 0;
                    preencherCampos();
                }
                else
                {
                    limparCampos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar operadores: " + ex.Message);
            }
        }

        private void modoConsulta()
        {
            toolNovo.Enabled = true;
            toolGravar.Enabled = false;
            toolAlterar.Enabled = true;
            toolExcluir.Enabled = true;
            toolDesfazer.Enabled = false;
            toolPrimeiro.Enabled = true;
            toolAnterior.Enabled = true;
            toolProximo.Enabled = true;
            toolUltimo.Enabled = true;

            txtCodigo.Enabled = true;
            btnListaOperador.Enabled = true;
            txtNome.Enabled = false;
            txtSenha.Enabled = false;
            chkAdmin.Enabled = false;
            chkInativo.Enabled = false;
        }

        private void modoInclusao()
        {
            toolNovo.Enabled = false;
            toolGravar.Enabled = true;
            toolAlterar.Enabled = false;
            toolExcluir.Enabled = false;
            toolDesfazer.Enabled = true;
            toolPrimeiro.Enabled = false;
            toolAnterior.Enabled = false;
            toolProximo.Enabled = false;
            toolUltimo.Enabled = false;

            txtCodigo.Enabled = false;
            txtCodigo.Text = "";
            btnListaOperador.Enabled = false;
            txtNome.Enabled = true;
            txtNome.Text = "";
            txtSenha.Enabled = true;
            txtSenha.Text = "";
            chkAdmin.Enabled = true;
            chkAdmin.Checked = false;
            chkInativo.Enabled = true;
            chkInativo.Checked = false;
        }

        private void modoAlteracao()
        {
            toolNovo.Enabled = false;
            toolGravar.Enabled = true;
            toolAlterar.Enabled = false;
            toolExcluir.Enabled = false;
            toolDesfazer.Enabled = true;
            toolPrimeiro.Enabled = false;
            toolAnterior.Enabled = false;
            toolProximo.Enabled = false;
            toolUltimo.Enabled = false;

            txtCodigo.Enabled = false;
            btnListaOperador.Enabled = false;
            txtNome.Enabled = true;
            txtSenha.Enabled = true;
            chkAdmin.Enabled = true;
            chkInativo.Enabled = true;
        }

        private void toolNovo_Click(object sender, EventArgs e)
        {
            modoInclusao();
        }
        private void toolGravar_Click(object sender, EventArgs e)
        {
            
        }
        private void toolAlterar_Click(object sender, EventArgs e)
        {
            modoAlteracao();
        }
        private void toolExcluir_Click(object sender, EventArgs e)
        {
            
        }
        private void toolDesfazer_Click(object sender, EventArgs e)
        {
            modoConsulta();
        }

        private void preencherCampos()
        {
            if (_listaOperadores.Count > 0 && _indiceAtual >= 0 && _indiceAtual < _listaOperadores.Count)
            {
                var op = _listaOperadores[_indiceAtual];
                txtCodigo.Text = op.Codigo.ToString();
                txtNome.Text = op.Nome;
                txtSenha.Text = op.Senha;
                chkAdmin.Checked = op.Admin == 1;
                chkInativo.Checked = op.Inativo == 1;

                lblContagem.Text = $"{_indiceAtual + 1} de {_listaOperadores.Count}";
            }
            else
            {
                limparCampos();
            }
        }

        private void limparCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtSenha.Text = "";
            chkAdmin.Checked = false;
            chkInativo.Checked = false;
            lblContagem.Text = "0 de 0";
        }

        private void toolPrimeiro_Click(object sender, EventArgs e)
        {
            if (_listaOperadores.Count > 0)
            {
                _indiceAtual = 0;
                preencherCampos();
            }
        }

        private void toolAnterior_Click(object sender, EventArgs e)
        {
            if (_indiceAtual > 0)
            {
                _indiceAtual--;
                preencherCampos();
            }
        }

        private void toolProximo_Click(object sender, EventArgs e)
        {
            if (_indiceAtual < _listaOperadores.Count - 1)
            {
                _indiceAtual++;
                preencherCampos();
            }
        }

        private void toolUltimo_Click(object sender, EventArgs e)
        {
            if (_listaOperadores.Count > 0)
            {
                _indiceAtual = _listaOperadores.Count - 1;
                preencherCampos();
            }
        }
    }
}