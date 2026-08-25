using System;
using System.IO;

public abstract class Relatorio
{
    protected void Cabecalho(StreamWriter writer)
    {
        writer.WriteLine("=== RELATÓRIO ALMOXARIFADO ===");
        writer.WriteLine($"DATA DE EMISSÃO: {DateTime.Now}");
    }

    public abstract void Imprimir();
}

public class RelatorioEntrada : Relatorio
{
    private Movimentacao movimentacao;

    public RelatorioEntrada(Movimentacao movimentacao)
    {
        this.movimentacao = movimentacao;
    }
    public override void Imprimir()
    {
        string pasta = Path.Combine(Directory.GetCurrentDirectory(),"src");

        Directory.CreateDirectory(pasta);

        using(StreamWriter writer = new StreamWriter(Path.Combine(pasta, "RelatorioEntrada.txt")))
        {
            Cabecalho(writer);

            writer.WriteLine("RELATÓRIO DE ENTRADA");
            writer.WriteLine();

            writer.WriteLine($"ID: {movimentacao.ObterIdMovimentacao()}");
            writer.WriteLine($"DATA: {movimentacao.ObterData()}");
            writer.WriteLine($"OBSERVAÇÃO: {movimentacao.ObterObservacao()}");
            writer.WriteLine();

            writer.WriteLine("ITENS:");
            foreach(var item in movimentacao.ObterItens())
            {
                writer.WriteLine($"PRODUTO: {item.ObterLote().ObterProduto().ObterNome()}");
                writer.WriteLine($"LOTE: {item.ObterLote().ObterCodigoLote()}");
                writer.WriteLine($"QUANTIDADE: {item.ObterQuantidade()}");
                writer.WriteLine();
            }

            writer.WriteLine($"TOTAL DE ITENS MOVIMENTADOS: {movimentacao.CalcularQuantidadeTotal()}");
        }
    }
}

public class RelatorioSaida : Relatorio
{
    private Movimentacao movimentacao;

    public RelatorioSaida(Movimentacao movimentacao)
    {
        this.movimentacao = movimentacao;
    }
    public override void Imprimir()
    {
        string pasta = Path.Combine(Directory.GetCurrentDirectory(),"src");

        Directory.CreateDirectory(pasta);

        using(StreamWriter writer = new StreamWriter(Path.Combine(pasta, "RelatorioSaida.txt")))
        {
            Cabecalho(writer);

            writer.WriteLine("RELATÓRIO DE SAÍDA");
            writer.WriteLine();

            writer.WriteLine($"ID: {movimentacao.ObterIdMovimentacao()}");
            writer.WriteLine($"DATA: {movimentacao.ObterData()}");
            writer.WriteLine($"OBSERVAÇÃO: {movimentacao.ObterObservacao()}");
            writer.WriteLine();

            writer.WriteLine("ITENS:");
            foreach(var item in movimentacao.ObterItens())
            {
                writer.WriteLine($"PRODUTO: {item.ObterLote().ObterProduto().ObterNome()}");
                writer.WriteLine($"LOTE: {item.ObterLote().ObterCodigoLote()}");
                writer.WriteLine($"QUANTIDADE: {item.ObterQuantidade()}");
                writer.WriteLine();
            }

            writer.WriteLine($"TOTAL DE ITENS MOVIMENTADOS: {movimentacao.CalcularQuantidadeTotal()}");
        }
    }
}