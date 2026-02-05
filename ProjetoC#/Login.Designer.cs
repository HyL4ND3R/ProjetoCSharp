namespace ProjetoC_
{
    partial class Login
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
            SuspendLayout();
            // 
            // btnEntrar
            // 
            btnEntrar.Location = new Point(123, 273);
            btnEntrar.Name = "btnEntrar";
            btnEntrar.Size = new Size(91, 41);
            btnEntrar.TabIndex = 0;
            btnEntrar.Text = "Entrar";
            btnEntrar.Click += btnEntrar_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(340, 360);
            Controls.Add(btnEntrar);
            Name = "Login";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnEntrar;
    }
}
