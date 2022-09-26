using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TIC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_Insertar_Click(object sender, EventArgs e)
        {
            int registrosAfectados = 0;
            registrosAfectados = Conexion.EjecutarConsulta(textBox1.Text);
            Mensajes.Mensaje("Registros Afectados: "+registrosAfectados);
            LlenarCombo(textBox1.Text, comboBox1,"id","Nombre");
            LlenarListView(textBox1.Text, listView1);
            LlenarDataGrid(textBox1.Text, dataGridView1);
        }
        public static void LlenarCombo(string consulta, ComboBox combo, String id, String campo)
        {
            DataTable dt;
            //  dt = Conexion.EjecutaSeleccion(consulta);
            dt = Conexion.AgregarElementoCombo(consulta);
            if (dt == null)
            {
                return;
            }
            combo.Items.Clear();
            combo.DataSource = dt;
            combo.ValueMember = id;
            combo.DisplayMember = campo;

        }
        public static void LlenarDataGrid(string consulta, DataGridView Data)
        {

            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            Data.DataSource = dt;
        }
        public static void LlenarListView(string consulta, ListView list)
        {
            DataTable dt;
            dt = Conexion.EjecutaSeleccion(consulta);
            int CantidadC = dt.Columns.Count;
            list.Items.Clear();
            list.View = View.Details;
            list.GridLines = true;
            for (int i = 0; i<CantidadC; i++)
            {
                list.Columns.Add(dt.Columns[i].ToString());
            }
            foreach (DataRow renglon in dt.Rows)
            {
                String[] arreglo = new String[CantidadC];
                ListViewItem elemento = new ListViewItem();
                for(int i = 0; i<CantidadC; i++)
                {
                    arreglo[i] = renglon[i].ToString();
                    elemento = new ListViewItem(arreglo);
                }
                list.Items.Add(elemento);
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text = comboBox1.SelectedValue.ToString();
        }
    }
}
