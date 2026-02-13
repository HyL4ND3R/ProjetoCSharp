using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoC_.Utils
{
    public static class FuncoesUI
    {
        public static void AdicionarSelecaoAoFoco(Control container)
        {
            foreach (Control c in container.Controls)
            {
                // Se for um TextBox, assina o evento
                if (c is TextBox txt)
                {
                    txt.Enter += (sender, e) =>
                    {
                        // O BeginInvoke é necessário para garantir que a seleção ocorra 
                        // após o clique do mouse ser processado pelo Windows
                        txt.BeginInvoke((MethodInvoker)delegate
                        {
                            txt.SelectAll();
                        });
                    };
                }

                // Se o controle tiver "filhos" (como um Panel ou GroupBox), faz a busca neles também (recursividade)
                if (c.HasChildren)
                {
                    AdicionarSelecaoAoFoco(c);
                }
            }
        }
    }
}
