using Proyecto1.Forms.Productos;
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
    public partial class ListarProveedores : Form
    {
        private Inicio inicio;
        public ListarProveedores(Inicio inicio)
        {
            this.inicio = inicio;
            InitializeComponent();
        }

        private void ListarProveedores_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ProveedorService.ObtenerProveedores();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarProveedor frmProvee = new AgregarProveedor(this.inicio);

            frmProvee.TopLevel = false;
            frmProvee.FormBorderStyle = FormBorderStyle.None;
            frmProvee.Dock = DockStyle.Fill;

            this.inicio.panelContent.Controls.Clear();

            this.inicio.panelContent.Controls.Add(frmProvee);
            frmProvee.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                Proveedor proveedor = ProveedorService.ObtenerProveedor(int.Parse(id));

                EditarProveedor frmPro = new EditarProveedor(this.inicio, proveedor);

                frmPro.TopLevel = false;
                frmPro.FormBorderStyle = FormBorderStyle.None;
                frmPro.Dock = DockStyle.Fill;

                this.inicio.panelContent.Controls.Clear();

                this.inicio.panelContent.Controls.Add(frmPro);
                frmPro.Show();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                string id = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                ProveedorService.EliminarProveedor(int.Parse(id));

                MessageBox.Show("Registro eliminado " + id);

                dataGridView1.DataSource = ProveedorService.ObtenerProveedores();
            }
        }
    }
}
