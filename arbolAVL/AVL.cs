using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace arbolAVL
{
    class AVL
    {
        Nodo root;
        int contadordenodo;
        public AVL()
        {
            root = null;
            contadordenodo = 0;
        }
        Nodo extraerRaiz() { return root; }
        int Altura()
        {
            if (root == null) return 0;
            return root.Altura;
        }
        int Tama() { return contadordenodo; }
        bool EsVacio()
        {
            if (root == null) return true;
            return false;
        }
        bool ExisteVal(int d)
        {
            return ExisteVal(root, d);
        }
        bool ExisteVal(Nodo n, int d)
        {
            if (n == null) return false;

            if (d < n.Dato) return ExisteVal(n.Izquierda, d);

            if (d > n.Dato) return ExisteVal(n.Derecha, d);

            return true;
        }
        public bool Insertar(int d)
        {
            if (!ExisteVal(root, d))
            {
                root = Insertar(root, d);
                contadordenodo++;
                return true;
            }
            return false;
        }
        Nodo Insertar(Nodo n, int d)
        {
            if (n == null)
            {
                return new Nodo(d);

            }
            else if (d < n.Dato)
            {
                n.Izquierda = Insertar(n.Izquierda, d);
            }
            else
            {
                n.Derecha = Insertar(n.Derecha, d);
            }
            Actualizar(n);
            return Balanceo(n);
        }
        void Actualizar(Nodo n)
        {
            int alizqui = (n.Izquierda == null) ? -1 : n.Izquierda.Altura;
            int alderecha = (n.Derecha == null) ? -1 : n.Derecha.Altura;
            n.Altura = 1 + Max(alizqui, alderecha);
            n.Fb = alderecha - alizqui;
        }
        int Max(int x, int y)
        {
            if (x < y)
            {
                return y;
            }
            else if (x > y)
            {
                return x;
            }
            else
            {
                return y;
            }

        }
        Nodo Balanceo(Nodo n)
        {
            if (n.Fb == -2)
            {
                if (n.Izquierda.Fb <= 0)
                {
                    // Caso izquierda-izquierda.
                    return IzquiIzqui(n);

                    // Caso izquierda-derecha.
                }
                else
                {
                    return izquiDere(n);
                }
                //	El subárbol pesado derecho necesita equilibrio.
            }
            else if (n.Fb == +2)
            {

                // Caso derecha-derecha.
                if (n.Derecha.Fb >= 0)
                {
                    return DereDere(n);


                    // Caso derecho-izquierdo.
                }
                else
                {
                    return DereIzqui(n);
                }
            }


            // El nodo tiene un factor de equilibrio de 0, +1 o -1, que está bien.
            return n;
        }
        Nodo IzquiIzqui(Nodo n)
        {
            return RotacionDere(n);
        }
        Nodo izquiDere(Nodo n)
        {
            n.Izquierda = RotacionIzqui(n.Izquierda);
            return IzquiIzqui(n);
        }

        Nodo DereDere(Nodo n)
        {
            return RotacionIzqui(n);
        }

        Nodo DereIzqui(Nodo n)
        {
            n.Derecha = RotacionDere(n.Derecha);
            return DereDere(n);
        }
        Nodo RotacionIzqui(Nodo n)
        {
            Nodo aux = n.Derecha;
            n.Derecha = aux.Izquierda;
            aux.Izquierda = n;
            Actualizar(n);
            Actualizar(aux);
            return aux;
        }

        Nodo RotacionDere(Nodo n)
        {
            Nodo aux = n.Izquierda;
            n.Izquierda = aux.Derecha;
            aux.Derecha = n;
            Actualizar(n);
            Actualizar(aux);
            return aux;
        }
        public bool Eliminar(int d)
        {

            if (ExisteVal(root, d))
            {
                root = Eliminar(root, d);
                contadordenodo--;
                return true;
            }

            return false;
        }
        Nodo Eliminar(Nodo n, int d)
        {

            if (n == null) return null;

            if (d < n.Dato)
            {
                n.Izquierda = Eliminar(n.Izquierda, d);
            }
            else if (d > n.Dato)
            {
                n.Derecha = Eliminar(n.Derecha, d);
            }
            else
            {
                if (n.Izquierda == null)
                {
                    return n.Derecha;
                }
                else if (n.Derecha == null)
                {
                    return n.Izquierda;
                }
                else
                {
                    if (n.Izquierda.Altura > n.Derecha.Altura)
                    {

                        int datoderecha = VMDerecha(n.Izquierda);
                        n.Dato = datoderecha;
                        n.Izquierda = Eliminar(n.Izquierda, datoderecha);

                    }
                    else
                    {
                        int datoizquierda = VMIzquierda(n.Derecha);
                        n.Dato = datoizquierda;
                        n.Derecha = Eliminar(n.Derecha, datoizquierda);
                    }
                }
            }

            Actualizar(n);
            return Balanceo(n);
        }
        int VMIzquierda(Nodo n)
        {
            while (n.Izquierda != null) n = n.Izquierda;
            return n.Dato;
        }
        int VMDerecha(Nodo n)
        {
            while (n.Derecha != null) n = n.Derecha;
            return n.Dato;
        }
        public Nodo Buscar(int d, Nodo n)
        {
            if (n == null)
            {
                return null;
            }
            else if (n.Dato == d)
            {
                return n;
            }
            else if (n.Dato < d)
            {
                return Buscar(d, n.Derecha);

            }
            else
            {
                return Buscar(d, n.Izquierda);
            }

        }
        public void inOrder(Nodo r)
        {
            if (r != null)
            {
                inOrder(r.Izquierda);
                Console.Write(r.Dato+",");
                inOrder(r.Derecha);
            }
        }

        public void inOrder1(Nodo r)
        {
            if (r != null)
            {
                inOrder(r.Izquierda);
                Console.Write(r.Dato + ",");
                inOrder(r.Derecha);
            }
        }

        public void preOrder(Nodo r)
        {
            if (r != null)
            {
                Console.Write(r.Dato + ",");
                preOrder(r.Izquierda);
                preOrder(r.Derecha);
            }
        }

        public void postOrder(Nodo r)
        {
            if (r != null)
            {
                postOrder(r.Izquierda);
                postOrder(r.Derecha);
                Console.Write(r.Dato + ",");
            }
        }
        public void generarDotAVL()
        {
            string ruta = System.IO.Directory.GetCurrentDirectory();
            string strdot = "";
            string nombre = "Arbol_AVL";
            strdot = strdot + "digraph G{\n" + "label = \"ARBOL AVL\";\n graph [ dpi = 300 ]; \n";
            strdot = strdot + "node[shape=circle; color=blue;];\n";
            strdot = strdot + dotStringAVL(root);
            strdot = strdot + "}\n";


            //------->escribir archivo
         
            StreamWriter dot = new StreamWriter(ruta+"\\"+nombre+".dot");
            dot.WriteLine(strdot);
            dot.Close();
            string comando = "dot -Tpng " + ruta + "\\" + nombre + ".dot -o  " + nombre + ".png";
            //------->generar png
            Process cmd = new Process();
            cmd.StartInfo.FileName = "cmd.exe";
            cmd.StartInfo.RedirectStandardInput = true;
            cmd.StartInfo.RedirectStandardOutput = true;
            cmd.StartInfo.CreateNoWindow = true;
            cmd.StartInfo.UseShellExecute = false;
            cmd.StartInfo.Arguments = "/C "+comando;
            cmd.Start();

            cmd.StandardInput.WriteLine("echo Oscar");
            cmd.StandardInput.Flush();
            cmd.StandardInput.Close();
            cmd.WaitForExit();
            Console.WriteLine(cmd.StandardOutput.ReadToEnd());


        }
        string dotStringAVL(Nodo nnz)
        {
            string ccdot = "";
            Nodo aux, aux2, aux3;
            if (nnz != null)
            {
                aux = nnz;
                ccdot = "\"ffe" + aux.Dato +"\""+ "[label=\"" + nnz.Dato + "\",color=\"chartreuse2\"];\n";
                if (nnz.Izquierda != null)
                {
                    
                    aux2= nnz.Izquierda;
                    ccdot = ccdot + "\"ffe" + aux.Dato+"\"" + "-> \"ffe" + aux2.Dato + "\";\n";
                }
                if (nnz.Derecha != null)
                {
                    aux2 = nnz.Derecha;
                    ccdot = ccdot + "\"ffe" + aux.Dato+"\"" + "-> \"ffe" + aux2.Dato + "\";\n";
                }
                ccdot = ccdot + dotStringAVL(nnz.Izquierda) + dotStringAVL(nnz.Derecha);
            }
            return ccdot;
        }

    }
}
