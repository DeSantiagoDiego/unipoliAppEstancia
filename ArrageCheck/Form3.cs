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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            tBHost.Text= UsuarioActual.Login.baseDeDatos;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UsuarioActual.Login.baseDeDatos = tBHost.Text;
            string conexion = UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            //servidor2.Connect();//Realizar conexion
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Admins>("Admins");
            var exists = coleccion.FindOne(Query<Admins>.EQ(admins => admins.correo, tBCorreo.Text));
            if (exists == null)
            {
                MessageBox.Show("El correo ingresado no existe","Error");
            }
            else
            {
                //MessageBox.Show(exists.contraseña);
                //MessageBox.Show(exists.name);
                if (exists.contraseña == tBContraseña.Text)
                {
                    MessageBox.Show("Bienvenido: " + exists.name);
                    UsuarioActual.Login.nombreUsuario = exists.name;
                    Form13 Inicio = new Form13();
                    Inicio.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }
                
            }

        }

        public static class UsuarioActual
        {
            public static class Login
            {
                public static string nombreUsuario;
                public static string baseDeDatos;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UsuarioActual.Login.baseDeDatos = tBHost.Text;
            string conexion = UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Admins>("SuperAdmin");
            var exists = coleccion.FindOne(Query<Admins>.EQ(admins => admins.correo, tBCorreo.Text));
            if (exists == null)
            {
                MessageBox.Show("El correo ingresado no existe", "Error");
            }
            else
            {
                //MessageBox.Show(exists.contraseña);
                //MessageBox.Show(exists.name);
                if (exists.contraseña == tBContraseña.Text)
                {
                    MessageBox.Show("Bienvenido: " + exists.name);
                    UsuarioActual.Login.nombreUsuario = exists.name;
                    Form4 Inicio = new Form4();
                    Inicio.Show();
                    this.Visible = false;
                }
                else
                {
                    MessageBox.Show("Contraseña incorrecta");
                }

            }
        }
    }
}
