using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Novacode;
using System.Drawing;
using System.Diagnostics;
using MongoDB.Driver.Builders;
using MongoDB.Bson;

namespace ArrageCheck
{
    public partial class Form9 : Form
    {
        public Form9()
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

            dgvHistorialPrestamos.DataSource = coleccion.FindAll().ToList();
            dgvHistorialPrestamos.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvHistorialPrestamos.SelectedRows.Count == 1)
            {
                if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Entregado")
                {
                    MessageBox.Show("Este material ya fue entregado");
                } else if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "No Entregado")
                {
                    MessageBox.Show("Este material fue aceptado");
                }
                else if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Rechazado")
                {
                    MessageBox.Show("Este prestamo ya fue rechazado. El material fue regresado");
                }
                else if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Pendiente")
                {

                    ObjectId id = ObjectId.Parse(Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[0].Value));
                    var materialPrestado = Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[1].Value);
                    var unidadesPrestadas = Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[4].Value);

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
                    MessageBox.Show("Unidades disponibles una vez regresado el material: " + Convert.ToString(total));
                    exists.unidades = Convert.ToString(total);
                    estadoActual.EstadoActual = "Rechazado";
                    coleccion5.Save(estadoActual);
                    coleccion4.Save(exists);
                    dgvHistorialPrestamos.DataSource = coleccion5.FindAll().ToList();
                    dgvHistorialPrestamos.Columns[0].Visible = false;
                    MessageBox.Show("Prestamo Rechazado. El material fue regresado");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ExportarDgvAWord(dgvHistorialPrestamos,"HistorialPrestamos.docx");
        }
             private void ExportarDgvAWord(DataGridView dgvHistorialPrestamos, string filename)
        {

            //Creamos el Word
            DocX miWord = DocX.Create(filename);
            miWord.PageLayout.Orientation = Novacode.Orientation.Landscape;
            //miWord.InsertParagraph("ArrangeCheck-Historial de Prestamos");
            var headLineFormat = new Formatting();
            headLineFormat.Size = 18D;
            headLineFormat.Position = 12;
            var headLineFormat2 = new Formatting();
            headLineFormat2.Size = 28D;
            headLineFormat2.Position = 12;
            miWord.InsertParagraph("Universidad Politécnica del estado de Durango", false, headLineFormat2);
            miWord.InsertParagraph("ArrangeCheck-Historial de Prestamos de Laboratorios", false, headLineFormat);
            //Creamos la tabla
            //Le sumo + 1 para adicionarle el encabezado
            Table miTabla = miWord.AddTable(dgvHistorialPrestamos.RowCount + 1, dgvHistorialPrestamos.ColumnCount);

            for (int fila = -1; fila < dgvHistorialPrestamos.RowCount; fila++)
            {
                for(int col = 1; col < dgvHistorialPrestamos.ColumnCount; col++)
                {
                    if( fila == -1) //Es encabezado
                    {
                        //Mediante Bold() cambio a negrita toda la fila
                        miTabla.Rows[0].Cells[col].Paragraphs.First().Append(dgvHistorialPrestamos.Columns[col].HeaderText).Bold();
                    }
                    else //Es otra fila
                    {
                        miTabla.Rows[fila + 1].Cells[col].Paragraphs.First().Append(dgvHistorialPrestamos.Rows[fila].Cells[col].Value.ToString());
                    }
                }
            }

            miWord.InsertTable(miTabla);
            miWord.Save();
            //Process.Start("Funciona5.docx");
            //Process.Start(@"C:\Archivos de programa\HistorialPrestamos.docx");
            Process.Start(filename);
            MessageBox.Show("Done");
     
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 Administrador = new Form10();
            Administrador.Show();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            ExportarDgvAWord(dgvHistorialPrestamos, "HistorialPrestamos.docx");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Form10 Administrador = new Form10();
            //Administrador.Show();
            if (dgvHistorialPrestamos.SelectedRows.Count == 1)
            {
                if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Entregado")
                {
                    MessageBox.Show("Este material ya fue entregado");
                }
                else if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Rechazado")
                {
                    MessageBox.Show("Este prestamo no fue aceptado. El material fue regresado");
                }
                else if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Pendiente")
                {
                    MessageBox.Show("Este prestamo aun se encuentra en espera, reviselo para continuar");
                }
                else
                {

                    ObjectId id = ObjectId.Parse(Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[0].Value));
                    var materialPrestado = Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[1].Value);
                    var unidadesPrestadas = Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[4].Value);

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
                    dgvHistorialPrestamos.DataSource = coleccion5.FindAll().ToList();
                    dgvHistorialPrestamos.Columns[0].Visible = false;
                    MessageBox.Show("Prestamo Entregado");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dgvHistorialPrestamos.SelectedRows.Count == 1)
            {
                if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Entregado")
                {
                    MessageBox.Show("Este material ya fue entregado");
                }
                else if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Rechazado")
                {
                    MessageBox.Show("Este prestamo no fue aceptado. El material fue regresado");
                }
                else if (Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "No Entregado")
                {
                    MessageBox.Show("Este prestamo ya fue aceptado");
                }
                else if(Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[10].Value) == "Pendiente")
                {
                    ObjectId id = ObjectId.Parse(Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[0].Value));
                    var materialPrestado = Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[1].Value);
                    var unidadesPrestadas = Convert.ToString(dgvHistorialPrestamos.CurrentRow.Cells[4].Value);

                    //string conexion = "mongodb://localhost:27017";
                    string conexion = Form3.UsuarioActual.Login.baseDeDatos;
                    var mc = new MongoClient(conexion);
                    var servidor = mc.GetServer();
                    var database = servidor.GetDatabase("ArrageCheck");//Uso de base de datos
                    servidor.Connect();//Realizar conexion
                    var coleccion5 = database.GetCollection<Historial>("HistorialPrestamos");
                    var estadoActual = coleccion5.FindOne(Query<Historial>.EQ(historial => historial.id, id));
                    estadoActual.EstadoActual = "No Entregado";
                    coleccion5.Save(estadoActual);
                    dgvHistorialPrestamos.DataSource = coleccion5.FindAll().ToList();
                    dgvHistorialPrestamos.Columns[0].Visible = false;
                    MessageBox.Show("Prestamo Aceptado");


                }


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
            Form1 Admins = new Form1();
            Admins.Show();
            this.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form5 Materiales = new Form5();
            Materiales.Show();
            this.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form6 Prestamo = new Form6();
            Prestamo.Show();
            this.Visible = false;
        }
    }
}
