using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practica12
{
    class Program
    {
        //Marco René Esquivel Juárez
        //13-nov-2019
        static void Main(string[] args)
        {
            int op;
            ejercicio1 eje1 = new ejercicio1();
            ejercicio2 eje2 = new ejercicio2();
            ejercicio3 eje3 = new ejercicio3();


            do
            {
                Console.WriteLine("Elija el ejercicio que desa ejecutar");
                Console.WriteLine("1- Ejercicio 1");
                Console.WriteLine("2- Ejercicio 2");
                Console.WriteLine("3- Ejercicio 3");
                op = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                switch (op)
                {
                    case 1:
                        eje1.ejer1();
                        break;
                    case 2:
                        eje2.ejer2();
                        break;
                    case 3:
                        eje3.ejer3();
                        break;
                }
                Console.Clear();
            } while (op != 0);
        }
    }
}
