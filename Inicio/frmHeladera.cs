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
using Entidades;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

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

            //dataGridView1.DataSource = CarnesBDD.Leer();
            //dataGridView1.DataSource = EmbutidosBDD.Leer();

            //dataGridView1.DataSource = ProductosBDD.Leer();
            //---------
            CargarDataGrid();

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
            if (File.Exists("HistorialFacturas.txt"))
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
                btnEliminar.Enabled = true;

                indiceFilaSeleccionada = e.RowIndex;

                int idProducto = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                if (diccionarioProductos.ContainsKey(idProducto))
                {
                    Productos productoSeleccionado = diccionarioProductos[idProducto];

                    nudModifPrecio.Value = (decimal)productoSeleccionado.Precio;

                    if (productoSeleccionado is Carne)
                    {
                        txtModDescripcion.Text = ((Carne)productoSeleccionado).Animal;
                        txtModifCorte.Text = ((Carne)productoSeleccionado).Corte;
                        txtModifCorte.Enabled = true;
                    }
                    else if (productoSeleccionado is Embutido)
                    {
                        txtModDescripcion.Text = ((Embutido)productoSeleccionado).TipoEmbutido;
                        txtModifCorte.Text = null;
                        txtModifCorte.Enabled = false;
                    }
                }
            }
            else { btnDetalles.Enabled = false; btnModificar.Enabled = false; btnEliminar.Enabled = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int idSeleccionado = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                if (diccionarioProductos.ContainsKey(idSeleccionado))
                {
                    Productos productoSeleccionado = diccionarioProductos[idSeleccionado];

                    if (btnDetalles.Enabled == true)
                    {
                        frmDetalles frmDetalles = new frmDetalles(vendedorElegido.VerDetallesProducto(productoSeleccionado));
                        frmDetalles.ShowDialog();
                    }
                }
            }

            //Productos productoSeleccionado = diccionarioProductos[indiceFilaSeleccionada];

            //if (btnDetalles.Enabled == true)
            //{
            //    frmDetalles frmDetalles = new frmDetalles(vendedorElegido.VerDetallesProducto(productoSeleccionado));
            //    frmDetalles.ShowDialog();
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                int idSeleccionado = Convert.ToInt32(selectedRow.Cells["ID"].Value);

                //MessageBox.Show($"ID {idSeleccionado}");

                if (diccionarioProductos.ContainsKey(idSeleccionado))
                {
                    Productos productoSeleccionado = diccionarioProductos[idSeleccionado];

                    //MessageBox.Show(productoSeleccionado.ToString());

                    if (btnModificar.Enabled == true)
                    {
                        float precioOriginal = productoSeleccionado.Precio;
                        string nuevaDescripcion;
                        string corteOriginal;
                        string nuevoCorte;
                        float nuevoPrecio;
                        int nuevoKgStock;
                        EstadoModificacion huboModificacion = EstadoModificacion.noModificado;

                        StringBuilder sb = new StringBuilder();

                        nuevaDescripcion = txtModDescripcion.Text;
                        if (productoSeleccionado is Carne && nuevaDescripcion != ((Carne)productoSeleccionado).Animal)
                        {
                            huboModificacion = EstadoModificacion.modificado;
                            sb.AppendLine($"- Animal: de '{((Carne)productoSeleccionado).Animal}' a '{nuevaDescripcion}'");
                            vendedorElegido.FijarAnimal((Carne)productoSeleccionado, txtModDescripcion.Text);
                            dataGridView1.Rows[indiceFilaSeleccionada].Cells["Descripcion"].Value = nuevaDescripcion;

                            CarnesBDD.ModificarCarne((Carne)productoSeleccionado);
                        }
                        else if (productoSeleccionado is Embutido && nuevaDescripcion != ((Embutido)productoSeleccionado).TipoEmbutido)
                        {
                            huboModificacion = EstadoModificacion.modificado;
                            sb.AppendLine($"- Nombre del embutido: de '{((Embutido)productoSeleccionado).TipoEmbutido}' a '{nuevaDescripcion}'"); vendedorElegido.FijarTipoEmbutido((Embutido)productoSeleccionado, txtModDescripcion.Text);
                            dataGridView1.Rows[indiceFilaSeleccionada].Cells["Descripcion"].Value = nuevaDescripcion;

                            EmbutidosBDD.ModificarEmbutido((Embutido)productoSeleccionado);
                        }

                        nuevoCorte = txtModifCorte.Text;
                        if (productoSeleccionado is Carne)
                        {
                            corteOriginal = ((Carne)productoSeleccionado).Corte;
                            if (nuevoCorte != corteOriginal)
                            {
                                huboModificacion = EstadoModificacion.modificado;
                                sb.AppendLine($"- Corte: de '{corteOriginal}' a '{nuevoCorte}'");
                                vendedorElegido.FijarCorteDeCarne((Carne)productoSeleccionado, nuevoCorte);
                                dataGridView1.Rows[indiceFilaSeleccionada].Cells["Corte"].Value = nuevoCorte;

                                CarnesBDD.ModificarCarne((Carne)productoSeleccionado);
                            }
                        }

                        nuevoKgStock = (int)nudModifStock.Value;
                        if (nuevoKgStock > 0)
                        {
                            huboModificacion = EstadoModificacion.modificado;
                            sb.AppendLine($"- Se repuso {nuevoKgStock}kg de stock");
                            vendedorElegido.ReponerProductos(productoSeleccionado, (int)nudModifStock.Value);
                            dataGridView1.Rows[indiceFilaSeleccionada].Cells["kg en stock"].Value = productoSeleccionado.KgEnStock;

                            ProductosBDD.ModificarProducto(productoSeleccionado);
                        }

                        nuevoPrecio = (float)nudModifPrecio.Value;
                        if (nuevoPrecio != precioOriginal && nuevoPrecio > 0)
                        {
                            huboModificacion = EstadoModificacion.modificado;
                            sb.AppendLine($"- Precio: de ${precioOriginal} a ${nuevoPrecio}");
                            vendedorElegido.FijarPrecioKg(productoSeleccionado, (float)nudModifPrecio.Value);
                            dataGridView1.Rows[indiceFilaSeleccionada].Cells["precio/Kg"].Value = nuevoPrecio;

                            ProductosBDD.ModificarProducto(productoSeleccionado);
                        }

                        if (huboModificacion == EstadoModificacion.modificado)
                        {
                            MessageBox.Show("Se modificaron:\n" + sb.ToString(), "Modificacion realizada", MessageBoxButtons.OK);
                            nudModifStock.Value = 0;
                        }
                        else { MessageBox.Show("No se efectuó una modificacion", "Sin modificacion", MessageBoxButtons.OK); }
                    }
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
            //int indiceComboboxCliente = comboBoxClientes.SelectedIndex;

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                //MessageBox.Show($"ID: {selectedRow.Index}");
                int idSeleccionado = Convert.ToInt32(selectedRow.Cells["ID"].Value);
                //MessageBox.Show($"ID: {idSeleccionado}");

                if (btnEliminar.Enabled == true)
                {
                    ProductosBDD.Eliminar(idSeleccionado);
                    dataGridView1.Rows.RemoveAt(indiceFilaSeleccionada); // Eliminar la fila seleccionada del DataGridView
                    dataGridView1.ClearSelection();

                    txtModDescripcion.Text = string.Empty;
                    txtModifCorte.Text = string.Empty;
                    nudModifPrecio.Value = 0;
                    txtModDescripcion.Enabled = false;
                    txtModifCorte.Enabled = false;
                    nudModifPrecio.Enabled = false;
                    nudModifStock.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnDetalles.Enabled = false;
                }
            }
        }

        private void CargarDataGrid()
        {

            DataTable dataTable = new DataTable();
            dataGridView1.DataSource = dataTable;

            dataTable.Columns.Add("Id", typeof(int));
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
                dr["Id"] = item.Id;
                if (item is Carne)
                {
                    Carne newItem = (Carne)item;
                    dr["Corte"] = newItem.Corte;
                    dr["Descripcion"] = newItem.Animal;
                }
                else if (item is Embutido)
                {
                    Embutido newItem = (Embutido)item;
                    dr["Descripcion"] = newItem.TipoEmbutido;
                }
                dr["kg en stock"] = item.KgEnStock;
                dr["precio/Kg"] = item.Precio;
                dataTable.Rows.Add(dr);

                if (diccionarioProductos.ContainsKey(item.Id))
                {
                    diccionarioProductos[item.Id] = item; // Actualizar el valor del producto existente en el diccionario
                }
                else
                {
                    diccionarioProductos.Add(item.Id, item); // Agregar el nuevo producto al diccionario
                }
                posicionFila++;
            }
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            List<Embutido> embutidos = new List<Embutido>();
            List<Carne> carnes = new List<Carne>();

            foreach (var prod in productosStockList)
            {
                if (prod is Embutido)
                {
                    embutidos.Add((Embutido)prod);
                }
            }

            foreach (var prod in productosStockList)
            {
                if (prod is Carne)
                {
                    carnes.Add((Carne)prod);
                }
            }

            try
            {
                Serializacion.SerializarAXml(embutidos, "Embutidos.xml");
                Serializacion.SerializarAXml(carnes, "Carnes.xml");
            }
            catch (Exception)
            {
                throw;
            }

        }

        private void btnCrearProd_Click(object sender, EventArgs e)
        {
            frmProductoNuevo frmProductoNuevo = new frmProductoNuevo(productosStockList);
            frmProductoNuevo.ShowDialog();

            productosStockList = ProductosBDD.Leer();
            CargarDataGrid();
        }

        private void btnDeserializarXml_Click(object sender, EventArgs e)
        {
            //string archivoXml = "Productos.xml";
            StringBuilder sb = new StringBuilder();

            List<Carne> carnes =  Serializacion.DeserializarDesdeXml<List<Carne>>("Carnes.xml");
            List<Embutido> embutidos =  Serializacion.DeserializarDesdeXml<List<Embutido>>("Embutidos.xml");
            
            foreach (Carne car in carnes)
            {
                sb.AppendLine($"ID: {car.Id} | DETALLE: {car.Animal} {car.Corte} | STOCK: {car.KgEnStock}kg | PRECIO: ${car.Precio}");
            }
            foreach(Embutido embutido in embutidos)
            {
                sb.AppendLine($"ID: {embutido.Id} | DETALLE: {embutido.TipoEmbutido} | STOCK: {embutido.KgEnStock}kg | PRECIO: ${embutido.Precio}");
            }

            MessageBox.Show($"{sb}");
        }
    }
}
