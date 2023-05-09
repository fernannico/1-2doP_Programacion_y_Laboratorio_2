﻿using Facturas;
using ProductosNs;
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

namespace Inicio
{
    public partial class frmVenta : Form
    {
        private Cliente? clienteElegido;
        List<Usuario> usuariosList;
        private List<Productos> productosStockList;
        decimal costoTotal;

        public frmVenta()
        {
            InitializeComponent();
        }

        public frmVenta(Cliente cliente, List<Productos> listaProductos, List<Usuario> listaUsuarios) : this()
        {
            this.clienteElegido = cliente;
            this.productosStockList = listaProductos;
            this.usuariosList = listaUsuarios;
        }
        private void CalcularCostoTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow rows in dataGridView1.Rows)
            {
                total += Convert.ToDecimal(rows.Cells[2].Value);
            }
            this.costoTotal = total;
        }
        private void frmVenta_Load(object sender, EventArgs e)
        {
            foreach (Usuario usuarios in usuariosList)
            {
                if(usuarios is Vendedor)
                {
                    comboBoxVendedores.Items.Add(usuarios);
                }
            }

            foreach (Productos productos in productosStockList)
            {
                listBoxProductos.Items.Add(productos);
            }

            lblCliente.Text = "Cliente: " + clienteElegido.MailPropiedad;
            lblMontoCliente.Text = "Monto maximo a gastar: $" + (clienteElegido.GastoMaximoPropiedad).ToString();
            
            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            dataTable.Columns.Add("Productos", typeof(Productos));
            dataTable.Columns.Add("Cantidad (kg's)", typeof(decimal));
            dataTable.Columns.Add("Costo individual", typeof(decimal));
        }
        private void listBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVendedores.SelectedIndex is > 0 && listBoxProductos.SelectedItem is not null && nudKgs.Value > 0)
            {
                btnAgregar.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            decimal cantidadProducto = nudKgs.Value;
            decimal precioPorKg = (decimal)((Productos)(listBoxProductos.SelectedItem)).PrecioPropiedad;
            int stockDisponible = (int)((Productos)(listBoxProductos.SelectedItem)).KgEnStockPropiedad;
            decimal totalIndividual = cantidadProducto * precioPorKg;
            Productos productoSeleccionado = (Productos)listBoxProductos.SelectedItem;

            CalcularCostoTotal();

            if (btnAgregar.Enabled && totalIndividual <= clienteElegido.GastoMaximoPropiedad)
            {
                if ((totalIndividual + costoTotal) <= clienteElegido.GastoMaximoPropiedad)
                {
                    if (cantidadProducto <= stockDisponible)
                    {
                        productoSeleccionado.KgEnStockPropiedad -= (int)cantidadProducto;
                        DataTable dataTable = (DataTable)dataGridView1.DataSource;
                        DataRow newRow = dataTable.NewRow();
                        newRow[0] = listBoxProductos.SelectedItem;
                        newRow[1] = cantidadProducto;
                        newRow[2] = cantidadProducto * precioPorKg;
                        dataTable.Rows.Add(newRow);

                        CalcularCostoTotal();
                        txtTotal.Text = "Total: $" + costoTotal.ToString();
                        txtTotal.Refresh();
                    }
                    else { MessageBox.Show("No tenemos stock"); }
                }
                else { MessageBox.Show("comprar esta cantidad de producto supera su presupuesto "); }
            }
            else { MessageBox.Show("la cantidad que intenta comprar ya supera su presupuesto"); }
        }
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            decimal costoPorKg = (decimal)((Productos)row.Cells[0].Value).PrecioPropiedad;
            decimal kgsComprados = Convert.ToDecimal(row.Cells[1].Value);

            costoTotal = costoPorKg * kgsComprados;

            row.Cells[2].Value = costoTotal;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows is not null && dataGridView1.Rows.Count > 0)
            {
                btnEliminar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Productos productoEliminado;
            decimal kgStockRecuperados;
            if (btnEliminar.Enabled && dataGridView1.SelectedRows is not null)
            {
                productoEliminado = (Productos)dataGridView1.SelectedRows[0].Cells[0].Value;
                kgStockRecuperados = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[1].Value);
                //MessageBox.Show(productoEliminado.ToString());
                productoEliminado.KgEnStockPropiedad = (int)((decimal)productoEliminado.KgEnStockPropiedad + kgStockRecuperados);

                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                CalcularCostoTotal();
                txtTotal.Text = "Total: $" + costoTotal.ToString();
            }
            txtTotal.Refresh();
        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                e.Cancel = true;
                MessageBox.Show("Si quiere cancelar la venta, primero elimine los productos del carrito");
            }
        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                btnComprar.Enabled = true;
            }
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dataGridView1.Rows.Count <= 0)
            {
                btnComprar.Enabled = false;
                btnEliminar.Enabled = false;
            }
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            Vendedor? vendedorElegido = comboBoxVendedores.SelectedItem as Vendedor;
            List<Productos> listaProductosComprados = new List<Productos>();

            if (btnComprar.Enabled && costoTotal < clienteElegido.GastoMaximoPropiedad)
            {
                DialogResult = MessageBox.Show("Pagaras con credito?", "EFECTIVO O CREDITO", MessageBoxButtons.YesNo);
                if(DialogResult == DialogResult.Yes) 
                {
                    costoTotal = costoTotal * (decimal)1.05;
                }
                DialogResult = MessageBox.Show($"Efectuar la compra? el monto total es de {costoTotal}", "COBRO", MessageBoxButtons.OKCancel);
                
                if(DialogResult == DialogResult.OK)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Productos? producto = row.Cells[0].Value as Productos;
                        if (producto != null)
                        {
                            listaProductosComprados.Add(producto);
                        }
                    }
                                
                    clienteElegido.EfectuarCompraventa(costoTotal);
                    vendedorElegido.EfectuarCompraventa(costoTotal);
                    Factura factura;
                    factura = vendedorElegido.HacerFactura(vendedorElegido.MailPropiedad, clienteElegido.MailPropiedad, costoTotal, listaProductosComprados);

                    MessageBox.Show(factura.MostrarFactura());

                    while (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(0);
                    }
                    lblMontoCliente.Text = "Monto maximo a gastar: $" + (clienteElegido.GastoMaximoPropiedad).ToString();
                }
            }
            else { MessageBox.Show("se quedó sin dinero para comprar estos items"); }
        }

        private void comboBoxVendedores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
