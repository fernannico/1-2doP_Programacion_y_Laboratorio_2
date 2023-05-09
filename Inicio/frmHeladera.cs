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
        private Cliente? clienteElegido;
        private List<Productos> productosStockList;
        private List<Usuario> usuariosList;
        private int indiceFilaSeleccionada = -1;

        Dictionary<int, Productos> diccionarioProductos = new Dictionary<int, Productos>();

        public frmHeladera()
        {
            InitializeComponent();
        }
        public frmHeladera(Vendedor vendedor, List<Productos> listaProductos, List<Usuario> listaUsuarios) : this()
        {
            this.vendedorElegido = vendedor;
            this.productosStockList = listaProductos;
            this.usuariosList = listaUsuarios;
        }

        public Cliente ClienteElegidoPropiedad
        {
            get
            {
                return clienteElegido;
            }
            set
            {
                clienteElegido = value;
            }
        }


        private void frmHeladera_Load(object sender, EventArgs e)
        {
            lblVendedorElegido.Text = vendedorElegido?.ToString();

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
                DataRow dr = dataTable.NewRow();        //.NewRow para crear una nueva fila en el objeto DataTable. devuelve una nueva instancia de DataRow que es una fila vacía
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
                dr["kg en stock"] = item.KgEnStockPropiedad; //los valores de las celdas pueden ser establecidos mediante la propiedad Item de la fila
                dr["precio/Kg"] = item.PrecioPropiedad;
                dataTable.Rows.Add(dr);                 //para agregar la fila creada anteriormente dr a la tabla de datos dataTable. De esta manera, se agrega una nueva fila a la tabla para cada objeto en la lista productosStockList.

                diccionarioProductos.Add(posicionFila, item);
                posicionFila++;
            }

            foreach (Usuario usuarios in usuariosList)
            {
                if (usuarios is Cliente)
                {
                    comboBoxClientes.Items.Add(usuarios);
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
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
                }
                else if (productoSeleccionado is Embutido)
                {
                    txtModDescripcion.Text = ((Embutido)productoSeleccionado).TipoEmbutidoPropiedad;
                    txtModifCorte.Text = "";
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
            string nuevaDescripcion;
            string nuevoCorte;
            float nuevoPrecio;
            int nuevoKgStock;

            if (btnModificar.Enabled == true)
            {
                nuevoPrecio = (float)nudModifPrecio.Value;
                if (nuevoPrecio != productoSeleccionado.PrecioPropiedad && nuevoPrecio > 0)
                {
                    vendedorElegido.FijarPrecioKg(productoSeleccionado, (float)nudModifPrecio.Value);
                    dataGridView1.Rows[indiceFilaSeleccionada].Cells["precio/Kg"].Value = nuevoPrecio;
                    MessageBox.Show("precio modificado", "error", MessageBoxButtons.OK);
                }

                nuevoKgStock = (int)nudModifStock.Value;
                if (nuevoKgStock > 0)
                {
                    vendedorElegido.ReponerProductos(productoSeleccionado, (int)nudModifStock.Value);
                    dataGridView1.Rows[indiceFilaSeleccionada].Cells["kg en stock"].Value = productoSeleccionado.KgEnStockPropiedad;
                    MessageBox.Show("stock repuesto", "error", MessageBoxButtons.OK);
                }

                nuevaDescripcion = txtModDescripcion.Text;
                if (productoSeleccionado is Carne && nuevaDescripcion != ((Carne)productoSeleccionado).AnimalPropiedad)
                {
                    vendedorElegido.FijarAnimal((Carne)productoSeleccionado, txtModDescripcion.Text);
                    dataGridView1.Rows[indiceFilaSeleccionada].Cells["Descripcion"].Value = nuevaDescripcion;
                    MessageBox.Show("descripcion modificada", "error", MessageBoxButtons.OK);
                }
                else if (productoSeleccionado is Embutido && nuevaDescripcion != ((Embutido)productoSeleccionado).TipoEmbutidoPropiedad)
                {
                    vendedorElegido.FijarTipoEmbutido((Embutido)productoSeleccionado, txtModDescripcion.Text);
                    dataGridView1.Rows[indiceFilaSeleccionada].Cells["Descripcion"].Value = nuevaDescripcion;
                    MessageBox.Show("descripcion modificada", "error", MessageBoxButtons.OK);
                }

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

            if(btnVender.Enabled == true)
            {
                cliente = (Cliente)comboBoxClientes.SelectedItem;
                
                frmVenta frmVenta = new frmVenta(cliente, productosStockList, usuariosList);
                frmVenta.ShowDialog();
            }
        }
    }
}
