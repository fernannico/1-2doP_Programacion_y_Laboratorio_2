using eModificacion;
using Facturas;
using ProductosNs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using usuarios;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Inicio
{
    public partial class frmHeladera : Form
    {
        private Vendedor? vendedorElegido;
        private List<Productos> productosStockList;
        private List<Factura> listaFacturasHistorial;
        private List<Usuario> usuariosList;
        private int indiceFilaSeleccionada = -1;

        Dictionary<int, Productos> diccionarioProductos = new Dictionary<int, Productos>();

        public frmHeladera()
        {
            InitializeComponent();
        }
        public frmHeladera(Vendedor vendedor, List<Productos> listaProductos, List<Usuario> listaUsuarios, List<Factura> listaFacturasHistorial) : this()
        {
            this.vendedorElegido = vendedor;
            this.productosStockList = listaProductos;
            this.usuariosList = listaUsuarios;
            this.listaFacturasHistorial = listaFacturasHistorial;
        }

        private void frmHeladera_Load(object sender, EventArgs e)
        {

            this.Text = "Bienvenido " + vendedorElegido.MailPropiedad;

            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            dataTable.Columns.Add("Descripcion", typeof(string));
            dataTable.Columns.Add("Corte", typeof(string));
            dataTable.Columns.Add("kg en stock", typeof(int));
            dataTable.Columns.Add("precio/Kg", typeof(float));

            foreach (DataGridViewColumn columna in dataGridView1.Columns)
            {
                columna.SortMode = DataGridViewColumnSortMode.NotSortable;
                columna.ReadOnly = true;
            }

            int posicionFila = 0;

            foreach (var item in productosStockList)
            {
                DataRow dr = dataTable.NewRow();
                if (item is Carne)
                {
                    Carne newItem = (Carne)item;
                    dr["Corte"] = newItem.CortePropiedad;
                    dr["Descripcion"] = newItem.AnimalPropiedad;
                }
                else if (item is Embutido)
                {
                    Embutido newItem = (Embutido)item;
                    dr["Descripcion"] = newItem.TipoEmbutidoPropiedad;
                }
                dr["kg en stock"] = item.KgEnStockPropiedad;
                dr["precio/Kg"] = item.PrecioPropiedad;
                dataTable.Rows.Add(dr);

                diccionarioProductos.Add(posicionFila, item);
                posicionFila++;
            }

            dataGridView1.ClearSelection();
            if (dataGridView1.SelectedRows.Count == 0)
            {
                txtModDescripcion.Enabled = false;
                txtModifCorte.Enabled = false;
                nudModifPrecio.Enabled = false;
                nudModifStock.Enabled = false;
            }

            foreach (Usuario usuarios in usuariosList)
            {
                if (usuarios is Cliente)
                {
                    comboBoxClientes.Items.Add(usuarios);
                }
            }
            if (listaFacturasHistorial.Count > 0)
            {
                btcFacturasHistorial.Enabled = true;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtModDescripcion.Enabled = true;
                nudModifStock.Enabled = true;
                nudModifPrecio.Enabled = true;
                btnDetalles.Enabled = true;
                btnModificar.Enabled = true;

                indiceFilaSeleccionada = e.RowIndex;

                Productos productoSeleccionado = diccionarioProductos[e.RowIndex];

                //nudModifStock.Value = productoSeleccionado.KgEnStockPropiedad;
                nudModifPrecio.Value = (decimal)productoSeleccionado.PrecioPropiedad;

                if (productoSeleccionado is Carne)
                {
                    txtModDescripcion.Text = ((Carne)productoSeleccionado).AnimalPropiedad;
                    txtModifCorte.Text = ((Carne)productoSeleccionado).CortePropiedad;
                    txtModifCorte.Enabled = true;
                }
                else if (productoSeleccionado is Embutido)
                {
                    txtModDescripcion.Text = ((Embutido)productoSeleccionado).TipoEmbutidoPropiedad;
                    txtModifCorte.Text = null;
                    txtModifCorte.Enabled = false;
                }
            }
            else { btnDetalles.Enabled = false; btnModificar.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Productos productoSeleccionado = diccionarioProductos[indiceFilaSeleccionada];

            if (btnDetalles.Enabled == true)
            {
                frmDetalles frmDetalles = new frmDetalles(vendedorElegido.VerDetallesProducto(productoSeleccionado));
                frmDetalles.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Productos productoSeleccionado = diccionarioProductos[indiceFilaSeleccionada];

            if (btnModificar.Enabled == true)
            {
                float precioOriginal = productoSeleccionado.PrecioPropiedad;
                string nuevaDescripcion;
                string corteOriginal;
                string nuevoCorte;
                float nuevoPrecio;
                int nuevoKgStock;
                EstadoModificacion huboModificacion = EstadoModificacion.noModificado;

                StringBuilder sb = new StringBuilder();

                nuevaDescripcion = txtModDescripcion.Text;
                if (productoSeleccionado is Carne && nuevaDescripcion != ((Carne)productoSeleccionado).AnimalPropiedad)
                {
                    huboModificacion = EstadoModificacion.modificado;
                    sb.AppendLine($"- Animal: de '{((Carne)productoSeleccionado).AnimalPropiedad}' a '{nuevaDescripcion}'");
                    vendedorElegido.FijarAnimal((Carne)productoSeleccionado, txtModDescripcion.Text);
                    dataGridView1.Rows[indiceFilaSeleccionada].Cells["Descripcion"].Value = nuevaDescripcion;
                }
                else if (productoSeleccionado is Embutido && nuevaDescripcion != ((Embutido)productoSeleccionado).TipoEmbutidoPropiedad)
                {
                    huboModificacion = EstadoModificacion.modificado;
                    sb.AppendLine($"- Nombre del embutido: de '{((Embutido)productoSeleccionado).TipoEmbutidoPropiedad}' a '{nuevaDescripcion}'"); vendedorElegido.FijarTipoEmbutido((Embutido)productoSeleccionado, txtModDescripcion.Text);
                    dataGridView1.Rows[indiceFilaSeleccionada].Cells["Descripcion"].Value = nuevaDescripcion;
                }

                nuevoCorte = txtModifCorte.Text;
                if (productoSeleccionado is Carne)
                {
                    corteOriginal = ((Carne)productoSeleccionado).CortePropiedad;
                    if (nuevoCorte != corteOriginal)
                    {
                        huboModificacion = EstadoModificacion.modificado;
                        sb.AppendLine($"- Corte: de '{corteOriginal}' a '{nuevoCorte}'");
                        vendedorElegido.FijarCorteDeCarne((Carne)productoSeleccionado, nuevoCorte);
                        dataGridView1.Rows[indiceFilaSeleccionada].Cells["Corte"].Value = nuevoCorte;
                    }
                }

                nuevoKgStock = (int)nudModifStock.Value;
                if (nuevoKgStock > 0)
                {
                    huboModificacion = EstadoModificacion.modificado;
                    sb.AppendLine($"- Se repuso {nuevoKgStock}kg de stock");
                    vendedorElegido.ReponerProductos(productoSeleccionado, (int)nudModifStock.Value);
                    dataGridView1.Rows[indiceFilaSeleccionada].Cells["kg en stock"].Value = productoSeleccionado.KgEnStockPropiedad;
                }

                nuevoPrecio = (float)nudModifPrecio.Value;
                if (nuevoPrecio != precioOriginal && nuevoPrecio > 0)
                {
                    huboModificacion = EstadoModificacion.modificado;
                    sb.AppendLine($"- Precio: de ${precioOriginal} a ${nuevoPrecio}");
                    vendedorElegido.FijarPrecioKg(productoSeleccionado, (float)nudModifPrecio.Value);
                    dataGridView1.Rows[indiceFilaSeleccionada].Cells["precio/Kg"].Value = nuevoPrecio;
                }

                if (huboModificacion == EstadoModificacion.modificado)
                {
                    MessageBox.Show("Se modificaron:\n" + sb.ToString(), "Modificacion realizada", MessageBoxButtons.OK);
                    nudModifStock.Value = 0;
                }
                else { MessageBox.Show("No se efectuó una modificacion", "Sin modificacion", MessageBoxButtons.OK); }
            }
        }
        private void comboBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxClientes.SelectedIndex >= 0)
            {
                btnVender.Enabled = true;
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            Cliente cliente;
            int indiceComboboxCliente = comboBoxClientes.SelectedIndex;

            if (btnVender.Enabled == true)
            {
                cliente = (Cliente)comboBoxClientes.SelectedItem;

                frmVenta frmVenta = new frmVenta(vendedorElegido, cliente, productosStockList, usuariosList, listaFacturasHistorial);
                frmVenta.ShowDialog();
                this.Close();
            }
        }

        private void btcFacturasHistorial_Click(object sender, EventArgs e)
        {
            if (btcFacturasHistorial.Enabled)
            {
                frmHistorialFacturas frmHistorialFacturas = new frmHistorialFacturas(listaFacturasHistorial);
                frmHistorialFacturas.Show();
            }
        }
    }
}
