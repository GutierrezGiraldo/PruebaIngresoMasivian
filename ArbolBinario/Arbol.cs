using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArbolBinario
{
    class Arbol
    {
        
        public ArrayList listaInOrder = new ArrayList();
        public ArrayList listaPosOrder = new ArrayList();
        public ArrayList listaFinal = new ArrayList();
        public ArrayList listaFinalPuntajes = new ArrayList();




        public class Nodo
        {
            public int n;
            public Nodo izq;
            public Nodo der;

            public Nodo( int dato )
            {
                this.n = dato;
                this.izq = null;
                this.der = null;               
            }

            public Nodo()
            {

            }
        }

        public Nodo raiz;
        public string cadenaIo = "";
        public string cadenaPo = "";
        public string cadenaPosO = "";

        public void crearNodo( int dato )
        {
            Nodo nuevo = new Nodo(dato);

            if( this.raiz == null)
            {
                this.raiz = nuevo;
                
            }
            else
            {
                this.raiz = this.enlazar(raiz, nuevo);               
            }
        }

        public Nodo enlazar( Nodo aux, Nodo nuevo)
        {
            if (nuevo.n < aux.n)
            {
                if (aux.izq == null)
                {
                    aux.izq = nuevo;
                    return aux;
                }
                else
                {
                    aux.izq = enlazar(aux.izq, nuevo);
                    return aux;

                }
            }
            else
            {
                if( aux.der == null)
                {
                    aux.der = nuevo;
                    return aux;
                }
                else
                {
                    aux.der = enlazar(aux.der, nuevo);
                    return aux;
                }
            }
        }

        public void inOrden(Nodo aux)
        {
            if (aux != null)
            {
                inOrden(aux.izq);
                listaInOrder.Add(aux.n);
                cadenaIo = cadenaIo + " " + aux.n;
                inOrden(aux.der);
            }
            
        }

        public void invocarPreOrden()
        {
            preOrden(raiz);            
        }

        public void preOrden(Nodo aux)
        {
            if (aux != null)
            {
                cadenaPo = cadenaPo + " " + aux.n;
                preOrden(aux.izq);
                preOrden(aux.der);
            }

        }

        public void invocarInOrden()
        {
            inOrden(raiz);
        }

        public void posOrden(Nodo aux)
        {
            if (aux != null)
            {                
                posOrden(aux.izq);
                posOrden(aux.der);
                listaPosOrder.Add(aux.n);
                cadenaPosO = cadenaPosO + " " + aux.n;
            }

        }

        public void invocarPosOrden()
        {
            posOrden(raiz);
        }

        public String ancestroComunMasBajo(int numeroUno, int numeroDos)
        {
            listaFinal.Clear();
            listaFinalPuntajes.Clear();
            int numUno, numDos;
            numUno = listaInOrder.IndexOf(numeroUno);
            numDos = listaInOrder.IndexOf(numeroDos);

            if (numUno < 0 || numDos < 0)
            {
                return "Los números especificados no se encuentran en el árbol...";
            }
            else
            {
                if (numUno < numDos)
                {
                    for(int i= (numUno+1); i<=(numDos-1); i++)
                    {                        
                        listaFinal.Add(listaInOrder[i]);
                    }
                }
                else
                {
                    for (int i = (numDos + 1); i <= (numUno - 1); i++)
                    {
                        listaFinal.Add(listaInOrder[i]);
                    }
                }
            }

            foreach(int numero in listaFinal)
            {
                listaFinalPuntajes.Add(listaPosOrder.IndexOf(numero));
            }            

            int mayor = 0; 

            foreach(int numero in listaFinalPuntajes)
            {
                if (numero > mayor)
                {
                    mayor = numero;
                }
            }

            return "" + listaFinal[listaFinalPuntajes.IndexOf(mayor)];
        }


        public Arbol()
        {
            this.raiz = null;
        }
        
    }
}
