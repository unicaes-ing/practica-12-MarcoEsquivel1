using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace practica12
{
    class ejercicio1
    {
        //Marco René Esquivel Juárez
        //13-nov-2019
        [Serializable]
        public struct Mascota
        {
            public string nombre;
            public string especie;
            public string raza;
            public string sexo;
            public int edad;
        }
        public void ejer1()
        {
            FileStream stream;
            BinaryFormatter formatter = new BinaryFormatter();
            const string NOMBRE_ARCHIVO = "mascota.bin";
            try
            {
                Mascota mascota = new Mascota();
                Console.WriteLine("Ingrese el nombre de la mascota");
                mascota.nombre = Console.ReadLine();
                Console.WriteLine("Ingrese la especie de la mascota");
                mascota.especie = Console.ReadLine();
                Console.WriteLine("Ingrese la raza de la mascota");
                mascota.raza = Console.ReadLine();
                Console.WriteLine("Ingrese el sexo de la mascota");
                mascota.sexo = Console.ReadLine();
                Console.WriteLine("Ingrese la edad de la mascota");
                mascota.edad = Convert.ToInt32(Console.ReadLine());
                stream = new FileStream(NOMBRE_ARCHIVO, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, mascota);
                stream.Close();
                Console.WriteLine();
                Console.WriteLine("DATOS GUARDADOS...");
            }
            catch (Exception)
            {

                throw;
            }
            Console.ReadKey();
        }
    }
}
