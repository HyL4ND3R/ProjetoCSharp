using iText.IO.Font.Constants;
using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using ProjetoC_.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace ProjetoC_.Utils
{
    public class Relatorios
    {
        public void GerarVisualizacaoPedido(Pedido pedido, BindingList<PedidoItem> itens)
        {
            // 1. Define o caminho do arquivo (Pasta Temporária)
            string caminhoPdf = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"Pedido_{pedido.Codigo}.pdf");
            PdfFont fBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            using (PdfWriter writer = new PdfWriter(caminhoPdf))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document document = new Document(pdf, PageSize.A4);
                    document.SetMargins(20, 20, 20, 20);

                    // --- CABEÇALHO ---
                    document.Add(new Paragraph("RESUMO DO PEDIDO")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(18)
                        .SetFont(fBold));


                    // Criamos uma tabela para organizar os dados do cabeçalho (2 colunas)
                    Table headerTable = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth();
                    headerTable.SetMarginTop(10);
                    headerTable.SetMarginBottom(20);

                    headerTable.AddCell(new Cell().Add(new Paragraph($"Código: {pedido.Codigo}")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                    headerTable.AddCell(new Cell().Add(new Paragraph($"Data: {pedido.DataPedido:dd/MM/yyyy}")).SetTextAlignment(TextAlignment.RIGHT).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                    headerTable.AddCell(new Cell().Add(new Paragraph($"Cliente: {pedido.ClienteNome}")).SetBorder(iText.Layout.Borders.Border.NO_BORDER));
                    headerTable.AddCell(new Cell().Add(new Paragraph($"Valor Total: {pedido.ValorTotal:C2}")).SetTextAlignment(TextAlignment.RIGHT).SetFont(fBold).SetBorder(iText.Layout.Borders.Border.NO_BORDER));

                    document.Add(headerTable);

                    // --- CORPO (ITENS) ---
                    document.Add(new Paragraph("ITENS DO PEDIDO").SetFont(fBold).SetFontSize(12));

                    // Tabela de itens (Colunas: Cod, Descrição, Qtde, Unit, Total)
                    Table table = new Table(UnitValue.CreatePercentArray(new float[] { 10, 45, 15, 15, 15 })).UseAllAvailableWidth();

                    // Estilo do Header da Tabela
                    Cell headerCell(string texto) => new Cell().Add(new Paragraph(texto).SetFont(fBold).SetFontColor(ColorConstants.WHITE)).SetBackgroundColor(ColorConstants.DARK_GRAY);

                    table.AddHeaderCell(headerCell("Cód."));
                    table.AddHeaderCell(headerCell("Descrição"));
                    table.AddHeaderCell(headerCell("Qtde"));
                    table.AddHeaderCell(headerCell("Unit."));
                    table.AddHeaderCell(headerCell("Total"));

                    foreach (var item in itens)
                    {
                        table.AddCell(new Cell().Add(new Paragraph(item.ProdutoCodigo.ToString())));
                        table.AddCell(new Cell().Add(new Paragraph(item.ProdutoDescricao)));
                        table.AddCell(new Cell().Add(new Paragraph(item.Quantidade.ToString("N2"))).SetTextAlignment(TextAlignment.RIGHT));
                        table.AddCell(new Cell().Add(new Paragraph(item.ValorUnitario.ToString("C2"))).SetTextAlignment(TextAlignment.RIGHT));
                        table.AddCell(new Cell().Add(new Paragraph(item.ValorTotal.ToString("C2"))).SetTextAlignment(TextAlignment.RIGHT));
                    }

                    document.Add(table);
                    document.Close();
                }
            }

            // 3. Abre o PDF automaticamente
            Process.Start(new ProcessStartInfo(caminhoPdf) { UseShellExecute = true });
        }

        public void GerarRelatorioPedido(List<PedidoRelatorioDTO> dados)
        {
            string caminhoPdf = System.IO.Path.Combine(System.IO.Path.GetTempPath(), "RelatorioPedidos.pdf");
            PdfFont fNormal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
            PdfFont fBold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);

            using (PdfWriter writer = new PdfWriter(caminhoPdf))
            {
                using (PdfDocument pdf = new PdfDocument(writer))
                {
                    Document doc = new Document(pdf, PageSize.A4);

                    // Cabeçalho e Filtros
                    doc.Add(new Paragraph("RELATÓRIO DE PEDIDOS").SetFont(fBold).SetFontSize(16).SetTextAlignment(TextAlignment.CENTER));
                    doc.Add(new LineSeparator(new SolidLine()));

                    // Agrupando os dados por Pedido para criar a estrutura mestre-detalhe
                    var pedidosAgrupados = dados.GroupBy(p => p.PedidoCodigo);

                    foreach (var grupo in pedidosAgrupados)
                    {
                        var infoPedido = grupo.First();

                        // Linha do Pedido (Mestre)
                        Table tabMestre = new Table(UnitValue.CreatePercentArray(new float[] { 15, 45, 20, 20 })).UseAllAvailableWidth().SetMarginTop(10);
                        tabMestre.SetBackgroundColor(ColorConstants.LIGHT_GRAY);

                        tabMestre.AddCell(new Cell().Add(new Paragraph($"Ped: {infoPedido.PedidoCodigo}").SetFont(fBold)));
                        tabMestre.AddCell(new Cell().Add(new Paragraph($"Cliente: {infoPedido.ClienteNome}").SetFont(fBold)));
                        tabMestre.AddCell(new Cell().Add(new Paragraph($"Itens: {grupo.Sum(x => x.QuantidadeTotalPedido):N2}").SetFont(fBold)));
                        tabMestre.AddCell(new Cell().Add(new Paragraph($"Total: {infoPedido.ValorTotalPedido:C2}").SetFont(fBold)));
                        doc.Add(tabMestre);

                        // Tabela de Itens (Detalhe)
                        Table tabDetalhe = new Table(UnitValue.CreatePercentArray(new float[] { 10, 45, 15, 15, 15 })).UseAllAvailableWidth();
                        tabDetalhe.AddHeaderCell(new Cell().Add(new Paragraph("Cód").SetFontSize(8).SetFont(fBold)));
                        tabDetalhe.AddHeaderCell(new Cell().Add(new Paragraph("Descrição").SetFontSize(8).SetFont(fBold)));
                        tabDetalhe.AddHeaderCell(new Cell().Add(new Paragraph("Qtde").SetFontSize(8).SetFont(fBold)));
                        tabDetalhe.AddHeaderCell(new Cell().Add(new Paragraph("V.Un").SetFontSize(8).SetFont(fBold)));
                        tabDetalhe.AddHeaderCell(new Cell().Add(new Paragraph("V.Tot").SetFontSize(8).SetFont(fBold)));

                        foreach (var item in grupo)
                        {
                            tabDetalhe.AddCell(new Cell().Add(new Paragraph(item.ProdutoCodigo.ToString()).SetFontSize(8)));
                            tabDetalhe.AddCell(new Cell().Add(new Paragraph(item.ProdutoDescricao).SetFontSize(8)));
                            tabDetalhe.AddCell(new Cell().Add(new Paragraph(item.ProdutoQuantidade.ToString("N2")).SetFontSize(8)));
                            tabDetalhe.AddCell(new Cell().Add(new Paragraph(item.ProdutoValorUn.ToString("N2")).SetFontSize(8)));
                            tabDetalhe.AddCell(new Cell().Add(new Paragraph(item.ProdutoValorTotal.ToString("N2")).SetFontSize(8)));
                        }
                        doc.Add(tabDetalhe);
                    }
                    doc.Close();
                }
            }
            Process.Start(new ProcessStartInfo(caminhoPdf) { UseShellExecute = true });
        }
    }
}
