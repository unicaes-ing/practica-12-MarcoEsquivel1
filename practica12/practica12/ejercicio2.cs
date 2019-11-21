using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace practica12
{
    class ejercicio2
    {
        //Marco René Esquivel Juárez
        //13-nov-2019
        public void ejer2()
        {
            ejercicio1.Mascota mascota;
            FileStream stream;
            BinaryFormatter formatter = new BinaryFormatter();
            const string NOMBRE_ARCHIVO = "mascota.bin";
            if (File.Exists(NOMBRE_ARCHIVO))
            {
                try
                {
                    stream = new FileStream(NOMBRE_ARCHIVO, FileMode.Open, FileAccess.Read);
                    mascota = (ejercicio1.Mascota)formatter.Deserialize(stream);
                    Console.WriteLine("Datos");
                    Console.WriteLine("Nombre: {0}", mascota.nombre);
                    Console.WriteLine("Especie: {0}", mascota.especie);
                    Console.WriteLine("Raza: {0}", mascota.raza);
                    Console.WriteLine("Sexo: {0}", mascota.sexo);
                    Console.WriteLine("Edad: {0}", mascota.edad);
                    Console.WriteLine("Presiona cualquier tecla para salir");
                }
                catch (Exception)
                {

                    throw;
                }

            }
            Console.ReadKey();
        }
    }
}
