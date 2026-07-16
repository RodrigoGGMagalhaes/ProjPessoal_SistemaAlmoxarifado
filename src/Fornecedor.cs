public class Fornecedor
{
    private int idFornecedor;
    private string nome;
    private string cnpj;
    private string telefone;
    private string email;
    private List<Produto> produtos;

    public Fornecedor(int idFornecedor, string nome, string cnpj, string telefone, string email)
    {
        this.idFornecedor = idFornecedor;
        this.nome = nome;
        this.cnpj = cnpj;
        this.telefone = telefone;
        this.email = email;
        produtos = new List<Produto>();
    }

    public void AdicionarProduto(Produto produto)
    {
        produtos.Add(produto);
    }

    public int ObterIdFornecedor()
    {
        return idFornecedor;
    }

    public string ObterNome()
    {
        return nome;
    }

    public string ObterCnpj()
    {
        return cnpj;
    }

    public string ObterTelefone()
    {
        return telefone;
    }

    public string ObterEmail()
    {
        return email;
    }

    public int IdFornecedor{get{ return idFornecedor;} set{idFornecedor = value;}}
    public string Nome{get {return nome;} set{nome = value;}}
    public string Cnpj{get{return cnpj;} set{cnpj = value;}}
    public string Telefone{get{return telefone;} set{telefone = value;}}
    public string Email{get{return email;} set{email = value;}}
}