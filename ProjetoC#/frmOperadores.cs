using ProjetoC_.Classes;
using ProjetoC_.Enums;
using ProjetoC_.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace ProjetoC_
{
    public partial class frmOperadores : Form
    {

        private List<Operador> _listaOperadores;
        // Índice para controle de navegação, -1 indica que não há registro posicionado
        private int _indiceAtual = -1;
        private ModoTela _eModoAtual;

        public frmOperadores()
        {
            InitializeComponent();
        }

        private async void frmOperadores_Load(object sender, EventArgs e)
        {
            _listaOperadores = new List<Operador>();
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

            _eModoAtual = ModoTela.Consulta;
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

            _eModoAtual = ModoTela.Inclusao;
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

            _eModoAtual = ModoTela.Alteracao;
        }

        private void toolNovo_Click(object sender, EventArgs e)
        {
            modoInclusao();
        }
        private async void toolGravar_Click(object sender, EventArgs e)
        {
            try
            {
                validaCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message);
                return;
            }

            try
            {
                OperadorService operadorService = new OperadorService();
                Operador novoOperador = new Operador
                {
                    Nome = txtNome.Text.Trim(),
                    Senha = txtSenha.Text.Trim(),
                    Admin = chkAdmin.Checked ? (byte)1 : (byte)0,
                    Inativo = chkInativo.Checked ? (byte)1 : (byte)0
                };
                int idGerado = 0;

                if (int.TryParse(txtCodigo.Text, out int codigo))
                    novoOperador.Codigo = codigo;
                else
                    novoOperador.Codigo = 0; // Código 0 para novos registros, o banco deve gerar o código real

                try
                {
                    if (_eModoAtual == ModoTela.Inclusao)
                    {
                        // 1. Use o await para esperar a gravação. 
                        idGerado = await operadorService.InserirOperador(novoOperador);

                        if (idGerado <= 0)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                    else
                    {
                        bool sucesso = await operadorService.AlterarOperador(novoOperador);

                        if (!sucesso)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar operador no banco: " + ex.Message);
                    return;
                }

                if (_eModoAtual == ModoTela.Alteracao)
                    _listaOperadores[_indiceAtual] = novoOperador; // Atualiza o registro existente
                else
                {
                    novoOperador.Codigo = idGerado;
                    _listaOperadores.Add(novoOperador); // Adiciona o novo registro
                    _indiceAtual = _listaOperadores.Count - 1; // Posiciona no novo registro
                }

                modoConsulta();
                preencherCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar operador: " + ex.Message);
            }

        }
        private void toolAlterar_Click(object sender, EventArgs e)
        {
            modoAlteracao();
        }
        private async void toolExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma a exclusão do registro?",
                "Confirmação",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            if (!int.TryParse(txtCodigo.Text, out int codigo))
            {
                MessageBox.Show("Código inválido para exclusão.");
                return;
            }

            try
            {
                OperadorService operadorService = new OperadorService();
                bool sucesso = await operadorService.ExcluirOperador(codigo);

                if (!sucesso)
                {
                    MessageBox.Show("O banco de dados não confirmou a exclusão.");
                    return;
                }

                _listaOperadores.RemoveAt(_indiceAtual); // Remove da lista local
                toolProximo_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir operador do banco: " + ex.Message);
                return;
            }
        }
        private void toolDesfazer_Click(object sender, EventArgs e)
        {
            modoConsulta();
            preencherCampos();
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
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere
            }

            if (_eModoAtual == ModoTela.Consulta && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                if (!int.TryParse(txtCodigo.Text, out int codigo))
                {
                    MessageBox.Show("Código inválido.");
                    txtCodigo.Focus();
                    return;
                }

                int indiceEncontrado = _listaOperadores.FindIndex(op => op.Codigo == codigo);
                if (indiceEncontrado >= 0)
                {
                    _indiceAtual = indiceEncontrado;
                    preencherCampos();
                }
                else
                {
                    MessageBox.Show("Código não encontrado.");
                    txtCodigo.Focus();
                }
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                txtSenha.Focus(); // Move o foco para o próximo campo
            }
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                if (MessageBox.Show("Confirma Gravação?",
                    "Confirmação",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    toolGravar_Click(sender, e); // Chama o método de gravação
                }
            }
        }

        private void validaCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                throw new Exception("O campo Nome é obrigatório.");
            }

            if (String.IsNullOrWhiteSpace(txtSenha.Text.Trim()))
            {
                throw new Exception("O campo Senha é obrigatório.");
            }
        }

        private async void btnListaOperador_Click(object sender, EventArgs e)
        {
            var listaOp = new List<Operador>();
            try
            {
                var service = new OperadorService();
                listaOp = await service.CarregarOperadores();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar operadores para pesquisa: " + ex.Message);
                return;
            }
            // Convertemos a lista de Operadores para uma lista de Objetos
            var listaParaPesquisa = listaOp.Cast<object>().ToList();

            using (var frm = new frmListaPesquisa(listaParaPesquisa))
            {
                frm.Text = "Pesquisa de Operadores";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // Aqui você converte de volta (Cast)
                    var opSelecionado = (Operador)frm.ObjetoSelecionado;

                    // Sincroniza o índice
                    _listaOperadores = listaOp; // Atualiza a lista local com os dados mais recentes
                    _indiceAtual = _listaOperadores.FindIndex(x => x.Codigo == opSelecionado.Codigo);
                    preencherCampos();
                }
            }
        }
    }
}