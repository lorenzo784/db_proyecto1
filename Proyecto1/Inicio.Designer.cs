using System.Drawing;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnDis = new System.Windows.Forms.Button();
            this.btnProvee = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.panelContent = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnInicio);
            this.panel1.Controls.Add(this.btnDis);
            this.panel1.Controls.Add(this.btnProvee);
            this.panel1.Controls.Add(this.btnProductos);
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(278, 671);
            this.panel1.TabIndex = 0;
            // 
            // btnInicio
            // 
            this.btnInicio.BackColor = System.Drawing.Color.Transparent;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkCyan;
            this.btnInicio.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkCyan;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnInicio.Location = new System.Drawing.Point(20, 51);
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
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.Transparent;
            this.panelContent.Controls.Add(this.chart1);
            this.panelContent.Location = new System.Drawing.Point(291, 5);
            this.panelContent.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(767, 671);
            this.panelContent.TabIndex = 1;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(147, 306);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(494, 300);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
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
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "Inicio";
            this.Text = "Form1";
            this.panel1.ResumeLayout(false);
            this.panelContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDis;
        private System.Windows.Forms.Button btnProvee;
        private System.Windows.Forms.Button btnProductos;
        public System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

