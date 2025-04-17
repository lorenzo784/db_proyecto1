using Proyecto1.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto1.Forms.Login
{
    public partial class Registro : Form
    {
        public Layout layout;
        public Registro(Layout layout)
        {
            InitializeComponent();
            this.layout = layout;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            login();
        }

        public static bool EsCorreoValido(string correo)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(correo);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbNombre.Text == "" || tbCorreo.Text == "" || tbContra.Text == "" || tbContra2.Text == "")
            {
                MessageBox.Show("Rellene los campos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!EsCorreoValido(tbCorreo.Text))
            {
                MessageBox.Show("Correo no valido", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbContra.Text.Length < 8)
            {
                MessageBox.Show("La contraseña debe tener 8 digitos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tbContra.Text != tbContra2.Text)
            {
                MessageBox.Show("La contraseña uno coicide", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool resultado = LoginService.InsertarUsuario(tbNombre.Text, tbCorreo.Text, tbContra.Text);

            if (!resultado)
            {
                MessageBox.Show("El producto ya existe", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Se creo la cuenta con exito", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            login();
        }

        private void login()
        {
            InicioSesion frm = new InicioSesion(this.layout);

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;

            this.layout.panel1.Controls.Clear();

            this.layout.panel1.Controls.Add(frm);
            frm.Show();
        }
    }
}
