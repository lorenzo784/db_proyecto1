using Proyecto1.Forms.Productos;
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

namespace Proyecto1.Forms.Proveedores
{
    public partial class AgregarProveedor : Form
    {
        private Inicio inicio;
        public AgregarProveedor(Inicio inicio)
        {
            this.inicio = inicio;
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "" || tbCorreo.Text == "" || tbTelefono.Text == "" || tbDireccion.Text == "")
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = ProveedorService.InsertarProveedor(tbNombre.Text, tbTelefono.Text, tbCorreo.Text, tbDireccion.Text);

            //if (!resultado)
            //{
            //    MessageBox.Show("El proveedor ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            MessageBox.Show("El proveedor se agregó con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            limpiarCampos();
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            mostrarDatos();
        }
    }
}
