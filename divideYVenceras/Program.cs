
//Funciones de Factorial
long Factorial(int numero)
{
    if (numero == 0 || numero == 1)
    {
        return 1;
    }

    return numero * Factorial(numero - 1);
}
//*********************************** Funciones QuickSort *******************************
void Intercambiar(int[] array, int i, int j)
{
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}

int Particionar(int[] array, int bajo, int alto)
{
    int pivote = array[alto];
    int i = bajo - 1;

    for (int j = bajo; j < alto; j++)
    {
        if (array[j] <= pivote)
        {
            i++;
            Intercambiar(array, i, j);
        }
    }
    Intercambiar(array, i + 1, alto);
    return i + 1;
}

void QuickSort(int[] array, int bajo, int alto)
{
    int indicePivote;
    if (bajo < alto)
    {
        indicePivote = Particionar(array, bajo, alto);
        QuickSort(array, bajo, indicePivote - 1);
        QuickSort(array, indicePivote + 1, alto);
    }
}
 void ImprimirArray(int[] array)
{
    Console.WriteLine(string.Join(" ", array));
}


//*************************** Funciones para decimal to binary *****************************

 static string ConvertirADecimal(int numero)
 {
     string binario = "";
     while (numero > 0)
     {
         // Obtener el residuo de la división entre 2 (0 o 1)
         int residuo = numero % 2;  //El operador de módulo devuelve el residuo de una división entre dos números.
         binario = residuo + binario;  // Añadir el residuo al inicio de la cadena

         // Dividir el número entre 2 para continuar el proceso
         numero /= 2;
     }

     return binario == "" ? "0" : binario;
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
        case 1:
            Console.WriteLine(
                "----------------------------Programa para calcular el fatorial de un numero--------------------------------");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Ingrese un numero: ");

            int numero = int.Parse(Console.ReadLine());



            Console.WriteLine($"El factorial del numero {numero} es {Factorial(numero)}");
            break;
            
        case 2:
            while (true)
            {
                Console.WriteLine("Ingrese los números separados por comas (o 'salir' para terminar):");
                string input = Console.ReadLine();
                if (input.ToLower() == "salir")
                    break;

                int[] numeros;
                try
                {
                    numeros = Array.ConvertAll(input.Split(','), int.Parse);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Asegúrese de ingresar números válidos.");
                    continue;
                }

                Console.WriteLine("Array original:");
                ImprimirArray(numeros);
                QuickSort(numeros, 0, numeros.Length - 1);
                Console.WriteLine("Array ordenado:");
                ImprimirArray(numeros);
            }

            break;
        
        
    }
}