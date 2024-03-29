﻿using Entidades;
using Facturas;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inicio
{
    public partial class frmVenta : Form
    {
        private Vendedor vendedorElegido;
        private Cliente? clienteElegido;
        private List<Usuario> usuariosList;
        private List<Productos> productosStockList;
        private decimal costoTotal;
        public List<Factura> listaFacturasHistorial;

        public frmVenta()
        {
            InitializeComponent();
        }

        public frmVenta(Vendedor vendedor, Cliente cliente, List<Productos> listaProductos, List<Usuario> listaUsuarios, List<Factura> facturasHistorial) : this()
        {
            this.vendedorElegido = vendedor;
            this.clienteElegido = cliente;
            this.productosStockList = listaProductos;
            this.usuariosList = listaUsuarios;
            this.listaFacturasHistorial = facturasHistorial;
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
            int indiceObjeto;

            this.Text = "Bienvenido a la seccion de compraventa";

            foreach (Usuario usuarios in usuariosList)
            {
                if (usuarios is Vendedor)
                {
                    comboBoxVendedores.Items.Add(usuarios);
                }
            }

            if (vendedorElegido is not null)
            {
                indiceObjeto = usuariosList.IndexOf(vendedorElegido);
                //MessageBox.Show($"{indiceObjeto}");
                comboBoxVendedores.SelectedIndex = indiceObjeto;
            }
            else if (vendedorElegido is null)
            {
                comboBoxVendedores.SelectedIndex = 0;
            }

            foreach (Productos productos in productosStockList)
            {
                listBoxProductos.Items.Add(productos);
            }

            lblCliente.Text = "Cliente: " + clienteElegido.MailPropiedad;
            lblMontoCliente.Text = "Monto maximo a gastar: $" + (clienteElegido.GastoMaximoPropiedad).ToString();
            txtBuscador.PlaceholderText = "Buscar corte:";

            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            dataTable.Columns.Add("Productos", typeof(Productos));
            dataTable.Columns.Add("Cantidad (kg's)", typeof(decimal));
            dataTable.Columns.Add("Costo individual", typeof(decimal));

            Reloj reloj = new Reloj();
            reloj.SegundoCambiado += AsignarHora;
            reloj.Iniciar();
        }

        public void AsignarHora(Reloj reloj)
        {
            if (lblReloj.InvokeRequired)
            {
                Action<Reloj> delegado = AsignarHora;

                lblReloj.Invoke(delegado, reloj);
            }
            else
            {
                lblReloj.Text = $"Hora: {reloj.ToString()}";
            }
        }


        private void listBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxVendedores.SelectedIndex is >= 0 && listBoxProductos.SelectedItem is not null && nudKgs.Value > 0)
            {
                btnAgregar.Enabled = true;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            decimal cantidadProducto = nudKgs.Value;
            decimal precioPorKg = (decimal)((Productos)(listBoxProductos.SelectedItem)).Precio;
            int stockDisponible = (int)((Productos)(listBoxProductos.SelectedItem)).KgEnStock;
            decimal totalIndividual = cantidadProducto * precioPorKg;
            Productos productoSeleccionado = (Productos)listBoxProductos.SelectedItem;

            CalcularCostoTotal();

            if (btnAgregar.Enabled && totalIndividual <= clienteElegido.GastoMaximoPropiedad)
            {
                if ((totalIndividual + costoTotal) <= clienteElegido.GastoMaximoPropiedad)
                {
                    if (cantidadProducto <= stockDisponible)
                    {
                        productoSeleccionado.KgEnStock -= (int)cantidadProducto;
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
                    else { MessageBox.Show("No tenemos stock", "Error de stock"); }
                }
                else { MessageBox.Show("comprar esta cantidad de producto supera su presupuesto ", "Error de presupuesto", MessageBoxButtons.OK); }
            }
            else { MessageBox.Show("la cantidad que intenta comprar ya supera su presupuesto", "Error de presupuesto", MessageBoxButtons.OK); }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[rowIndex];

            decimal costoPorKg = (decimal)((Productos)row.Cells[0].Value).Precio;
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
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                }
                productoEliminado = (Productos)dataGridView1.SelectedRows[0].Cells[0].Value;
                kgStockRecuperados = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[1].Value);
                productoEliminado.KgEnStock = (int)((decimal)productoEliminado.KgEnStock + kgStockRecuperados);

                dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
                CalcularCostoTotal();
                txtTotal.Text = "Total: $" + costoTotal.ToString();
            }
            txtTotal.Refresh();
        }

        private void frmVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult seguir = MessageBox.Show("Desea seguir comprando?", "Compraventa", MessageBoxButtons.YesNo);
            if (seguir == DialogResult.No)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
            if (dataGridView1.Rows.Count > 0)
            {
                e.Cancel = true;
                MessageBox.Show("Si quiere cancelar la venta, primero elimine los productos del carrito", "Cancelar venta");
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
                if (DialogResult == DialogResult.Yes)
                {
                    costoTotal = costoTotal * (decimal)1.05;
                }
                DialogResult = MessageBox.Show($"Efectuar la compra? el monto total es de {costoTotal}", "COBRO", MessageBoxButtons.OKCancel);

                if (DialogResult == DialogResult.OK)
                {
                    Factura factura;
                    vendedorElegido.Cobrar(clienteElegido, costoTotal);

                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        Productos? producto = row.Cells[0].Value as Productos;
                        decimal montoIndividual = (decimal)row.Cells[2].Value;
                        if (producto != null)
                        {
                            listaProductosComprados.Add(producto);
                        }

                        StringBuilder sb = new StringBuilder();
                        if (producto is Carne)
                        {
                            sb.AppendLine($"{((Carne)producto).Corte} de {((Carne)producto).Animal} - ${montoIndividual}");
                        }
                        else if (producto is Embutido)
                        {
                            sb.AppendLine($"{((Embutido)producto).TipoEmbutido} - ${montoIndividual}");
                        }
                        listBoxHistorial.Items.Add(sb.ToString());
                    }

                    factura = vendedorElegido.HacerFactura(vendedorElegido.MailPropiedad, clienteElegido.MailPropiedad, costoTotal, listaProductosComprados);

                    listaFacturasHistorial.Add(factura);

                    MessageBox.Show(factura.MostrarFactura(), "Factura B");
                    try
                    {
                        ArchivarTexto.GuardarFacturaTexto(factura.MostrarFactura(), "HistorialFacturas.txt");
                    }
                    catch (ExcepcionesPropias ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    while (dataGridView1.Rows.Count > 0)
                    {
                        dataGridView1.Rows.RemoveAt(0);
                    }
                    lblMontoCliente.Text = "Monto maximo a gastar: $" + (clienteElegido.GastoMaximoPropiedad).ToString();
                }
            }
            else { MessageBox.Show("se quedó sin dinero para comprar estos items", "Falta de fondos"); }
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            string producto = txtBuscador.Text;
            string corte;
            string tipoEmbutido;
            int index = -1;
            foreach (object item in listBoxProductos.Items)
            {
                if (item is Carne)
                {
                    corte = ((Carne)item).Corte;
                    if (producto == corte)
                    {
                        index = listBoxProductos.Items.IndexOf(item);
                        break;
                    }
                }
                if (item is Embutido)
                {
                    tipoEmbutido = ((Embutido)item).TipoEmbutido;
                    if (producto == tipoEmbutido)
                    {
                        index = listBoxProductos.Items.IndexOf(item);
                        break;
                    }
                }
            }
            listBoxProductos.SelectedIndex = index;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            List<Carne> carnes = new List<Carne>();
            List<Embutido> embutidos = new List<Embutido>();
            try
            {
                foreach (object item in productosStockList)
                {
                    if (item is Carne)
                    {
                        carnes.Add((Carne)item);
                    }
                    else if (item is Embutido)
                    {
                        embutidos.Add((Embutido)item);
                    }
                }
                Serializacion.SerializarAJson(carnes, "CarnesJson.json");
                Serializacion.SerializarAJson(embutidos, "EmbutidosJson.json");
                MessageBox.Show("Guardado el estado del stock", "Productos Guardados", MessageBoxButtons.OK);
            }
            catch (ExcepcionesPropias ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeserializarJson_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                List<Carne> carnes = Serializacion.DeserializarDesdeJson<List<Carne>>("CarnesJson.json");
                List<Embutido> embutidos = Serializacion.DeserializarDesdeJson<List<Embutido>>("EmbutidosJson.json");

                foreach (Carne car in carnes)
                {
                    sb.AppendLine($"ID: {car.Id} | DETALLE: {car.Animal} {car.Corte} | STOCK: {car.KgEnStock}kg | PRECIO: ${car.Precio}");
                }
                foreach (Embutido embutido in embutidos)
                {
                    sb.AppendLine($"ID: {embutido.Id} | DETALLE: {embutido.TipoEmbutido} | STOCK: {embutido.KgEnStock}kg | PRECIO: ${embutido.Precio}");
                }

                MessageBox.Show($"{sb}", "Anterior Stock guardado", MessageBoxButtons.OK);
            }
            catch (ExcepcionesPropias ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
