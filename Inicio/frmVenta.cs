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
        private List<Productos> productosStockList;
        decimal costoTotal;

        public frmVenta()
        {
            InitializeComponent();
        }

        public frmVenta(Cliente cliente, List<Productos> listaProductos) : this()
        {
            this.clienteElegido = cliente;
            this.productosStockList = listaProductos;
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
            lblCliente.Text = "Cliente: " + clienteElegido.MailPropiedad;
            lblMontoCliente.Text = "Monto maximo a gastar: $" + (clienteElegido.GastoMaximoPropiedad).ToString();

            foreach (Productos productos in productosStockList)
            {
                listBoxProductos.Items.Add(productos);
            }

            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            dataTable.Columns.Add("Productos", typeof(Productos));
            dataTable.Columns.Add("Cantidad (kg's)", typeof(decimal));
            dataTable.Columns.Add("Costo individual", typeof(decimal));
        }
        private void listBoxProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxProductos.SelectedItem is not null && nudKgs.Value > 0)
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
            if (dataGridView1.SelectedRows is not null)
            {
                btnEliminar.Enabled = true;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Productos productoEliminado;
            decimal kgStockRecuperados;
            if (btnEliminar.Enabled)
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
                MessageBox.Show("No puede cerrar el formulario con elementos en el carrito.\n " +
                    "Si quiere cancelar la venta, primero eliminar los productos del carrito");
            }
        }
    }
}
