﻿using System.Drawing;

namespace Proyecto1
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelContent = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnDis = new System.Windows.Forms.Button();
            this.btnProvee = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.btnSalida = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Location = new System.Drawing.Point(285, 6);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(777, 671);
            this.panelContent.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSalida);
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.btnDis);
            this.panel1.Controls.Add(this.btnProvee);
            this.panel1.Controls.Add(this.btnProductos);
            this.panel1.Location = new System.Drawing.Point(5, 6);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(280, 671);
            this.panel1.TabIndex = 0;
            // 
            // btnCerrar
            // 
            this.btnCerrar.FlatAppearance.BorderSize = 0;
            this.btnCerrar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnCerrar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrar.Location = new System.Drawing.Point(20, 595);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(240, 50);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "Cerrar sesion";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Transparent;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInicio.Location = new System.Drawing.Point(20, 50);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(240, 50);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.UseVisualStyleBackColor = false;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnDis
            // 
            this.btnDis.FlatAppearance.BorderSize = 0;
            this.btnDis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnDis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnDis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDis.Location = new System.Drawing.Point(19, 230);
            this.btnDis.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnDis.Name = "btnDis";
            this.btnDis.Size = new System.Drawing.Size(240, 50);
            this.btnDis.TabIndex = 3;
            this.btnDis.Text = "Distribución";
            this.btnDis.UseVisualStyleBackColor = true;
            this.btnDis.Click += new System.EventHandler(this.btnDis_Click);
            // 
            // btnProvee
            // 
            this.btnProvee.BackColor = System.Drawing.Color.Transparent;
            this.btnProvee.FlatAppearance.BorderSize = 0;
            this.btnProvee.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnProvee.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnProvee.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProvee.Location = new System.Drawing.Point(20, 171);
            this.btnProvee.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnProvee.Name = "btnProvee";
            this.btnProvee.Size = new System.Drawing.Size(240, 50);
            this.btnProvee.TabIndex = 2;
            this.btnProvee.Text = "Proveedores";
            this.btnProvee.UseVisualStyleBackColor = false;
            this.btnProvee.Click += new System.EventHandler(this.btnProvee_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.BackColor = System.Drawing.Color.Transparent;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnProductos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnProductos.Location = new System.Drawing.Point(19, 110);
            this.btnProductos.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Size = new System.Drawing.Size(240, 50);
            this.btnProductos.TabIndex = 1;
            this.btnProductos.Text = "Productos";
            this.btnProductos.UseVisualStyleBackColor = false;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // btnSalida
            // 
            this.btnSalida.FlatAppearance.BorderSize = 0;
            this.btnSalida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnSalida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnSalida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalida.Location = new System.Drawing.Point(19, 290);
            this.btnSalida.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.btnSalida.Name = "btnSalida";
            this.btnSalida.Size = new System.Drawing.Size(240, 50);
            this.btnSalida.TabIndex = 4;
            this.btnSalida.Text = "Salida de productos";
            this.btnSalida.UseVisualStyleBackColor = true;
            this.btnSalida.Click += new System.EventHandler(this.btnSalida_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Lucida Fax", 14.25F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnDis;
        private System.Windows.Forms.Button btnProvee;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Button btnSalida;
    }
}

