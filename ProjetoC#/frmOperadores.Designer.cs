namespace ProjetoC_
{
    partial class frmOperadores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOperadores));
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
            lblSenha = new Label();
            txtCodigo = new TextBox();
            lblNome = new Label();
            txtNome = new TextBox();
            txtSenha = new TextBox();
            chkAdmin = new CheckBox();
            chkInativo = new CheckBox();
            btnListaOperador = new Button();
            lblContagem = new Label();
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
            toolStrip.TabIndex = 4;
            // 
            // toolNovo
            // 
            toolNovo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolNovo.Image = (Image)resources.GetObject("toolNovo.Image");
            toolNovo.ImageScaling = ToolStripItemImageScaling.None;
            toolNovo.ImageTransparentColor = Color.Magenta;
            toolNovo.Margin = new Padding(0, 3, 0, 0);
            toolNovo.Name = "toolNovo";
            toolNovo.Padding = new Padding(5, 0, 0, 0);
            toolNovo.Size = new Size(41, 45);
            toolNovo.Click += toolNovo_Click;
            // 
            // toolGravar
            // 
            toolGravar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolGravar.Image = (Image)resources.GetObject("toolGravar.Image");
            toolGravar.ImageScaling = ToolStripItemImageScaling.None;
            toolGravar.ImageTransparentColor = Color.Magenta;
            toolGravar.Margin = new Padding(0, 3, 0, 0);
            toolGravar.Name = "toolGravar";
            toolGravar.Padding = new Padding(5, 0, 0, 0);
            toolGravar.Size = new Size(41, 45);
            toolGravar.Click += toolGravar_Click;
            // 
            // toolAlterar
            // 
            toolAlterar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolAlterar.Image = (Image)resources.GetObject("toolAlterar.Image");
            toolAlterar.ImageScaling = ToolStripItemImageScaling.None;
            toolAlterar.ImageTransparentColor = Color.Magenta;
            toolAlterar.Margin = new Padding(0, 3, 0, 0);
            toolAlterar.Name = "toolAlterar";
            toolAlterar.Padding = new Padding(5, 0, 0, 0);
            toolAlterar.Size = new Size(41, 45);
            toolAlterar.Click += toolAlterar_Click;
            // 
            // toolExcluir
            // 
            toolExcluir.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolExcluir.Image = (Image)resources.GetObject("toolExcluir.Image");
            toolExcluir.ImageScaling = ToolStripItemImageScaling.None;
            toolExcluir.ImageTransparentColor = Color.Magenta;
            toolExcluir.Margin = new Padding(0, 3, 0, 0);
            toolExcluir.Name = "toolExcluir";
            toolExcluir.Padding = new Padding(5, 0, 0, 0);
            toolExcluir.Size = new Size(41, 45);
            toolExcluir.Click += toolExcluir_Click;
            // 
            // toolDesfazer
            // 
            toolDesfazer.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolDesfazer.Image = (Image)resources.GetObject("toolDesfazer.Image");
            toolDesfazer.ImageScaling = ToolStripItemImageScaling.None;
            toolDesfazer.ImageTransparentColor = Color.Magenta;
            toolDesfazer.Margin = new Padding(0, 3, 0, 0);
            toolDesfazer.Name = "toolDesfazer";
            toolDesfazer.Padding = new Padding(5, 0, 0, 0);
            toolDesfazer.Size = new Size(41, 45);
            toolDesfazer.Text = "toolStripButton1";
            toolDesfazer.Click += toolDesfazer_Click;
            // 
            // toolPrimeiro
            // 
            toolPrimeiro.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolPrimeiro.Image = (Image)resources.GetObject("toolPrimeiro.Image");
            toolPrimeiro.ImageScaling = ToolStripItemImageScaling.None;
            toolPrimeiro.ImageTransparentColor = Color.Magenta;
            toolPrimeiro.Margin = new Padding(10, 3, 0, 0);
            toolPrimeiro.Name = "toolPrimeiro";
            toolPrimeiro.Padding = new Padding(5, 0, 0, 0);
            toolPrimeiro.Size = new Size(41, 45);
            toolPrimeiro.Click += toolPrimeiro_Click;
            // 
            // toolAnterior
            // 
            toolAnterior.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolAnterior.Image = (Image)resources.GetObject("toolAnterior.Image");
            toolAnterior.ImageScaling = ToolStripItemImageScaling.None;
            toolAnterior.ImageTransparentColor = Color.Magenta;
            toolAnterior.Margin = new Padding(0, 3, 0, 0);
            toolAnterior.Name = "toolAnterior";
            toolAnterior.Size = new Size(36, 45);
            toolAnterior.Click += toolAnterior_Click;
            // 
            // toolProximo
            // 
            toolProximo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolProximo.Image = (Image)resources.GetObject("toolProximo.Image");
            toolProximo.ImageScaling = ToolStripItemImageScaling.None;
            toolProximo.ImageTransparentColor = Color.Magenta;
            toolProximo.Margin = new Padding(0, 3, 0, 0);
            toolProximo.Name = "toolProximo";
            toolProximo.Size = new Size(36, 45);
            toolProximo.Click += toolProximo_Click;
            // 
            // toolUltimo
            // 
            toolUltimo.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolUltimo.Image = (Image)resources.GetObject("toolUltimo.Image");
            toolUltimo.ImageScaling = ToolStripItemImageScaling.None;
            toolUltimo.ImageTransparentColor = Color.Magenta;
            toolUltimo.Margin = new Padding(0, 3, 0, 0);
            toolUltimo.Name = "toolUltimo";
            toolUltimo.Size = new Size(36, 45);
            toolUltimo.Click += toolUltimo_Click;
            // 
            // lblCodigo
            // 
            lblCodigo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCodigo.Location = new Point(40, 56);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(64, 26);
            lblCodigo.TabIndex = 5;
            lblCodigo.Text = "Codigo:";
            lblCodigo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSenha
            // 
            lblSenha.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSenha.Location = new Point(40, 136);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(64, 26);
            lblSenha.TabIndex = 7;
            lblSenha.Text = "Senha:";
            lblSenha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtCodigo
            // 
            txtCodigo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodigo.Location = new Point(112, 56);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(72, 26);
            txtCodigo.TabIndex = 8;
            // 
            // lblNome
            // 
            lblNome.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNome.Location = new Point(40, 96);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(64, 26);
            lblNome.TabIndex = 11;
            lblNome.Text = "Nome:";
            lblNome.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtNome
            // 
            txtNome.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNome.Location = new Point(112, 96);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(168, 26);
            txtNome.TabIndex = 12;
            // 
            // txtSenha
            // 
            txtSenha.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSenha.Location = new Point(112, 136);
            txtSenha.Name = "txtSenha";
            txtSenha.Size = new Size(168, 26);
            txtSenha.TabIndex = 13;
            // 
            // chkAdmin
            // 
            chkAdmin.AutoSize = true;
            chkAdmin.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkAdmin.Location = new Point(112, 176);
            chkAdmin.Name = "chkAdmin";
            chkAdmin.Size = new Size(125, 22);
            chkAdmin.TabIndex = 14;
            chkAdmin.Text = "Administrador";
            chkAdmin.UseVisualStyleBackColor = true;
            // 
            // chkInativo
            // 
            chkInativo.AutoSize = true;
            chkInativo.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            chkInativo.Location = new Point(112, 208);
            chkInativo.Name = "chkInativo";
            chkInativo.Size = new Size(71, 22);
            chkInativo.TabIndex = 15;
            chkInativo.Text = "Inativo";
            chkInativo.UseVisualStyleBackColor = true;
            // 
            // btnListaOperador
            // 
            btnListaOperador.Image = (Image)resources.GetObject("btnListaOperador.Image");
            btnListaOperador.Location = new Point(183, 55);
            btnListaOperador.Name = "btnListaOperador";
            btnListaOperador.Size = new Size(30, 28);
            btnListaOperador.TabIndex = 16;
            btnListaOperador.UseVisualStyleBackColor = true;
            // 
            // lblContagem
            // 
            lblContagem.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContagem.Location = new Point(240, 56);
            lblContagem.Name = "lblContagem";
            lblContagem.Size = new Size(248, 26);
            lblContagem.TabIndex = 17;
            // 
            // frmOperadores
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblContagem);
            Controls.Add(btnListaOperador);
            Controls.Add(chkInativo);
            Controls.Add(chkAdmin);
            Controls.Add(txtSenha);
            Controls.Add(txtNome);
            Controls.Add(lblNome);
            Controls.Add(txtCodigo);
            Controls.Add(lblSenha);
            Controls.Add(lblCodigo);
            Controls.Add(toolStrip);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmOperadores";
            StartPosition = FormStartPosition.CenterParent;
            Text = "frmOperadores";
            Load += frmOperadores_Load;
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
        private Label lblCodigo;
        private Label lblSenha;
        private TextBox txtCodigo;
        private Label lblNome;
        private TextBox txtNome;
        private TextBox txtSenha;
        private CheckBox chkAdmin;
        private CheckBox chkInativo;
        private Button btnListaOperador;
        private ToolStripButton toolDesfazer;
        private ToolStripButton toolPrimeiro;
        private ToolStripButton toolAnterior;
        private ToolStripButton toolProximo;
        private ToolStripButton toolUltimo;
        private Label lblContagem;
    }
}