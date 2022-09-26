using System.Windows.Forms;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class acciones
    {
        public static void Mensaje(string mensaje)
        {
            MessageBox.Show(mensaje, "AVISO!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void LlenarCombo(String consulta, ComboBox combo, string id, string campo)
        {
            DataTable dt;
            dt = conexion.EjecutaSeleccion(consulta);

            DataRow r = dt.NewRow();
            r[0] = 0;
            r[1] = "Todos Los Datos";
            dt.Rows.InsertAt(r, 0);

            if (dt == null)
            {
                return;
            }
            combo.Items.Clear();
            combo.DataSource = dt;
            combo.ValueMember = id;
            combo.DisplayMember = campo;

        }
        public static void llenardatagrid(string consulta, DataGridView data)
        {
            DataTable dt;
            dt = conexion.EjecutaSeleccion(consulta);
            if (dt == null)
            {
                return;
            }
            data.DataSource = dt;

        }
        public static void LlenarListView(string consulta, ListView list)
        {
            DataTable dt;
            dt = conexion.EjecutaSeleccion(consulta);
            int columns = dt.Columns.Count;
            if (dt == null)
            {
                return;
            }
            list.View = View.Details;
            foreach (DataColumn itemColumn in dt.Columns)
            {
                list.Columns.Add(Convert.ToString(itemColumn));
            }
            foreach (DataRow row in dt.Rows)
            {
                ListViewItem itemlist = new ListViewItem(Convert.ToString(row[0]));
                for (int i = 1; i < columns; i++)
                {
                    itemlist.SubItems.Add(Convert.ToString(row[i]));
                }
                list.Items.Add(itemlist);
            }
        }
    }
}

