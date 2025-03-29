using Proyecto1.Forms.Proveedores;
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

namespace Proyecto1.Forms.Distribucion
{
    public partial class ListarDistribuciones : Form
    {
        private Inicio inicio;
        public ListarDistribuciones(Inicio inicio)
        {
            this.inicio = inicio;
            InitializeComponent();
        }

        private void ListarDistribuciones_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DistribucionService.ObtenerProveedores();
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                string idProveedor = dataGridView1.CurrentRow.Cells["id"].Value.ToString();
                ListarProductosDis frmPro = new ListarProductosDis(this.inicio, int.Parse(idProveedor));

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
