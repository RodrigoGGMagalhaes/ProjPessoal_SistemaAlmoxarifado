using System.Text.Json;
using System.IO;

public static class Gerenciamento
{
    public static List<Produto> CarregarProdutos(List<Produto> produtos)
    {
        string caminhoArquivo = ObterCaminhoProdutos();

        if (File.Exists(caminhoArquivo))
        {
            string json = File.ReadAllText(caminhoArquivo);
            produtos = JsonSerializer.Deserialize<List<Produto>>(json)?? new List<Produto>();
        }

        return produtos;
    }

    public static List<Lote> CarregarLotes(List<Lote> lotes)
    {
        string caminhoArquivo = ObterCaminhoLotes();

        if (File.Exists(caminhoArquivo))
        {
            string json = File.ReadAllText(caminhoArquivo);
            lotes = JsonSerializer.Deserialize<List<Lote>>(json)?? new List<Lote>();
        }

        return lotes;
    }

    public static List<Fornecedor> CarregarFornecedores(List<Fornecedor> fornecedores)
    {
        string caminhoArquivo = ObterCaminhoFornecedores();

        if (File.Exists(caminhoArquivo))
        {
            string json = File.ReadAllText(caminhoArquivo);
            fornecedores = JsonSerializer.Deserialize<List<Fornecedor>>(json)?? new List<Fornecedor>();
        }

        return fornecedores;
    }

    public static List<Movimentacao> CarregarMovimentacoes(List<Movimentacao> movimentacoes)
    {
        string caminhoArquivo = ObterCaminhoMovimentacoes();

        if (File.Exists(caminhoArquivo))
        {
            string json = File.ReadAllText(caminhoArquivo);
            movimentacoes = JsonSerializer.Deserialize<List<Movimentacao>>(json)?? new List<Movimentacao>();
        }

        return movimentacoes;
    }

    public static void SalvarProdutos(List<Produto> produtos)
    {
        string caminhoArquivo = ObterCaminhoProdutos();

        string json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(caminhoArquivo, json);
    }

    public static void SalvarLotes(List<Lote> lotes)
    {
        string caminhoArquivo = ObterCaminhoLotes();

        string json = JsonSerializer.Serialize(lotes, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(caminhoArquivo, json);
    }

    public static void SalvarFornecedores(List<Fornecedor> fornecedores)
    {
        string caminhoArquivo = ObterCaminhoFornecedores();

        string json = JsonSerializer.Serialize(fornecedores, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(caminhoArquivo, json);
    }

    public static void SalvarMovimentacoes(List<Movimentacao> movimentacoes)
    {
        string caminhoArquivo = ObterCaminhoMovimentacoes();

        string json = JsonSerializer.Serialize(movimentacoes, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText(caminhoArquivo, json);
    }

    public static string ObterCaminhoProdutos()
    {
        string pasta = Path.Combine(Directory.GetCurrentDirectory(),"src");
        Directory.CreateDirectory(pasta);
        return Path.Combine(pasta, "produtos.json");
    }

    public static string ObterCaminhoLotes()
    {
        string pasta = Path.Combine(Directory.GetCurrentDirectory(),"src");

        Directory.CreateDirectory(pasta);

        return Path.Combine(pasta, "lotes.json");
    }

    public static string ObterCaminhoFornecedores()
    {
        string pasta = Path.Combine(Directory.GetCurrentDirectory(),"src");

        Directory.CreateDirectory(pasta);

        return Path.Combine(pasta, "fornecedores.json");
    }

    public static string ObterCaminhoMovimentacoes()
    {
        string pasta = Path.Combine(Directory.GetCurrentDirectory(),"src");

        Directory.CreateDirectory(pasta);

        return Path.Combine(pasta, "movimentacoes.json");
    }
}