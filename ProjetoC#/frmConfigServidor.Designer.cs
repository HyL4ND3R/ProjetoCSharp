namespace ProjetoC_
{
    partial class frmConfigServidor
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
            txtUrl = new TextBox();
            lblUrl = new Label();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // txtUrl
            // 
            txtUrl.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUrl.Location = new Point(104, 40);
            txtUrl.MaxLength = 200;
            txtUrl.Name = "txtUrl";
            txtUrl.Size = new Size(264, 26);
            txtUrl.TabIndex = 0;
            txtUrl.KeyDown += txtUrl_KeyDown;
            // 
            // lblUrl
            // 
            lblUrl.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUrl.Location = new Point(24, 40);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(80, 23);
            lblUrl.TabIndex = 1;
            lblUrl.Text = "Caminho:";
            lblUrl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnSalvar
            // 
            btnSalvar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSalvar.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSalvar.Location = new Point(280, 104);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(90, 30);
            btnSalvar.TabIndex = 2;
            btnSalvar.Text = "Salvar";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // frmConfigServidor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 167);
            Controls.Add(btnSalvar);
            Controls.Add(lblUrl);
            Controls.Add(txtUrl);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "frmConfigServidor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Config. Servidor";
            KeyDown += frmConfigServidor_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txtUrl;
        private Label lblUrl;
        private Button btnSalvar;
    }
}