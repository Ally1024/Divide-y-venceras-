// Funciones de Factorial
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
    if (bajo < alto)
    {
        int indicePivote = Particionar(array, bajo, alto);
        QuickSort(array, bajo, indicePivote - 1);
        QuickSort(array, indicePivote + 1, alto);
    }
}

// Función para imprimir el array
void ImprimirArray(int[] array)
{
    Console.WriteLine(string.Join(", ", array));
}

//*************************** Funciones para decimal a binario *****************************
string ConvertirADecimal(int numero)
{
    string binario = "";
    while (numero > 0)
    {
        int residuo = numero % 2;  // Obtener el residuo
        binario = residuo + binario;  // Añadir el residuo al inicio de la cadena
        numero /= 2;  // Dividir el número entre 2
    }

    return binario == "" ? "0" : binario;
}

// Método para mostrar el menú
void MostrarMenu()
{
    bool bandera = true;

    while (bandera)
    {
        Console.WriteLine("-----------------------------Menu-------------------------");
        Console.WriteLine("1. Encontrar el Factorial de un número.");
        Console.WriteLine("2. Algoritmo de ordenamiento QuickSort.");
        Console.WriteLine("3. Pasar un número decimal a binario.");
        Console.WriteLine("4. Salir del Menu.");
        Console.WriteLine();

        byte option;

        // Leer la opción del menú
        while (!byte.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
        {
            Console.WriteLine("Opción inválida. Intente de nuevo (1-4):");
        }

        switch (option)
        {
            case 1:
                Console.WriteLine("----------------------------Programa para calcular el factorial de un número--------------------------------");
                Console.WriteLine("Ingrese un número: ");
                int numero = int.Parse(Console.ReadLine());
                Console.WriteLine($"El factorial del número {numero} es {Factorial(numero)}");
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

            case 3:
                Console.Write("Digite un número decimal: ");
                int numeroD = int.Parse(Console.ReadLine());

                // Llamar a la función
                string numeroBinario = ConvertirADecimal(numeroD);

                // Mostrar en la consola
                Console.WriteLine($"El número {numeroD} en binario es: {numeroBinario}");
                break;

            case 4:
                bandera = false;  // Salir del menú
                break;
        }

        Console.WriteLine(); // Espacio adicional antes de volver al menú
    }
}

MostrarMenu();
