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

namespace ArrageCheck
{
    public partial class Form6 : Form
    {
        
        //public string materialesPrestamoCantidad;
        public Form6()
        {
            InitializeComponent();
            label8.Visible = false;
            label9.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            numericUpDown1.Visible = false;
            //string conexion = "mongodb://localhost:27017";
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion = database.GetCollection<Materiales>("Materiales");
            var coleccion2 = database.GetCollection<Materiales>("MaterialesPrestamo");
            coleccion2.RemoveAll();
            string hola;
            dataGridView1.DataSource = coleccion2.FindAll().ToList();
            dataGridView1.Columns[4].Visible = false;
            dgvAdmins.DataSource = coleccion.FindAll().ToList();
            dgvAdmins.Columns[4].Visible = false;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvAdmins.SelectedRows.Count == 1) {

                /*PARTE PARA GUARDAR DATOS EN LA COLECCION PRESTAMOS FINALES
                 int i = 0;
                 int j = 0;
                 button1.Visible = false;
                 MessageBox.Show(Convert.ToString(dgvAdmins.RowCount));
                 i = Convert.ToInt16(dgvAdmins.RowCount);
                 j = i - 1;
                 do
                 {
                     MessageBox.Show(Convert.ToString(dgvAdmins.Rows[j].Cells[0].Value));
                     MessageBox.Show(Convert.ToString(dgvAdmins.Rows[j].Cells[1].Value));
                     MessageBox.Show(Convert.ToString(dgvAdmins.Rows[j].Cells[2].Value));
                     MessageBox.Show(Convert.ToString(dgvAdmins.Rows[j].Cells[3].Value));
                     i--;
                     j--;
                 } while(i!=0);*/
            Globals.prestamosCantidadees.canti = Convert.ToString(dgvAdmins.CurrentRow.Cells[3].Value);
            MessageBox.Show(Convert.ToString(dgvAdmins.CurrentRow.Cells[0].Value));
            MessageBox.Show(Convert.ToString(dgvAdmins.CurrentRow.Cells[1].Value));
            MessageBox.Show(Convert.ToString(dgvAdmins.CurrentRow.Cells[2].Value));
            label9.Text = Globals.prestamosCantidadees.canti;
            MessageBox.Show(label9.Text);
            label8.Visible = true;
            label9.Visible = true;
            button5.Visible = true;
            button4.Visible = true;
            numericUpDown1.Visible = true;
            }
            else
            {
                MessageBox.Show("Selecciona un material");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form8 Prestatario = new Form8();
            Prestatario.Visible = true;
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Form9 Historial = new Form9();
            this.Visible = false;
            Historial.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
            label9.Visible = false;
            button5.Visible = false;
            button4.Visible = false;
            numericUpDown1.Visible = false;
            button1.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*MessageBox.Show("Numero de materiales: "+Convert.ToString(dgvAdmins.RowCount));
            MessageBox.Show(Convert.ToString(dgvAdmins.CurrentRow.Cells[0].Value));
            MessageBox.Show(Convert.ToString(dgvAdmins.CurrentRow.Cells[1].Value));
            MessageBox.Show(Convert.ToString(dgvAdmins.CurrentRow.Cells[2].Value));
            MessageBox.Show(label9.Text);
            MessageBox.Show(Convert.ToString(numericUpDown1.Value));
            */
            int cantidadTomada = Convert.ToInt16(numericUpDown1.Value);
            if (cantidadTomada <= 0)
            {
                MessageBox.Show("Seleccione una cantidad");
            }
            else if (cantidadTomada > Convert.ToInt16(label9.Text))
            {
                MessageBox.Show("Seleccione una cantidad valida");
            }
            else
            {
                //string conexion = "mongodb://localhost:27017";
                string conexion = Form3.UsuarioActual.Login.baseDeDatos;
                var mc = new MongoClient(conexion);
                var servidor = mc.GetServer();
                var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
                servidor.Connect();//Realizar conexion
                var coleccion2 = database.GetCollection<Materiales>("MaterialesPrestamo");
                string hola;
                //MessageBox.Show("Numero de materiales: " + Convert.ToString(dataGridView1.RowCount));
                var prestamo = new Materiales { nombre = Convert.ToString(dgvAdmins.CurrentRow.Cells[0].Value), descripcion= Convert.ToString(dgvAdmins.CurrentRow.Cells[1].Value), estado= Convert.ToString(dgvAdmins.CurrentRow.Cells[2].Value), unidades = Convert.ToString(numericUpDown1.Value) };
                coleccion2.Insert(prestamo);//Insertamos
                dataGridView1.DataSource = coleccion2.FindAll().ToList();
                dataGridView1.Columns[4].Visible = false;
               // MessageBox.Show("Nombre: " + Convert.ToString(dataGridView1.Rows[0].Cells[0].Value));
                //MessageBox.Show("Numero de materiales: " + Convert.ToString(dataGridView1.RowCount));
                Globals.prestamosCantidadees.materialesPrestamoCantidad = Convert.ToString(dataGridView1.RowCount);
                tBCantidad.Text = Globals.prestamosCantidadees.materialesPrestamoCantidad;
               // MessageBox.Show("Numero de materiales: " + tBCantidad.Text);
                label8.Visible = false;
                label9.Visible = false;
                button5.Visible = false;
                button4.Visible = false;
                numericUpDown1.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string conexion = "mongodb://localhost:27017";
            string conexion = Form3.UsuarioActual.Login.baseDeDatos;
            var mc = new MongoClient(conexion);
            var servidor = mc.GetServer();
            var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
            servidor.Connect();//Realizar conexion
            var coleccion2 = database.GetCollection<Materiales>("MaterialesPrestamo");
            coleccion2.RemoveAll();
            dataGridView1.DataSource = coleccion2.FindAll().ToList();
            dataGridView1.Columns[4].Visible = false;
        }

        public void guardarPrestamo()
        {
           // PARTE PARA GUARDAR DATOS EN LA COLECCION PRESTAMOS FINALES
                int i = 0;
                int j = 0;
                button1.Visible = false;
           // MessageBox.Show("Numero de materiales: " + Globals.prestamosCantidadees.materialesPrestamoCantidad);
            //MessageBox.Show(Convert.ToString(dataGridView1.RowCount));
                i = Convert.ToInt16(Globals.prestamosCantidadees.materialesPrestamoCantidad);
                j = i;
                do
                {
                /*    MessageBox.Show("Nombre: "+Convert.ToString(dataGridView1.Rows[j].Cells[0].Value));
                    MessageBox.Show("Descripcion: "+Convert.ToString(dataGridView1.Rows[j].Cells[1].Value));
                    MessageBox.Show("Estado: "+Convert.ToString(dataGridView1.Rows[j].Cells[2].Value));
                    MessageBox.Show("Unidades "+Convert.ToString(dataGridView1.Rows[j].Cells[3].Value));
                MessageBox.Show("Prestador: SuperAdmin");
                MessageBox.Show("Prestatario: "+ Globals.prestamosCantidadees.prestatarioNombre);
                MessageBox.Show("Celular Prestatario: " + Globals.prestamosCantidadees.prestatarioCelular);
                MessageBox.Show("Fecha prestamo: " + Globals.prestamosCantidadees.prestamoFecha);
                MessageBox.Show("Fecha entrega: " + Globals.prestamosCantidadees.prestamoEntrega);
                MessageBox.Show("Estado actual: No devuelto");
                */
                try
                {
                    //string conexion = "mongodb://localhost:27017";
                    string conexion = Form3.UsuarioActual.Login.baseDeDatos;
                    var mc = new MongoClient(conexion);
                    var servidor = mc.GetServer();
                    var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
                    servidor.Connect();//Realizar conexion
                    var coleccion3 = database.GetCollection<Historial>("HistorialPrestamos");
                    var materiales = new Historial { Nombre = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value),
                        Descripcion = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value),
                        Estado = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value),
                        Unidades = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value),
                        Prestador ="SuperAdmin",
                        Prestatario = Globals.prestamosCantidadees.prestatarioNombre,
                        CelularPrestatario = Globals.prestamosCantidadees.prestatarioCelular,
                        FechaPrestamo= Globals.prestamosCantidadees.prestamoFecha,
                        FechaEntrega= Globals.prestamosCantidadees.prestamoEntrega
                    };
                    coleccion3.Insert(materiales);//Insertamos
                    MessageBox.Show("Prestamo Completado","Exito!");
                }
                catch (Exception error)
                {
                    MessageBox.Show("Error: " + error);
                }
                i--;
                    j--;
                } while(i!=0);
        }
        public void guardarPrestamo1()
        {
            MessageBox.Show(Globals.prestamosCantidadees.materialesPrestamoCantidad);
            button6.Enabled = true;
        }
        public static class Globals
        {
            public static class prestamosCantidadees
            {
                public static string materialesPrestamoCantidad;
                public static string canti;
                public static string prestatarioNombre;
                public static string prestatarioCelular;
                public static string prestamoFecha;
                public static string prestamoEntrega;
                public static string completado;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Nombre: " + Convert.ToString(dataGridView1.Rows[0].Cells[0].Value));
            //MessageBox.Show(Globals.prestamosCantidadees.completado);
            if (Globals.prestamosCantidadees.completado == "1")
            {
                // PARTE PARA GUARDAR DATOS EN LA COLECCION PRESTAMOS FINALES
                int i = 0;
                int j = 0;
                //button1.Visible = false;
               // MessageBox.Show("Numero de materiales: " + Globals.prestamosCantidadees.materialesPrestamoCantidad);
                //MessageBox.Show(Convert.ToString(dataGridView1.RowCount));
                i = Convert.ToInt16(Globals.prestamosCantidadees.materialesPrestamoCantidad);
                j = i-1;
                do
                {
                /*    MessageBox.Show("Nombre: " + Convert.ToString(dataGridView1.Rows[j].Cells[0].Value));
                    MessageBox.Show("Descripcion: " + Convert.ToString(dataGridView1.Rows[j].Cells[1].Value));
                    MessageBox.Show("Estado: " + Convert.ToString(dataGridView1.Rows[j].Cells[2].Value));
                    MessageBox.Show("Unidades " + Convert.ToString(dataGridView1.Rows[j].Cells[3].Value));
                    MessageBox.Show("Prestador:"+Form3.UsuarioActual.Login.nombreUsuario);
                    MessageBox.Show("Prestatario: " + Globals.prestamosCantidadees.prestatarioNombre);
                    MessageBox.Show("Celular Prestatario: " + Globals.prestamosCantidadees.prestatarioCelular);
                    MessageBox.Show("Fecha prestamo: " + Globals.prestamosCantidadees.prestamoFecha);
                    MessageBox.Show("Fecha entrega: " + Globals.prestamosCantidadees.prestamoEntrega);
                    MessageBox.Show("Estado actual: No Entregado");
                    */
                    try
                    {
                        //string conexion = "mongodb://localhost:27017";
                        string conexion = Form3.UsuarioActual.Login.baseDeDatos;
                        var mc = new MongoClient(conexion);
                        var servidor = mc.GetServer();
                        var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
                        servidor.Connect();//Realizar conexion
                        var coleccion3 = database.GetCollection<Historial>("HistorialPrestamos");
                        var coleccion2 = database.GetCollection<Materiales>("MaterialesPrestamo");
                        var coleccion4 = database.GetCollection<Materiales>("Materiales");
                        var exists = coleccion4.FindOne(Query<Materiales>.EQ(Materiales => Materiales.nombre, Convert.ToString(dataGridView1.Rows[j].Cells[0].Value)));
                        if (exists == null)
                        {
                            //MessageBox.Show("El correo ingresado no existe", "Error");
                        }
                       // MessageBox.Show("Unidades disponibles: "+exists.unidades);
                        //MessageBox.Show("Unidades a prestar: " + Convert.ToString(dataGridView1.Rows[j].Cells[3].Value));
                        int total = Convert.ToInt16(exists.unidades) - Convert.ToInt16(dataGridView1.Rows[j].Cells[3].Value);
                       // MessageBox.Show("Unidades que quedaran: " + Convert.ToString(total));
                        exists.unidades = Convert.ToString(total);
                        coleccion4.Save(exists);
                        var materiales = new Historial
                        {
                            Nombre = Convert.ToString(dataGridView1.Rows[j].Cells[0].Value),
                            Descripcion = Convert.ToString(dataGridView1.Rows[j].Cells[1].Value),
                            Estado = Convert.ToString(dataGridView1.Rows[j].Cells[2].Value),
                            Unidades = Convert.ToString(dataGridView1.Rows[j].Cells[3].Value),
                            Prestador = Form3.UsuarioActual.Login.nombreUsuario,
                            Prestatario = Globals.prestamosCantidadees.prestatarioNombre,
                            CelularPrestatario = Globals.prestamosCantidadees.prestatarioCelular,
                            FechaPrestamo = Globals.prestamosCantidadees.prestamoFecha,
                            FechaEntrega = Globals.prestamosCantidadees.prestamoEntrega,
                            EstadoActual="No Entregado"
                        };
                        coleccion3.Insert(materiales);//Insertamos
                        MessageBox.Show("Prestamo Completado", "Exito!");

                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error: " + error);
                    }
                    i--;
                    j--;
                } while (i != 0);
                //string conexion2 = "mongodb://localhost:27017";
                string conexion2 = Form3.UsuarioActual.Login.baseDeDatos;
                var mc2 = new MongoClient(conexion2);
                var servidor2 = mc2.GetServer();
                var database2 = servidor2.GetDatabase("ArrageCheck");//Uso de base de datos
                servidor2.Connect();//Realizar conexion
                var coleccion7 = database2.GetCollection<Materiales>("Materiales");
                var coleccion8 = database2.GetCollection<Materiales>("MaterialesPrestamo");
                coleccion8.RemoveAll();
                string hola;
                dataGridView1.DataSource = coleccion8.FindAll().ToList();
                dataGridView1.Columns[4].Visible = false;
                dgvAdmins.DataSource = coleccion7.FindAll().ToList();
                dgvAdmins.Columns[4].Visible = false;
            }
            else
            {
                MessageBox.Show("No has terminado el prestamo");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form4 Inicio = new Form4();
            Inicio.Show();
            this.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 Administradores = new Form1();
            Administradores.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form5 Materiales = new Form5();
            Materiales.Show();
            this.Visible = false;
        }
    }

   
    
}
