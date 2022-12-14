using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace ArrageCheck
{
    public partial class Form2 : Form
    {
        public string idAdmin;
        public Form2()
        {
            InitializeComponent();
            Form1 AdminsTabla = new Form1();
            AdminsTabla.Close();
            //AdminsTabla.Visible = false;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 AdminsTabla = new Form1();

            //string conexion = "mongodb://localhost:27017";
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion


            var coleccion = database.GetCollection<Admins>("Admins");
            ObjectId id = ObjectId.Parse(textBox3.Text);
            var exists = coleccion.FindOne(Query<Admins>.EQ(admins => admins.id, id));
            //MessageBox.Show(Convert.ToString(exists));
            if (exists == null)
            {
                MessageBox.Show("No existe!");
            }
            var query = Query<Admins>.EQ(admins => admins.id, id);
            var rutina = coleccion.FindOne(query);
            rutina.name = textBox1.Text;
            rutina.correo = textBox2.Text;
            coleccion.Save(rutina);
            this.Visible = false;
            
            AdminsTabla.dgvAdmins.DataSource = null;
            AdminsTabla.dgvAdmins.DataSource = coleccion.FindAll().ToList();
            AdminsTabla.dgvAdmins.Columns[3].Visible = false;
            AdminsTabla.dgvAdmins.Columns[1].Visible = false;
            // cancel the closure of the form.
            MessageBox.Show("Administrador " + textBox1.Text + " actualizado.");
            AdminsTabla.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
