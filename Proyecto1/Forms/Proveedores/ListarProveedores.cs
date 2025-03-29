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
    }
}
