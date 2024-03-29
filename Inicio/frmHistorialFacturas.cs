﻿using Facturas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using usuarios;
using Entidades;

namespace Inicio
{
    public partial class frmHistorialFacturas : Form
    {
        private List<Factura> facturasList;

        public frmHistorialFacturas()
        {
            InitializeComponent();
        }

        public frmHistorialFacturas(List<Factura> facturas) : this()
        {
            this.facturasList = facturas;
        }

        private void frmHistorialFacturas_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            dataTable.Columns.Add("Cliente", typeof(string));
            dataTable.Columns.Add("Vendedor", typeof(string));
            dataTable.Columns.Add("Factura", typeof(Factura));
            dataTable.Columns.Add("Monto Total", typeof(decimal));

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.ReadOnly = true;
            }

            foreach (Factura item in facturasList)
            {
                DataRow dr = dataTable.NewRow();

                dr["Cliente"] = item.ClientePropiedad;
                dr["Vendedor"] = item.VendedorPropiedad;
                dr["Factura"] = item;
                dr["Monto Total"] = item.MontoPropiedad;
                dataTable.Rows.Add(dr);
            }
            dataGridView1.ClearSelection();
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            if (btnDetalle.Enabled)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DataGridViewCell cell = dataGridView1.CurrentRow.Cells[2];
                    Factura factura = (Factura)cell.Value;

                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        dataGridView1.Rows[0].Selected = true;
                    }
                    if (factura is Factura && factura is not null)
                    {
                        MessageBox.Show(factura.MostrarFactura(), "Factura A");
                    }
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.RowCount > 1)
            {
                btnDetalle.Enabled = true;
                btnSaveFact.Enabled = true;
            }
        }

        private void btnSaveFact_Click(object sender, EventArgs e)
        {

            if (btnDetalle.Enabled)
            {
                if (dataGridView1.CurrentRow != null)
                {
                    DataGridViewCell cell = dataGridView1.CurrentRow.Cells[2];
                    Factura factura = (Factura)cell.Value;

                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        dataGridView1.Rows[0].Selected = true;
                    }
                    if (factura is Factura && factura is not null)
                    {
                        try
                        {
                            ArchivarTexto.GuardarFacturaTexto(factura.MostrarFactura(), "FacturasElegidas.txt");
                        }
                        catch (ExcepcionesPropias ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string historialfacturas = ArchivarTexto.AbrirFacturaTexto("HistorialFacturas.txt");
                MessageBox.Show(historialfacturas, "HISTORIAL DE FACTURAS", MessageBoxButtons.OK);
            }
            catch (ExcepcionesPropias ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}