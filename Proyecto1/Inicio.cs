using Proyecto1.Forms.Distribucion;
using Proyecto1.Forms.Productos;
using Proyecto1.Forms.Proveedores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {

        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            ListarProductos frmPro = new ListarProductos(this);

            frmPro.TopLevel = false;
            frmPro.FormBorderStyle = FormBorderStyle.None;
            frmPro.Dock = DockStyle.Fill;

            panelContent.Controls.Clear();

            panelContent.Controls.Add(frmPro);
            frmPro.Show();
        }

        private void btnProvee_Click(object sender, EventArgs e)
        {
            ListarProveedores frmProvee = new ListarProveedores(this);

            frmProvee.TopLevel = false;
            frmProvee.FormBorderStyle = FormBorderStyle.None;
            frmProvee.Dock = DockStyle.Fill;

            panelContent.Controls.Clear();

            panelContent.Controls.Add(frmProvee);
            frmProvee.Show();
        }

        private void btnDis_Click(object sender, EventArgs e)
        {
            ListarDistribuciones frm = new ListarDistribuciones(this);

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            panelContent.Controls.Clear();

            panelContent.Controls.Add(frm);
            frm.Show();
        }
    }
}
