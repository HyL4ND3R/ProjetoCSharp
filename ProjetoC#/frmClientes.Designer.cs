namespace ProjetoC_
{
    partial class frmClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClientes));
            chkInativo = new CheckBox();
            txtNome = new TextBox();
            lblNome = new Label();
            lblContagem = new Label();
            btnListaCliente = new Button();
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
            cmbTipoDocumento = new ComboBox();
            lblDocumento = new Label();
            txtDocumento = new TextBox();
            lblTelefone = new Label();
            txtTelefone = new TextBox();
            toolStrip.SuspendLayout();
            SuspendLayout();
            // 
            // chkInativo
            // 
            chkInativo.AutoSize = true;
            chkInativo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkInativo.Location = new Point(112, 216);
            chkInativo.Name = "chkInativo";
            chkInativo.Size = new Size(71, 22);
            chkInativo.TabIndex = 33;
            chkInativo.Text = "Inativo";
            chkInativo.UseVisualStyleBackColor = true;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNome.Location = new Point(112, 96);
            txtNome.MaxLength = 200;
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(240, 26);
            txtNome.TabIndex = 30;
            txtNome.KeyPress += txtNome_KeyPress;
            // 
            // lblNome
            // 
            lblNome.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNome.Location = new Point(40, 96);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(64, 26);
            lblNome.TabIndex = 29;
            lblNome.Text = "Nome:";
            lblNome.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblContagem
            // 
            lblContagem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContagem.Location = new Point(224, 56);
            lblContagem.Name = "lblContagem";
            lblContagem.Size = new Size(248, 26);
            lblContagem.TabIndex = 28;
            // 
            // btnListaCliente
            // 
            btnListaCliente.Image = (Image)resources.GetObject("btnListaCliente.Image");
            btnListaCliente.Location = new Point(183, 55);
            btnListaCliente.Name = "btnListaCliente";
            btnListaCliente.Size = new Size(30, 28);
            btnListaCliente.TabIndex = 27;
            btnListaCliente.UseVisualStyleBackColor = true;
            btnListaCliente.Click += btnListaCliente_Click;
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(112, 56);
            txtCodigo.MaxLength = 10;
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(72, 26);
            txtCodigo.TabIndex = 26;
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
            toolStrip.Size = new Size(800, 48);
            toolStrip.TabIndex = 24;
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoDocumento.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Location = new Point(112, 136);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(80, 26);
            cmbTipoDocumento.TabIndex = 34;
            cmbTipoDocumento.SelectedIndexChanged += cmbTipoDocumento_SelectedIndexChanged;
            cmbTipoDocumento.KeyPress += cmbTipoDocumento_KeyPress;
            // 
            // lblDocumento
            // 
            lblDocumento.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDocumento.Location = new Point(8, 136);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(96, 26);
            lblDocumento.TabIndex = 35;
            lblDocumento.Text = "Documento:";
            lblDocumento.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDocumento
            // 
            txtDocumento.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDocumento.Location = new Point(200, 136);
            txtDocumento.MaxLength = 200;
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(152, 26);
            txtDocumento.TabIndex = 36;
            txtDocumento.KeyPress += txtDocumento_KeyPress;
            // 
            // lblTelefone
            // 
            lblTelefone.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTelefone.Location = new Point(32, 176);
            lblTelefone.Name = "lblTelefone";
            lblTelefone.Size = new Size(72, 26);
            lblTelefone.TabIndex = 37;
            lblTelefone.Text = "Telefone:";
            lblTelefone.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtTelefone
            // 
            txtTelefone.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTelefone.Location = new Point(112, 176);
            txtTelefone.MaxLength = 200;
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(160, 26);
            txtTelefone.TabIndex = 38;
            txtTelefone.KeyPress += txtTelefone_KeyPress;
            // 
            // frmClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtTelefone);
            Controls.Add(lblTelefone);
            Controls.Add(txtDocumento);
            Controls.Add(lblDocumento);
            Controls.Add(cmbTipoDocumento);
            Controls.Add(chkInativo);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(lblContagem);
            Controls.Add(btnListaCliente);
            Controls.Add(txtCodigo);
            Controls.Add(lblCodigo);
            Controls.Add(toolStrip);
            KeyPreview = true;
            Name = "frmClientes";
            Text = "Clientes";
            Load += frmClientes_Load;
            KeyDown += frmClientes_KeyDown;
            toolStrip.ResumeLayout(false);
            toolStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox chkInativo;
        private TextBox txtNome;
        private Label lblNome;
        private Label lblContagem;
        private Button btnListaCliente;
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
        private ComboBox cmbTipoDocumento;
        private Label lblDocumento;
        private TextBox txtDocumento;
        private Label lblTelefone;
        private TextBox txtTelefone;
    }
}