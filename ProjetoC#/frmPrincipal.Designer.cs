namespace ProjetoC_
{
    partial class frmPrincipal
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
            menuStrip1 = new MenuStrip();
            menuOperadores = new ToolStripMenuItem();
            menuClientes = new ToolStripMenuItem();
            menuProdutos = new ToolStripMenuItem();
            menuPedidos = new ToolStripMenuItem();
            menuRelatorioPedidos = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuOperadores, menuClientes, menuProdutos, menuPedidos, menuRelatorioPedidos });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1325, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuOperadores
            // 
            menuOperadores.Name = "menuOperadores";
            menuOperadores.Size = new Size(80, 20);
            menuOperadores.Text = "Operadores";
            menuOperadores.Click += menuOperadores_Click;
            // 
            // menuClientes
            // 
            menuClientes.Name = "menuClientes";
            menuClientes.Size = new Size(61, 20);
            menuClientes.Text = "Clientes";
            // 
            // menuProdutos
            // 
            menuProdutos.Name = "menuProdutos";
            menuProdutos.Size = new Size(67, 20);
            menuProdutos.Text = "Produtos";
            // 
            // menuPedidos
            // 
            menuPedidos.Name = "menuPedidos";
            menuPedidos.Size = new Size(61, 20);
            menuPedidos.Text = "Pedidos";
            // 
            // menuRelatorioPedidos
            // 
            menuRelatorioPedidos.Name = "menuRelatorioPedidos";
            menuRelatorioPedidos.Size = new Size(111, 20);
            menuRelatorioPedidos.Text = "Relatório Pedidos";
            // 
            // frmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1325, 637);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "frmPrincipal";
            Text = "Principal";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuOperadores;
        private ToolStripMenuItem menuClientes;
        private ToolStripMenuItem menuProdutos;
        private ToolStripMenuItem menuPedidos;
        private ToolStripMenuItem menuRelatorioPedidos;
    }
}