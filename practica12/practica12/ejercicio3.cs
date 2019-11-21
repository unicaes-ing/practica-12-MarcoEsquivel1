using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace practica12
{
    class ejercicio3
    {
        //Marco René Esquivel Juárez
        //13-nov-2019
        [Serializable]

        public struct eAlumno
        {

            public string carnet;
            public string nombre;
            public string carrera;
            private decimal CUM;
            public void setCUM(decimal cum)
            {
                if (cum > 0)
                {
                    this.CUM = cum;
                }
            }
            public decimal getCUM()
            {
                return CUM;
            }
        }


        private static Dictionary<string, eAlumno> dicAlumnos = new Dictionary<string, eAlumno>();
        private static BinaryFormatter formatter = new BinaryFormatter();
        private const string NOMBRE_ARCHIVO = "alumnos.bin";


        public void ejer3()
        {
            if (File.Exists(NOMBRE_ARCHIVO))
            {
                leer();
            }
            else
            {
                guardar(dicAlumnos);
            }
            int op;
            do
            {
                Console.Clear();
                Console.WriteLine(" [1] Agregar alumno.");
                Console.WriteLine(" [2] Mostrar alumnos.");
                Console.WriteLine(" [3] Buscar alumno.");
                Console.WriteLine(" [4] Editar alumno.");
                Console.WriteLine(" [5] Eliminar alumno.");
                Console.WriteLine(" [6] Salir.");
                op = Convert.ToInt32(Console.ReadLine());

                switch (op)
                {
                    case 1:

                        Console.Clear();
                        Console.WriteLine("Agregar alumno");
                        eAlumno alumno = new eAlumno();
                        do
                        {
                            Console.WriteLine("Carnet: ");
                            alumno.carnet = Console.ReadLine();
                            if (dicAlumnos.ContainsKey(alumno.carnet))
                            {
                                Console.WriteLine("El carnet ingresado ya existe.");
                            }
                        } while (dicAlumnos.ContainsKey(alumno.carnet));
                        Console.WriteLine("Nombre: ");
                        alumno.nombre = Console.ReadLine();
                        Console.WriteLine("Carrera: ");
                        alumno.carrera = Console.ReadLine();
                        Console.WriteLine("CUM: ");
                        alumno.setCUM(Convert.ToDecimal(Console.ReadLine()));
                        dicAlumnos.Add(alumno.carnet, alumno);
                        guardar(dicAlumnos);
                        Console.WriteLine("Datos almacenados Correctamente");
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();

                        break;
                    case 2:
                        Console.Clear();
                        try
                        {
                            Console.WriteLine("======================== LISTADO DE ALUMNOS =============================");
                            Console.WriteLine("{0, -10} {1,-30} {2,-30} {3,-5}", "Carnet: ", "Nombre: ", "Carrera: ", "CUM: ");
                            Console.WriteLine("=========================================================================");
                            leer();
                            foreach (KeyValuePair<string, eAlumno> alumnoG in dicAlumnos)
                            {
                                eAlumno alumns = alumnoG.Value;
                                Console.WriteLine("{0,-10} {1,-30} {2,-30} {3,-5}",
                                alumns.carnet, alumns.nombre, alumns.carrera, alumns.getCUM());
                            }
                            Console.WriteLine("=========================================================================");
                            Console.WriteLine("\nPresione <ENTER> para continuar.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            throw;
                        }
                        Console.ReadKey();

                        break;
                    case 3:
                        Console.Clear();
                        string carnetB;
                        Console.WriteLine("Ingrese carnet del alumno que desea buscar:");
                        carnetB = Console.ReadLine();
                        if (dicAlumnos.ContainsKey(carnetB))
                        {
                            Console.WriteLine("===== DATOS DE ALUMNO =====");
                            Console.WriteLine("{0, 10} {1,-25} {2,-30} {3,5}", "Carnet: ", "Nombre: ", "Carrera: ", "CUM: ");
                            Console.WriteLine("=========================================================================");
                            leer();
                            Console.WriteLine("{0,10} {1,-25} {2,-30} {3,5}",
                                dicAlumnos[carnetB].carnet, dicAlumnos[carnetB].nombre, dicAlumnos[carnetB].carrera, dicAlumnos[carnetB].getCUM());
                        }
                        else
                        {
                            Console.WriteLine("Lo sentimos : " + carnetB + " NO esta registrado en nuestra base de datos.");
                        }
                        Console.WriteLine("\nPresione <ENTER> para continuar.");
                        Console.ReadKey();

                        break;
                    case 4:
                        Console.Clear();
                        string carnetMod;
                        Console.WriteLine("Ingrese carnet del alumno que desea modificar:");
                        carnetMod = Console.ReadLine();
                        if (dicAlumnos.ContainsKey(carnetMod))
                        {
                            Console.WriteLine("===== MODIFICAR DATOS DE ALUMNO =====");
                            dicAlumnos.Remove(carnetMod);
                            Console.WriteLine("===== MODIFICAR =====");
                            Console.WriteLine("INGRESE LOS NUEVOS DATOS DEL ALUMNO " + carnetMod + " :");
                            eAlumno alumnN = new eAlumno();
                            do
                            {
                                Console.WriteLine("Carnet: ");
                                alumnN.carnet = Console.ReadLine();
                                if (dicAlumnos.ContainsKey(alumnN.carnet))
                                {
                                    Console.WriteLine("Carnet existente en el registro.");
                                }
                            } while (dicAlumnos.ContainsKey(alumnN.carnet));
                            Console.WriteLine("Nombre: ");
                            alumnN.nombre = Console.ReadLine();
                            Console.WriteLine("Carrera: ");
                            alumnN.carrera = Console.ReadLine();
                            Console.WriteLine("CUM: ");
                            alumnN.setCUM(Convert.ToDecimal(Console.ReadLine()));
                            dicAlumnos.Add(alumnN.carnet, alumnN);
                            guardar(dicAlumnos);
                            Console.WriteLine("Datos almacenados Correctamente");
                            Console.WriteLine("\nPresione <ENTER> para continuar.");
                            Console.ReadKey();
                        }
                        else
                        {
                            Console.WriteLine("Lo sentimos " + carnetMod + " NO esta registrado en nuestra base de datos.");
                        }

                        break;
                    case 5:
                        Console.Clear();
                        string carnetElim;
                        Console.WriteLine("Ingrese carnet del alumno que desea eliminar:");
                        carnetElim = Console.ReadLine();
                        if (dicAlumnos.ContainsKey(carnetElim))
                        {
                            dicAlumnos.Remove(carnetElim);
                        }
                        guardar(dicAlumnos);

                        break;
                }
            } while (op != 6);
        }
        public static bool guardar(Dictionary<string, eAlumno> dAlumnos)
        {
            try
            {
                FileStream stream = new FileStream(NOMBRE_ARCHIVO, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, dAlumnos);
                stream.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static bool leer()
        {
            try
            {
                FileStream fs = new FileStream(NOMBRE_ARCHIVO, FileMode.Open, FileAccess.Read);
                dicAlumnos = (Dictionary<string, eAlumno>)formatter.Deserialize(fs);
                fs.Close();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
