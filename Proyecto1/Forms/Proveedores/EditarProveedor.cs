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

namespace Proyecto1.Forms.Proveedores
{
    public partial class EditarProveedor : Form
    {
        private Inicio inicio;
        private Proveedor proveedor;
        public EditarProveedor(Inicio inicio, Proveedor proveedor)
        {
            this.inicio = inicio;
            this.proveedor = proveedor;
            InitializeComponent();
        }

        private void EditarProveedor_Load(object sender, EventArgs e)
        {
            tbCorreo.Text = proveedor.CorreoElectronico;
            tbDireccion.Text = proveedor.Direccion;
            tbNombre.Text = proveedor.Nombre;
            tbTelefono.Text = proveedor.Telefono;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "" || tbCorreo.Text == "" || tbTelefono.Text == "" || tbDireccion.Text == "")
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = ProveedorService.EditarProveedor(proveedor.Id, tbNombre.Text, tbTelefono.Text, tbCorreo.Text, tbDireccion.Text);

            //if (!resultado)
            //{
            //    MessageBox.Show("El proveedor ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            MessageBox.Show("El proveedor se actualizó", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiarCampos();
            mostrarDatos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }
        private void limpiarCampos()
        {
            tbNombre.Text = "";
            tbTelefono.Text = "";
            tbDireccion.Text = "";
            tbCorreo.Text = "";
        }

        private void mostrarDatos()
        {
            ListarProveedores frm = new ListarProveedores(inicio);

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            inicio.panelContent.Controls.Clear();

            inicio.panelContent.Controls.Add(frm);
            frm.Show();
        }
    }
}
