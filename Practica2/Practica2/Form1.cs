using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int Registros = 0;
            conexion.EjecutaConsulta(textBox1.Text);
            acciones.Mensaje("" + Registros);
            acciones.LlenarCombo(textBox1.Text, comboBox1, "id_Cliente", "Nombre_Cliente");
            acciones.llenardatagrid(textBox1.Text, dataGridView1);
            acciones.LlenarListView(textBox1.Text, listView1);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
