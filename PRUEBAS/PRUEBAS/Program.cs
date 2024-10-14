using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRUEBAS
{
    internal class Program
    {
        static string ConvertirADecimal(int numero)
        {
             //  Si el número es 0 o 1, devolvemos el número como cadena
              if (numero < 2)
              {
                return numero.ToString();
              }

            // Dividir Obtenemos el cociente y el residuo
            int residuo = numero % 2; // el operaodr modulo devuelve el residuo de una division 
            int cociente = numero / 2;

            // vencer Llamada recursiva con el cociente
            string binarioParcial = ConvertirADecimal(cociente);

            // Combinar Agregamos el residuo al resultado de la llamada recursiva
            return binarioParcial + residuo.ToString();


        }
        static void Main(string[] args)
        {
            //Este programa convierte un numero decimal a binario

            int numeroD;
            Console.Write("Digite un número decimal: ");
             numeroD = int.Parse(Console.ReadLine());

            // llamamos a la funcion
            string numeroBinario = ConvertirADecimal(numeroD);

            //muestra en la consolita :)
            Console.WriteLine($"El número {numeroD} en binario es: {numeroBinario}");
            Console.ReadKey();  
        }

        
    }
}
