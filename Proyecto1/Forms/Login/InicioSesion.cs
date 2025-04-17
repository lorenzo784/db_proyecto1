using Proyecto1.Forms.Productos;
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

namespace Proyecto1.Forms.Login
{
    public partial class InicioSesion : Form
    {
        private Layout layout;
        public InicioSesion(Layout layout)
        { 
            this.layout = layout;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(tbCorreo.Text == "" || tbContra.Text == "")
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = LoginService.IniciarSesion(tbCorreo.Text, tbContra.Text);

            if (!resultado)
            {
                MessageBox.Show("Credenciales invalidas", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            inicio();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Registro frmPro = new Registro(layout);

            frmPro.TopLevel = false;
            frmPro.FormBorderStyle = FormBorderStyle.None;
            frmPro.Dock = DockStyle.Fill;

            this.layout.panel1.Controls.Clear();

            this.layout.panel1.Controls.Add(frmPro);
            frmPro.Show();
        }

        private void inicio()
        {
            Inicio frm = new Inicio(this.layout);

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            this.layout.panel1.Controls.Clear();

            this.layout.panel1.Controls.Add(frm);
            frm.Show();
        }
    }
}
