public class Menu 
{
    private Contexto _db;
    public Menu(Contexto db)
    {
        _db = db;
    }

    public void MenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("           Lojão da Sapiron");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine(" [1] - Produtos");
        Console.WriteLine(" [2] - Vendedores");
        Console.WriteLine(" [3] - Venda");
        Console.WriteLine(" [4] - Relatórios");
        Console.WriteLine("\n [0] - Sair do programa");
        Console.WriteLine("---------------------------------------");
        Console.Write("Informe sua opção: ");
        var opcao = Console.ReadLine();
        if (opcao == "1") 
            MenuProduto();
        SairDoSistema();
    }
     
    public void MenuProduto()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("      Lojão da Sapiron - PRODUTOS");
        Console.WriteLine("---------------------------------------");
        Console.WriteLine(" [1] - Listar");
        Console.WriteLine(" [2] - Inserir");
        Console.WriteLine(" [3] - Pesquisar");
        Console.WriteLine(" [4] - Alterar");
        Console.WriteLine(" [5] - Excluir");
        Console.WriteLine("\n [0] - Menu Principal");
        Console.WriteLine("---------------------------------------");
        Console.Write("Informe sua opção: ");
        var opcao = Console.ReadLine();
        if (opcao == "1") 
            ProdutoListar();
        else if (opcao == "2") 
            ProdutoInserir();
        else if (opcao == "3") 
            ProdutoPesquisar();
        else if (opcao == "4") 
            ProdutoEditar();
        else if (opcao == "5") 
            ProdutoExcluir();
        else 
            MenuPrincipal();
        
    }

    public void ProdutoListar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("  Lojão da Sapiron - LISTA DE PRODUTOS");
        Console.WriteLine("---------------------------------------");
        foreach (var produto in _db.Produtos.OrderBy(p => p.Descricao)) {
            Console.WriteLine(produto);
        }
        Console.ReadLine();
        MenuProduto();
    }

    public void ProdutoInserir()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("  Lojão da Sapiron - INSERIR PRODUTOS");
        Console.WriteLine("---------------------------------------");
        Console.Write("Descricao: ");
        var descricao = Console.ReadLine();
        Console.Write("Valor: ");
        var valor = Convert.ToDouble(Console.ReadLine());
        _db.Produtos.Add(new Produto(descricao, valor));
        Console.ReadLine();
        MenuProduto();
    }

    public void ProdutoPesquisar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine(" Lojão da Sapiron - PESQUISAR PRODUTOS");
        Console.WriteLine("---------------------------------------");
        Console.Write(" Parâmetro de Pesquisa: ");
        var parametro = Console.ReadLine();
        if (parametro != null) {
            var produtos = _db.Produtos.Where(p => p.Descricao!.ToLower().Contains(parametro.ToLower()));
            foreach (var produto in produtos.OrderBy(p => p.Descricao)) {
                Console.WriteLine(produto);
            }
        }
        Console.ReadLine();
        MenuProduto();
    }

    public void ProdutoEditar()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("   Lojão da Sapiron - EDITAR PRODUTO");
        Console.WriteLine("---------------------------------------");
        Console.Write(" Código Produto: ");
   
        var parametro = Console.ReadLine();
        if (!string.IsNullOrEmpty(parametro)) {
            var codigo = Convert.ToInt32(parametro);
            var produto = _db.Produtos.Find(p => p.Id == codigo);
            if (produto != null) {
                Console.WriteLine($" Descrição:      {produto.Descricao}");
                Console.WriteLine($" Quantidade:     {produto.Quantidade}");
                Console.WriteLine($" Valor:          {produto.Valor.ToString("N2")}");
                Console.WriteLine($" Ativo:          {produto.Ativo}");
                Console.WriteLine("\nNovos valores\n");
                Console.Write(" Descricao: ");
                var descricao = Console.ReadLine();
                if (!string.IsNullOrEmpty(descricao)) {
                    produto.Descricao = descricao;
                }
                Console.Write(" Valor: ");
                var valor = Console.ReadLine();
                if (!string.IsNullOrEmpty(valor)) {
                    produto.Valor = Convert.ToDouble(valor);
                }
            }
            else 
                Console.WriteLine(" Produto inexistente");
        }
        Console.ReadLine();
        MenuProduto();
    }

    public void ProdutoExcluir()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine(" Lojão da Sapiron - EXCLUIR PRODUTO");
        Console.WriteLine("---------------------------------------");
        Console.Write(" Código Produto: ");
   
        var parametro = Console.ReadLine();
        if (!string.IsNullOrEmpty(parametro)) {
            var codigo = Convert.ToInt32(parametro);
            var produto = _db.Produtos.Find(p => p.Id == codigo);
            if (produto != null) {
                Console.WriteLine($" Excluído: {produto}");
                _db.Produtos.Remove(produto);
            }
            else 
                Console.WriteLine(" Produto inexistente");
        }
        Console.ReadLine();
        MenuProduto();
    }

    public void SairDoSistema()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("           Lojão da Sapiron");
        Console.WriteLine("             VOLTE SEMPRE");
        Console.WriteLine("---------------------------------------");
    }
}