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
    public partial class frmPedidos : Form
    {
        private List<Pedido> _listaPedidos;
        private List<PedidoItem> _listaItensPedido;
        // Índice para controle de navegação, -1 indica que não há registro posicionado
        private int _indiceAtual = -1;
        private eModoTela _eModoAtualPedido;
        private eModoTela _eModoAtualItem;

        public frmPedidos()
        {
            InitializeComponent();
            FuncoesUI.AdicionarSelecaoAoFoco(this);
            FuncoesUI.AplicarMascaraMoeda(txtProdutoQtde);
            FuncoesUI.AplicarMascaraMoeda(txtProdutoValorUn);
            FuncoesUI.AplicarMascaraMoeda(txtProdutoValorTotal);
            FuncoesUI.AplicarMascaraMoeda(txtValorTotal);
        }

        private async void frmProdutos_Load(object sender, EventArgs e)
        {
            _listaPedidos = new List<Pedido>();
            modoConsultaPedido();

            try
            {
                PedidoService pedido = new PedidoService();

                // Carrega os operadores usando o serviço
                _listaPedidos = await pedido.CarregarPedidos();

                if (_listaPedidos.Count > 0)
                {
                    _indiceAtual = _listaPedidos.Count - 1;
                    preencherCampos();
                }
                else
                {
                    limparCamposPedido();
                    limparCamposItens();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar pedidos: " + ex.Message);
            }
        }

        private void frmPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            // Bloqueio global
            if (_eModoAtualPedido == eModoTela.Bloqueado) return;

            switch (e.KeyCode)
            {
                case Keys.F2:// Novo Pedido
                    if (_eModoAtualPedido == eModoTela.Consulta)
                    {
                        e.Handled = true;
                        modoInclusaoPedido();
                    }
                    break;

                case Keys.F5:// Alterar Pedido
                    if (_eModoAtualPedido == eModoTela.Consulta)
                    {
                        e.Handled = true;
                        modoAlteracaoPedido();
                    }
                    break;

                case Keys.F3:// Gravar Pedido
                    if (_eModoAtualPedido == eModoTela.Alteracao || _eModoAtualPedido == eModoTela.Inclusao)
                    {
                        e.Handled = true;
                        toolGravar_Click(sender, e);
                    }
                    break;

                case Keys.Escape:// Desfazer ou Fechar
                    e.Handled = true;
                    if (_eModoAtualPedido == eModoTela.Alteracao || _eModoAtualPedido == eModoTela.Inclusao)
                    {
                        toolDesfazer_Click(sender, e);
                    }
                    else if (_eModoAtualPedido == eModoTela.Consulta)
                    {
                        this.Close();
                    }
                    break;
            }
        }

        private void modoConsultaPedido()
        {
            // Tools
            toolNovo.Enabled = true;
            toolGravar.Enabled = false;
            toolAlterar.Enabled = true;
            toolExcluir.Enabled = true;
            toolDesfazer.Enabled = false;
            toolPrimeiro.Enabled = true;
            toolAnterior.Enabled = true;
            toolProximo.Enabled = true;
            toolUltimo.Enabled = true;

            // Campos Pedido
            txtCodigo.Enabled = true;
            btnListaPedido.Enabled = true;
            txtCodCliente.Enabled = false;
            btnListaCliente.Enabled = false;
            txtNomeCliente.Enabled = false;
            dtpDataPedido.Enabled = false;

            // Botões itens
            btnNovoItem.Enabled = true;
            btnSalvarItem.Enabled = false;
            btnAlterarItem.Enabled = true;
            btnExcluirItem.Enabled = true;
            btnCancelar.Enabled = false;

            // Campos itens
            txtProdutoCod.Enabled = false;
            btnListaProduto.Enabled = false;
            txtProdutoNome.Enabled = false;
            txtProdutoQtde.Enabled = false;
            txtProdutoValorUn.Enabled = false;
            txtProdutoValorTotal.Enabled = false;

            txtCodigo.Focus();

            _eModoAtualPedido = eModoTela.Consulta;
            _eModoAtualItem = eModoTela.Consulta;
        }

        private void modoInclusaoPedido()
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

            // Campos Pedido
            txtCodigo.Enabled = false;
            //ver aqui para puxar o próximo código disponível
            btnListaPedido.Enabled = false;
            txtCodCliente.Enabled = true;
            txtCodCliente.Text = "";
            btnListaCliente.Enabled = true;
            txtNomeCliente.Enabled = true;
            txtNomeCliente.Text = "";
            dtpDataPedido.Enabled = false;
            dtpDataPedido.Value = DateTime.Now;

            // Botões itens
            btnNovoItem.Enabled = false;
            btnSalvarItem.Enabled = false;
            btnAlterarItem.Enabled = false;
            btnExcluirItem.Enabled = false;
            btnCancelar.Enabled = false;

            // Campos itens
            txtProdutoCod.Enabled = false;
            btnListaProduto.Enabled = false;
            txtProdutoNome.Enabled = false;
            txtProdutoQtde.Enabled = false;
            txtProdutoValorUn.Enabled = false;
            txtProdutoValorTotal.Enabled = false;

            txtProdutoNome.Focus();

            _eModoAtualPedido = eModoTela.Inclusao;
            _eModoAtualItem = eModoTela.Bloqueado;
        }

        private void modoAlteracaoPedido()
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

            // Campos Pedido
            txtCodigo.Enabled = false;
            //ver aqui para puxar o próximo código disponível
            btnListaPedido.Enabled = false;
            txtCodCliente.Enabled = true;
            btnListaCliente.Enabled = true;
            txtNomeCliente.Enabled = true;
            dtpDataPedido.Enabled = false;

            // Botões itens
            btnNovoItem.Enabled = false;
            btnSalvarItem.Enabled = false;
            btnAlterarItem.Enabled = false;
            btnExcluirItem.Enabled = false;
            btnCancelar.Enabled = false;

            // Campos itens
            txtProdutoCod.Enabled = false;
            btnListaProduto.Enabled = false;
            txtProdutoNome.Enabled = false;
            txtProdutoQtde.Enabled = false;
            txtProdutoValorUn.Enabled = false;
            txtProdutoValorTotal.Enabled = false;

            txtProdutoNome.Focus();

            _eModoAtualPedido = eModoTela.Alteracao;
            _eModoAtualItem = eModoTela.Bloqueado;
        }
        private void modoInclusaoItem()
        {
            toolNovo.Enabled = false;
            toolGravar.Enabled = false;
            toolAlterar.Enabled = false;
            toolExcluir.Enabled = false;
            toolDesfazer.Enabled = false;
            toolPrimeiro.Enabled = false;
            toolAnterior.Enabled = false;
            toolProximo.Enabled = false;
            toolUltimo.Enabled = false;

            // Campos Pedido
            txtCodigo.Enabled = false;
            btnListaPedido.Enabled = false;
            txtCodCliente.Enabled = false;
            btnListaCliente.Enabled = false;
            txtNomeCliente.Enabled = false;
            dtpDataPedido.Enabled = false;

            // Botões itens
            btnNovoItem.Enabled = false;
            btnSalvarItem.Enabled = true;
            btnAlterarItem.Enabled = false;
            btnExcluirItem.Enabled = false;
            btnCancelar.Enabled = true;

            // Campos itens
            txtProdutoCod.Enabled = true;
            txtProdutoNome.Text = "";
            btnListaProduto.Enabled = true;
            txtProdutoNome.Enabled = true;
            txtProdutoNome.Text = "";
            txtProdutoQtde.Enabled = true;
            txtProdutoQtde.Text = "";
            txtProdutoValorUn.Enabled = false;
            txtProdutoValorUn.Text = "";
            txtProdutoValorTotal.Enabled = false;
            txtProdutoValorTotal.Text = "";

            txtProdutoCod.Focus();

            _eModoAtualPedido = eModoTela.Bloqueado;
            _eModoAtualItem = eModoTela.Inclusao;
        }
        private void modoAlteracaoItem()
        {
            toolNovo.Enabled = false;
            toolGravar.Enabled = false;
            toolAlterar.Enabled = false;
            toolExcluir.Enabled = false;
            toolDesfazer.Enabled = false;
            toolPrimeiro.Enabled = false;
            toolAnterior.Enabled = false;
            toolProximo.Enabled = false;
            toolUltimo.Enabled = false;

            // Campos Pedido
            txtCodigo.Enabled = false;
            btnListaPedido.Enabled = false;
            txtCodCliente.Enabled = false;
            btnListaCliente.Enabled = false;
            txtNomeCliente.Enabled = false;
            dtpDataPedido.Enabled = false;

            // Botões itens
            btnNovoItem.Enabled = false;
            btnSalvarItem.Enabled = true;
            btnAlterarItem.Enabled = false;
            btnExcluirItem.Enabled = false;
            btnCancelar.Enabled = true;

            // Campos itens
            txtProdutoCod.Enabled = true;
            btnListaProduto.Enabled = true;
            txtProdutoNome.Enabled = true;
            txtProdutoQtde.Enabled = true;
            txtProdutoValorUn.Enabled = false;
            txtProdutoValorTotal.Enabled = false;

            txtProdutoCod.Focus();

            _eModoAtualPedido = eModoTela.Bloqueado;
            _eModoAtualItem = eModoTela.Alteracao;
        }
        private void cancelarItem()
        {
            // Tools
            toolNovo.Enabled = true;
            toolGravar.Enabled = false;
            toolAlterar.Enabled = true;
            toolExcluir.Enabled = true;
            toolDesfazer.Enabled = false;
            toolPrimeiro.Enabled = true;
            toolAnterior.Enabled = true;
            toolProximo.Enabled = true;
            toolUltimo.Enabled = true;

            // Campos Pedido
            txtCodigo.Enabled = true;
            btnListaPedido.Enabled = true;
            txtCodCliente.Enabled = false;
            btnListaCliente.Enabled = false;
            txtNomeCliente.Enabled = false;
            dtpDataPedido.Enabled = false;

            // Botões itens
            btnNovoItem.Enabled = true;
            btnSalvarItem.Enabled = false;
            btnAlterarItem.Enabled = true;
            btnExcluirItem.Enabled = true;
            btnCancelar.Enabled = false;

            // Campos itens
            txtProdutoCod.Enabled = false;
            btnListaProduto.Enabled = false;
            txtProdutoNome.Enabled = false;
            txtProdutoQtde.Enabled = false;
            txtProdutoValorUn.Enabled = false;
            txtProdutoValorTotal.Enabled = false;

            preencherCamposItens();

            _eModoAtualPedido = eModoTela.Consulta;
            _eModoAtualItem = eModoTela.Consulta;
        }

        private void toolNovo_Click(object sender, EventArgs e)
        {
            modoInclusaoPedido();
        }
        private async void toolGravar_Click(object sender, EventArgs e)
        {
            try
            {
                validaCamposPedido();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message);
                return;
            }

            try
            {
                PedidoService PedidoService = new PedidoService();
                Pedido novoPedido = new Pedido
                {
                    Codigo = int.Parse(txtCodigo.Text),
                    ClienteCodigo = int.Parse(txtCodCliente.Text),
                    ClienteNome = txtNomeCliente.Text,
                    DataPedido = dtpDataPedido.Value
                };

                int idGerado = 0;

                try
                {
                    if (_eModoAtualPedido == eModoTela.Inclusao)
                    {
                        novoPedido.Controle = _listaPedidos[_indiceAtual].Controle;
                        // 1. Use o await para esperar a gravação. 
                        idGerado = await PedidoService.InserirPedido(novoPedido);

                        if (idGerado <= 0)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                    else
                    {
                        bool sucesso = await PedidoService.AlterarPedido(novoPedido);

                        if (!sucesso)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar pedido no banco: " + ex.Message);
                    return;
                }

                if (_eModoAtualPedido == eModoTela.Alteracao)
                    _listaPedidos[_indiceAtual] = novoPedido; // Atualiza o registro existente
                else
                {
                    novoPedido.Controle = idGerado;
                    _listaPedidos.Add(novoPedido); // Adiciona o novo registro
                    _indiceAtual = _listaPedidos.Count - 1; // Posiciona no novo registro
                }

                modoConsultaPedido();
                preencherCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar pedido: " + ex.Message);
            }

        }
        private void toolAlterar_Click(object sender, EventArgs e)
        {
            modoAlteracaoPedido();
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
                int controle = _listaPedidos[_indiceAtual].Controle; // Pega o controle do pedido atual para exclusão
                PedidoService PedidoService = new PedidoService();
                bool sucesso = await PedidoService.ExcluirPedido(controle);

                if (!sucesso)
                {
                    MessageBox.Show("O banco de dados não confirmou a exclusão.");
                    return;
                }

                _listaPedidos.RemoveAt(_indiceAtual); // Remove da lista local
                toolProximo_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir pedido do banco: " + ex.Message);
                return;
            }
        }
        private void toolDesfazer_Click(object sender, EventArgs e)
        {
            modoConsultaPedido();
            preencherCampos();
        }
        private void toolPrimeiro_Click(object sender, EventArgs e)
        {
            if (_listaPedidos.Count > 0)
            {
                _indiceAtual = 0;
                preencherCampos();
                preencherItensPedido();
            }
        }
        private void toolAnterior_Click(object sender, EventArgs e)
        {
            if (_indiceAtual > 0)
            {
                _indiceAtual--;
                preencherCampos();
                preencherItensPedido();
            }
        }
        private void toolProximo_Click(object sender, EventArgs e)
        {
            if (_indiceAtual < _listaPedidos.Count - 1)
            {
                _indiceAtual++;
                preencherCampos();
                preencherItensPedido();
            }
            else if (_indiceAtual > _listaPedidos.Count - 1)
            {
                _indiceAtual = _listaPedidos.Count - 1; // no caso de já estar no último, mantém o índice
                preencherCampos();
                preencherItensPedido();
            }
        }
        private void toolUltimo_Click(object sender, EventArgs e)
        {
            if (_listaPedidos.Count > 0)
            {
                _indiceAtual = _listaPedidos.Count - 1;
                preencherCampos();
                preencherItensPedido();
            }
        }

        private async void preencherCampos()
        {
            if (_listaPedidos.Count > 0 && _indiceAtual >= 0 && _indiceAtual < _listaPedidos.Count)
            {
                var obj = _listaPedidos[_indiceAtual];
                txtCodigo.Text = obj.Codigo.ToString();
                txtCodCliente.Text = obj.ClienteCodigo.ToString();
                txtNomeCliente.Text = obj.ClienteNome;
                dtpDataPedido.Value = obj.DataPedido;
                txtValorTotal.Text = obj.ValorTotal.ToString("F2");

                lblContagem.Text = $"{_indiceAtual + 1} de {_listaPedidos.Count}";
            }
            else
            {
                limparCamposPedido();
                limparCamposItens();
            }
        }

        private async void preencherItensPedido()
        {
            if (_listaPedidos[_indiceAtual] == null)
            {
                return;
            }
            try
            {
                PedidoItemService service = new PedidoItemService();
                _listaItensPedido = await service.CarregarItensPedido(_listaPedidos[_indiceAtual].Controle);

                dgvItens.DataSource = _listaItensPedido;

                preencherCamposItens();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar itens do pedido: " + ex.Message);
            }
        }

        private void preencherCamposItens()
        {
            if (!(dgvItens.CurrentRow == null)) return;

            var itemSelecionado = (PedidoItem)dgvItens.CurrentRow.DataBoundItem;

            if (itemSelecionado != null)
            {
                txtProdutoCod.Text = itemSelecionado.ProdutoCodigo.ToString();
                txtProdutoNome.Text = itemSelecionado.ProdutoDescricao;
                txtProdutoQtde.Text = itemSelecionado.Quantidade.ToString("F2");
                txtProdutoValorUn.Text = itemSelecionado.ValorUnitario.ToString("F2");
                txtProdutoValorTotal.Text = itemSelecionado.ValorTotal.ToString("F2");
            }
        }

        private void limparCamposPedido()
        {
            txtCodigo.Text = "";
            txtCodCliente.Text = "";
            txtNomeCliente.Text = "";
            dtpDataPedido.Value = DateTime.Now;
            txtValorTotal.Text = "0,00";
            lblContagem.Text = "0 de 0";
        }

        private void limparCamposItens()
        {
            txtProdutoCod.Text = "";
            txtProdutoNome.Text = "";
            txtProdutoQtde.Text = "";
            txtProdutoValorUn.Text = "";
            txtProdutoValorTotal.Text = "";
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere
            }

            if (_eModoAtualPedido == eModoTela.Consulta && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                if (!int.TryParse(txtCodigo.Text, out int codigo))
                {
                    MessageBox.Show("Código inválido.");
                    txtCodigo.Focus();
                    return;
                }

                int indiceEncontrado = _listaPedidos.FindIndex(obj => obj.Codigo == codigo);
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

        private void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            //fazer aqui aquela putaria lá de buscar o código
        }

        private void dtpDataPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                toolGravar_Click(sender, e); // Chama o método de gravação
            }
        }

        private void validaCamposPedido()
        {
            if (string.IsNullOrWhiteSpace(txtCodCliente.Text))
            {
                throw new Exception("O campo Código do Cliente é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(txtNomeCliente.Text))
            {
                throw new Exception("O campo Nome do Cliente é obrigatório.");
            }
            if (dtpDataPedido.Value != null)
            {
                throw new Exception("A data do pedido é obrigatória.");
            }
        }

        private void validaCamposItem()
        {
            if (string.IsNullOrWhiteSpace(txtProdutoCod.Text))
            {
                throw new Exception("O campo Código do Produto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(txtProdutoNome.Text))
            {
                throw new Exception("O campo Nome do Produto é obrigatório.");
            }
            if (string.IsNullOrWhiteSpace(txtProdutoQtde.Text))
            {
                throw new Exception("O campo Quantidade é obrigatório.");
            }
            if (!decimal.TryParse(txtProdutoQtde.Text, out decimal qtde))
            {
                throw new Exception("O campo Quantidade deve ser um número válido.");
            }
            if (string.IsNullOrWhiteSpace(txtProdutoValorUn.Text))
            {
                throw new Exception("O campo Valor Unitário é obrigatório.");
            }
            if (!decimal.TryParse(txtProdutoValorUn.Text, out decimal valorUn))
            {
                throw new Exception("O campo Valor Unitário deve ser um número válido.");
            }
            if (string.IsNullOrWhiteSpace(txtProdutoValorTotal.Text))
            {
                throw new Exception("O campo Valor Total é obrigatório.");
            }
            if (!decimal.TryParse(txtProdutoValorTotal.Text, out decimal valorTotal))
            {
                throw new Exception("O campo Valor Total deve ser um número válido.");
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
                MessageBox.Show("Erro ao carregar produtos para pesquisa: " + ex.Message);
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

                    txtProdutoCod.Text = prSelecionado.Codigo.ToString();
                    txtProdutoNome.Text = prSelecionado.Nome;
                }
            }
        }
    }
    /*FAZER:
    botões de crud do item
    botões de lista de pesquisa do pedido e cliente
    lincar todos os métodos com os objetos na tela
    analisar o código do vb para ver se falta alguma coisa
    */
}