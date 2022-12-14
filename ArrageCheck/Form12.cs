using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace ArrageCheck
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();

            //string conexion = "mongodb://localhost:27017";
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Historial>("HistorialPrestamos");
            string hola;

            dgvHistorialPrestamosAdmin.DataSource = coleccion.FindAll().ToList();
            dgvHistorialPrestamosAdmin.Columns[0].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvHistorialPrestamosAdmin.SelectedRows.Count == 1)
            {
                if (Convert.ToString(dgvHistorialPrestamosAdmin.CurrentRow.Cells[5].Value) != Form3.UsuarioActual.Login.nombreUsuario)
                {
                    MessageBox.Show("Este prestamo no lo realizó usted");
                }
                else
                if (Convert.ToString(dgvHistorialPrestamosAdmin.CurrentRow.Cells[10].Value) == "Entregado")
                {
                    MessageBox.Show("Este material ya fue entregado");
                }
                else if (Convert.ToString(dgvHistorialPrestamosAdmin.CurrentRow.Cells[10].Value) == "Rechazado")
                {
                    MessageBox.Show("Este prestamo no fue aceptado. El material fue regresado");
                }
                else if (Convert.ToString(dgvHistorialPrestamosAdmin.CurrentRow.Cells[10].Value) == "Pendiente")
                {
                    MessageBox.Show("Este prestamo aun se encuentra en espera");
                }
                else
                {

                    ObjectId id = ObjectId.Parse(Convert.ToString(dgvHistorialPrestamosAdmin.CurrentRow.Cells[0].Value));
                    var materialPrestado = Convert.ToString(dgvHistorialPrestamosAdmin.CurrentRow.Cells[1].Value);
                    var unidadesPrestadas = Convert.ToString(dgvHistorialPrestamosAdmin.CurrentRow.Cells[4].Value);

                    //string conexion = "mongodb://localhost:27017";
                    string conexion = Form3.UsuarioActual.Login.baseDeDatos;
                    var mc = new MongoClient(conexion);
                    var servidor = mc.GetServer();
                    var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
                    servidor.Connect();//Realizar conexion
                    var coleccion4 = database.GetCollection<Materiales>("Materiales");
                    var coleccion5 = database.GetCollection<Historial>("HistorialPrestamos");
                    var exists = coleccion4.FindOne(Query<Materiales>.EQ(Materiales => Materiales.nombre, materialPrestado));
                    var estadoActual = coleccion5.FindOne(Query<Historial>.EQ(historial => historial.id, id));
                    if (exists == null)
                    {
                        MessageBox.Show("El correo ingresado no existe", "Error");
                    }
                    MessageBox.Show("Unidades tras el prestamo: " + exists.unidades);
                    MessageBox.Show("Unidades prestadas: " + unidadesPrestadas);
                    int total = Convert.ToInt16(exists.unidades) + Convert.ToInt16(unidadesPrestadas);
                    MessageBox.Show("Unidades disponibles una vez entregado el material: " + Convert.ToString(total));
                    exists.unidades = Convert.ToString(total);
                    estadoActual.EstadoActual = "Entregado";
                    coleccion5.Save(estadoActual);
                    coleccion4.Save(exists);
                    dgvHistorialPrestamosAdmin.DataSource = coleccion5.FindAll().ToList();
                    dgvHistorialPrestamosAdmin.Columns[0].Visible = false;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Hola");
            Form13 Inicio = new Form13();
            Inicio.Show();
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form10 Prestamos = new Form10();
            Prestamos.Show();
            this.Visible = false;
        }
    }
}
