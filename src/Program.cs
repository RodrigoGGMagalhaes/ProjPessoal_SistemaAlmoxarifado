using System.Text.Json;

class Program
{
    static List<Produto> produtos = new List<Produto>();
    static List<Fornecedor> fornecedores = new List<Fornecedor>();
    static List<Lote> lotes = new List<Lote>();
    static List<Movimentacao> movimentacoes = new List<Movimentacao>();

    static void Main()
    {
        Gerenciamento.CarregarProdutos(produtos);
        Gerenciamento.CarregarLotes(lotes);
        Gerenciamento.CarregarFornecedores(fornecedores);
        Gerenciamento.CarregarMovimentacoes(movimentacoes);
        
        int paginaMenu = 4;

        try
        {
            do
            {
                Console.Clear();

                Console.WriteLine("=== SISTEMA ALMOXARIFADO ===");
                Console.WriteLine();

                Console.WriteLine("1 - Cadastro de Informações");
                Console.WriteLine("2 - Obter Informações");
                Console.WriteLine("3 - Impressão de Relatórios");
                Console.WriteLine("0 - Sair");

                Console.Write("ESCOLHA: ");
                paginaMenu = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (paginaMenu)
                {
                    case 0:
                    Console.WriteLine("Obrigado por utilizar nosso sistema!");
                    Gerenciamento.SalvarProdutos(produtos);
                    Gerenciamento.SalvarLotes(lotes);
                    Gerenciamento.SalvarFornecedores(fornecedores);
                    Gerenciamento.SalvarMovimentacoes(movimentacoes);
                    break;

                    case 1:
                    Cadastros();
                    break;

                    case 2:
                    Listagem();
                    break;

                    case 3:
                    ImprimirRelatorio();
                    break;
                
                    default:
                    Console.WriteLine($"Número inválido!\n(Clique novamente para continuar)");
                    Console.ReadKey();
                    Console.WriteLine();
                    break;
                }


            }while(paginaMenu != 0); 
        }
        catch (System.FormatException)
        {
            Console.WriteLine($"Valor inválido!\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
        }
        
    }
    public static void Cadastros()
    {
        Console.Clear();

        int paginaCadastro;

        Console.WriteLine("=== CADASTROS ===");
        Console.WriteLine();

        Console.WriteLine("Cadastro a ser realizado: ");
        Console.WriteLine("1 - Produto");
        Console.WriteLine("2 - Lote");
        Console.WriteLine("3 - Fornecedor");
        Console.WriteLine("4 - Movimentação");
        Console.WriteLine("0 - Cancelar");

        try
        {
            Console.Write("ESCOLHA: ");
            paginaCadastro = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (paginaCadastro)
            {
                case 0:
                Console.WriteLine($"Voltando ao menu...\n(Clique novamente para continuar)");
                Console.ReadKey();
                Console.WriteLine();
                break;

                case 1:
                CadastroProduto();
                break;

                case 2:
                CadastroLote();
                break;

                case 3:
                CadastroFornecedor();
                break;

                case 4:
                CadastroMovimentacao();
                break;
            
                default:
                Console.WriteLine($"Número inválido!\n(Clique novamente para continuar)");
                Console.ReadKey();
                Console.WriteLine();
                break;
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine($"Valor inválido!\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
        }
    }

    public static void CadastroProduto()
    {
        int idProduto;
        string nome;
        string descricao;
        double preco;
        string categoria;

        Console.Clear();

        try
        {
            Console.Write("ID: ");
            idProduto = int.Parse(Console.ReadLine());

            foreach (Produto item in produtos)
                if (idProduto == item.ObterIdProduto())
                    throw new IDsimilarException("Dois produtos não podem ter o mesmo ID!");
                
            
        }
        catch (IDsimilarException ex)
        {
            Console.WriteLine($"{ex.Message}\n(Clique novamente para continuar)");
            Console.ReadKey();
            return;
        }
        

        Console.Write("NOME: ");
        nome = Console.ReadLine();

        Console.Write("DESCRIÇÃO: ");
        descricao = Console.ReadLine();

        try
        {
            Console.Write("PREÇO: ");
            preco = double.Parse(Console.ReadLine());
            
            if(preco <= 0)
                throw new PreçoInvalidoException("Preço não pode ser menor ou igual a zero!");
        }
        catch (PreçoInvalidoException ex)
        {
            Console.WriteLine($"{ex.Message}\n(Clique novamente para continuar)");
            Console.ReadKey();
            return;
        }

        Console.Write("CATEGORIA: ");
        categoria = Console.ReadLine();

        Produto produto = new Produto(idProduto, nome, descricao, preco, categoria);
        produtos.Add(produto);

        Console.WriteLine($"Cadastro realizado com sucesso!\n(Clique novamente para voltar ao menu)");
        Console.ReadKey();
    }
    public static void CadastroLote()
    {
        int idProduto;
        int idLote;
        string codigoLote;
        int quantidade;
        DateTime dataValidade;

        Console.Clear();

        Console.WriteLine("Produtos cadastrados:");

        foreach (Produto produto in produtos)
            Console.WriteLine($"{produto.ObterIdProduto()} - {produto.ObterNome()}");

        Console.Write("Informe o ID do produto: ");
        idProduto = int.Parse(Console.ReadLine());

        Produto produtoSelecionado = null;

        foreach (Produto produto in produtos)
            if (produto.ObterIdProduto() == idProduto)
            {
                produtoSelecionado = produto;
                break;
            }

        if (produtoSelecionado == null)
        {
            Console.WriteLine($"Produto não encontrado!\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            Console.WriteLine();
            return;
        }

        try
        {
            Console.Write("ID: ");
            idLote = int.Parse(Console.ReadLine());

            foreach (Lote item in lotes)
            {
                if (idLote == item.ObterIdLote())
                    throw new IDsimilarException("Dois lotes não podem ter o mesmo ID!");
                
            }
        }
        catch (IDsimilarException ex)
        {
            Console.WriteLine($"{ex.Message}\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            return;
        }

        Console.Write("CÓDIGO DO LOTE: ");
        codigoLote = Console.ReadLine();

        try
        {
            Console.Write("QUANTIDADE: ");
            quantidade = int.Parse(Console.ReadLine());

            if (quantidade < 0)
                throw new QuantidadeInvalidaException("Quantidade do lote não pode ser negativa!");
            
        }
        catch (System.FormatException)
        {
            Console.WriteLine($"Valor inválido!\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            return;
        }
        catch (QuantidadeInvalidaException ex)
        {
            Console.WriteLine($"{ex.Message}\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            return;
        }

        try
        {
            Console.Write("VALIDADE: ");
            dataValidade = DateTime.Parse(Console.ReadLine());

            if (dataValidade <= DateTime.Today)
                throw new DataValidadeInvalidaException("A data de validade não pode ser igual ou anterior a data de hoje!");
            
        }
        catch (DataValidadeInvalidaException ex)
        {
            Console.WriteLine($"{ex.Message}\n(Clique novamente para continuar)");
            Console.ReadKey();
            return;
        }
        

        Lote lote = new Lote(idLote, codigoLote, quantidade, dataValidade, produtoSelecionado);
        lotes.Add(lote);
        produtoSelecionado.AdicionarLote(lote);
        
        Console.WriteLine($"Cadastro realizado com sucesso!\n(Clique novamente para voltar ao menu)");
        Console.ReadKey();
    }
    public static void CadastroFornecedor()
    {
        int idFornecedor;
        string nome;
        string cnpj;
        string telefone;
        string email;

        Console.Clear();

        try
        {
            Console.Write("ID: ");
            idFornecedor = int.Parse(Console.ReadLine());

            foreach (Fornecedor item in fornecedores)
                if (idFornecedor == item.ObterIdFornecedor())
                    throw new IDsimilarException("Dois fornecedores não podem ter o mesmo ID!");
                
            
        }
        catch (IDsimilarException ex)
        {
            Console.WriteLine($"{ex.Message}\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            return;
        }

        Console.Write("NOME: ");
        nome = Console.ReadLine();

        Console.Write("CNPJ: ");
        cnpj = Console.ReadLine();

        Console.Write("TELEFONE: ");
        telefone = Console.ReadLine();

        Console.Write("E-MAIL: ");
        email = Console.ReadLine();
        
        Fornecedor fornecedor = new Fornecedor(idFornecedor, nome, cnpj, telefone, email);
        fornecedores.Add(fornecedor);

        Console.WriteLine($"Cadastro realizado com sucesso!\n(Clique novamente para voltar ao menu)");
        Console.ReadKey();
    }
    public static void CadastroMovimentacao()
    {
        int idMovimentacao = 0;
        string tipo;
        string observacao;

        Console.Clear();

        try
        {
            Console.Write("ID: ");
            idMovimentacao = int.Parse(Console.ReadLine());

            foreach (Movimentacao item in movimentacoes)
                if (idMovimentacao == item.ObterIdMovimentacao())
                    throw new IDsimilarException("Duas movimentações não podem ter o mesmo ID!");
            
        }
        catch (IDsimilarException ex)
        {
            Console.WriteLine($"{ex.Message}\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            return;
        }

        try
        {
            Console.Write("TIPO (entrada / saida): ");
            tipo = Console.ReadLine().ToLower();

            if((tipo != "entrada") && (tipo != "saida"))
                throw new TipoMovimentacaoInvalidaException("Tipo da movimentação inválido!");
        }
        catch (TipoMovimentacaoInvalidaException ex)
        {
            Console.WriteLine($"{ex.Message}\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            return;
        }
        

        Console.Write("OBSERVAÇÃO: ");
        observacao = Console.ReadLine();

        Movimentacao movimentacao = new Movimentacao(idMovimentacao, DateTime.Now, tipo, observacao);

        int continuar = 1;

        do
        {
            Console.WriteLine("Lotes:");

            foreach (Lote lote in lotes)
            {
                Console.WriteLine($"PRODUTO: {lote.ObterProduto().ObterNome()}");
                Console.WriteLine($"LOTE DO PRODUTO: {lote.ObterCodigoLote()} - ID: {lote.ObterIdLote()}\n");
            }

            Console.Write("Informe o ID do lote: ");
            int idLote = int.Parse(Console.ReadLine());

            Lote loteSelecionado = null;

            foreach (Lote lote in lotes)
                if (lote.ObterIdLote() == idLote)
                {
                    loteSelecionado = lote;
                    break;
                }
            

            if (loteSelecionado == null)
            {
                Console.WriteLine("Lote não encontrado.");
                return;
            }

            int quantidade;
            try
            {
                Console.Write("QUANTIDADE: ");
                quantidade = int.Parse(Console.ReadLine());

                if(quantidade <= 0)
                    throw new QuantidadeInvalidaException("A quantidade a ser movimentada deve ser maior do que 0!");
            }
            catch (System.FormatException)
            {
                Console.WriteLine($"Valor inválido!\n(Clique novamente para voltar ao menu)");
                Console.ReadKey();
                return;
            }
            catch (QuantidadeInvalidaException ex)
            {
                Console.WriteLine($"{ex.Message}\n(Clique novamente para voltar ao menu)");
                Console.ReadKey();
                return;
            }
            

            if (tipo == "entrada")
                loteSelecionado.AdicionarQuantidade(quantidade);
            
        else if (tipo == "saida")
        {
            bool sucesso = loteSelecionado.RemoverQuantidade(quantidade);

            if (!sucesso)
            {
                Console.WriteLine("Estoque insuficiente.");
                continue;
            }
        }

            ItemMovimentacao item = new ItemMovimentacao(loteSelecionado, quantidade);

            movimentacao.AdicionarItem(item);

            Console.Write("Adicionar outro item? (1-Sim / 0-Não): ");
            continuar = int.Parse(Console.ReadLine());

        } while (continuar == 1);

        movimentacoes.Add(movimentacao);

        Console.WriteLine($"Cadastro realizado com sucesso!\n(Clique novamente para voltar ao menu)");
        Console.ReadKey();
    }

    public static void Listagem()
    {
        Console.Clear();

        int paginaListagem;

        Console.WriteLine("=== LISTAGEM ===");
        Console.WriteLine();

        Console.WriteLine("Lista a ser montada: ");
        Console.WriteLine("1 - Produtos e Lotes");
        Console.WriteLine("2 - Fornecedor");
        Console.WriteLine("3 - Movimentação");
        Console.WriteLine("0 - Cancelar");
        try
        {
            Console.Write("ESCOLHA: ");
            paginaListagem = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (paginaListagem)
            {
                case 0:
                Console.WriteLine($"Voltando ao menu...\n(Clique novamente para continuar)");
                Console.ReadKey();
                Console.WriteLine();
                break;

                case 1:
                Console.Clear();
                foreach(Produto produto in produtos)
                    {
                        Console.WriteLine($"ID DO PRODUTO: {produto.ObterIdProduto()}");
                        Console.WriteLine($"NOME: {produto.ObterNome()}");
                        Console.WriteLine($"DESCRIÇÃO: {produto.ObterDescricao()}");
                        Console.WriteLine($"PREÇO: {produto.ObterPreco()}");
                        Console.WriteLine($"CATEGORIA: {produto.ObterCategoria()}");
                        Console.WriteLine($"LOTES DO PRODUTO: ");
                        foreach (Lote lote in lotes)
                        {
                            if(lote.ObterProduto().ObterIdProduto() == produto.ObterIdProduto())
                            {
                                Console.WriteLine();
                                Console.WriteLine($"ID DO LOTE: {lote.ObterIdLote()}");
                                Console.WriteLine($"CÓDIGO: {lote.ObterCodigoLote()}");
                                Console.WriteLine($"QUANTIDADE: {lote.ObterQuantidadeAtual()}");
                                Console.WriteLine($"VALIDADE: {lote.ObterValidade()}");
                            }
                        }
                        Console.WriteLine();
                    }

                Console.WriteLine("(Clique novamente para voltar ao menu)");
                Console.ReadKey();
                break;

                case 2:
                Console.Clear();
                foreach(Fornecedor fornecedor in fornecedores)
                    {
                        Console.WriteLine($"ID DO FORNECEDOR: {fornecedor.ObterIdFornecedor()}");
                        Console.WriteLine($"NOME: {fornecedor.ObterNome()}");
                        Console.WriteLine($"CNPF: {fornecedor.ObterCnpj()}");
                        Console.WriteLine($"TELEFONE: {fornecedor.ObterTelefone()}");
                        Console.WriteLine($"E-MAIL: {fornecedor.ObterEmail()}");
                        Console.WriteLine();
                    }

                Console.WriteLine("(Clique novamente para voltar ao menu)");
                Console.ReadKey();
                break;

                case 3:
                Console.Clear();
                foreach (Movimentacao mov in movimentacoes)
                    {
                        Console.WriteLine($"ID DA MOVIMENTAÇÃO: {mov.ObterIdMovimentacao()}");
                        Console.WriteLine($"TIPO: {mov.ObterTipo()}");
                        Console.WriteLine($"DATA: {mov.ObterData()}");

                        foreach (ItemMovimentacao item in mov.ObterItens())
                        {
                            Console.WriteLine($"PRODUTO: {item.ObterLote().ObterProduto().ObterNome()}");
                            Console.WriteLine($"LOTE: {item.ObterLote().ObterCodigoLote()}");
                            Console.WriteLine($"QUANTIDADE: {item.ObterQuantidade()}");
                            Console.WriteLine();
                        }
                    }

                Console.WriteLine("(Clique novamente para voltar ao menu)");
                Console.ReadKey();
                break;
            
                default:
                Console.WriteLine($"Número inválido!\n(Clique novamente para voltar ao menu)");
                Console.ReadKey();
                break;
            }
        }
        catch (System.FormatException)
        {
            Console.WriteLine($"Valor inválido!\n(Clique novamente para voltar ao menu)");
            Console.ReadKey();
        }
    }

    public static void ImprimirRelatorio()
    {
        int paginaImprimir;

        Console.WriteLine("=== IMPRIMIR RELATÓRIO ===");
        Console.WriteLine();

        Console.WriteLine("Tipo de relatório a ser impresso");
        Console.WriteLine("1 - Entrada");
        Console.WriteLine("2 - Saída");
        Console.WriteLine("0 - Cancelar");
        Console.Write("ESCOLHA: ");
        paginaImprimir = int.Parse(Console.ReadLine());

        switch (paginaImprimir)
        {
            case 0:
            Console.WriteLine($"Voltando ao menu...\n(Clique novamente para continuar)");
            Console.ReadKey();
            Console.WriteLine();
            break;

            case 1:
            foreach(Movimentacao mov in movimentacoes)
                if(mov.ObterTipo() == "entrada")
                    {
                        Console.WriteLine($"ID: {mov.ObterIdMovimentacao()} - DATA: {mov.ObterData()}");
                        Console.WriteLine($"OBSERVAÇÃO: {mov.ObterObservacao()}");
                    }

            Console.Write("Informe o ID da Movimentação: ");
            int idMovimentacaoEntrada = int.Parse(Console.ReadLine());

            Movimentacao movEntradaEscolhida = null;
            
            foreach(Movimentacao mov in movimentacoes)
                if(idMovimentacaoEntrada == mov.ObterIdMovimentacao())
                    {
                        movEntradaEscolhida = mov;
                        break;
                    }

                if (movEntradaEscolhida == null)
                {
                    Console.WriteLine("Relatório não encontrado!");
                    break;
                }

            Relatorio entrada = new RelatorioEntrada(movEntradaEscolhida);
            entrada.Imprimir();
            break;

            case 2:
            foreach(Movimentacao mov in movimentacoes)
                if(mov.ObterTipo() == "saida")
                    {
                        Console.WriteLine($"ID: {mov.ObterIdMovimentacao()} - DATA: {mov.ObterData()}");
                        Console.WriteLine($"OBSERVAÇÃO: {mov.ObterObservacao()}");
                    }

            Console.Write("Informe o ID da Movimentação: ");
            int idMovimentacaoSaida = int.Parse(Console.ReadLine());

            Movimentacao movSaidaEscolhida = null;

            foreach(Movimentacao mov in movimentacoes)
                if(idMovimentacaoSaida == mov.ObterIdMovimentacao())
                    {
                        movSaidaEscolhida = mov;
                        break;
                    }

            if (movSaidaEscolhida == null)
                {
                    Console.WriteLine("Relatório não encontrado!");
                    break;
                }

            Relatorio saida = new RelatorioSaida(movSaidaEscolhida);
            saida.Imprimir();
            break;

            default:
            Console.WriteLine($"Número inválido!\n(Clique novamente para continuar)");
            Console.ReadKey();
            Console.WriteLine();
            break;
        }
    }
}