namespace ProjetoC_
{
    partial class frmRelPedidos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRelPedidos));
            lblDataInicial = new Label();
            dtpDataInicial = new DateTimePicker();
            lblDataFinal = new Label();
            dtpDataFinal = new DateTimePicker();
            btnListaCliente = new Button();
            txtCodCliente = new TextBox();
            txtNomeCliente = new TextBox();
            txtProdutoNome = new TextBox();
            btnListaProduto = new Button();
            txtProdutoCod = new TextBox();
            lblCliente = new Label();
            lblProduto = new Label();
            btnVisualizar = new Button();
            SuspendLayout();
            // 
            // lblDataInicial
            // 
            lblDataInicial.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDataInicial.Location = new Point(32, 24);
            lblDataInicial.Name = "lblDataInicial";
            lblDataInicial.Size = new Size(96, 26);
            lblDataInicial.TabIndex = 38;
            lblDataInicial.Text = "Data Inicial:";
            lblDataInicial.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpDataInicial
            // 
            dtpDataInicial.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDataInicial.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDataInicial.Format = DateTimePickerFormat.Short;
            dtpDataInicial.Location = new Point(136, 24);
            dtpDataInicial.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            dtpDataInicial.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpDataInicial.Name = "dtpDataInicial";
            dtpDataInicial.Size = new Size(120, 26);
            dtpDataInicial.TabIndex = 1;
            dtpDataInicial.Value = new DateTime(2026, 2, 13, 23, 25, 2, 0);
            dtpDataInicial.KeyDown += dtpDataInicial_KeyDown;
            // 
            // lblDataFinal
            // 
            lblDataFinal.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDataFinal.Location = new Point(32, 64);
            lblDataFinal.Name = "lblDataFinal";
            lblDataFinal.Size = new Size(96, 26);
            lblDataFinal.TabIndex = 39;
            lblDataFinal.Text = "Data Final:";
            lblDataFinal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // dtpDataFinal
            // 
            dtpDataFinal.CalendarFont = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDataFinal.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDataFinal.Format = DateTimePickerFormat.Short;
            dtpDataFinal.Location = new Point(136, 64);
            dtpDataFinal.MaxDate = new DateTime(2100, 12, 31, 0, 0, 0, 0);
            dtpDataFinal.MinDate = new DateTime(1900, 1, 1, 0, 0, 0, 0);
            dtpDataFinal.Name = "dtpDataFinal";
            dtpDataFinal.Size = new Size(120, 26);
            dtpDataFinal.TabIndex = 2;
            dtpDataFinal.Value = new DateTime(2026, 2, 13, 23, 25, 2, 0);
            dtpDataFinal.KeyDown += dtpDataFinal_KeyDown;
            // 
            // btnListaCliente
            // 
            btnListaCliente.Image = (Image)resources.GetObject("btnListaCliente.Image");
            btnListaCliente.Location = new Point(207, 103);
            btnListaCliente.Name = "btnListaCliente";
            btnListaCliente.Size = new Size(30, 28);
            btnListaCliente.TabIndex = 96;
            btnListaCliente.UseVisualStyleBackColor = true;
            btnListaCliente.Click += btnListaCliente_Click;
            // 
            // txtCodCliente
            // 
            txtCodCliente.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCodCliente.Location = new Point(136, 104);
            txtCodCliente.MaxLength = 10;
            txtCodCliente.Name = "txtCodCliente";
            txtCodCliente.Size = new Size(72, 26);
            txtCodCliente.TabIndex = 3;
            txtCodCliente.KeyDown += txtCodCliente_KeyDown;
            txtCodCliente.KeyPress += txtCodCliente_KeyPress;
            // 
            // txtNomeCliente
            // 
            txtNomeCliente.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNomeCliente.Location = new Point(236, 104);
            txtNomeCliente.MaxLength = 200;
            txtNomeCliente.Name = "txtNomeCliente";
            txtNomeCliente.Size = new Size(192, 26);
            txtNomeCliente.TabIndex = 97;
            // 
            // txtProdutoNome
            // 
            txtProdutoNome.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdutoNome.Location = new Point(236, 144);
            txtProdutoNome.MaxLength = 200;
            txtProdutoNome.Name = "txtProdutoNome";
            txtProdutoNome.Size = new Size(192, 26);
            txtProdutoNome.TabIndex = 99;
            // 
            // btnListaProduto
            // 
            btnListaProduto.Image = (Image)resources.GetObject("btnListaProduto.Image");
            btnListaProduto.Location = new Point(207, 143);
            btnListaProduto.Name = "btnListaProduto";
            btnListaProduto.Size = new Size(30, 28);
            btnListaProduto.TabIndex = 98;
            btnListaProduto.UseVisualStyleBackColor = true;
            btnListaProduto.Click += btnListaProduto_Click;
            // 
            // txtProdutoCod
            // 
            txtProdutoCod.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProdutoCod.Location = new Point(136, 144);
            txtProdutoCod.MaxLength = 10;
            txtProdutoCod.Name = "txtProdutoCod";
            txtProdutoCod.Size = new Size(72, 26);
            txtProdutoCod.TabIndex = 4;
            txtProdutoCod.KeyDown += txtProdutoCod_KeyDown;
            txtProdutoCod.KeyPress += txtProdutoCod_KeyPress;
            // 
            // lblCliente
            // 
            lblCliente.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCliente.Location = new Point(32, 104);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(96, 26);
            lblCliente.TabIndex = 47;
            lblCliente.Text = "Cliente:";
            lblCliente.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblProduto
            // 
            lblProduto.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProduto.Location = new Point(32, 144);
            lblProduto.Name = "lblProduto";
            lblProduto.Size = new Size(96, 26);
            lblProduto.TabIndex = 48;
            lblProduto.Text = "Produto:";
            lblProduto.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnVisualizar
            // 
            btnVisualizar.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnVisualizar.Location = new Point(184, 192);
            btnVisualizar.Name = "btnVisualizar";
            btnVisualizar.Size = new Size(100, 35);
            btnVisualizar.TabIndex = 5;
            btnVisualizar.Text = "Visualizar";
            btnVisualizar.UseVisualStyleBackColor = true;
            btnVisualizar.Click += btnVisualizar_Click;
            btnVisualizar.KeyDown += btnVisualizar_KeyDown;
            // 
            // frmRelPedidos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(532, 330);
            Controls.Add(btnVisualizar);
            Controls.Add(lblProduto);
            Controls.Add(lblCliente);
            Controls.Add(txtProdutoNome);
            Controls.Add(btnListaProduto);
            Controls.Add(txtProdutoCod);
            Controls.Add(btnListaCliente);
            Controls.Add(txtCodCliente);
            Controls.Add(txtNomeCliente);
            Controls.Add(dtpDataFinal);
            Controls.Add(lblDataFinal);
            Controls.Add(lblDataInicial);
            Controls.Add(dtpDataInicial);
            Name = "frmRelPedidos";
            Text = "frmRelPedidos";
            Load += frmRelPedidos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblDataInicial;
        private DateTimePicker dtpDataInicial;
        private Label lblDataFinal;
        private DateTimePicker dtpDataFinal;
        private Button btnListaCliente;
        private TextBox txtCodCliente;
        private TextBox txtNomeCliente;
        private TextBox txtProdutoNome;
        private Button btnListaProduto;
        private TextBox txtProdutoCod;
        private Label lblCliente;
        private Label lblProduto;
        private Button btnVisualizar;
    }
}