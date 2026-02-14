using ProjetoC_.Enums;
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


        // Variável estática para controlar o reentrada no evento
        private static bool _processandoAlteracao = false;
        public static void AplicarMascaraDocumento(TextBox txt, eTipoDocumentoCliente tipo)
        {
            // Removemos eventos anteriores para evitar duplicidade
            txt.TextChanged -= Txt_TextChanged;

            // Armazenamos o tipo no "Tag" do TextBox para recuperar dentro do evento
            txt.Tag = tipo;
            txt.MaxLength = (tipo == eTipoDocumentoCliente.CPF) ? 14 : (tipo == eTipoDocumentoCliente.CNPJ ? 18 : 50);

            txt.TextChanged += Txt_TextChanged;
        }

        private static void Txt_TextChanged(object sender, EventArgs e)
        {
            if (_processandoAlteracao) return;

            var txt = (TextBox)sender;
            var tipo = (eTipoDocumentoCliente)txt.Tag;

            if (tipo == eTipoDocumentoCliente.Outros) return;

            // Pega apenas os números
            string apenasNumeros = new string(txt.Text.Where(char.IsDigit).ToArray());
            string valorFormatado = apenasNumeros;

            // Aplica a lógica de máscara
            if (tipo == eTipoDocumentoCliente.CPF && apenasNumeros.Length <= 11)
            {
                if (apenasNumeros.Length > 9) valorFormatado = apenasNumeros.Insert(9, "-").Insert(6, ".").Insert(3, ".");
                else if (apenasNumeros.Length > 6) valorFormatado = apenasNumeros.Insert(6, ".").Insert(3, ".");
                else if (apenasNumeros.Length > 3) valorFormatado = apenasNumeros.Insert(3, ".");
            }
            else if (tipo == eTipoDocumentoCliente.CNPJ && apenasNumeros.Length <= 14)
            {
                if (apenasNumeros.Length > 12) valorFormatado = apenasNumeros.Insert(12, "-").Insert(8, "/").Insert(5, ".").Insert(2, ".");
                else if (apenasNumeros.Length > 8) valorFormatado = apenasNumeros.Insert(8, "/").Insert(5, ".").Insert(2, ".");
                else if (apenasNumeros.Length > 5) valorFormatado = apenasNumeros.Insert(5, ".").Insert(2, ".");
                else if (apenasNumeros.Length > 2) valorFormatado = apenasNumeros.Insert(2, ".");
            }

            if (txt.Text != valorFormatado)
            {
                try
                {
                    _processandoAlteracao = true; // Bloqueia a reentrada
                    txt.Text = valorFormatado;
                    txt.SelectionStart = txt.Text.Length;
                }
                finally
                {
                    _processandoAlteracao = false; // Libera para a próxima digitação
                }
            }
        }
        public static bool CaractereValidoTelefone(char c)
        {
            // Permitir números, Backspace, parênteses, hífen e espaço
            string permitidos = "0123456789() -";
            return permitidos.Contains(c) || c == (char)8 || c == (char)Keys.Enter;
        }
    }
}
