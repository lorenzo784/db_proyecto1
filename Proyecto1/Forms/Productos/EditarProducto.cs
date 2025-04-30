using Proyecto1.Modelos;
using Proyecto1.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Forms.Productos
{
    public partial class EditarProducto : Form
    {
        private Inicio inicio;
        private Producto producto;
        private string rutaImagen = string.Empty;
        public EditarProducto(Inicio inicio, Producto producto)
        {
            this.inicio = inicio;
            this.producto = producto;
            InitializeComponent();
        }

        private void EditarProducto_Load(object sender, EventArgs e)
        {
            tbNombre.Text = producto.Nombre;
            tbDesc.Text = producto.Descripcion;
            tbPrecio.Text = producto.Precio.ToString();
            tbStock.Text = producto.Stock.ToString();
            string pathImagenGuardada = producto.Ruta_imagen;

            if (!string.IsNullOrEmpty(pathImagenGuardada))
            {
                string rutaCompleta = Path.Combine(Application.StartupPath, pathImagenGuardada);
                if (File.Exists(rutaCompleta))
                {
                    pbImagen.Image = Image.FromFile(rutaCompleta);
                }
                else
                {
                    tbImagen.Text = "Seleccione una imagen";
                }
            }
            else
            {
                tbImagen.Text = "Seleccione una imagen";
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "" || tbPrecio.Text == "" || tbStock.Text == "" || tbDesc.Text == "")
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(tbPrecio.Text, out decimal precio) || precio <= 0 || !Regex.IsMatch(tbPrecio.Text, @"^\d+(\.\d{1,2})?$"))
            {
                MessageBox.Show("Ingrese un precio válido (ej. 10.50)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(tbStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Ingrese un stock válido (número entero positivo)", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pathImagenGuardada = null;
            if (!string.IsNullOrEmpty(rutaImagen))
            {
                string nombreArchivo = Path.GetFileName(rutaImagen);
                string carpetaDestino = Path.Combine(Application.StartupPath, "Imagenes");

                if (!Directory.Exists(carpetaDestino))
                    Directory.CreateDirectory(carpetaDestino);

                string rutaDestino = Path.Combine(carpetaDestino, nombreArchivo);
                File.Copy(rutaImagen, rutaDestino, true);

                pathImagenGuardada = Path.Combine("Imagenes", nombreArchivo);
            }

            bool resultado = ProductoService.EditarProducto(producto.Id, tbNombre.Text, tbDesc.Text, decimal.Parse(tbPrecio.Text), int.Parse(tbStock.Text), pathImagenGuardada);

            if (!resultado)
            {
                MessageBox.Show("El producto ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("El producto fue actualizado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiarCampos();
            mostrarDatos();
        }

        private void limpiarCampos()
        {
            tbNombre.Text = "";
            tbDesc.Text = "";
            tbPrecio.Text = "";
            tbStock.Text = "";
        }

        private void mostrarDatos()
        {
            ListarProductos frm = new ListarProductos(inicio);

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            inicio.panelContent.Controls.Clear();

            inicio.panelContent.Controls.Add(frm);
            frm.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    rutaImagen = ofd.FileName;
                    tbImagen.Text = Path.GetFileName(rutaImagen);
                    pbImagen.Image = Image.FromFile(rutaImagen);
                }
            }
        }
    }
}
