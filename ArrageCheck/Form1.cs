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
    public partial class Form1 : Form
    {
        public string idAdmin;
        public Form1()
        {
            InitializeComponent();
            textBox1.PasswordChar = '*';
            textBox3.PasswordChar = '*';
            textBox1.MaxLength =15;
            //string conexion = "mongodb://localhost:27017";
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Admins>("Admins");

            dgvAdmins.DataSource = coleccion.FindAll().ToList();
            dgvAdmins.Columns[3].Visible = false;
            dgvAdmins.Columns[1].Visible = false;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
             if (tBNombre.Text==""||tBNombre.Text==null)
            {
                MessageBox.Show("Ingrese Nombre");
            }
            else if (tBCorr.Text == "" || tBCorr.Text == null)
            {
                MessageBox.Show("Ingrese Correo");
            }
            else if (textBox1.Text == "" || textBox1.Text == null)
            {
                MessageBox.Show("Ingrese Contraseña");
            }
            else if (tBCorr.Text != textBox5.Text)
            {
                MessageBox.Show("Los correos no coinciden");
            }
            else if (textBox1.Text != textBox3.Text)
            {
                MessageBox.Show("Las contraseñas no conciden");
            }
             else
            {
                
                    //string conexion = "mongodb://localhost:27017";
                    string conexion = Form3.UsuarioActual.Login.baseDeDatos;
                    var mc = new MongoClient(conexion);
                    var servidor = mc.GetServer();
                    var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
                    servidor.Connect();//Realizar conexion
                    var coleccion = database.GetCollection<Admins>("Admins");
                    var exists2 = coleccion.FindOne(Query<Admins>.EQ(adminsE => adminsE.name, tBNombre.Text));
                    if (exists2 != null)
                    {
                        MessageBox.Show("Ya existe un administrador de nombre " + tBNombre.Text, "Error");
                    }
                    else
                    {
                        exists2 = coleccion.FindOne(Query<Admins>.EQ(adminsE => adminsE.correo, tBCorr.Text));
                        if (exists2 != null)
                        {
                            MessageBox.Show("Ya existe un administrador con el correo " + tBCorr.Text, "Error");
                        }
                        else
                        {
                        try
                        {
                            var admins = new Admins { name = tBNombre.Text, correo = tBCorr.Text, contraseña = textBox1.Text };
                            coleccion.Insert(admins);//Insertamos
                                                     //MessageBox.Show(tBNombre.Text);
                                                     //MessageBox.Show(tBCorr.Text);
                                                     //MessageBox.Show(textBox1.Text);
                            MessageBox.Show(tBNombre.Text + " registrado");
                            dgvAdmins.DataSource = null;
                            dgvAdmins.DataSource = coleccion.FindAll().ToList();
                            dgvAdmins.Columns[3].Visible = false;
                            dgvAdmins.Columns[1].Visible = false;
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("Error: " + error);
                        }

                    }
                    }
                
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 1)
            {
                const string seguro = "¿Estas seguro que desea borrar al administrador?";
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
                    var coleccion = database.GetCollection<Admins>("Admins");
                    ObjectId id = ObjectId.Parse(Convert.ToString(dgvAdmins.CurrentRow.Cells[3].Value));
                    var exists = coleccion.FindOne(Query<Admins>.EQ(admins => admins.id, id));
                    //MessageBox.Show(Convert.ToString(exists));
                    if (exists == null)
                    {
                        MessageBox.Show("No existe!");
                    }
                    var query = Query<Admins>.EQ(admins => admins.id, id);
                    coleccion.Remove(query);
                    dgvAdmins.DataSource = null;
                    dgvAdmins.DataSource = coleccion.FindAll().ToList();
                    dgvAdmins.Columns[3].Visible = false;
                    dgvAdmins.Columns[1].Visible = false;
                    // cancel the closure of the form.
                    MessageBox.Show("Administrador " + administrador + " eliminado.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (dgvAdmins.SelectedRows.Count == 1)
            {
                idAdmin = Convert.ToString(dgvAdmins.CurrentRow.Cells[3].Value);
                Form2 Actualizar = new Form2();
                Actualizar.textBox1.Text =Convert.ToString(dgvAdmins.CurrentRow.Cells[0].Value);
                Actualizar.textBox2.Text = Convert.ToString(dgvAdmins.CurrentRow.Cells[2].Value);
                Actualizar.textBox3.Text = Convert.ToString(dgvAdmins.CurrentRow.Cells[3].Value);
                //MessageBox.Show("iD:" +idAdmin);
                this.Close();
                Actualizar.Show();
            }
                
        }

        private void label8_Click(object sender, EventArgs e)
        {
            Form5 Materiales = new Form5();
            Materiales.Show();
            this.Visible = false;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Form6 Prestamos = new Form6();
            Prestamos.Show();
            this.Visible = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            Form4 Inicio = new Form4();
            Inicio.Show();
            this.Visible = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Form9 Inicio = new Form9();
            Inicio.Show();
            this.Visible = false;
        }
    }
}
