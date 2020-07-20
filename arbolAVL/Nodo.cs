using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace arbolAVL
{
    class Nodo
    {
		int dato;
		int fb;
		int altura;
		Nodo izquierda, derecha;
		public Nodo()
		{
			this.dato =0;
			this.fb = 0;
			this.altura = 0;
			this.izquierda = null;
			this.derecha = null;
		}
		public Nodo(int d)
		{
			this.dato = d;
			this.fb = 0;
			this.altura = 0;
			this.izquierda = null;
			this.derecha = null;
		}

        public int Dato { get => dato; set => dato = value; }
        public int Fb { get => fb; set => fb = value; }
        public int Altura { get => altura; set => altura = value; }
        internal Nodo Izquierda { get => izquierda; set => izquierda = value; }
        internal Nodo Derecha { get => derecha; set => derecha = value; }
    }
}
