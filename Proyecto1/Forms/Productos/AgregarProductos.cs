using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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

        }
    }
}
