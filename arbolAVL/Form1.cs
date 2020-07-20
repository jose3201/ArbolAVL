using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace arbolAVL
{
    public partial class Form1 : Form
    {
        AVL n;
        public Form1()
        {
            InitializeComponent();
            n = new AVL();
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            try
            {
                grafica.Image = null;
                string en = insertar.Text;
                if (n.Insertar(int.Parse(en)) == false)
                {
                    MessageBox.Show("Dato repetido!!!");
                }
                string ruta = System.IO.Directory.GetCurrentDirectory();
                n.generarDotAVL();
                Image ll = Image.FromFile(ruta + "\\" + "Arbol_AVL.png");
                Bitmap rr = new Bitmap(ll, new Size(grafica.Height, grafica.Width));
                grafica.Image = (Image)rr;
                grafica.Refresh();
                ll.Dispose();
                insertar.Text = "";

            }
            catch (FormatException)
            {
                string ruta = System.IO.Directory.GetCurrentDirectory();
                MessageBox.Show("Solo Numeros!!!");
                Image ll = Image.FromFile(ruta + "\\" + "Arbol_AVL.png");
                grafica.Image = ll;
                grafica.Refresh();
                ll.Dispose();
                insertar.Text = "";
            }
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            try
            {
                grafica.Image = null;
                string en = eliminar.Text;
                if (n.Eliminar(int.Parse(en)) == true)
                {
                    MessageBox.Show("Dato Eliminado!!!");
                }
                else
                {
                    MessageBox.Show("Dato no Existe!!!");
                }
                string ruta = System.IO.Directory.GetCurrentDirectory();
                n.generarDotAVL();
                Image ll = Image.FromFile(ruta + "\\" + "Arbol_AVL.png");
                Bitmap rr = new Bitmap(ll, new Size(grafica.Height,grafica.Width));
                grafica.Image = (Image)rr;
                grafica.Refresh();
                ll.Dispose();
                eliminar.Text = "";
            }
            catch (FormatException)
            {
                string ruta = System.IO.Directory.GetCurrentDirectory();
                MessageBox.Show("Solo Numeros!!!");
                Image ll = Image.FromFile(ruta + "\\" + "Arbol_AVL.png");
                grafica.Image = ll;
                grafica.Refresh();
                ll.Dispose();
                eliminar.Text = "";
            }
        }
    }
}
