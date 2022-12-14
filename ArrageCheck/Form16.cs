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
    public partial class Form16 : Form
    {
        public Form16()
        {
            InitializeComponent();
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Admins>("Admins");
            var exists = coleccion.FindOne(Query<Admins>.EQ(admins => admins.name, Form3.UsuarioActual.Login.nombreUsuario));
            if (exists == null)
            {
                MessageBox.Show("El correo ingresado no existe", "Error");
            }
            tBContraseñaAdmin.Text = exists.contraseña;
        }

        private void bCambiarAdmin_Click(object sender, EventArgs e)
        {
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Admins>("Admins");
            var exists = coleccion.FindOne(Query<Admins>.EQ(admins => admins.name, Form3.UsuarioActual.Login.nombreUsuario));
            if (exists == null)
            {
                MessageBox.Show("El correo ingresado no existe", "Error");
            }
            exists.contraseña = tBContraseñaAdmin.Text;
            coleccion.Save(exists);
            MessageBox.Show("Contraseña cambiada", "Exito!");
            Form13 InicioAdmin = new Form13();
            InicioAdmin.Show();
            this.Visible = false;
        }

        private void bCancelarAdmin_Click(object sender, EventArgs e)
        {
            this.Close();
            Form13 InicioAdmin = new Form13();
            InicioAdmin.Show();
        }
    }
}
