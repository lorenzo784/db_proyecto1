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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto1.Forms.Distribucion
{
    public partial class ListarProductosDis : Form
    {
        private Inicio inicio;
        private int idProveedor;
        public ListarProductosDis(Inicio inicio, int idProveedor)
        {
            this.inicio = inicio;
            this.idProveedor = idProveedor;
            InitializeComponent();
        }

        private void ListarProductosDis_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DistribucionService.ObtenerProductosDis(this.idProveedor);
            Dictionary<int, string> productos = ProductoService.ObtenerProductosDictionary();

            cbProducto.DataSource = new BindingSource(productos, null);
            cbProducto.DisplayMember = "Value";
            cbProducto.ValueMember = "Key";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedIndex != -1 && nCantidad.Value > 0)
            {
                int idProductoSeleccionado = (int)cbProducto.SelectedValue;
                decimal cantidad = nCantidad.Value;

                DistribucionService.InsertarProductoProveedor(idProductoSeleccionado, this.idProveedor,(int)cantidad);
                MessageBox.Show("Relación hecha", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = DistribucionService.ObtenerProductosDis(this.idProveedor);
                limpiarCampos();
                return;
            }
            MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void limpiarCampos()
        {
            cbProducto.SelectedIndex = -1;
            nCantidad.Value = 0;
        }
    }
}
