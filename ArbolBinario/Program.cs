using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    class Program
    {
        static void Main(string[] args)
        {
            int op;
            int nodoUno, nodoDos;
            int dato;
            Arbol objArbol = new Arbol();
            do
            {
                Console.Clear();
                Console.WriteLine("1. Cargar datos, crear árbol");
                Console.WriteLine("2. Ver árbol In Orden, Pre Orden, Pos Orden");
                Console.WriteLine("3. Ver ancestro común más cercano");
                Console.WriteLine("4. Salir");
                Console.WriteLine("Ingrese una opción...");

                op = Int16.Parse(Console.ReadLine()) ;

                switch (op)
                {
                    case 1:
                        {
                            String line;

                            try
                            {
                                System.IO.StreamReader file = new System.IO.StreamReader(@"nodos.txt");
                                while ((line = file.ReadLine()) != null)
                                {
                                    dato = Int16.Parse(line);
                                    Console.WriteLine(dato);
                                    objArbol.crearNodo(dato);
                                }
                                file.Close();
                                objArbol.invocarInOrden();
                                objArbol.invocarPreOrden();
                                objArbol.invocarPosOrden();

                            }
                            catch(System.IO.FileNotFoundException)
                            {
                                Console.WriteLine("No fue posible cargar datos desde el archivo...");
                            }
                            Console.ReadLine();
                            break;
                        }

                    case 2:
                        {
                            if (objArbol.raiz == null)
                            {
                                Console.WriteLine("No hay elementos el en árbol...");
                            }
                            else
                            {
                                
                                Console.WriteLine("Árbol In Orden:");
                                Console.WriteLine(objArbol.cadenaIo);
                                Console.WriteLine("Árbol Pre Orden:");
                                Console.WriteLine(objArbol.cadenaPo);
                                Console.WriteLine("Árbol Pos Orden:");
                                Console.WriteLine(objArbol.cadenaPosO);

                                /*Console.WriteLine("Cantidad de elementos lista In Orden");
                                Console.WriteLine(objArbol.elementos());*/

                            }                           

                            Console.ReadLine();
                            break;
                        }

                    case 3:
                        {
                            if (objArbol.raiz == null)
                            {
                                Console.WriteLine("No hay elementos el en árbol...");
                            }
                            else
                            {
                                Console.WriteLine("Ingrese nodo uno...");
                                nodoUno = Int16.Parse(Console.ReadLine());

                                Console.WriteLine("Ingrese nodo dos...");
                                nodoDos = Int16.Parse(Console.ReadLine());

                                Console.WriteLine("El ancestro común más cercano es: ");
                                Console.WriteLine(objArbol.ancestroComunMasBajo(nodoUno, nodoDos));

                            }                          


                            Console.ReadLine();
                            break;
                        }

                    case 4:
                        {
                            break;
                        }
                }

            } while (op != 4);          

            Console.ReadKey();

            

        }
    }

}


