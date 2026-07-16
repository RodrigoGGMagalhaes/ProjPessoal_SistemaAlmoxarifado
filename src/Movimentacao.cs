public class Movimentacao
{
    private int idMovimentacao;
    private DateTime data;
    private string tipo;
    private string observacao;
    private List<ItemMovimentacao> itens;

    public Movimentacao(int idMovimentacao, DateTime data, string tipo, string observacao)
    {
        this.idMovimentacao = idMovimentacao;
        this.data = data;
        this.tipo = tipo;
        this.observacao = observacao;
        itens = new List<ItemMovimentacao>();
    }

    public void AdicionarItem(ItemMovimentacao item)
    {
        itens.Add(item);
    }

    public int CalcularQuantidadeTotal()
    {
        int total = 0;
        foreach (ItemMovimentacao item in itens)
        {
            total += item.ObterQuantidade();
        }
        return total;
    }

    public int ObterIdMovimentacao()
    {
        return idMovimentacao;
    }

    public DateTime ObterData()
    {
        return data;
    }

    public string ObterTipo()
    {
        return tipo;
    }

    public string ObterObservacao()
    {
        return observacao;
    }

    public List<ItemMovimentacao> ObterItens()
    {
        return itens;
    }

    public int IdMovimentacao{get{return idMovimentacao;} set{idMovimentacao = value;}}
    public DateTime Data{get{return data;} set{data = value;}}
    public string Tipo{get{return tipo;} set{tipo = value;}}
    public string Observacao{get{return observacao;} set{observacao = value;}}
    public List<ItemMovimentacao> Itens{get{return itens;} set{itens = value;}}
}

public class ItemMovimentacao
{
    private Lote lote;
    private int quantidade;

    public ItemMovimentacao(Lote lote, int quantidade)
    {
        this.lote = lote;
        this.quantidade = quantidade;
    }

    public Lote ObterLote()
    {
        return lote;
    }

    public int ObterQuantidade()
    {
        return quantidade;
    }

    public Lote Lote{get{return lote;} set{lote = value;}}
    public int Quantidade{get{return quantidade;} set{quantidade = value;}}
}