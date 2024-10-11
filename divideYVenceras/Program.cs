long Factorial(int numero)
{
    if (numero == 0 || numero == 1)
    {
        return 1;
    }

    return numero * Factorial(numero - 1);
}

Console.WriteLine("-----------------------------Menu-------------------------");
Console.WriteLine();

Console.WriteLine("1.Encontrar el Factorial de un numero");
Console.WriteLine();
Console.WriteLine("2.Algoritmo de ordenamiento QuickSort");
Console.WriteLine();
Console.WriteLine("3.Pasar un numero decimal a binario");
Console.WriteLine();

bool bandera = true;
int option = 0;

while (bandera)
{
    switch (option)
    {
        case 1: Console.WriteLine("----------------------------Programa para calcular el fatorial de un numero--------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese un numero: ");

            int numero = int.Parse(Console.ReadLine());


  
            Console.WriteLine($"El factorial del numero {numero} es {Factorial(numero)}");
            break;
        
    }
}