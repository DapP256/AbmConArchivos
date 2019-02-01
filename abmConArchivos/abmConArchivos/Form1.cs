using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace abmConArchivos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        struct persona
        {
            public string nombre, apellido;
            public int dni, edad;

            public override string ToString()
            {
                return nombre+""+apellido+""+edad+""+dni.ToString();
            }
        }

        persona p1 = new persona();

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream altas = new FileStream("altas.txt", FileMode.Append);
            StreamWriter escritor = new StreamWriter(altas);
            string linea;
            p1.nombre = textBox1.Text;
            p1.apellido = textBox2.Text;
            p1.edad = Convert.ToInt16(textBox3.Text);
            p1.dni = Convert.ToInt32(textBox4.Text);

            linea = p1.nombre + "," + p1.apellido + "," + p1.edad + "," + p1.dni;
            escritor.WriteLine(linea);
            limpiar();
            escritor.Close();
            altas.Close();
            actualizar();

        }

        private void actualizar()
        {
            FileStream altas = new FileStream("altas.txt", FileMode.OpenOrCreate);
            StreamReader lector = new StreamReader(altas);

            string linea;
            linea = lector.ReadLine();
            listBox1.Items.Clear();
            while (linea != null)
            {
                lector.ReadLine();
                listBox1.Items.Add(linea);
                linea = lector.ReadLine();

            }
            lector.Close();
            altas.Close();
        }

        private void limpiar()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            actualizar();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string linea = listBox1.SelectedItem.ToString();
            string[] datos;
            datos = linea.Split(',');
            textBox1.Text = datos[0];
            textBox2.Text = datos[1];
            textBox3.Text = datos[2];
            textBox4.Text = datos[3];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileStream altas = new FileStream("altas.txt", FileMode.Open);
            StreamReader lector = new StreamReader(altas);
            FileStream aux = new FileStream("aux2.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(aux);
            string linea;
            string[] dato;
            linea = lector.ReadLine();

            while (linea != null)
            {

                dato = linea.Split(',');

                if (textBox4.Text != dato[3])
                {
                    escritor.WriteLine();
                }
                linea = lector.ReadLine();

            }
            escritor.Close();
            lector.Close();
            aux.Close();
            altas.Close();
            File.Delete("altas.txt");
            File.Move("aux2.txt", "altas.txt");
            actualizar();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream altas = new FileStream("altas.txt", FileMode.Open);
            StreamReader lector = new StreamReader(altas);
            FileStream aux = new FileStream("aux2.txt", FileMode.Create);
            StreamWriter escritor = new StreamWriter(aux);
            string linea;
            string[] dato;
            linea = lector.ReadLine();

            while (linea != null)
            {

                dato = linea.Split(',');

                if (textBox4.Text != dato[3])
                {
                    escritor.WriteLine();
                }

                else
                {
                    linea = textBox1.Text + "," + textBox2.Text + "," + textBox3.Text + "," + textBox4.Text;
                    escritor.WriteLine(linea);
                }
                linea = lector.ReadLine();

            }
            escritor.Close();
            lector.Close();
            aux.Close();
            altas.Close();
            File.Delete("altas.txt");
            File.Move("aux2.txt", "altas.txt");
            actualizar();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
