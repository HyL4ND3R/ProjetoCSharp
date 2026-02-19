namespace ProjetoC_
{
    partial class frmProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProdutos));
            toolStrip = new ToolStrip();
            toolNovo = new ToolStripButton();
            toolGravar = new ToolStripButton();
            toolAlterar = new ToolStripButton();
            toolExcluir = new ToolStripButton();
            toolDesfazer = new ToolStripButton();
            toolPrimeiro = new ToolStripButton();
            toolAnterior = new ToolStripButton();
            toolProximo = new ToolStripButton();
            toolUltimo = new ToolStripButton();
            lblCodigo = new Label();
            txtCodigo = new TextBox();
            btnListaProduto = new Button();
            lblContagem = new Label();
            lblNome = new Label();
            txtNome = new TextBox();
            lblValor = new Label();
            txtValor = new TextBox();
            chkInativo = new CheckBox();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip
            // 
            toolStrip.AutoSize = false;
            toolStrip.Items.AddRange(new ToolStripItem[] { toolNovo, toolGravar, toolAlterar, toolExcluir, toolDesfazer, toolPrimeiro, toolAnterior, toolProximo, toolUltimo });
            toolStrip.Location = new Point(0, 0);
            toolStrip.Margin = new Padding(10, 10, 0, 0);
            toolStrip.Name = "toolStrip";
            toolStrip.Padding = new Padding(0);
            toolStrip.Size = new Size(800, 48);
            toolStrip.TabIndex = 5;
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
            // lblCodigo
            // 
            lblCodigo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(40, 56);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(64, 26);
            lblCodigo.TabIndex = 6;
            lblCodigo.Text = "Codigo:";
            lblCodigo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(112, 56);
            txtCodigo.MaxLength = 10;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(72, 26);
            txtCodigo.TabIndex = 9;
            txtCodigo.KeyDown += txtCodigo_KeyDown;
            // 
            // btnListaProduto
            // 
            btnListaProduto.Image = (Image)resources.GetObject("btnListaProduto.Image");
            btnListaProduto.Location = new Point(183, 55);
            btnListaProduto.Name = "btnListaProduto";
            btnListaProduto.Size = new Size(30, 28);
            btnListaProduto.TabIndex = 17;
            btnListaProduto.UseVisualStyleBackColor = true;
            btnListaProduto.Click += btnListaProduto_Click;
            // 
            // lblContagem
            // 
            lblContagem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContagem.Location = new Point(224, 56);
            lblContagem.Name = "lblContagem";
            lblContagem.Size = new Size(248, 26);
            lblContagem.TabIndex = 18;
            // 
            // lblNome
            // 
            lblNome.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNome.Location = new Point(40, 96);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(64, 26);
            lblNome.TabIndex = 19;
            lblNome.Text = "Nome:";
            lblNome.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNome.Location = new Point(112, 96);
            txtNome.MaxLength = 100;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(224, 26);
            txtNome.TabIndex = 20;
            txtNome.KeyPress += txtNome_KeyPress;
            // 
            // lblValor
            // 
            lblValor.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValor.Location = new Point(40, 136);
            lblValor.Name = "lblValor";
            lblValor.Size = new Size(64, 26);
            lblValor.TabIndex = 21;
            lblValor.Text = "Valor:";
            lblValor.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtValor
            // 
            txtValor.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtValor.Location = new Point(112, 136);
            txtValor.MaxLength = 20;
            txtValor.Name = "txtValor";
            txtValor.Size = new Size(96, 26);
            txtValor.TabIndex = 22;
            txtValor.KeyPress += txtValor_KeyPress;
            // 
            // chkInativo
            // 
            chkInativo.AutoSize = true;
            chkInativo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkInativo.Location = new Point(112, 176);
            chkInativo.Name = "chkInativo";
            chkInativo.Size = new Size(71, 22);
            chkInativo.TabIndex = 23;
            chkInativo.Text = "Inativo";
            chkInativo.UseVisualStyleBackColor = true;
            // 
            // frmProdutos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(chkInativo);
            Controls.Add(txtValor);
            Controls.Add(lblValor);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(lblContagem);
            Controls.Add(btnListaProduto);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Controls.Add(toolStrip);
            KeyPreview = true;
            Name = "frmProdutos";
            Text = "Produtos";
            Load += frmProdutos_Load;
            KeyDown += frmProdutos_KeyDown;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip;
        private ToolStripButton toolNovo;
        private ToolStripButton toolGravar;
        private ToolStripButton toolAlterar;
        private ToolStripButton toolExcluir;
        private ToolStripButton toolDesfazer;
        private ToolStripButton toolPrimeiro;
        private ToolStripButton toolAnterior;
        private ToolStripButton toolProximo;
        private ToolStripButton toolUltimo;
        private Label lblCodigo;
        private TextBox txtCodigo;
        private Button btnListaProduto;
        private Label lblContagem;
        private Label lblNome;
        private TextBox txtNome;
        private Label lblValor;
        private TextBox txtValor;
        private CheckBox chkInativo;
    }
}