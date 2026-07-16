public class Produto
{
    private int idProduto;
    private string nome;
    private string descricao;
    private double preco;
    private string categoria;
    private List<Fornecedor> fornecedores;
    private List<Lote> lotes;

    public Produto(int idProduto, string nome, string descricao, double preco, string categoria)
    {
        this.idProduto = idProduto;
        this.nome = nome;
        this.descricao = descricao;
        this.preco = preco;
        this.categoria = categoria;
        fornecedores = new List<Fornecedor>();
        lotes = new List<Lote>();
    }

    public void AdicionarFornecedor(Fornecedor fornecedor)
    {
        fornecedores.Add(fornecedor);
    }

    public void AdicionarLote(Lote lote)
    {
        lotes.Add(lote);
    }

    public int ObterIdProduto()
    {
        return idProduto;
    }

    public string ObterNome()
    {
        return nome;
    }

    public string ObterDescricao()
    {
        return descricao;
    }

    public double ObterPreco()
    {
        return preco;
    }

    public string ObterCategoria()
    {
        return categoria;
    }

    public int IdProduto { get {return idProduto;} set{idProduto = value;} }
    public string Nome { get{return nome;} set{nome = value;} }
    public string Descricao { get{return descricao;} set{descricao = value;} }
    public double Preco { get{return preco;} set{preco = value;} }
    public string Categoria { get{return categoria;} set{categoria = value;} }
}

public class Lote
{
    private int idLote;
    private string codigoLote;
    private int quantidadeAtual;
    private DateTime dataValidade;
    private Produto produto;

    public Lote(int idLote, string codigoLote, int quantidadeAtual, DateTime dataValidade, Produto produto)
    {
        this.idLote = idLote;
        this.codigoLote = codigoLote;
        this.quantidadeAtual = quantidadeAtual;
        this.dataValidade = dataValidade;
        this.produto = produto;
    }

    public void AdicionarQuantidade(int quantidade)
    {
        if (quantidade > 0)
        {
            quantidadeAtual += quantidade;
        }
    }

    public bool RemoverQuantidade(int quantidade)
    {
        if (quantidade > 0 && quantidade <= quantidadeAtual)
        {
            quantidadeAtual -= quantidade;
            return true;
        }
        return false;
    }

    public int ObterIdLote()
    {
        return idLote;
    }

    public string ObterCodigoLote()
    {
        return codigoLote;
    }

    public int ObterQuantidadeAtual()
    {
        return quantidadeAtual;
    }

    public DateTime ObterValidade()
    {
        return dataValidade;
    }

    public Produto ObterProduto()
    {
        return produto;
    }

    public int IdLote{get{return idLote;} set{idLote = value;}}
    public string CodigoLote{get{return codigoLote;} set{codigoLote = value;}}
    public int QuantidadeAtual{get {return quantidadeAtual;} set{quantidadeAtual = value;}}
    public DateTime DataValidade{get {return dataValidade;} set{dataValidade = value;}}
    public Produto Produto{get {return produto;} set{produto = value;}}
}