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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            //string conexion = "mongodb://localhost:27017";
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Materiales>("MaterialesOficial");
      
            dgvAdmins.DataSource = coleccion.FindAll().ToList();
            dgvAdmins.Columns[4].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Materiales>("MaterialesOficial");
            var coleccion2 = database.GetCollection<Materiales>("Materiales");
            var exists2 = coleccion.FindOne(Query<Materiales>.EQ(materiales => materiales.nombre, tBNombre.Text));
            if (exists2 != null)
            {
                MessageBox.Show("Ya existe material de nombre " + tBNombre.Text, "Error");
            }
            else
            {

                try
                {
                    //string conexion = "mongodb://localhost:27017";
                    var materiales = new Materiales { nombre = tBNombre.Text, descripcion = tBDescripcion.Text, estado = tBEstado.Text, unidades = tBUnidades.Text };
                    coleccion.Insert(materiales);//Insertamos
                    coleccion2.Insert(materiales);//Insertamos
                                                  //MessageBox.Show(tBNombre.Text);
                                                  //MessageBox.Show(tBDescripcion.Text);
                                                  //MessageBox.Show(tBEstado.Text);
                                                  //MessageBox.Show(tBUnidades.Text);
                    MessageBox.Show("Material Registrado");
                    dgvAdmins.DataSource = null;
                    dgvAdmins.DataSource = coleccion.FindAll().ToList();
                    dgvAdmins.Columns[4].Visible = false;
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error);
                }
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 Administradores = new Form1();
            Administradores.Show();
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6 Prestamos = new Form6();
            Prestamos.Show();
            this.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form4 Inicio = new Form4();
            Inicio.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
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

            if(dgvAdmins.SelectedRows.Count == 1){

                //string conexion = "mongodb://localhost:27017";
                string conexion = Form3.UsuarioActual.Login.baseDeDatos;
                var mc = new MongoClient(conexion);
                var servidor = mc.GetServer();
                var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
                servidor.Connect();//Realizar conexion
                var coleccion2 = database.GetCollection<Materiales>("Materiales");
                var exists = coleccion2.FindOne(Query<Materiales>.EQ(Materiales => Materiales.nombre, Convert.ToString(dgvAdmins.CurrentRow.Cells[0].Value)));
                if (exists == null)
                {
                    //MessageBox.Show("El correo ingresado no existe", "Error");
                    
                }

                //MessageBox.Show(exists.unidades);
                if (exists.unidades== Convert.ToString(dgvAdmins.CurrentRow.Cells[3].Value))
                {
                    Material.modificarMaterial.unidades = Convert.ToString(dgvAdmins.CurrentRow.Cells[3].Value);
                    Material.modificarMaterial.estado = Convert.ToString(dgvAdmins.CurrentRow.Cells[2].Value);
                    Material.modificarMaterial.id = Convert.ToString(dgvAdmins.CurrentRow.Cells[4].Value);
                    Form14 ActualizarMaterial = new Form14();
                    this.Close();
                    ActualizarMaterial.Show();
                }
                else
                {
                    MessageBox.Show("No puedes editar este material.\nAsegurese de no tener unidades prestadas de este material y vuelva a intentarlo", "Error!");
                }
                
            }
        }

        public static class Material
        {
            public static class modificarMaterial
            {
                public static string unidades;
                public static string estado;
                public static string id;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (dgvAdmins.SelectedRows.Count == 1)
            {
                string conexion2 = Form3.UsuarioActual.Login.baseDeDatos;
                var mc2 = new MongoClient(conexion2);
                var servidor2 = mc2.GetServer();
                var database2 = servidor2.GetDatabase("ArrageCheck");//Uso de base de datos
                servidor2.Connect();//Realizar conexion
                var coleccion3 = database2.GetCollection<Materiales>("Materiales");
                var exists2 = coleccion3.FindOne(Query<Materiales>.EQ(Materiales => Materiales.nombre, Convert.ToString(dgvAdmins.CurrentRow.Cells[0].Value)));
                if (exists2 == null)
                {
                    //MessageBox.Show("El correo ingresado no existe", "Error");

                }

                //MessageBox.Show(exists.unidades);
                if (exists2.unidades == Convert.ToString(dgvAdmins.CurrentRow.Cells[3].Value))
                {
                    const string seguro = "¿Estas seguro que desea borrar el material?";
                    string administrador = Convert.ToString(dgvAdmins.CurrentRow.Cells[0].Value);
                    var result = MessageBox.Show(seguro, "Borrar: " + administrador, MessageBoxButtons.YesNo);
                    //textBox1.Text = Convert.ToString(dgvAdmins.CurrentRow.Cells[0].Value);
                    if (result == DialogResult.Yes)
                    {
                        //string conexion = "mongodb://localhost:27017";
                        string conexion = Form3.UsuarioActual.Login.baseDeDatos;
                        var mc = new MongoClient(conexion);
                        var servidor = mc.GetServer();
                        var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
                        servidor.Connect();//Realizar conexion
                        var coleccion = database.GetCollection<Materiales>("Materiales");
                        var coleccion2 = database.GetCollection<Materiales>("MaterialesOficial");
                        ObjectId id = ObjectId.Parse(Convert.ToString(dgvAdmins.CurrentRow.Cells[4].Value));
                        var exists = coleccion.FindOne(Query<Materiales>.EQ(admins => admins.id, id));
                        MessageBox.Show(Convert.ToString(exists));
                        if (exists == null)
                        {
                            MessageBox.Show("No existe!");
                        }
                        var query = Query<Admins>.EQ(admins => admins.id, id);
                        coleccion.Remove(query);
                        coleccion2.Remove(query);
                        dgvAdmins.DataSource = null;
                        dgvAdmins.DataSource = coleccion.FindAll().ToList();
                        dgvAdmins.Columns[4].Visible = false;
                        // cancel the closure of the form.
                        MessageBox.Show("Material " + administrador + " eliminado.");
                    }
                }
                else
                {
                    MessageBox.Show("No puedes eliminar este material.\nAsegurese de no tener unidades prestadas de este material y vuelva a intentarlo", "Error!");
                }
               
            }
        }
    }
}
