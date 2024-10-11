
  


long Factorial(int numero)
{
  if (numero == 0 || numero == 1)
  {
    return 1;
 }

  return numero * Factorial(numero - 1);
}

Console.WriteLine("----------------------------Programa para calcular el fatorial de un numero--------------------------------");
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Ingrese un numero: ");

int numero = int.Parse(Console.ReadLine());


  
Console.WriteLine($"El factorial del numero {numero} es {Factorial(numero)}");