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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* MessageBox.Show("Prestamo Completado", "Exito!");
            MessageBox.Show("Prestatario: "+textBox1.Text);
            MessageBox.Show("Prestatario Celular: " + textBox2.Text);
            MessageBox.Show("Prestamo Completado", "Exito!");
            MessageBox.Show("Fecha de entrega: "+dateTimePicker1.Text);
            MessageBox.Show("Fecha de prestamo: "+Convert.ToString(DateTime.Now));
            */
            Form6 Prestamos = new Form6();
            Form6.Globals.prestamosCantidadees.prestatarioNombre = textBox1.Text;
            Form6.Globals.prestamosCantidadees.prestatarioCelular = textBox2.Text;
            Form6.Globals.prestamosCantidadees.prestamoFecha = Convert.ToString(DateTime.Now);
            Form6.Globals.prestamosCantidadees.prestamoEntrega = dateTimePicker1.Text;
            Form6.Globals.prestamosCantidadees.completado = "1";
            //Prestamos.materialesPrestamoCantidad = Convert.ToString(Prestamos.dataGridView1.RowCount);
           // MessageBox.Show("Numero de materiales: " + Prestamos.materialesPrestamoCantidad);
          //  MessageBox.Show("Prestatario 2: " + Form6.Globals.prestamosCantidadees.prestatarioNombre);
           // MessageBox.Show("Prestatario Celular 2: " + Form6.Globals.prestamosCantidadees.prestatarioCelular);
            //MessageBox.Show("Prestamo Completado 2", "Exito!");
           // MessageBox.Show("Fecha de entrega 2: " + Form6.Globals.prestamosCantidadees.prestamoEntrega);
           // MessageBox.Show("Fecha de prestamo 2: " + Form6.Globals.prestamosCantidadees.prestamoFecha);
            this.Close();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
