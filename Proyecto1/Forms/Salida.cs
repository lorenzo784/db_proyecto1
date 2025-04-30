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

namespace Proyecto1.Forms
{
    public partial class Salida : Form
    {

        public string nit = null;
        public Salida()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("idProducto", "ID Producto");
            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("cantidad", "Cantidad");
            dataGridView1.Columns.Add("precio", "Precio");
            dataGridView1.Columns["IdProducto"].Visible = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedItem != null && nCantidad.Value > 0)
            {
                Producto productoSeleccionado = (Producto)cbProducto.SelectedItem;

                int idProducto = productoSeleccionado.Id;
                string nombre = productoSeleccionado.Nombre;
                int cantidad = (int)nCantidad.Value;
                decimal precio = productoSeleccionado.Precio;
                int stock = productoSeleccionado.Stock;

                nCantidad.Value = 0;
                dataGridView1.Rows.Add(idProducto, nombre, cantidad, precio);
            }
            else
            {
                MessageBox.Show("Selecciona un producto y especifica una cantidad mayor a cero.");
            }
        }

        private void Salida_Load(object sender, EventArgs e)
        {
            List<Producto> productos = ProductoService.ObtenerProductosParaCombo();

            cbProducto.DataSource = productos;
            cbProducto.DisplayMember = "Nombre";
            cbProducto.ValueMember = "Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool hayProductos = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Any(row => !row.IsNewRow);

            if (!hayProductos)
            {
                MessageBox.Show("No hay productos agregados para registrar la salida.");
                return;
            }

            if (string.IsNullOrEmpty(nit))
            {
                MessageBox.Show("No hay nit del cliente");
                return;
            }

            int cantidadTotal = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value) * Convert.ToInt32(row.Cells["Precio"].Value);
                cantidadTotal += cantidad;

            }

            bool todoCorrecto = true;

            int id_venta = SalidaService.RegistrarVenta(nit, cantidadTotal);

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                bool exito = SalidaService.RegistrarSalidaProducto(idProducto, cantidad, id_venta);

                if (!exito)
                {
                    MessageBox.Show($"Error: stock insuficiente o fallo al registrar la salida del producto con ID {idProducto}.");
                    todoCorrecto = false;
                    break;
                }
            }

            if (todoCorrecto)
            {
                MessageBox.Show("Todas las salidas fueron registradas con éxito.");
                dataGridView1.Rows.Clear();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int index = dataGridView1.SelectedRows[0].Index;

                if (!dataGridView1.Rows[index].IsNewRow)
                {
                    dataGridView1.Rows.RemoveAt(index);
                }
                else
                {
                    MessageBox.Show("No puedes eliminar una fila nueva sin confirmar.");
                }
            }
            else
            {
                MessageBox.Show("Selecciona una fila para eliminar.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbNit.Text))
            {
                MessageBox.Show("Por favor, ingresa un NIT.");
                return;
            }

            var cliente = ClientesService.BuscarClientePorNit(tbNit.Text);
            if (cliente != null)
            {
                this.nit = cliente["nit"].ToString();
                string mensaje = $"Nombre: {cliente["nombre"]}\n" +
                                 $"Dirección: {cliente["direccion"]}\n" +
                                 $"Teléfono: {cliente["telefono"]}\n" +
                                 $"Correo: {cliente["correo"]}";
                MessageBox.Show("Cliente encontrado");
                textBox1.Text = cliente["nombre"].ToString();
                textBox2.Text = cliente["direccion"].ToString();
                textBox3.Text = cliente["telefono"].ToString();
                textBox4.Text = cliente["correo"].ToString();
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.");
            }
        }

    }
}
