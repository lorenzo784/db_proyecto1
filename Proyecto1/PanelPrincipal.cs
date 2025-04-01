using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Proyecto1.Servicios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Proyecto1
{
    public partial class PanelPrincipal : Form
    {
        public PanelPrincipal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (numericUpDown1.Value > 0)
            {
                DataTable productos = ReporteService.ObtenerProductosStockBajo((int)numericUpDown1.Value);
                dataGridView1.DataSource = productos;
                if (productos.Rows.Count > 0)
                {
                    CrearPdf("Productos por Fecha", productos);
                }
                return;
            }
            MessageBox.Show("Ingrese una cantidad de stock", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio = dateTimePicker1.Value;
            DateTime fechaFin = dateTimePicker2.Value;

            DataTable productos = ReporteService.ObtenerProductosPorFecha(fechaInicio, fechaFin);

            if (productos.Rows.Count > 0)
            {
                CrearPdf("Productos por Fecha", productos);
            }
            else
            {
                MessageBox.Show("No se encontraron productos para las fechas seleccionadas.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable productos = ReporteService.ObtenerProveedoresYProductos();

            if (productos.Rows.Count > 0)
            {
                CrearPdf("Productos por Fecha", productos);
            }
            else
            {
                MessageBox.Show("No se encontraron datos.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable productos = ReporteService.ObtenerProveedoresYProductosLeftJoin();

            if (productos.Rows.Count > 0)
            {
                CrearPdf("Productos por Fecha", productos);
            }
            else
            {
                MessageBox.Show("No se encontraron datos.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable productos = ReporteService.ObtenerProveedoresYProductosRightJoin();

            if (productos.Rows.Count > 0)
            {
                CrearPdf("Productos por Fecha", productos);
            }
            else
            {
                MessageBox.Show("No se encontraron datos.");
            }
        }

        public static void CrearPdf(string titulo, DataTable datos)
        {
            if (datos.Rows.Count == 0)
            {
                Console.WriteLine("No hay datos para generar el PDF.");
                return;
            }

            PdfDocument document = new PdfDocument();
            document.Info.Title = titulo;
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XFont fontTitulo = new XFont("Arial", 14);
            XFont fontTexto = new XFont("Arial", 10);

            gfx.DrawString(titulo, fontTitulo, XBrushes.Black, new XPoint(50, 50));

            int yPos = 80;
            int xPos = 50;
            int columnWidth = 150;

            for (int i = 0; i < datos.Columns.Count; i++)
            {
                gfx.DrawString(datos.Columns[i].ColumnName, fontTexto, XBrushes.Black, new XPoint(xPos + (i * columnWidth), yPos));
            }

            gfx.DrawLine(XPens.Black, 50, yPos + 10, 50 + (columnWidth * datos.Columns.Count), yPos + 10);

            yPos += 30;
            foreach (DataRow row in datos.Rows)
            {
                xPos = 50;
                for (int i = 0; i < datos.Columns.Count; i++)
                {
                    gfx.DrawString(row[i].ToString(), fontTexto, XBrushes.Black, new XPoint(xPos + (i * columnWidth), yPos));
                }
                yPos += 20;
            }

            string filename = $"{titulo.Replace(" ", "_")}.pdf";
            document.Save(filename);
            Console.WriteLine($"PDF generado con éxito: {filename}");

            Process.Start(new ProcessStartInfo(filename) { UseShellExecute = true });
        }

        private void PanelPrincipal_Load(object sender, EventArgs e)
        {
            DataTable dt = ReporteService.ObtenerCantidadProductosPorProveedor();

            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.ChartAreas.Add(new ChartArea("chartArea"));
            chart1.Series.Add("CantidadProductos");
            chart1.Series["CantidadProductos"].XValueMember = "Proveedor";
            chart1.Series["CantidadProductos"].YValueMembers = "TotalProductos";
            chart1.Series["CantidadProductos"].ChartType = SeriesChartType.Bar;

            chart1.DataSource = dt;
            chart1.DataBind();
        }
    }
}
