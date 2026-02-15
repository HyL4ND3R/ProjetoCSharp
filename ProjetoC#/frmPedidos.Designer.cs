namespace ProjetoC_
{
    partial class frmPedidos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPedidos));
            txtValorTotal = new TextBox();
            lblValorTotal = new Label();
            txtNomeCliente = new TextBox();
            lblCliente = new Label();
            lblContagem = new Label();
            btnListaPedido = new Button();
            txtCodigo = new TextBox();
            lblCodigo = new Label();
            toolUltimo = new ToolStripButton();
            toolAnterior = new ToolStripButton();
            toolPrimeiro = new ToolStripButton();
            toolDesfazer = new ToolStripButton();
            toolExcluir = new ToolStripButton();
            toolAlterar = new ToolStripButton();
            toolGravar = new ToolStripButton();
            toolNovo = new ToolStripButton();
            toolProximo = new ToolStripButton();
            toolStrip = new ToolStrip();
            txtCodCliente = new TextBox();
            btnListaCliente = new Button();
            dtpDataPedido = new DateTimePicker();
            lblData = new Label();
            btnNovoItem = new Button();
            btnSalvarItem = new Button();
            btnAlterarItem = new Button();
            btnExcluirItem = new Button();
            btnCancelar = new Button();
            dgvItens = new DataGridView();
            txtProdutoCod = new TextBox();
            btnListaProduto = new Button();
            txtProdutoNome = new TextBox();
            lblProduto = new Label();
            txtProdutoQtde = new TextBox();
            txtProdutoValorUn = new TextBox();
            txtProdutoValorTotal = new TextBox();
            lblQuantidade = new Label();
            lblValorUn = new Label();
            lblTotalItem = new Label();
            toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItens).BeginInit();
            SuspendLayout();
            // 
            // txtValorTotal
            // 
            txtValorTotal.Enabled = false;
            txtValorTotal.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtValorTotal.Location = new Point(296, 464);
            txtValorTotal.Name = "txtValorTotal";
            txtValorTotal.Size = new Size(128, 26);
            txtValorTotal.TabIndex = 32;
            // 
            // lblValorTotal
            // 
            lblValorTotal.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValorTotal.Location = new Point(208, 464);
            lblValorTotal.Name = "lblValorTotal";
            lblValorTotal.Size = new Size(88, 26);
            lblValorTotal.TabIndex = 31;
            lblValorTotal.Text = "Valor Total:";
            lblValorTotal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomeCliente.Location = new Point(192, 96);
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(260, 26);
            txtNomeCliente.TabIndex = 5;
            // 
            // lblCliente
            // 
            lblCliente.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(40, 96);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(64, 26);
            lblCliente.TabIndex = 29;
            lblCliente.Text = "Cliente:";
            lblCliente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblContagem
            // 
            lblContagem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContagem.Location = new Point(464, 56);
            lblContagem.Name = "lblContagem";
            lblContagem.Size = new Size(128, 26);
            lblContagem.TabIndex = 28;
            // 
            // btnListaPedido
            // 
            btnListaPedido.Image = (Image)resources.GetObject("btnListaPedido.Image");
            btnListaPedido.Location = new Point(183, 55);
            btnListaPedido.Name = "btnListaPedido";
            btnListaPedido.Size = new Size(30, 28);
            btnListaPedido.TabIndex = 2;
            btnListaPedido.UseVisualStyleBackColor = true;
            btnListaPedido.Click += btnListaPedido_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(112, 56);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(72, 26);
            txtCodigo.TabIndex = 1;
            txtCodigo.KeyDown += txtCodigo_KeyDown;
            txtCodigo.KeyPress += txtCodigo_KeyPress;
            // 
            // lblCodigo
            // 
            lblCodigo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(40, 56);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(64, 26);
            lblCodigo.TabIndex = 25;
            lblCodigo.Text = "Codigo:";
            lblCodigo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // toolUltimo
            // 
            toolUltimo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolUltimo.Image = Properties.Resources._64;
            toolUltimo.ImageScaling = ToolStripItemImageScaling.None;
            toolUltimo.ImageTransparentColor = Color.Magenta;
            toolUltimo.Margin = new Padding(0, 3, 0, 5);
            toolUltimo.Name = "toolUltimo";
            toolUltimo.Size = new Size(36, 40);
            toolUltimo.Click += toolUltimo_Click;
            // 
            // toolAnterior
            // 
            toolAnterior.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolAnterior.Image = Properties.Resources._41;
            toolAnterior.ImageScaling = ToolStripItemImageScaling.None;
            toolAnterior.ImageTransparentColor = Color.Magenta;
            toolAnterior.Margin = new Padding(0, 3, 0, 5);
            toolAnterior.Name = "toolAnterior";
            toolAnterior.Size = new Size(36, 40);
            toolAnterior.Click += toolAnterior_Click;
            // 
            // toolPrimeiro
            // 
            toolPrimeiro.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolPrimeiro.Image = Properties.Resources._63;
            toolPrimeiro.ImageScaling = ToolStripItemImageScaling.None;
            toolPrimeiro.ImageTransparentColor = Color.Magenta;
            toolPrimeiro.Margin = new Padding(10, 3, 0, 5);
            toolPrimeiro.Name = "toolPrimeiro";
            toolPrimeiro.Padding = new Padding(5, 0, 0, 0);
            toolPrimeiro.Size = new Size(41, 40);
            toolPrimeiro.Click += toolPrimeiro_Click;
            // 
            // toolDesfazer
            // 
            toolDesfazer.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolDesfazer.Image = Properties.Resources._12;
            toolDesfazer.ImageScaling = ToolStripItemImageScaling.None;
            toolDesfazer.ImageTransparentColor = Color.Magenta;
            toolDesfazer.Margin = new Padding(0, 3, 0, 5);
            toolDesfazer.Name = "toolDesfazer";
            toolDesfazer.Padding = new Padding(5, 0, 0, 0);
            toolDesfazer.Size = new Size(41, 40);
            toolDesfazer.Text = "toolStripButton1";
            toolDesfazer.Click += toolDesfazer_Click;
            // 
            // toolExcluir
            // 
            toolExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolExcluir.Image = Properties.Resources._18;
            toolExcluir.ImageScaling = ToolStripItemImageScaling.None;
            toolExcluir.ImageTransparentColor = Color.Magenta;
            toolExcluir.Margin = new Padding(0, 3, 0, 5);
            toolExcluir.Name = "toolExcluir";
            toolExcluir.Padding = new Padding(5, 0, 0, 0);
            toolExcluir.Size = new Size(41, 40);
            toolExcluir.Click += toolExcluir_Click;
            // 
            // toolAlterar
            // 
            toolAlterar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolAlterar.Image = Properties.Resources._3;
            toolAlterar.ImageScaling = ToolStripItemImageScaling.None;
            toolAlterar.ImageTransparentColor = Color.Magenta;
            toolAlterar.Margin = new Padding(0, 3, 0, 5);
            toolAlterar.Name = "toolAlterar";
            toolAlterar.Padding = new Padding(5, 0, 0, 0);
            toolAlterar.Size = new Size(41, 40);
            toolAlterar.Click += toolAlterar_Click;
            // 
            // toolGravar
            // 
            toolGravar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolGravar.Image = Properties.Resources._37;
            toolGravar.ImageScaling = ToolStripItemImageScaling.None;
            toolGravar.ImageTransparentColor = Color.Magenta;
            toolGravar.Margin = new Padding(0, 3, 0, 5);
            toolGravar.Name = "toolGravar";
            toolGravar.Padding = new Padding(5, 0, 0, 0);
            toolGravar.Size = new Size(41, 40);
            toolGravar.Click += toolGravar_Click;
            // 
            // toolNovo
            // 
            toolNovo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolNovo.Image = Properties.Resources._27;
            toolNovo.ImageScaling = ToolStripItemImageScaling.None;
            toolNovo.ImageTransparentColor = Color.Magenta;
            toolNovo.Margin = new Padding(0, 3, 0, 5);
            toolNovo.Name = "toolNovo";
            toolNovo.Padding = new Padding(5, 0, 0, 0);
            toolNovo.Size = new Size(41, 40);
            toolNovo.Click += toolNovo_Click;
            // 
            // toolProximo
            // 
            toolProximo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolProximo.Image = Properties.Resources._40;
            toolProximo.ImageScaling = ToolStripItemImageScaling.None;
            toolProximo.ImageTransparentColor = Color.Magenta;
            toolProximo.Margin = new Padding(0, 3, 0, 5);
            toolProximo.Name = "toolProximo";
            toolProximo.Size = new Size(36, 40);
            toolProximo.Click += toolProximo_Click;
            // 
            // toolStrip
            // 
            toolStrip.AutoSize = false;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolNovo, toolGravar, toolAlterar, toolExcluir, toolDesfazer, toolPrimeiro, toolAnterior, toolProximo, toolUltimo });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Margin = new Padding(10, 10, 0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new Padding(0);
            toolStrip.Size = new Size(1118, 48);
            toolStrip.TabIndex = 24;
            // 
            // txtCodCliente
            // 
            txtCodCliente.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodCliente.Location = new Point(112, 96);
            txtCodCliente.Name = "txtCodCliente";
            txtCodCliente.Size = new Size(52, 26);
            txtCodCliente.TabIndex = 3;
            txtCodCliente.KeyDown += txtCodCliente_KeyDown;
            txtCodCliente.KeyPress += txtCodCliente_KeyPress;
            // 
            // btnListaCliente
            // 
            btnListaCliente.Image = (Image)resources.GetObject("btnListaCliente.Image");
            btnListaCliente.Location = new Point(163, 95);
            btnListaCliente.Name = "btnListaCliente";
            btnListaCliente.Size = new Size(30, 28);
            btnListaCliente.TabIndex = 4;
            btnListaCliente.UseVisualStyleBackColor = true;
            btnListaCliente.Click += btnListaCliente_Click;
            // 
            // dtpDataPedido
            // 
            dtpDataPedido.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDataPedido.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDataPedido.Format = DateTimePickerFormat.Short;
            dtpDataPedido.Location = new Point(332, 56);
            dtpDataPedido.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            dtpDataPedido.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpDataPedido.Name = "dtpDataPedido";
            dtpDataPedido.Size = new Size(120, 26);
            dtpDataPedido.TabIndex = 6;
            dtpDataPedido.Value = new DateTime(2026, 2, 13, 23, 25, 2, 0);
            dtpDataPedido.KeyPress += dtpDataPedido_KeyPress;
            // 
            // lblData
            // 
            lblData.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblData.Location = new Point(284, 56);
            lblData.Name = "lblData";
            lblData.Size = new Size(48, 26);
            lblData.TabIndex = 36;
            lblData.Text = "Data:";
            lblData.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnNovoItem
            // 
            btnNovoItem.AutoSize = true;
            btnNovoItem.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnNovoItem.Location = new Point(112, 152);
            btnNovoItem.Name = "btnNovoItem";
            btnNovoItem.Size = new Size(77, 30);
            btnNovoItem.TabIndex = 7;
            btnNovoItem.Text = "Novo";
            btnNovoItem.UseVisualStyleBackColor = true;
            btnNovoItem.Click += btnNovoItem_Click;
            // 
            // btnSalvarItem
            // 
            btnSalvarItem.AutoSize = true;
            btnSalvarItem.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSalvarItem.Location = new Point(188, 152);
            btnSalvarItem.Name = "btnSalvarItem";
            btnSalvarItem.Size = new Size(77, 30);
            btnSalvarItem.TabIndex = 8;
            btnSalvarItem.Text = "Salvar";
            btnSalvarItem.UseVisualStyleBackColor = true;
            btnSalvarItem.Click += btnSalvarItem_Click;
            // 
            // btnAlterarItem
            // 
            btnAlterarItem.AutoSize = true;
            btnAlterarItem.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAlterarItem.Location = new Point(264, 152);
            btnAlterarItem.Name = "btnAlterarItem";
            btnAlterarItem.Size = new Size(77, 30);
            btnAlterarItem.TabIndex = 9;
            btnAlterarItem.Text = "Alterar";
            btnAlterarItem.UseVisualStyleBackColor = true;
            btnAlterarItem.Click += btnAlterarItem_Click;
            // 
            // btnExcluirItem
            // 
            btnExcluirItem.AutoSize = true;
            btnExcluirItem.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnExcluirItem.Location = new Point(340, 152);
            btnExcluirItem.Name = "btnExcluirItem";
            btnExcluirItem.Size = new Size(77, 30);
            btnExcluirItem.TabIndex = 10;
            btnExcluirItem.Text = "Excluir";
            btnExcluirItem.UseVisualStyleBackColor = true;
            btnExcluirItem.Click += btnExcluirItem_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.AutoSize = true;
            btnCancelar.Font = new Font("Arial", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(416, 152);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(77, 30);
            btnCancelar.TabIndex = 11;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // dgvItens
            // 
            dgvItens.AllowUserToAddRows = false;
            dgvItens.AllowUserToDeleteRows = false;
            dgvItens.AllowUserToOrderColumns = true;
            dgvItens.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvItens.Location = new Point(208, 216);
            dgvItens.Name = "dgvItens";
            dgvItens.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvItens.Size = new Size(664, 240);
            dgvItens.TabIndex = 42;
            dgvItens.SelectionChanged += dgvItens_SelectionChanged;
            // 
            // txtProdutoCod
            // 
            txtProdutoCod.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdutoCod.Location = new Point(113, 184);
            txtProdutoCod.Name = "txtProdutoCod";
            txtProdutoCod.Size = new Size(73, 26);
            txtProdutoCod.TabIndex = 12;
            txtProdutoCod.KeyDown += txtProdutoCod_KeyDown;
            txtProdutoCod.KeyPress += txtProdutoCod_KeyPress;
            // 
            // btnListaProduto
            // 
            btnListaProduto.Image = (Image)resources.GetObject("btnListaProduto.Image");
            btnListaProduto.Location = new Point(185, 183);
            btnListaProduto.Name = "btnListaProduto";
            btnListaProduto.Size = new Size(30, 28);
            btnListaProduto.TabIndex = 13;
            btnListaProduto.UseVisualStyleBackColor = true;
            btnListaProduto.Click += btnListaProduto_Click;
            // 
            // txtProdutoNome
            // 
            txtProdutoNome.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdutoNome.Location = new Point(214, 184);
            txtProdutoNome.Name = "txtProdutoNome";
            txtProdutoNome.Size = new Size(278, 26);
            txtProdutoNome.TabIndex = 14;
            txtProdutoNome.KeyPress += txtProdutoDescricao_KeyPress;
            // 
            // lblProduto
            // 
            lblProduto.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProduto.Location = new Point(40, 184);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(72, 26);
            lblProduto.TabIndex = 46;
            lblProduto.Text = "Produto:";
            lblProduto.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtProdutoQtde
            // 
            txtProdutoQtde.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdutoQtde.Location = new Point(113, 216);
            txtProdutoQtde.Name = "txtProdutoQtde";
            txtProdutoQtde.Size = new Size(88, 26);
            txtProdutoQtde.TabIndex = 15;
            txtProdutoQtde.KeyPress += txtProdutoQtde_KeyPress;
            txtProdutoQtde.Leave += txtProdutoQtde_Leave;
            // 
            // txtProdutoValorUn
            // 
            txtProdutoValorUn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdutoValorUn.Location = new Point(113, 248);
            txtProdutoValorUn.Name = "txtProdutoValorUn";
            txtProdutoValorUn.Size = new Size(88, 26);
            txtProdutoValorUn.TabIndex = 16;
            txtProdutoValorUn.KeyPress += txtProdutoValorUn_KeyPress;
            txtProdutoValorUn.Leave += txtProdutoValorUn_Leave;
            // 
            // txtProdutoValorTotal
            // 
            txtProdutoValorTotal.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdutoValorTotal.Location = new Point(113, 280);
            txtProdutoValorTotal.Name = "txtProdutoValorTotal";
            txtProdutoValorTotal.Size = new Size(88, 26);
            txtProdutoValorTotal.TabIndex = 17;
            txtProdutoValorTotal.KeyPress += txtProdutoValorTotal_KeyPress;
            // 
            // lblQuantidade
            // 
            lblQuantidade.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuantidade.Location = new Point(40, 216);
            lblQuantidade.Name = "lblQuantidade";
            lblQuantidade.Size = new Size(72, 26);
            lblQuantidade.TabIndex = 50;
            lblQuantidade.Text = "Qtde:";
            lblQuantidade.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblValorUn
            // 
            lblValorUn.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValorUn.Location = new Point(40, 248);
            lblValorUn.Name = "lblValorUn";
            lblValorUn.Size = new Size(72, 26);
            lblValorUn.TabIndex = 51;
            lblValorUn.Text = "Valor Un:";
            lblValorUn.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblTotalItem
            // 
            lblTotalItem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalItem.Location = new Point(40, 280);
            lblTotalItem.Name = "lblTotalItem";
            lblTotalItem.Size = new Size(72, 26);
            lblTotalItem.TabIndex = 52;
            lblTotalItem.Text = "Total:";
            lblTotalItem.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 560);
            Controls.Add(lblTotalItem);
            Controls.Add(lblValorUn);
            Controls.Add(lblQuantidade);
            Controls.Add(txtProdutoValorTotal);
            Controls.Add(txtProdutoValorUn);
            Controls.Add(txtProdutoQtde);
            Controls.Add(lblProduto);
            Controls.Add(txtProdutoNome);
            Controls.Add(btnListaProduto);
            Controls.Add(txtProdutoCod);
            Controls.Add(dgvItens);
            Controls.Add(btnCancelar);
            Controls.Add(btnExcluirItem);
            Controls.Add(btnAlterarItem);
            Controls.Add(btnSalvarItem);
            Controls.Add(btnNovoItem);
            Controls.Add(lblData);
            Controls.Add(dtpDataPedido);
            Controls.Add(btnListaCliente);
            Controls.Add(txtCodCliente);
            Controls.Add(txtValorTotal);
            Controls.Add(lblValorTotal);
            Controls.Add(txtNomeCliente);
            Controls.Add(lblCliente);
            Controls.Add(lblContagem);
            Controls.Add(btnListaPedido);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Controls.Add(toolStrip);
            KeyPreview = true;
            Name = "frmPedidos";
            Text = "frmPedido";
            Load += frmProdutos_Load;
            KeyDown += frmPedidos_KeyDown;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvItens).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtValorTotal;
        private Label lblValorTotal;
        private TextBox txtNomeCliente;
        private Label lblCliente;
        private Label lblContagem;
        private Button btnListaPedido;
        private TextBox txtCodigo;
        private Label lblCodigo;
        private ToolStripButton toolUltimo;
        private ToolStripButton toolAnterior;
        private ToolStripButton toolPrimeiro;
        private ToolStripButton toolDesfazer;
        private ToolStripButton toolExcluir;
        private ToolStripButton toolAlterar;
        private ToolStripButton toolGravar;
        private ToolStripButton toolNovo;
        private ToolStripButton toolProximo;
        private ToolStrip toolStrip;
        private TextBox txtCodCliente;
        private Button btnListaCliente;
        private DateTimePicker dtpDataPedido;
        private Label lblData;
        private Button btnNovoItem;
        private Button btnSalvarItem;
        private Button btnAlterarItem;
        private Button btnExcluirItem;
        private Button btnCancelar;
        private DataGridView dgvItens;
        private TextBox txtProdutoCod;
        private Button btnListaProduto;
        private TextBox txtProdutoNome;
        private Label lblProduto;
        private TextBox txtProdutoQtde;
        private TextBox txtProdutoValorUn;
        private TextBox txtProdutoValorTotal;
        private Label lblQuantidade;
        private Label lblValorUn;
        private Label lblTotalItem;
    }
}