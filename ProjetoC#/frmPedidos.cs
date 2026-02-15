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
        private BindingList<PedidoItem> _listaItensPedido;
        // Índice para controle de navegação, -1 indica que não há registro posicionado
        private int _indiceAtual = -1;
        private int _controlePedidoItemAtual = 0;
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
            ConfigurarGradeItens();
            ModoConsultaPedido();

            try
            {
                PedidoService pedidoService = new PedidoService();

                _listaPedidos = await pedidoService.CarregarPedidos();

                if (_listaPedidos.Count > 0)
                {
                    _indiceAtual = _listaPedidos.Count - 1;
                    preencherCampos();
                    preencherItensPedido();
                    if (dgvItens.Rows.Count > 0)
                    {
                        dgvItens.Rows[0].Selected = true;
                        preencherCamposItens();
                    }
                }
                else
                {
                    limparCamposPedido();
                    limparCamposItens();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar Dados: " + ex.Message);
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
                        ModoInclusaoPedido();
                    }
                    break;

                case Keys.F5:// Alterar Pedido
                    if (_eModoAtualPedido == eModoTela.Consulta)
                    {
                        e.Handled = true;
                        ModoAlteracaoPedido();
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

        private void ModoConsultaPedido()
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

            dgvItens.Enabled = true;

            txtCodigo.Focus();

            _eModoAtualPedido = eModoTela.Consulta;
            _eModoAtualItem = eModoTela.Consulta;
        }

        private void ModoInclusaoPedido()
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
            txtCodigo.Text = (_listaPedidos.Count > 0 ? _listaPedidos.Max(i => i.Codigo) + 1 : 1).ToString();
            btnListaPedido.Enabled = false;
            txtCodCliente.Enabled = true;
            txtCodCliente.Text = "";
            btnListaCliente.Enabled = true;
            txtNomeCliente.Enabled = true;
            txtNomeCliente.Text = "";
            dtpDataPedido.Enabled = true;
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

            _listaItensPedido.Clear();
            dgvItens.Enabled = false;

            txtProdutoCod.Focus();

            _eModoAtualPedido = eModoTela.Inclusao;
            _eModoAtualItem = eModoTela.Bloqueado;
        }

        private void ModoAlteracaoPedido()
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
            dtpDataPedido.Enabled = true;

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

            dgvItens.Enabled = true;

            txtProdutoNome.Focus();

            _eModoAtualPedido = eModoTela.Alteracao;
            _eModoAtualItem = eModoTela.Bloqueado;
        }
        private void ModoInclusaoItem()
        {
            dgvItens.Enabled = false;
            dgvItens.ClearSelection();

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
            txtProdutoCod.Text = "";
            btnListaProduto.Enabled = true;
            txtProdutoNome.Enabled = true;
            txtProdutoNome.Text = "";
            txtProdutoQtde.Enabled = true;
            txtProdutoQtde.Text = "1,00";
            txtProdutoValorUn.Enabled = true;
            txtProdutoValorUn.Text = "";
            txtProdutoValorTotal.Enabled = true;
            txtProdutoValorTotal.Text = "";

            txtProdutoCod.Focus();

            _eModoAtualPedido = eModoTela.Bloqueado;
            _eModoAtualItem = eModoTela.Inclusao;
        }
        private void ModoAlteracaoItem()
        {
            dgvItens.Enabled = false;
            dgvItens.ClearSelection();

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
            txtProdutoValorUn.Enabled = true;
            txtProdutoValorTotal.Enabled = true;

            txtProdutoCod.Focus();

            _eModoAtualPedido = eModoTela.Bloqueado;
            _eModoAtualItem = eModoTela.Alteracao;
        }
        private void CancelarItem()
        {
            //DataGrid
            dgvItens.Enabled = true;
            dgvItens.ClearSelection();
            if (dgvItens.Rows.Count > 0)
                dgvItens.Rows[0].Selected = true;

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
            
            _eModoAtualPedido = eModoTela.Consulta;
            _eModoAtualItem = eModoTela.Consulta;
            
            preencherCamposItens();
        }

        private void toolNovo_Click(object sender, EventArgs e)
        {
            ModoInclusaoPedido();
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
                PedidoService pedidoService = new PedidoService();
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
                        // 1. Verifica se o código que o usuário tentou já existe
                        var pedidoExistente = await pedidoService.BuscarPedidoPorCodigo(novoPedido.Codigo);

                        if (pedidoExistente != null)
                        {
                            // 2. Se existe,  o usuário e busca o próximo vago
                            MessageBox.Show($"O código {novoPedido.Codigo} já existe. Será atribuído o próximo código disponível.");

                            int codigoVago = await pedidoService.BuscarProximoCodigoDisponivel();
                            novoPedido.Codigo = codigoVago;
                        }

                        // 3. Agora o novoPedido.Codigo é o próximo vago.

                        idGerado = await pedidoService.InserirPedido(novoPedido);

                        if (idGerado <= 0)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                    else
                    {
                        novoPedido.Controle = _listaPedidos[_indiceAtual].Controle;

                        bool sucesso = await pedidoService.AlterarPedido(novoPedido);

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

                ModoConsultaPedido();
                preencherCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar pedido: " + ex.Message);
            }

        }
        private void toolAlterar_Click(object sender, EventArgs e)
        {
            ModoAlteracaoPedido();
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
            ModoConsultaPedido();
            preencherCampos();
            preencherItensPedido();
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
                txtValorTotal.Text = obj.ValorTotal.ToString("F2") ?? "";

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
                var _listaItensPedidoApi = await service.CarregarItensPedido(_listaPedidos[_indiceAtual].Controle);
                _listaItensPedido = new BindingList<PedidoItem>(_listaItensPedidoApi);
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

            if (_eModoAtualItem == eModoTela.Alteracao
                || _eModoAtualItem == eModoTela.Inclusao) return;

            if ((dgvItens.CurrentRow == null)) return;

            var itemSelecionado = (PedidoItem)dgvItens.CurrentRow.DataBoundItem;

            if (itemSelecionado != null)
            {
                _controlePedidoItemAtual = itemSelecionado.Controle; // Armazena o controle do item selecionado para futuras operações
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

        private void dgvItens_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvItens.CurrentRow != null)
            {
                preencherCamposItens();
            }
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
                    preencherItensPedido();
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
                btnListaPedido_Click(sender, e);
            }
        }

        private async void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere
            }

            if ((_eModoAtualPedido == eModoTela.Alteracao || _eModoAtualPedido == eModoTela.Inclusao)
                && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                if (!int.TryParse(txtCodCliente.Text, out int codigo))
                {
                    MessageBox.Show("Código inválido.");
                    txtCodCliente.Focus();
                    return;
                }

                ClienteService service = new ClienteService();

                var cliente = await service.BuscarClientePorCodigo(codigo);

                if (cliente != null)
                {
                    txtCodCliente.Text = cliente.Codigo.ToString();
                    txtNomeCliente.Text = cliente.Nome;
                    dtpDataPedido.Focus();
                }
                else
                {
                    MessageBox.Show("Código não encontrado.");
                    txtCodCliente.Focus();
                }
            }
        }

        private void txtCodCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                e.Handled = true; // Evita o som de alerta
                btnListaCliente_Click(sender, e); // Chama o método de pesquisa
            }
        }

        private void dtpDataPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                toolGravar_Click(sender, e); // Chama o método de gravação
            }
        }

        private async void txtProdutoCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere
            }

            if ((_eModoAtualItem == eModoTela.Alteracao || _eModoAtualItem == eModoTela.Inclusao)
                && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                if (!int.TryParse(txtProdutoCod.Text, out int codigo))
                {
                    MessageBox.Show("Código inválido.");
                    txtProdutoCod.Focus();
                    return;
                }

                Produto produto = null;

                try
                {
                    ProdutoService service = new ProdutoService();
                    produto = await service.BuscarProdutoPorCodigo(codigo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro na busca do produto: " + ex.ToString());
                }

                if (produto != null)
                {
                    txtProdutoCod.Text = produto.Codigo.ToString();
                    txtProdutoNome.Text = produto.Nome;
                    txtProdutoValorUn.Text = produto.Valor.ToString("F2");
                    txtProdutoNome.Focus();
                }
                else
                {
                    MessageBox.Show("Código não encontrado.");
                    txtProdutoCod.Focus();
                }
            }
        }

        private void txtProdutoCod_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                e.Handled = true; // Evita o som de alerta
                btnListaProduto_Click(sender, e); // Chama o método de pesquisa
            }
        }

        private void txtProdutoDescricao_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                txtProdutoQtde.Focus();
            }
        }

        private void txtProdutoQtde_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, vírgula e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; // Ignora o caractere
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                txtProdutoValorUn.Focus();
            }
        }

        private void txtProdutoValorUn_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, vírgula e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; // Ignora o caractere
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                txtProdutoValorTotal.Focus();
            }
        }

        private void txtProdutoValorTotal_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números, vírgula e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true; // Ignora o caractere
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta

                CalcularValorUnItem();

                if (MessageBox.Show("Confirma Gravação?", "Confirmação", MessageBoxButtons.YesNo) == DialogResult.No) return;
                btnSalvarItem_Click(sender, e); // Chama o método de gravação do item
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

        private async void btnListaPedido_Click(object sender, EventArgs e)
        {
            var listaPd = new List<Pedido>();
            try
            {
                var service = new PedidoService();
                listaPd = await service.CarregarPedidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar pedidos para pesquisa: " + ex.Message);
                return;
            }
            // Convertemos a lista de Operadores para uma lista de Objetos
            var listaParaPesquisa = listaPd.Cast<object>().ToList();

            using (var frm = new frmListaPesquisa(listaParaPesquisa))
            {
                frm.Text = "Pesquisa de Pedidos";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // converte de volta object para Produto(Cast)
                    var pdSelecionado = (Pedido)frm.ObjetoSelecionado;

                    // Sincroniza o índice
                    _listaPedidos = listaPd; // Atualiza a lista local com os dados mais recentes
                    _indiceAtual = _listaPedidos.FindIndex(x => x.Controle == pdSelecionado.Controle);
                    preencherCampos();
                    preencherCamposItens();
                }
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
                    txtProdutoValorUn.Text = prSelecionado.Valor.ToString("F2");
                }
            }
        }

        private async void btnListaCliente_Click(object sender, EventArgs e)
        {
            var listaCl = new List<Cliente>();
            try
            {
                var service = new ClienteService();
                listaCl = await service.CarregarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes para pesquisa: " + ex.Message);
                return;
            }
            // Convertemos a lista de Operadores para uma lista de Objetos
            var listaParaPesquisa = listaCl.Cast<object>().ToList();

            using (var frm = new frmListaPesquisa(listaParaPesquisa))
            {
                frm.Text = "Pesquisa de Clientes";
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // converte de volta object para Produto(Cast)
                    var clSelecionado = (Cliente)frm.ObjetoSelecionado;

                    txtCodCliente.Text = clSelecionado.Codigo.ToString();
                    txtNomeCliente.Text = clSelecionado.Nome;
                }
            }
        }

        private void btnNovoItem_Click(object sender, EventArgs e)
        {
            ModoInclusaoItem();
        }

        private async void btnSalvarItem_Click(object sender, EventArgs e)
        {
            try
            {
                validaCamposItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro de validação: " + ex.Message);
                return;
            }

            try
            {
                PedidoItemService pedidoItemService = new PedidoItemService();
                PedidoService pedidoService = new PedidoService();

                PedidoItem novoItemPedido = new PedidoItem
                {
                    ControlePedido = _listaPedidos[_indiceAtual].Controle,
                    Item = _listaItensPedido.Count > 0 ? _listaItensPedido.Max(i => i.Item) + 1 : 1, // Incrementa o item com base no maior existente
                    ProdutoCodigo = int.Parse(txtProdutoCod.Text),
                    ProdutoDescricao = txtProdutoNome.Text,
                    Quantidade = decimal.Parse(txtProdutoQtde.Text),
                    ValorUnitario = decimal.Parse(txtProdutoValorUn.Text),
                    ValorTotal = decimal.Parse(txtProdutoValorTotal.Text)
                };

                int idGerado = 0;
                bool recalculoSucesso;

                try
                {
                    if (_eModoAtualItem == eModoTela.Inclusao)
                    {
                        idGerado = await pedidoItemService.InserirItemPedido(novoItemPedido);

                        if (idGerado <= 0)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                    else
                    {
                        novoItemPedido.Controle = _controlePedidoItemAtual;

                        bool sucesso = await pedidoItemService.AlterarItemPedido(novoItemPedido);

                        if (!sucesso)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }

                    recalculoSucesso = await pedidoService.RecalcularTotaisPedido(_listaPedidos[_indiceAtual].Controle);

                    if (!recalculoSucesso)
                    {
                        MessageBox.Show("O banco de dados não confirmou o recálculo dos totais do pedido.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar item no banco: " + ex.Message);
                    return;
                }

                int indiceItem = -1;

                if (_eModoAtualItem == eModoTela.Alteracao)
                {
                    var item = _listaItensPedido.FirstOrDefault(i => i.Controle == _controlePedidoItemAtual);

                    if (item != null)
                    {
                        int indiceAtual = _listaItensPedido.IndexOf(item);
                        _listaItensPedido[indiceAtual] = novoItemPedido;
                    }

                    dgvItens.Refresh(); // Atualiza a grade para refletir as mudanças
                    dgvItens.Rows[indiceItem].Selected = true; // Seleciona o item alterado na grade
                    preencherCamposItens(); // Atualiza os campos com o item selecionado
                }
                else
                {
                    novoItemPedido.Controle = idGerado;
                    _listaItensPedido.Add(novoItemPedido); // Adiciona o novo registro
                    dgvItens.Refresh(); // Atualiza a grade para refletir as mudanças
                }

                if (recalculoSucesso) RecalcularTotaisPedidoLocal();

                ModoInclusaoItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar item: " + ex.Message);
            }
        }

        private void btnAlterarItem_Click(object sender, EventArgs e)
        {
            ModoAlteracaoItem();
        }

        private async void btnExcluirItem_Click(object sender, EventArgs e)
        {

            if (dgvItens.CurrentRow == null)
            {
                MessageBox.Show("Nenhum item selecionado para exclusão.");
                return;
            }

            if (MessageBox.Show("Confirma a exclusão do item?",
                "Confirmação",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            var itemSelecionado = (PedidoItem)dgvItens.CurrentRow.DataBoundItem;

            try
            {

                PedidoItemService pedidoItemService = new PedidoItemService();
                PedidoService pedidoService = new PedidoService();

                int controle = itemSelecionado.Controle; // Pega o controle do item selecionado para exclusão
                bool sucesso = await pedidoItemService.ExcluirItemPedido(controle);

                if (!sucesso)
                {
                    MessageBox.Show("O banco de dados não confirmou a exclusão.");
                    return;
                }

                bool recalculoSucesso = await pedidoItemService.RecalcularItemPedido(_listaPedidos[_indiceAtual].Controle);

                if (!recalculoSucesso)
                {
                    MessageBox.Show("O banco de dados não confirmou o recálculo dos itens do pedido.");
                }

                recalculoSucesso = await pedidoService.RecalcularTotaisPedido(_listaPedidos[_indiceAtual].Controle);

                if (!recalculoSucesso)
                {
                    MessageBox.Show("O banco de dados não confirmou o recálculo dos totais do pedido.");
                }

                var item = _listaItensPedido.FirstOrDefault(i => i.Controle == controle); // Encontra o índice do item excluído
                int indiceItem = -1;
                if (item != null)
                {
                    indiceItem = _listaItensPedido.IndexOf(item);
                    _listaItensPedido.RemoveAt(indiceItem); // Remove da lista local
                }

                if (recalculoSucesso) RecalcularTotaisPedidoLocal();

                dgvItens.Refresh();

                if (dgvItens.Rows.Count > 0)
                {
                    dgvItens.Rows[0].Selected = true; // Seleciona o primeiro item da grade após exclusão
                    preencherCamposItens(); // Atualiza os campos com o item selecionado
                }
                else
                {
                    limparCamposItens(); // Limpa os campos se não houver mais itens
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir pedido do banco: " + ex.Message);
                return;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelarItem();
        }

        private void txtProdutoQtde_Leave(object sender, EventArgs e)
        {
            CalcularValorTotalItem();
        }

        private void txtProdutoValorUn_Leave(object sender, EventArgs e)
        {
            CalcularValorTotalItem();
        }

        private void CalcularValorTotalItem()
        {
            if (decimal.TryParse(txtProdutoQtde.Text, out decimal qtde) &&
                decimal.TryParse(txtProdutoValorUn.Text, out decimal valorUn))
            {
                decimal valorTotal = qtde * valorUn;
                txtProdutoValorTotal.Text = valorTotal.ToString("F2");
            }
        }

        private void CalcularValorUnItem()
        {
            if (decimal.TryParse(txtProdutoQtde.Text, out decimal qtde) &&
                decimal.TryParse(txtProdutoValorTotal.Text, out decimal valorTotal))
            {
                decimal valorUn = valorTotal / qtde;
                txtProdutoValorUn.Text = valorUn.ToString("F2");
            }
        }

        private void ConfigurarGradeItens()
        {
            dgvItens.ReadOnly = true;
            dgvItens.AutoGenerateColumns = false;
            dgvItens.Columns.Clear();

            // Coluna Código do Produto
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProdutoCodigo", // Nome EXATO da propriedade na sua classe PedidoItem
                HeaderText = "Cód.",
                Width = 80,
                ReadOnly = true
            });

            // Coluna Descrição (Se você tiver essa propriedade no objeto)
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ProdutoDescricao",
                HeaderText = "Descrição",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill // Ocupa o espaço restante
            });

            // Coluna Quantidade
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Quantidade",
                HeaderText = "Qtde",
                Width = 70,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "N2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Coluna Valor Unitário (Com Formatação de Moeda)
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValorUnitario",
                HeaderText = "Vlr. Unit.",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            // Coluna Valor Total (Com Formatação de Moeda)
            dgvItens.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValorTotal",
                HeaderText = "Total",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2", Alignment = DataGridViewContentAlignment.MiddleRight }
            });
        }

        private void RecalcularTotaisPedidoLocal()
        {
            decimal totalGeral = _listaItensPedido.Sum(item => item.ValorTotal);
            _listaPedidos[_indiceAtual].ValorTotal = totalGeral;
            txtValorTotal.Text = totalGeral.ToString("F2");
        }
    }
}