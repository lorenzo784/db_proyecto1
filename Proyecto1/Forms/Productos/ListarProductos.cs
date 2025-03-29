using Proyecto1.Modelos;
using Proyecto1.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Forms.Productos
{
    public partial class ListarProductos : Form
    {
        private Inicio inicio;
        public ListarProductos(Inicio inicio)
        {
            this.inicio = inicio;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AgregarPro frmPro = new AgregarPro(inicio);

            frmPro.TopLevel = false;
            frmPro.FormBorderStyle = FormBorderStyle.None;
            frmPro.Dock = DockStyle.Fill;

            this.inicio.panelContent.Controls.Clear();

            this.inicio.panelContent.Controls.Add(frmPro);
            frmPro.Show();
        }

        private void ListarProductos_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ProductoService.ObtenerProductos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                ProductoService.EliminarProducto(int.Parse(id));

                MessageBox.Show("Registro eliminado " + id);

                dataGridView1.DataSource = ProductoService.ObtenerProductos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                Producto producto = ProductoService.ObtenerProducto(int.Parse(id));

                EditarProducto frmPro = new EditarProducto(this.inicio, producto);

                frmPro.TopLevel = false;
                frmPro.FormBorderStyle = FormBorderStyle.None;
                frmPro.Dock = DockStyle.Fill;

                this.inicio.panelContent.Controls.Clear();

                this.inicio.panelContent.Controls.Add(frmPro);
                frmPro.Show();
            }
        }
    }
}
