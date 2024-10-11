using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quicksort2
{
    internal class Program
    {

        public void QuickSort(int[] array, int bajo, int alto)
        {
            int indicePivote;
            if (bajo < alto)
            {
                indicePivote = Particionar(array, bajo, alto);
                QuickSort(array, bajo, indicePivote - 1);
                QuickSort(array, indicePivote + 1, alto);
            }
        }

        private int Particionar(int[] array, int bajo, int alto)
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

        private void Intercambiar(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public void ImprimirArray(int[] array)
        {
            Console.WriteLine(string.Join(" ", array));
        }

        static void Main(string[] args)
        {
            Program programa = new Program();

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
                programa.ImprimirArray(numeros);

                programa.QuickSort(numeros, 0, numeros.Length - 1);

                Console.WriteLine("Array ordenado:");
                programa.ImprimirArray(numeros);
                Console.ReadKey();

            }

        }
    }
}