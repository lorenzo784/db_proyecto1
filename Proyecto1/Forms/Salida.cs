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
        public Salida()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("IdProducto", "ID");
            dataGridView1.Columns.Add("NombreProducto", "Producto");
            dataGridView1.Columns.Add("Cantidad", "Cantidad");
            dataGridView1.Columns["IdProducto"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cbProducto.SelectedItem != null && nCantidad.Value > 0)
            {
                var item = (KeyValuePair<int, string>)cbProducto.SelectedItem;
                int idProducto = item.Key;
                string nombre = item.Value;
                int cantidad = (int)nCantidad.Value;
                dataGridView1.Rows.Add(idProducto, nombre, cantidad);
            }
            else
            {
                MessageBox.Show("Selecciona un producto y especifica una cantidad mayor a cero.");
            }
        }

        private void Salida_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> productos = ProductoService.ObtenerProductosDictionary();

            cbProducto.DataSource = new BindingSource(productos, null);
            cbProducto.DisplayMember = "Value";
            cbProducto.ValueMember = "Key";
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

            bool todoCorrecto = true;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);

                bool exito = SalidaService.RegistrarSalidaProducto(idProducto, cantidad);

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
                string mensaje = $"Nombre: {cliente["nombre"]}\n" +
                                 $"Dirección: {cliente["direccion"]}\n" +
                                 $"Teléfono: {cliente["telefono"]}\n" +
                                 $"Correo: {cliente["correo"]}";
                MessageBox.Show(mensaje, "Cliente encontrado");
            }
            else
            {
                MessageBox.Show("Cliente no encontrado.");
            }
        }

    }
}
