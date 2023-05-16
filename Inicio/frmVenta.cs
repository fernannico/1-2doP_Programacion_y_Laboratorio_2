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
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    dataGridView1.Rows[0].Selected = true;
                }
                productoEliminado = (Productos)dataGridView1.SelectedRows[0].Cells[0].Value;
                kgStockRecuperados = Convert.ToDecimal(dataGridView1.SelectedRows[0].Cells[1].Value);
                productoEliminado.KgEnStockPropiedad = (int)((decimal)productoEliminado.KgEnStockPropiedad + kgStockRecuperados);

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
                            sb.AppendLine($"{((Carne)producto).CortePropiedad} de {((Carne)producto).AnimalPropiedad} - ${montoIndividual}");
                        }
                        else if (producto is Embutido)
                        {
                            sb.AppendLine($"{((Embutido)producto).TipoEmbutidoPropiedad} - ${montoIndividual}");
                        }
                        listBoxHistorial.Items.Add(sb.ToString());
                    }

                    factura = vendedorElegido.HacerFactura(vendedorElegido.MailPropiedad, clienteElegido.MailPropiedad, costoTotal, listaProductosComprados);

                    listaFacturasHistorial.Add(factura);

                    MessageBox.Show(factura.MostrarFactura(), "Factura B");

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
                    corte = ((Carne)item).CortePropiedad;
                    if (producto == corte)
                    {
                        index = listBoxProductos.Items.IndexOf(item);
                        break;
                    }
                }
                if (item is Embutido)
                {
                    tipoEmbutido = ((Embutido)item).TipoEmbutidoPropiedad;
                    if (producto == tipoEmbutido)
                    {
                        index = listBoxProductos.Items.IndexOf(item);
                        break;
                    }
                }
            }
            listBoxProductos.SelectedIndex = index;
        }
    }
}
