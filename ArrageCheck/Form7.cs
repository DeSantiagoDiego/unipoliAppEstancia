using MongoDB.Driver;
using MongoDB.Driver.Builders;
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
    public partial class Form7 : Form
    {
        public string cantidadDisponible;
        public Form7()
        {
            InitializeComponent();
            textBox1.Text= Form3.UsuarioActual.Login.nombreUsuario;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Admins>("SuperAdmin");
            var exists = coleccion.FindOne(Query<Admins>.EQ(admins => admins.name, Form3.UsuarioActual.Login.nombreUsuario));
            if (exists == null)
            {
                MessageBox.Show("El correo ingresado no existe", "Error");
            }
            exists.name = textBox1.Text;
            Form3.UsuarioActual.Login.nombreUsuario = textBox1.Text;
            coleccion.Save(exists);
            MessageBox.Show("Nombre cambiado", "Exito!");
            Form4 Inicio = new Form4();
            Inicio.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 Inicio = new Form4();
            Inicio.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
