using static System.Console;

var numeros = CreateArray(5);
var soma = numeros.Sum();
var media = numeros.Average();
var menor = numeros.Min();
var maior = numeros.Max();
var mediaMaior70 = numeros.Where(n => n >= 70).Average();
var somaMaior50 = numeros.Where(n => n >= 50).Sum();
var somaPares = numeros.Where(n => n % 2 == 0).Sum();
var somaParesMaior50 = numeros.Where(n => n % 2 == 0 && n > 50).Sum();

WriteLine($"A soma dos elementos é {soma}"); 
WriteLine($"A média dos elementos é {media}"); 
WriteLine($"A menor dos elementos é {menor}"); 
WriteLine($"A maior dos elementos é {maior}"); 
WriteLine($"A média dos números maiores que 70 é {mediaMaior70}"); 
WriteLine($"A soma dos números maiores que 50 é {somaMaior50}"); 
WriteLine($"A soma dos números pares {somaPares}"); 
WriteLine($"A soma dos números pares maiores que 50 {somaParesMaior50}"); 

int[] CreateArray(int length) {
	var array = new int[length];
	var r = new Random();
	for(int i = 0; i < array.Length; i++) {
		array[i] = r.Next(1, 100);
	}
	PrintArray(array);
	return array;
}

void PrintArray(int[] vetor) {
	foreach(var item in vetor) 
		Write(item + " ");
	WriteLine();
}