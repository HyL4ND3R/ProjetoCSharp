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
        public static void AplicarMascaraMoeda(TextBox txt)
        {
            // Alinha o texto à direita como em sistemas contábeis
            txt.TextAlign = HorizontalAlignment.Right;

            // Evento para bloquear letras
            txt.KeyPress += (sender, e) =>
            {
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)8) // Permite apenas números e Backspace
                    e.Handled = true;
            };

            // Evento para formatar o valor enquanto digita
            txt.TextChanged += (sender, e) =>
            {
                // Remove qualquer formatação anterior para pegar apenas os números
                string valorLimpo = txt.Text.Replace(",", "").Replace(".", "").TrimStart('0');

                if (string.IsNullOrEmpty(valorLimpo))
                {
                    txt.Text = "0,00";
                }
                else
                {
                    // Transforma o número em decimal (ex: 125 vira 1,25)
                    double valorDecimal = double.Parse(valorLimpo) / 100;
                    txt.Text = string.Format("{0:N2}", valorDecimal);
                }

                // Mantém o cursor sempre no final do texto
                txt.SelectionStart = txt.Text.Length;
            };

            // Inicializa com o valor padrão
            txt.Text = "0,00";
        }
    }
}
