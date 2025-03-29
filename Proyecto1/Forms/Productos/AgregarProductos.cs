using Proyecto1.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Forms.Productos
{
    public partial class AgregarPro : Form
    {
        private Inicio inicio;
        public AgregarPro(Inicio inicio)
        {
            InitializeComponent();
            this.inicio = inicio;
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

            bool resultado = ProductoService.InsertarProducto(tbNombre.Text, tbDesc.Text, decimal.Parse(tbPrecio.Text), int.Parse(tbStock.Text));

            if(!resultado)
            {
                MessageBox.Show("El producto ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("El producto se agregó con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void AgregarPro_Load(object sender, EventArgs e)
        {

        }
    }
}
