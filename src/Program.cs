﻿using System.Text.Json;

class Program
{
    static List<Produto> produtos = new List<Produto>();
    static List<Fornecedor> fornecedores = new List<Fornecedor>();
    static List<Lote> lotes = new List<Lote>();
    static List<Movimentacao> movimentacoes = new List<Movimentacao>();

    static void Main()
    {
        Console.Clear(); // Limpar o terminal de mensagens de possíveis erros

        CarregarProdutos();
        CarregarLotes();
        CarregarFornecedores();
        CarregarMovimentacoes();
        int paginaMenu = 1;

        do
        {
            Console.WriteLine("=== SISTEMA ALMOXARIFADO ===");
            Console.WriteLine();

            Console.WriteLine("1 - Cadastro de Informações");
            Console.WriteLine("2 - Listagem de Informações");
            Console.WriteLine("3 - Imprimir Relatório");
            Console.WriteLine("0 - Sair");

            Console.Write("ESCOLHA: ");
            paginaMenu = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (paginaMenu)
            {
                case 0:
                Console.WriteLine("Obrigado por utilizar nosso sistema!");
                SalvarProdutos();
                SalvarLotes();
                SalvarFornecedores();
                SalvarMovimentacoes();
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
    public static void Cadastros()
    {
        int paginaCadastro;

        Console.WriteLine("=== CADASTROS ===");
        Console.WriteLine();

        Console.WriteLine("Cadastro a ser realizado: ");
        Console.WriteLine("1 - Produto");
        Console.WriteLine("2 - Lote");
        Console.WriteLine("3 - Fornecedor");
        Console.WriteLine("4 - Movimentação");
        Console.WriteLine("0 - Cancelar");
        
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

    public static void CadastroProduto()
    {
        Console.Write("ID: ");
        int idProduto = int.Parse(Console.ReadLine());

        Console.Write("NOME: ");
        string nome = Console.ReadLine();

        Console.Write("DESCRIÇÃO: ");
        string descricao = Console.ReadLine();

        Console.Write("PREÇO: ");
        double preco = double.Parse(Console.ReadLine());

        Console.Write("CATEGORIA: ");
        string categoria = Console.ReadLine();

        Produto produto = new Produto(idProduto, nome, descricao, preco, categoria);
        produtos.Add(produto);

        Console.WriteLine("Cadastro realizado com sucesso!");
        Console.WriteLine();
    }
    public static void CadastroLote()
    {
        Console.WriteLine("Produtos cadastrados:");

        foreach (Produto produto in produtos)
            Console.WriteLine($"{produto.ObterIdProduto()} - {produto.ObterNome()}");

        Console.Write("Informe o ID do produto: ");
        int idProduto = int.Parse(Console.ReadLine());

        Produto produtoSelecionado = null;

        foreach (Produto produto in produtos)
            if (produto.ObterIdProduto() == idProduto)
            {
                produtoSelecionado = produto;
                break;
            }

        if (produtoSelecionado == null)
        {
            Console.WriteLine($"Produto não encontrado!\n(Clique novamente para continuar)");
            Console.ReadKey();
            Console.WriteLine();
            return;
        }

        Console.Write("ID: ");
        int idLote = int.Parse(Console.ReadLine());

        Console.Write("CÓDIGO DO LOTE: ");
        string codigoLote = Console.ReadLine();

        Console.Write("QUANTIDADE: ");
        int quantidade = int.Parse(Console.ReadLine());

        Console.Write("VALIDADE: ");
        DateTime dataValidade = DateTime.Parse(Console.ReadLine());

        Lote lote = new Lote(idLote, codigoLote, quantidade, dataValidade, produtoSelecionado);
        lotes.Add(lote);
        produtoSelecionado.AdicionarLote(lote);
        
        Console.WriteLine("Cadastro realizado com sucesso!");
        Console.WriteLine();
    }
    public static void CadastroFornecedor()
    {
        Console.Write("ID: ");
        int idFornecedor = int.Parse(Console.ReadLine());

        Console.Write("NOME: ");
        string nome = Console.ReadLine();

        Console.Write("CNPJ: ");
        string cnpj = Console.ReadLine();

        Console.Write("TELEFONE: ");
        string telefone = Console.ReadLine();

        Console.Write("E-MAIL: ");
        string email = Console.ReadLine();
        
        Fornecedor fornecedor = new Fornecedor(idFornecedor, nome, cnpj, telefone, email);
        fornecedores.Add(fornecedor);

        Console.WriteLine("Cadastro realizado com sucesso!");
        Console.WriteLine();
    }
    public static void CadastroMovimentacao()
    {
        Console.Write("ID: ");
        int idMovimentacao = int.Parse(Console.ReadLine());

        Console.Write("TIPO (entrada / saida): ");
        string tipo = Console.ReadLine().ToLower();

        Console.Write("OBSERVAÇÃO: ");
        string observacao = Console.ReadLine();

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
                continue;
            }


            Console.Write("QUANTIDADE: ");
            int quantidade = int.Parse(Console.ReadLine());

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

        Console.WriteLine("Cadastro realizado com sucesso!");
        Console.WriteLine();
    }

    public static void Listagem()
    {
        int paginaListagem;

        Console.WriteLine("=== LISTAGEM ===");
        Console.WriteLine();

        Console.WriteLine("Lista a ser montada: ");
        Console.WriteLine("1 - Produto");
        Console.WriteLine("2 - Lote");
        Console.WriteLine("3 - Fornecedor");
        Console.WriteLine("4 - Movimentação");
        Console.WriteLine("0 - Cancelar");
        
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
            foreach(Produto produto in produtos)
                {
                    Console.WriteLine($"ID: {produto.ObterIdProduto()}");
                    Console.WriteLine($"NOME: {produto.ObterNome()}");
                    Console.WriteLine($"DESCRIÇÃO: {produto.ObterDescricao()}");
                    Console.WriteLine($"PREÇO: {produto.ObterPreco()}");
                    Console.WriteLine($"CATEGORIA: {produto.ObterCategoria()}");
                    Console.WriteLine();
                }

            Console.WriteLine("(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            break;

            case 2:
            foreach (Lote lote in lotes)
                {
                    Console.WriteLine($"ID DO PRODUTO: {lote.ObterProduto().ObterIdProduto()}");
                    Console.WriteLine($"NOME DO PRODUTO: {lote.ObterProduto().ObterNome()}");
                    Console.WriteLine($"ID DO LOTE: {lote.ObterIdLote()}");
                    Console.WriteLine($"CÓDIGO DO LOTE: {lote.ObterCodigoLote()}");
                    Console.WriteLine($"QUANTIDADE: {lote.ObterQuantidadeAtual()}");
                    Console.WriteLine($"VALIDADE: {lote.ObterValidade()}");
                    Console.WriteLine();
                }

            Console.WriteLine("(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            break;

            case 3:
            foreach(Fornecedor fornecedor in fornecedores)
                {
                    Console.WriteLine($"ID: {fornecedor.ObterIdFornecedor()}");
                    Console.WriteLine($"NOME: {fornecedor.ObterNome()}");
                    Console.WriteLine($"CNPF: {fornecedor.ObterCnpj()}");
                    Console.WriteLine($"TELEFONE: {fornecedor.ObterTelefone()}");
                    Console.WriteLine($"E-MAIL: {fornecedor.ObterEmail()}");
                    Console.WriteLine();
                }

            Console.WriteLine("(Clique novamente para voltar ao menu)");
            Console.ReadKey();
            break;

            case 4:
            foreach (Movimentacao mov in movimentacoes)
                {
                    Console.WriteLine($"ID: {mov.ObterIdMovimentacao()}");
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
            Console.WriteLine($"Número inválido!\n(Clique novamente para continuar)");
            Console.ReadKey();
            Console.WriteLine();
            break;
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

    static void SalvarProdutos()
    {
        string json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("produtos.json", json);
    }

    public static void SalvarLotes()
    {
        string json = JsonSerializer.Serialize(lotes, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("lotes.json", json);
    }

    public static void SalvarFornecedores()
    {
        string json = JsonSerializer.Serialize(fornecedores, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("fornecedores.json", json);
    }

    public static void SalvarMovimentacoes()
    {
        string json = JsonSerializer.Serialize(movimentacoes, new JsonSerializerOptions {WriteIndented = true});
        File.WriteAllText("movimentacoes.json", json);
    }

    public static void CarregarProdutos()
    {
        if (File.Exists("produtos.json"))
        {
            string json = File.ReadAllText("produtos.json");
            produtos = JsonSerializer.Deserialize<List<Produto>>(json);
        }
    }

    public static void CarregarLotes()
    {
        if (File.Exists("lotes.json"))
        {
            string json = File.ReadAllText("lotes.json");
            lotes = JsonSerializer.Deserialize<List<Lote>>(json);
        }
    }

    public static void CarregarFornecedores()
    {
        if (File.Exists("fornecedores.json"))
        {
            string json = File.ReadAllText("fornecedores.json");
            fornecedores = JsonSerializer.Deserialize<List<Fornecedor>>(json);
        }
    }

    public static void CarregarMovimentacoes()
    {
        if (File.Exists("movimentacoes.json"))
        {
            string json = File.ReadAllText("movimentacoes.json");
            movimentacoes = JsonSerializer.Deserialize<List<Movimentacao>>(json);
        }
    }
}