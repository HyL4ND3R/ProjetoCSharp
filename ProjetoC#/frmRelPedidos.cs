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
    public partial class frmRelPedidos : Form
    {
        private readonly DatabaseService _dbService;
        private readonly Relatorios _relatorio;

        public frmRelPedidos()
        {
            InitializeComponent();
            _dbService = new DatabaseService();
            _relatorio = new Relatorios();
        }

        private void frmRelPedidos_Load(object sender, EventArgs e)
        {
            dtpDataInicial.Value = DateTime.Now.AddMonths(-1);
            dtpDataFinal.Value = DateTime.Now;
        }

        private void dtpDataInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                dtpDataFinal.Focus(); // Move o foco para o próximo campo
            }
        }

        private void dtpDataFinal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                txtCodCliente.Focus(); // Move o foco para o próximo campo
            }
        }

        private async void txtCodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta

                if (String.IsNullOrWhiteSpace(txtCodCliente.Text))
                {
                    txtNomeCliente.Text = "";
                    txtProdutoCod.Focus();
                    return;
                }

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
                    txtProdutoCod.Focus();
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

        private async void txtProdutoCod_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas números e controle de backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Ignora o caractere
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta

                if (String.IsNullOrWhiteSpace(txtProdutoCod.Text))
                {
                    txtProdutoNome.Text = "";
                    btnVisualizar.Focus();
                    return;
                }

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
                    btnVisualizar.Focus();
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

        private void btnVisualizar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                btnVisualizar_Click(sender, e); // Chama o método de visualização
            }
        }

        private async void btnVisualizar_Click(object sender, EventArgs e)
        {
            try
            {
                validaCampos();

                string query = @"SELECT p.Codigo PedidoCodigo, p.ClienteCodigo ClienteCodigo, c.Nome ClienteNome, 
                                    p.Data DataPedido, p.QtdeTotal QuantidadeTotalPedido, p.ValorTotal ValorTotalPedido, 
                                    i.ProdutoCodigo ProdutoCodigo, i.Descricao ProdutoDescricao, 
                                    i.Quantidade ProdutoQuantidade, i.ValorUn ProdutoValorUn, i.ValorTotal ProdutoValorTotal 
                                 FROM Pedido p
                                 LEFT JOIN PedidoItem i ON p.Controle = i.ControlePedido 
				                 INNER JOIN Cliente c on P.ClienteCodigo = c.Codigo 
                                 WHERE p.Data BETWEEN @dataIni AND @dataFim";

                var parametros = new Dictionary<string, object>
                {
                    { "@dataIni", dtpDataInicial.Value.Date },
                    { "@dataFim", dtpDataFinal.Value.Date }
                };

                if (!string.IsNullOrEmpty(txtCodCliente.Text))
                {
                    query += " AND p.ClienteCodigo = @cli";
                    parametros.Add("@cli", txtCodCliente.Text);
                }

                if (!string.IsNullOrEmpty(txtProdutoCod.Text))
                {
                    query += " AND i.ProdutoCodigo = @prod";
                    parametros.Add("@prod", txtProdutoCod.Text);
                }

                List<PedidoRelatorioDTO> resultado = await _dbService.ExecutarConsultaAsync<PedidoRelatorioDTO>(query, parametros);

                if (resultado.Count == 0)
                {
                    MessageBox.Show("Nenhum pedido encontrado.");
                    return;
                }

                _relatorio.GerarRelatorioPedido(resultado);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void validaCampos()
        {
            if (dtpDataInicial.Value > dtpDataFinal.Value)
            {
                throw new Exception("A data inicial não pode ser maior que a data final.");
            }

            if (txtCodCliente.Text.Length > 0 &&
                (!int.TryParse(txtCodCliente.Text, out int clienteCod)))
            {
                throw new Exception("Cliente inválido");
            }

            if (txtProdutoCod.Text.Length > 0 &&
                (!int.TryParse(txtProdutoCod.Text, out int produtoCod)))
            {
                throw new Exception("Produto inválido");
            }
        }
    }
}
