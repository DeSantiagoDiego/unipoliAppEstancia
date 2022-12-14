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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
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
            tBContraseña.Text = exists.contraseña;
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            Form4 Inicio = new Form4();
            Inicio.Show();
        }

        private void bCambiar_Click(object sender, EventArgs e)
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
            exists.contraseña =tBContraseña.Text;
            coleccion.Save(exists);
            MessageBox.Show("Contraseña cambiada", "Exito!");
            Form4 Inicio = new Form4();
            Inicio.Show();
            this.Visible = false;
        }

        private void lNombre_Click(object sender, EventArgs e)
        {

        }

        private void tBContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }
    }
}
