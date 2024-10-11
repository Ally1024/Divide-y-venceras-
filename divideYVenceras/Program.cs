// Funciones de Factorial
long Factorial(int numero)
{
    // Caso base: el factorial de 0 y 1 es 1
    if (numero == 0 || numero == 1)
    {
        return 1;
    }

    // Recursión: número * factorial del número - 1
    return numero * Factorial(numero - 1);
}

//*********************************** Funciones QuickSort *******************************
void Intercambiar(int[] array, int i, int j)
{
    // Intercambia los elementos en las posiciones i y j del array
    int temp = array[i];
    array[i] = array[j];
    array[j] = temp;
}

int Particionar(int[] array, int bajo, int alto)
{
    // Selecciona el último elemento como pivote
    int pivote = array[alto];
    int i = bajo - 1; // Indice para el elemento más pequeño

    // Reorganiza el array colocando los elementos menores o iguales al pivote a su izquierda
    for (int j = bajo; j < alto; j++)
    {
        if (array[j] <= pivote)
        {
            i++;
            Intercambiar(array, i, j); // Intercambiar elementos
        }
    }
    // Intercambiar el pivote con el primer elemento mayor
    Intercambiar(array, i + 1, alto);
    return i + 1; // Retorna el índice del pivote
}

void QuickSort(int[] array, int bajo, int alto)
{
    // Si hay más de un elemento en el subarray
    if (bajo < alto)
    {
        // Particiona el array y obtiene el índice del pivote
        int indicePivote = Particionar(array, bajo, alto);
        // Ordena recursivamente las dos mitades
        QuickSort(array, bajo, indicePivote - 1);
        QuickSort(array, indicePivote + 1, alto);
    }
}

// Función para imprimir el array
void ImprimirArray(int[] array)
{
    // Imprime todos los elementos del array separados por comas
    Console.WriteLine(string.Join(", ", array));
}

//*************************** Funciones para decimal a binario *****************************
string ConvertirADecimal(int numero)
{
    string binario = ""; // Variable para almacenar la representación binaria
    // Convierte el número decimal a binario
    while (numero > 0)
    {
        int residuo = numero % 2;  // Obtener el residuo (0 o 1)
        binario = residuo + binario;  // Añadir el residuo al inicio de la cadena
        numero /= 2;  // Dividir el número entre 2 para continuar
    }

    // Si el binario es vacío, significa que el número era 0
    return binario == "" ? "0" : binario;
}

// Método para mostrar el menú
void MostrarMenu()
{
    // Imprime las opciones del menú
    Console.WriteLine("-----------------------------Menu-------------------------");
    Console.WriteLine("1. Encontrar el Factorial de un número.");
    Console.WriteLine("2. Algoritmo de ordenamiento QuickSort.");
    Console.WriteLine("3. Pasar un número decimal a binario.");
    Console.WriteLine("4. Salir del Menu.");
    Console.WriteLine();
}

// Método principal para manejar la lógica del menú
void EjecutarPrograma()
{
    bool bandera = true; // Bandera para controlar el flujo del programa

    while (bandera) // Ciclo principal del menú
    {
        MostrarMenu(); // Llamar a la función para mostrar el menú

        byte option; // Variable para almacenar la opción elegida

        // Leer la opción del menú con validación
        while (!byte.TryParse(Console.ReadLine(), out option) || option < 1 || option > 4)
        {
            Console.WriteLine("Opción inválida. Intente de nuevo (1-4):");
        }

        // Procesar la opción seleccionada
        switch (option)
        {
            case 1: // Opción para calcular el factorial
                Console.WriteLine("----------------------------Programa para calcular el factorial de un número--------------------------------");
                Console.WriteLine("Ingrese un número: ");
                int numero = int.Parse(Console.ReadLine()); // Leer el número
                // Calcular y mostrar el factorial
                Console.WriteLine($"El factorial del número {numero} es {Factorial(numero)}");
                break;

            case 2: // Opción para ordenar un array
                while (true)
                {
                    Console.WriteLine("Ingrese los números separados por comas (o 'salir' para terminar):");
                    string input = Console.ReadLine();
                    if (input.ToLower() == "salir") // Opción para salir
                        break;

                    int[] numeros;
                    // Convertir la entrada en un array de enteros
                    try
                    {
                        numeros = Array.ConvertAll(input.Split(','), int.Parse);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Entrada inválida. Asegúrese de ingresar números válidos.");
                        continue; // Volver al inicio del ciclo si la entrada es inválida
                    }

                    Console.WriteLine("Array original:");
                    ImprimirArray(numeros); // Imprimir el array original
                    QuickSort(numeros, 0, numeros.Length - 1); // Ordenar el array
                    Console.WriteLine("Array ordenado:");
                    ImprimirArray(numeros); // Imprimir el array ordenado
                }
                break;

            case 3: // Opción para convertir decimal a binario
                Console.Write("Digite un número decimal: ");
                int numeroD = int.Parse(Console.ReadLine()); // Leer el número decimal
                // Llamar a la función para convertir a binario
                string numeroBinario = ConvertirADecimal(numeroD);
                // Mostrar el resultado en la consola
                Console.WriteLine($"El número {numeroD} en binario es: {numeroBinario}");
                break;

            case 4: // Opción para salir del menú
                bandera = false;  // Cambia la bandera para salir del ciclo
                break;
        }

        // Preguntar al usuario si desea volver al menú o salir
        Console.WriteLine("¿Desea volver al menú? (s/n)");
        string respuesta = Console.ReadLine(); // Leer respuesta
        // Si la respuesta no es "s" (sin importar mayúsculas o minúsculas), salir
        if (respuesta.ToLower() != "s")
        {
            bandera = false;  // Cambia la bandera para salir del ciclo
        }

        Console.WriteLine(); // Espacio adicional antes de volver al menú
    }
}

// Llamar al método para ejecutar el programa
EjecutarPrograma();
