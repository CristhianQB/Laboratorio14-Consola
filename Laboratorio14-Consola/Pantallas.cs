using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio14_Consola
{
    public class Pantallas
    {
        public static int[] personas = new int[1];
        public static int[] ordenPersonas = new int[1];
        public static string[] sioNo = new string[1];
        public static int pantallaPrincipal()
        {
            Console.Clear();
            cabeza("Encuesta Covid-19\n");
            Console.Write("1: Realizar Encuesta\n" +
            "2: Mostrar Datos de la encuesta\n" +
            "3: Mostrar Resultados\n" +
            "4: Buscar Personas por edad\n" +
            "5: Salir\n" +
            "================================\n");
            return imprimir("Ingrese una opción: ");
        }

        public static int numPersonas = 0;
        public static int vacunados = 0;
        public static int noVacunados = 0;
        public static int encuesta()
        {
            ordenPersonas[numPersonas] = numPersonas;
            Console.Clear();
            cabeza("Encuesta de vacunación\n");
            string texto1 = "¿Qué edad tienes?: ";
            Console.Write(texto1);
            personas[numPersonas] = int.Parse(Console.ReadLine());

            string texto2 = "Te has vacunado\n" +
                "1: Sí\n" +
                "2: No\n" +
                "===================================\n";
            Console.Write(texto2);

            int vacunado = imprimir("Ingrese una opción: ");
            if (vacunado == 1)
            {
                sioNo[numPersonas] = "Si";
                vacunados++;
            }
            else
            {
                sioNo[numPersonas] = "No";
                noVacunados++;
            }

            int[] nuevoArreglo = new int[personas.Length + 1];
            for (int i = 0; i < personas.Length; i++)
            {
                nuevoArreglo[i] = personas[i];
            }
            personas = nuevoArreglo;

            string[] nuevoArreglo2 = new string[sioNo.Length + 1];
            for(int i = 0; i < sioNo.Length; i++)
            {
                nuevoArreglo2[i] = sioNo[i];
            }
            sioNo = nuevoArreglo2;

            int[] nuevoOrden = new int[ordenPersonas.Length + 1];
            for (int i = 0; i < ordenPersonas.Length; i++)
            {
                nuevoOrden[i] = ordenPersonas[i]; 
            }
            ordenPersonas = nuevoOrden;

            numPersonas++;
            return encuesta2();
        }

        static int encuesta2()
        {
            int opcion = 0;
            Console.Clear();
            cabeza("Encuesta de vacunación\n");
                Console.Write("\n" +
                "¡Gracias por participar!\n" +
                "===================================\n" +
                "Presione una tecla ...");
            Console.ReadKey();
            return opcion;

        }

        public static int datos()
        {
            int opcion = 0;
            Console.Clear();
            cabeza("Datos de la encuesta\n");

            Console.Write("ID \t| Edad \t| Vacunado\n" +
               "====================================\n");

            for (int i = 0; i < numPersonas; i++)
            {
                Console.WriteLine(ordenPersonas[i].ToString("0000")+"\t| " + personas[i]+"\t| " + sioNo[i]);
            }
               Console.Write("\n===================================\n" +
                "Presione una tecla para regresar ...");
            Console.ReadKey();
            return opcion;
        }

        static int num1 = 0;
        static int num2 = 0;
        static int num3 = 0;
        static int num4 = 0;
        static int num5 = 0;
        static int num6 = 0;
        public static int resultados()
        {
            for (int i = 0; i < personas.Length; i++)
            {
                if (personas[i] < 21) num1++;
                else if (personas[i] > 20 && personas[i] < 31) num2++;
                else if (personas[i] > 30 && personas[i] < 41) num3++;
                else if (personas[i] > 40 && personas[i] < 51) num4++;
                else if (personas[i] > 50 && personas[i] < 61) num5++;
                else if (personas[i] > 60) num6++;
                       
            }
            int opcion = 0;
            Console.Clear();
            cabeza("Resultados de la encuesta\n");

            string texto1 = vacunados+ " personas se han vacunado\n" +
                noVacunados +" personas no se han vacunado\n";
            Console.Write(texto1);
                Console.Write("Existen:\n" +
                num1.ToString("00")+" personas entre 01 y 20 años\n" +
                num2.ToString("00")+" personas entre 21 y 30 años\n" +
                num3.ToString("00") + " personas entre 31 y 40 años\n" +
                num4.ToString("00") + " personas entre 41 y 50 años\n" +
                num5.ToString("00") + " personas entre 51 y 60 años\n" +
                num6.ToString("00") + " personas de más de 61 años\n" +
                "\n" +
                "===================================\n" +
                "Presione una tecla para regresar ...");
            Console.ReadKey();
            return opcion;
        }

        static int contadorsi = 0;
        static int contadorno = 0;
        public static int buscarDatos()
        {
            int opcion = 0;
            Console.Clear();
            cabeza("Busca a personas por edad\n");
            string texto1 ="¿Qué edad quieres buscar?: ";
            Console.Write(texto1);
            int buscar = int.Parse(Console.ReadLine());

            for (int i = 0; i < personas.Length; i++)
            {
                if (personas[i] ==20)
                {
                    if (sioNo[i] == "Si")
                    {
                        contadorsi++;
                    }
                    else
                    {
                        contadorno++;
                    }
                }
            }
            Console.Write("\n" +
                contadorsi+" se vacunaron\n" +
                contadorno+" no se vacunaron\n" +
                "\n================================\n" +
                "Presione una tecla para regresar ..");
            Console.ReadKey();
            return opcion;
        }

        public static int imprimir(string Texto)
        {
            Console.Write(Texto);
            return int.Parse(Console.ReadLine());
        }

        private static void cabeza(string texto)
        {
            Console.Write("================================\n" +
                            texto +
                            "================================\n");
        }

    }
}
