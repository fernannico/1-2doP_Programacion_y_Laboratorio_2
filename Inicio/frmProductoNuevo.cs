using Entidades;
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

namespace Inicio
{
    public partial class frmProductoNuevo : Form
    {
        private Productos productoNuevo;
        private List<Productos> productosStockList;

        public frmProductoNuevo()
        {
            InitializeComponent();
        }
        public frmProductoNuevo(List<Productos> productosLista) : this()
        {
            this.productosStockList = productosLista;
        }

        private void frmProductoNuevo_Load(object sender, EventArgs e)
        {
            comboBoxTipoProd.Items.Add("Carne");
            comboBoxTipoProd.Items.Add("Embutido");

        }

        private void btnCrearOk_Click(object sender, EventArgs e)
        {
            if (ValidarProductoNuevo())
            {
                try
                {
                    ProductosBDD.CrearProducto(productoNuevo);
                }
                catch
                {
                    throw new InvalidOperationException("producto invalido");
                }

            }
            else { MessageBox.Show("No se completaron todos los datos para crear el producto, reintentar"); }
        }

        private bool ValidarProductoNuevo()
        {
            bool validacion = false;
            float precioPorKgNew = (float)NudPrecio.Value;
            int kgStockNew = (int)NudStock.Value;
            string descripcionNew = txtDescripcion.Text;
            string corteNew;

            if (ValidarDatosACargar(precioPorKgNew, kgStockNew, descripcionNew))
            {
                if (comboBoxTipoProd.SelectedIndex == 0)
                {
                    corteNew = txtCorte.Text;

                    if (string.IsNullOrEmpty(corteNew))
                    {
                        MessageBox.Show($"Intentó crear una carne y no especificó el corte", "Error", MessageBoxButtons.OK);
                    }
                    else
                    {
                        productoNuevo = new Carne(precioPorKgNew, kgStockNew, descripcionNew, corteNew);
                        productosStockList.Add(productoNuevo);
                        validacion = true;
                    }
                }
                else if (comboBoxTipoProd.SelectedIndex == 1)
                {
                    productoNuevo = new Embutido(precioPorKgNew, kgStockNew, descripcionNew);
                    productosStockList.Add(productoNuevo);
                    validacion = true;
                }
            }
            return validacion;
        }

        private bool ValidarDatosACargar(float precio, int stock, string descripcion)
        {
            bool banderaError = false;
            StringBuilder sb = new StringBuilder();
            if (precio == 0)
            {
                banderaError = true;
                sb.AppendLine("Precio");
            }
            if (stock == 0)
            {
                banderaError = true;
                sb.AppendLine("Stock");
            }
            if (string.IsNullOrEmpty(descripcion))
            {
                banderaError = true;
                sb.AppendLine("Descripcion");
            }
            if (banderaError == true)
            {
                MessageBox.Show($"Datos invalidos: \n{sb}", "Error", MessageBoxButtons.OK);
                return false;
            }

            return true;
        }
        private void comboBoxTipoProd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxTipoProd.SelectedIndex == 0)
            {
                txtCorte.Enabled = true;
            }
            else { txtCorte.Enabled = false; }
        }

    }
}
