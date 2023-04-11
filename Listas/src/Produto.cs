public class Produto {
	public int Id { get; set; }
	public string? Descricao { get; set; }
	public int Quantidade { get; set; }
	public double Valor { get; set; }
	public bool Ativo { get; set; }
	
	public Produto() {}
	
	public Produto(int id, string? descricao, int quantidade, double valor) {
		Id = id;
		Descricao = descricao;
		Quantidade = quantidade;
		Valor = valor;
		Ativo = true;
	}
	
	public override string ToString() {
		return $"({Id}) {Descricao}: {Quantidade} unidades à R$ {Valor.ToString("N2")}";
	}
}