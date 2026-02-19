namespace ProjetoC_
{
    partial class frmListaPesquisa
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
            dgvListaPesquisa = new DataGridView();
            btnCancelar = new Button();
            btnSelecionar = new Button();
            txtFiltro = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvListaPesquisa).BeginInit();
            SuspendLayout();
            // 
            // dgvListaPesquisa
            // 
            dgvListaPesquisa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvListaPesquisa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvListaPesquisa.Location = new Point(0, 0);
            dgvListaPesquisa.Name = "dgvListaPesquisa";
            dgvListaPesquisa.Size = new Size(800, 400);
            dgvListaPesquisa.TabIndex = 0;
            dgvListaPesquisa.CellDoubleClick += dgvListaPesquisa_CellDoubleClick;
            // 
            // btnCancelar
            // 
            btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancelar.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancelar.Location = new Point(704, 406);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(88, 32);
            btnCancelar.TabIndex = 3;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnSelecionar
            // 
            btnSelecionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSelecionar.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSelecionar.Location = new Point(616, 406);
            btnSelecionar.Name = "btnSelecionar";
            btnSelecionar.Size = new Size(88, 32);
            btnSelecionar.TabIndex = 2;
            btnSelecionar.Text = "Selecionar";
            btnSelecionar.UseVisualStyleBackColor = true;
            btnSelecionar.Click += btnSelecionar_Click;
            // 
            // txtFiltro
            // 
            txtFiltro.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtFiltro.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtFiltro.Location = new Point(8, 407);
            txtFiltro.MaxLength = 500;
            txtFiltro.Name = "txtFiltro";
            txtFiltro.Size = new Size(232, 26);
            txtFiltro.TabIndex = 1;
            txtFiltro.TextChanged += txtFiltro_TextChanged;
            // 
            // frmListaPesquisa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 440);
            Controls.Add(txtFiltro);
            Controls.Add(btnSelecionar);
            Controls.Add(btnCancelar);
            Controls.Add(dgvListaPesquisa);
            KeyPreview = true;
            Name = "frmListaPesquisa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lista de Pesquisa";
            KeyDown += frmListaPesquisa_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvListaPesquisa).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvListaPesquisa;
        private Button btnCancelar;
        private Button btnSelecionar;
        private TextBox txtFiltro;
    }
}