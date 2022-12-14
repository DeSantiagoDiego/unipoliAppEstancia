using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArrageCheck
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
           lNombreUsuario.Text= Form3.UsuarioActual.Login.nombreUsuario;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 Administradores = new Form1();
            Administradores.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form5 Materiales = new Form5();
            Materiales.Show();
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6 Prestamos = new Form6();
            Prestamos.Show();
            this.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form9 Historial = new Form9();
            Historial.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 Login = new Form3();
            Login.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form7 CambiarNombre = new Form7();
            CambiarNombre.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form15 CambiarContraseña = new Form15();
            CambiarContraseña.Show();
            this.Visible = false;
        }
    }
}
