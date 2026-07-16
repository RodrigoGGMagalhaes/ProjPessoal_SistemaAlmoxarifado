using System.Text.Json;

public static class Gerenciamento
{
    public static List<Produto> CarregarProdutos(List<Produto> produtos)
    {
        if (File.Exists("produtos.json"))
        {
            string json = File.ReadAllText("produtos.json");
            produtos = JsonSerializer.Deserialize<List<Produto>>(json);
        }

        return produtos;
    }

    public static List<Lote> CarregarLotes(List<Lote> lotes)
    {
        if (File.Exists("lotes.json"))
        {
            string json = File.ReadAllText("lotes.json");
            lotes = JsonSerializer.Deserialize<List<Lote>>(json);
        }

        return lotes;
    }

    public static List<Fornecedor> CarregarFornecedores(List<Fornecedor> fornecedores)
    {
        if (File.Exists("fornecedores.json"))
        {
            string json = File.ReadAllText("fornecedores.json");
            fornecedores = JsonSerializer.Deserialize<List<Fornecedor>>(json);
        }

        return fornecedores;
    }

    public static List<Movimentacao> CarregarMovimentacoes(List<Movimentacao> movimentacoes)
    {
        if (File.Exists("movimentacoes.json"))
        {
            string json = File.ReadAllText("movimentacoes.json");
            movimentacoes = JsonSerializer.Deserialize<List<Movimentacao>>(json);
        }

        return movimentacoes;
    }

    public static void SalvarProdutos(List<Produto> produtos)
    {
        string json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("produtos.json", json);
    }

    public static void SalvarLotes(List<Lote> lotes)
    {
        string json = JsonSerializer.Serialize(lotes, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("lotes.json", json);
    }

    public static void SalvarFornecedores(List<Fornecedor> fornecedores)
    {
        string json = JsonSerializer.Serialize(fornecedores, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("fornecedores.json", json);
    }

    public static void SalvarMovimentacoes(List<Movimentacao> movimentacoes)
    {
        string json = JsonSerializer.Serialize(movimentacoes, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("movimentacoes.json", json);
    }
}