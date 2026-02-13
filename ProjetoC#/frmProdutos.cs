using ProjetoC_.Classes;
using ProjetoC_.Enums;
using ProjetoC_.Models;
using ProjetoC_.Service;
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
    public partial class frmProdutos : Form
    {
        private List<Produto> _listaProdutos;
        // Índice para controle de navegação, -1 indica que não há registro posicionado
        private int _indiceAtual = -1;
        private ModoTela _eModoAtual;

        public frmProdutos()
        {
            InitializeComponent();
            FuncoesUI.AdicionarSelecaoAoFoco(this);
        }

        private async void frmProdutos_Load(object sender, EventArgs e)
        {
            _listaProdutos = new List<Produto>();
            modoConsulta();

            try
            {
                ProdutoService produto = new ProdutoService();

                // Carrega os operadores usando o serviço
                _listaProdutos = await produto.CarregarProdutos();

                if (_listaProdutos.Count > 0)
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
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        private void frmProdutos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && _eModoAtual == ModoTela.Consulta)
            {
                e.Handled = true; // Evita o som de alerta
                modoInclusao();
            }
            if (e.KeyCode == Keys.F5 && _eModoAtual == ModoTela.Consulta)
            {
                e.Handled = true; // Evita o som de alerta
                modoAlteracao();
            }
            if (e.KeyCode == Keys.F3 &&
                (_eModoAtual == ModoTela.Alteracao ||
                _eModoAtual == ModoTela.Inclusao))
            {
                e.Handled = true; // Evita o som de alerta
                toolGravar_Click(sender, e); // Chama o método de gravação
            }
            if (e.KeyCode == Keys.Escape &&
                (_eModoAtual == ModoTela.Alteracao ||
                _eModoAtual == ModoTela.Inclusao))
            {
                e.Handled = true; // Evita o som de alerta
                toolDesfazer_Click(sender, e); // Chama o método de desfazer
            }
            else if (e.KeyCode == Keys.Escape && _eModoAtual == ModoTela.Consulta)
            {
                e.Handled = true; // Evita o som de alerta
                this.Close(); // Fecha o formulário
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
            btnListaProduto.Enabled = true;
            txtNome.Enabled = false;
            txtValor.Enabled = false;
            chkInativo.Enabled = false;

            txtCodigo.Focus();

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
            btnListaProduto.Enabled = false;
            txtNome.Enabled = true;
            txtNome.Text = "";
            txtValor.Enabled = true;
            txtValor.Text = "";
            chkInativo.Enabled = true;
            chkInativo.Checked = false;

            txtNome.Focus();

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
            btnListaProduto.Enabled = false;
            txtNome.Enabled = true;
            txtValor.Enabled = true;
            chkInativo.Enabled = true;

            txtNome.Focus();

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
                ProdutoService produtoService = new ProdutoService();
                Produto novoProduto = new Produto
                {
                    Nome = txtNome.Text.Trim(),
                    Valor = decimal.Parse(txtValor.Text.Trim()),
                    Inativo = chkInativo.Checked ? (byte)1 : (byte)0
                };
                

                if (int.TryParse(txtCodigo.Text, out int codigo))
                    novoProduto.Codigo = codigo;
                else
                    novoProduto.Codigo = 0; // Código 0 para novos registros, o banco deve gerar o código real
                
                int idGerado = 0;

                try
                {
                    if (_eModoAtual == ModoTela.Inclusao)
                    {
                        // 1. Use o await para esperar a gravação. 
                        idGerado = await produtoService.InserirProduto(novoProduto);

                        if (idGerado <= 0)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                    else
                    {
                        bool sucesso = await produtoService.AlterarProduto(novoProduto);

                        if (!sucesso)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar produto no banco: " + ex.Message);
                    return;
                }

                if (_eModoAtual == ModoTela.Alteracao)
                    _listaProdutos[_indiceAtual] = novoProduto; // Atualiza o registro existente
                else
                {
                    novoProduto.Codigo = idGerado;
                    _listaProdutos.Add(novoProduto); // Adiciona o novo registro
                    _indiceAtual = _listaProdutos.Count - 1; // Posiciona no novo registro
                }

                modoConsulta();
                preencherCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar produto: " + ex.Message);
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
                ProdutoService produtoService = new ProdutoService();
                bool sucesso = await produtoService.ExcluirProduto(codigo);

                if (!sucesso)
                {
                    MessageBox.Show("O banco de dados não confirmou a exclusão.");
                    return;
                }

                _listaProdutos.RemoveAt(_indiceAtual); // Remove da lista local
                toolProximo_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto do banco: " + ex.Message);
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
            if (_listaProdutos.Count > 0)
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
            if (_indiceAtual < _listaProdutos.Count - 1)
            {
                _indiceAtual++;
                preencherCampos();
            }
            else if (_indiceAtual == _listaProdutos.Count - 1)
            {
                _indiceAtual = _listaProdutos.Count - 1; // no caso de já estar no último, mantém o índice
                preencherCampos();
            }
        }
        private void toolUltimo_Click(object sender, EventArgs e)
        {
            if (_listaProdutos.Count > 0)
            {
                _indiceAtual = _listaProdutos.Count - 1;
                preencherCampos();
            }
        }

        private void preencherCampos()
        {
            if (_listaProdutos.Count > 0 && _indiceAtual >= 0 && _indiceAtual < _listaProdutos.Count)
            {
                var op = _listaProdutos[_indiceAtual];
                txtCodigo.Text = op.Codigo.ToString();
                txtNome.Text = op.Nome;
                txtValor.Text = op.Valor.ToString("F2");
                chkInativo.Checked = op.Inativo == 1;

                lblContagem.Text = $"{_indiceAtual + 1} de {_listaProdutos.Count}";
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
            txtValor.Text = "";
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

                int indiceEncontrado = _listaProdutos.FindIndex(op => op.Codigo == codigo);
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

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                e.Handled = true; // Evita o som de alerta
                btnListaProduto_Click(sender, e); // Chama o método de pesquisa
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                txtValor.Focus(); // Move o foco para o próximo campo
            }
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
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

            if (string.IsNullOrWhiteSpace(txtValor.Text))
            {
                throw new Exception("O campo Valor é obrigatório.");
            }

            if (!decimal.TryParse(txtValor.Text, out decimal valor))
            {
                throw new Exception("O campo Valor deve ser um número válido.");
            }
        }

        private async void btnListaProduto_Click(object sender, EventArgs e)
        {
            var listaPr = new List<Produto>();
            try
            {
                var service = new ProdutoService();
                listaPr = await service.CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar operadores para pesquisa: " + ex.Message);
                return;
            }
            // Convertemos a lista de Operadores para uma lista de Objetos
            var listaParaPesquisa = listaPr.Cast<object>().ToList();

            using (var frm = new frmListaPesquisa(listaParaPesquisa))
            {
                frm.Text = "Pesquisa de Produtos";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // converte de volta object para Produto(Cast)
                    var prSelecionado = (Produto)frm.ObjetoSelecionado;

                    // Sincroniza o índice
                    _listaProdutos = listaPr; // Atualiza a lista local com os dados mais recentes
                    _indiceAtual = _listaProdutos.FindIndex(x => x.Codigo == prSelecionado.Codigo);
                    preencherCampos();
                }
            }
        }
    }
}
