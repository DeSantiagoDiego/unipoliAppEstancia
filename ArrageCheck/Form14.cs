using MongoDB.Bson;
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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
            textBox1.Text = Form5.Material.modificarMaterial.unidades;
            textBox2.Text = Form5.Material.modificarMaterial.estado;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 AdminsMaterial = new Form5();

            //string conexion = "mongodb://localhost:27017";
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Materiales>("Materiales");
            var coleccion2 = database.GetCollection<Materiales>("MaterialesOficial");
            ObjectId id = ObjectId.Parse(Form5.Material.modificarMaterial.id);
            var exists = coleccion.FindOne(Query<Materiales>.EQ(admins => admins.id, id));
            //MessageBox.Show(Convert.ToString(exists));
            if (exists == null)
            {
                MessageBox.Show("No existe!");
            }
            var query = Query<Admins>.EQ(admins => admins.id, id);
            var rutina = coleccion.FindOne(query);
            rutina.unidades = textBox1.Text;
            rutina.estado = textBox2.Text;
            coleccion.Save(rutina);
            coleccion2.Save(rutina);
            this.Visible = false;

            AdminsMaterial.dgvAdmins.DataSource = null;
            AdminsMaterial.dgvAdmins.DataSource = coleccion2.FindAll().ToList();
            AdminsMaterial.dgvAdmins.Columns[4].Visible = false;
            // cancel the closure of the form.
            MessageBox.Show("Material actualizado.");
            AdminsMaterial.Show();
        }
    }
}
