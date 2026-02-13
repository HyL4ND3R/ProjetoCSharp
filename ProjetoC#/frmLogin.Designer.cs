namespace ProjetoC_
{
    partial class frmLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnEntrar = new Button();
            lblTitulo = new Label();
            txtLogin = new TextBox();
            txtSenha = new TextBox();
            lblLogin = new Label();
            lblSenha = new Label();
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEntrar.Location = new Point(104, 200);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(125, 33);
            btnEntrar.TabIndex = 3;
            btnEntrar.Text = "Entrar";
            btnEntrar.Click += btnEntrar_Click;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Arial", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 24);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(320, 32);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "LOGIN";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtLogin
            // 
            txtLogin.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtLogin.Location = new Point(102, 95);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(164, 26);
            txtLogin.TabIndex = 1;
            txtLogin.KeyPress += txtLogin_KeyPress;
            // 
            // txtSenha
            // 
            txtSenha.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtSenha.Location = new Point(102, 144);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.Size = new Size(164, 26);
            txtSenha.TabIndex = 2;
            txtSenha.KeyPress += txtSenha_KeyPress;
            // 
            // lblLogin
            // 
            lblLogin.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLogin.Location = new Point(40, 96);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(56, 24);
            lblLogin.TabIndex = 4;
            lblLogin.Text = "Login:";
            lblLogin.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSenha
            // 
            lblSenha.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSenha.Location = new Point(40, 144);
            lblSenha.Name = "lblSenha";
            lblSenha.Size = new Size(57, 24);
            lblSenha.TabIndex = 5;
            lblSenha.Text = "Senha:";
            lblSenha.TextAlign = ContentAlignment.MiddleRight;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(321, 287);
            Controls.Add(lblSenha);
            Controls.Add(lblLogin);
            Controls.Add(txtSenha);
            Controls.Add(txtLogin);
            Controls.Add(lblTitulo);
            Controls.Add(btnEntrar);
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEntrar;
        private Label lblTitulo;
        private TextBox txtLogin;
        private TextBox txtSenha;
        private Label lblLogin;
        private Label lblSenha;
    }
}
