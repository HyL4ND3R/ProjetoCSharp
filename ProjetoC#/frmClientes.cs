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
    public partial class frmClientes : Form
    {
        private List<Cliente> _listaClientes;
        // Índice para controle de navegação, -1 indica que não há registro posicionado
        private int _indiceAtual = -1;
        private eModoTela _eModoAtual;

        public frmClientes()
        {
            InitializeComponent();
            ConfigurarComboDocumento();
            FuncoesUI.AdicionarSelecaoAoFoco(this);
        }

        private async void frmClientes_Load(object sender, EventArgs e)
        {
            _listaClientes = new List<Cliente>();
            modoConsulta();

            try
            {
                ClienteService cliente = new ClienteService();

                // Carrega os operadores usando o serviço
                _listaClientes = await cliente.CarregarClientes();

                if (_listaClientes.Count > 0)
                {
                    _indiceAtual = _listaClientes.Count - 1;
                    preencherCampos();
                }
                else
                {
                    limparCampos();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
            }
        }

        private void frmClientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && _eModoAtual == eModoTela.Consulta)
            {
                e.Handled = true; // Evita o som de alerta
                modoInclusao();
            }
            if (e.KeyCode == Keys.F5 && _eModoAtual == eModoTela.Consulta)
            {
                e.Handled = true; // Evita o som de alerta
                modoAlteracao();
            }
            if (e.KeyCode == Keys.F3 &&
                (_eModoAtual == eModoTela.Alteracao ||
                _eModoAtual == eModoTela.Inclusao))
            {
                e.Handled = true; // Evita o som de alerta
                toolGravar_Click(sender, e); // Chama o método de gravação
            }
            if (e.KeyCode == Keys.Escape &&
                (_eModoAtual == eModoTela.Alteracao ||
                _eModoAtual == eModoTela.Inclusao))
            {
                e.Handled = true; // Evita o som de alerta
                toolDesfazer_Click(sender, e); // Chama o método de desfazer
            }
            else if (e.KeyCode == Keys.Escape && _eModoAtual == eModoTela.Consulta)
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
            btnListaCliente.Enabled = true;
            txtNome.Enabled = false;
            cmbTipoDocumento.Enabled = false;
            txtDocumento.Enabled = false;
            txtTelefone.Enabled = false;
            chkInativo.Enabled = false;

            txtCodigo.Focus();

            _eModoAtual = eModoTela.Consulta;
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
            btnListaCliente.Enabled = false;
            txtNome.Enabled = true;
            txtNome.Text = "";
            cmbTipoDocumento.Enabled = true;
            cmbTipoDocumento.SelectedIndex = -1;
            txtDocumento.Enabled = true;
            txtDocumento.Text = "";
            txtTelefone.Enabled = true;
            txtTelefone.Text = "";
            chkInativo.Enabled = true;
            chkInativo.Checked = false;

            txtNome.Focus();

            _eModoAtual = eModoTela.Inclusao;
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
            btnListaCliente.Enabled = false;
            txtNome.Enabled = true;
            cmbTipoDocumento.Enabled = true;
            txtDocumento.Enabled = true;
            txtTelefone.Enabled = true;
            chkInativo.Enabled = true;

            txtNome.Focus();

            _eModoAtual = eModoTela.Alteracao;
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
                ClienteService clienteService = new ClienteService();
                Cliente novoCliente = new Cliente
                {
                    Nome = txtNome.Text.Trim(),
                    TipoDocumento = (eTipoDocumentoCliente)cmbTipoDocumento.SelectedItem,
                    Documento = txtDocumento.Text.Trim(),
                    Telefone = txtTelefone.Text.Trim(),
                    Inativo = chkInativo.Checked ? (byte)1 : (byte)0
                };


                if (int.TryParse(txtCodigo.Text, out int codigo))
                    novoCliente.Codigo = codigo;
                else
                    novoCliente.Codigo = 0; // Código 0 para novos registros, o banco deve gerar o código real

                int idGerado = 0;

                try
                {
                    if (_eModoAtual == eModoTela.Inclusao)
                    {
                        // 1. Use o await para esperar a gravação. 
                        idGerado = await clienteService.InserirCliente(novoCliente);

                        if (idGerado <= 0)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                    else
                    {
                        bool sucesso = await clienteService.AlterarCliente(novoCliente);

                        if (!sucesso)
                        {
                            MessageBox.Show("O banco de dados não confirmou a gravação.");
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao gravar cliente no banco: " + ex.Message);
                    return;
                }

                if (_eModoAtual == eModoTela.Alteracao)
                    _listaClientes[_indiceAtual] = novoCliente; // Atualiza o registro existente
                else
                {
                    novoCliente.Codigo = idGerado;
                    _listaClientes.Add(novoCliente); // Adiciona o novo registro
                    _indiceAtual = _listaClientes.Count - 1; // Posiciona no novo registro
                }

                modoConsulta();
                preencherCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao gravar cliente: " + ex.Message);
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
                ClienteService clienteService = new ClienteService();
                bool sucesso = await clienteService.ExcluirCliente(codigo);

                if (!sucesso)
                {
                    MessageBox.Show("O banco de dados não confirmou a exclusão.");
                    return;
                }

                _listaClientes.RemoveAt(_indiceAtual); // Remove da lista local
                toolProximo_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir cliente do banco: " + ex.Message);
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
            if (_listaClientes.Count > 0)
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
            if (_indiceAtual < _listaClientes.Count - 1)
            {
                _indiceAtual++;
                preencherCampos();
            }
            else if (_indiceAtual > _listaClientes.Count - 1)
            {
                _indiceAtual = _listaClientes.Count - 1; // no caso de já estar no último, mantém o índice
                preencherCampos();
            }
        }
        private void toolUltimo_Click(object sender, EventArgs e)
        {
            if (_listaClientes.Count > 0)
            {
                _indiceAtual = _listaClientes.Count - 1;
                preencherCampos();
            }
        }

        private void preencherCampos()
        {
            if (_listaClientes.Count > 0 && _indiceAtual >= 0 && _indiceAtual < _listaClientes.Count)
            {
                var op = _listaClientes[_indiceAtual];
                txtCodigo.Text = op.Codigo.ToString();
                txtNome.Text = op.Nome;
                cmbTipoDocumento.SelectedItem = op.TipoDocumento;
                txtDocumento.Text = op.Documento;
                txtTelefone.Text = op.Telefone;
                chkInativo.Checked = op.Inativo == 1;

                lblContagem.Text = $"{_indiceAtual + 1} de {_listaClientes.Count}";
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
            cmbTipoDocumento.SelectedIndex = -1;
            txtDocumento.Text = "";
            txtTelefone.Text = "";
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

            if (_eModoAtual == eModoTela.Consulta && e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                if (!int.TryParse(txtCodigo.Text, out int codigo))
                {
                    MessageBox.Show("Código inválido.");
                    txtCodigo.Focus();
                    return;
                }

                int indiceEncontrado = _listaClientes.FindIndex(op => op.Codigo == codigo);
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
                btnListaCliente_Click(sender, e); // Chama o método de pesquisa
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                cmbTipoDocumento.Focus(); // Move o foco para o próximo campo
            }
        }
        private void cmbTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                txtDocumento.Focus(); // Move o foco para o próximo campo
            }
        }
        private void cmbTipoDocumento_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Limpa o texto e remove eventos antigos para não acumular máscaras
            txtDocumento.Text = "";

            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                return;
            }
            
            // Pega o enum selecionado
            eTipoDocumentoCliente tipoSelecionado = (eTipoDocumentoCliente)cmbTipoDocumento.SelectedItem;

            // Aplica a Máscara ou define o MaxLength conforme o tipo selecionado
            if (tipoSelecionado == eTipoDocumentoCliente.Outros)
            {
                txtDocumento.MaxLength = 50;
            }
            else
            {
                FuncoesUI.AplicarMascaraDocumento(txtDocumento, tipoSelecionado);
            }
        }
        private void txtDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Evita o som de alerta
                txtTelefone.Focus(); // Move o foco para o próximo campo
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Lógica de Atalho para Gravação (Enter)
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

            // 2. Lógica de Restrição (Somente números e símbolos de telefone)
            if (!FuncoesUI.CaractereValidoTelefone(e.KeyChar))
            {
                e.Handled = true; // Bloqueia letras e outros símbolos
            }

            // 3. Lógica de Tamanho Máximo (Manual ou via Propriedade MaxLength)
            if (txtTelefone.Text.Length >= 15 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void validaCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                throw new Exception("O campo Nome é obrigatório.");
            }

            if (cmbTipoDocumento.SelectedIndex == -1)
            {
                throw new Exception("O campo Tipo de Documento é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(txtDocumento.Text))
            {
                throw new Exception("O campo Documento é obrigatório.");
            }

            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                throw new Exception("O campo Telefone é obrigatório.");
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
                    // converte de volta object para Clientes(Cast)
                    var clSelecionado = (Cliente)frm.ObjetoSelecionado;

                    // Sincroniza o índice
                    _listaClientes = listaCl; // Atualiza a lista local com os dados mais recentes
                    _indiceAtual = _listaClientes.FindIndex(x => x.Codigo == clSelecionado.Codigo);
                    preencherCampos();
                }
            }
        }
        private void ConfigurarComboDocumento()
        {
            // Preenche o ComboBox com os nomes do Enum
            cmbTipoDocumento.DataSource = Enum.GetValues(typeof(eTipoDocumentoCliente));

            // Valor padrão
            cmbTipoDocumento.SelectedIndex = -1;
        }
    }
}
