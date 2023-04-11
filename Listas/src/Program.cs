using System.Text.Json;

Console.Clear();

// criando uma lista
var lista = new List<Produto>(); // lista está vazia

// adiciono o primeiro produto na lista
lista.Add(new Produto() { 
    Id = 1,
	Descricao = "TV LCD 55",
    Quantidade = 10,
    Valor = 1999,
    Ativo = true
});

// adiciono o 2º produto na lista
lista.Add(new Produto(2, "Pendrive 128GB", 38, 64)); 

// percorrendo a lista
foreach (var item in lista) {
	Console.WriteLine(item);
}

// pesquisar um objeto na lista
var produto = lista.Find(p => p.Id == 2);
if (produto != null) {
    Console.WriteLine("\n" + produto);

    // alterando um objeto na lista
    produto.Quantidade = 30;
    produto.Valor = 61.99;
    Console.WriteLine("\n" + produto);
}

// convertendo a lista em texto
var json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
// salvei o texto em um arquivo
File.WriteAllText("produtos.json", json);

/*
// lendo um texto de um arquivo
var leitor = File.ReadAllText("produtos.json");
// escrever o texto lido do arquivo
Console.WriteLine(leitor);
*/

Console.ReadLine();