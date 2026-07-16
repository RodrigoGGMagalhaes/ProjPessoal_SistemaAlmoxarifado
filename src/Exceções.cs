public class PreçoInvalidoException : Exception
{
    public PreçoInvalidoException(string Mensagem) : base(Mensagem){}
}

public class IDsimilarException : Exception
{
    public IDsimilarException(string Mensagem) : base(Mensagem){}
}

public class QuantidadeInvalidaException : Exception
{
    public QuantidadeInvalidaException(string Mensagem) : base(Mensagem){}
}

public class DataValidadeInvalidaException : Exception
{
    public DataValidadeInvalidaException(string Mensagem) : base(Mensagem){}
}

public class TipoMovimentacaoInvalidaException : Exception
{
    public TipoMovimentacaoInvalidaException(string Mensagem) : base(Mensagem){}
}