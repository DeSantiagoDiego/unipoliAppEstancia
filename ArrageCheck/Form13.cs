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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
            lNombreUsuario.Text = Form3.UsuarioActual.Login.nombreUsuario;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form10 Prestamos = new Form10();
            Prestamos.Show();
            this.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form12 Historial = new Form12();
            Historial.Show();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 Login = new Form3();
            Login.Show();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 CambiarContraseñaAdmin = new Form16();
            CambiarContraseñaAdmin.Show();
            this.Visible = false;
        }
    }
}
