using Entidades;
using Facturas;
using ProductosNs;
using usuarios;


namespace Inicio
{
    public partial class frmLogin : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Productos> productosStockList = new List<Productos>();
        private List<Factura> listaFacturasHistorial = new List<Factura>();
        private Usuario usuarioSeleccionado;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            usuarios = UsuariosBDD.Leer<Usuario>();
            foreach (Usuario usuario in usuarios)
            {
                listBox1.Items.Add(usuario);
            }

            productosStockList = ProductosBDD.Leer();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex != -1)
            {
                IngresarDesdePrecargado();
            }
            else
            {
                IngresarDesdeTipeo();
            }
        }

        private void IngresarDesdeTipeo() {
            string mail = txtMail.Text;
            string contrasena = txtContrasenia.Text;
            string tipoUsuario;

            if (!string.IsNullOrEmpty(mail) && !string.IsNullOrEmpty(contrasena))
            {
                tipoUsuario = UsuariosBDD.TraerTipoUsuario(mail, contrasena);

                if (tipoUsuario is not null)
                {
                    if (tipoUsuario == "Vendedor")
                    {
                        usuarioSeleccionado = (Vendedor)usuarios.Find(u => u.MailPropiedad == mail && u.PwdPropiedad == contrasena);
                        EntrarComoVendedor();
                    }
                    else if (tipoUsuario == "Cliente")
                    {
                        usuarioSeleccionado = usuarios.Find(u => u.MailPropiedad == mail && u.PwdPropiedad == contrasena);
                        EntrarComoCliente();
                    }
                }
                else
                {
                    MessageBox.Show("No existe el usuario", "Usuario invalido", MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("faltan completar los campos para loguearse", "Usuario invalido", MessageBoxButtons.OK);
            }
        }

        private void IngresarDesdePrecargado()
        {
            if (listBox1.SelectedItem is not null)
            {
                usuarioSeleccionado = (Usuario)listBox1.SelectedItem;

                if (listBox1.SelectedItem is Cliente)
                {
                    EntrarComoCliente();
                }

                if (listBox1.SelectedItem is Vendedor)
                {
                    EntrarComoVendedor();
                }

            }
        }

        private void EntrarComoVendedor()
        {
            Vendedor vendedorSeleccionado = (Vendedor)usuarioSeleccionado;
            frmHeladera frmHeladera = new frmHeladera(vendedorSeleccionado, productosStockList, usuarios, listaFacturasHistorial);
            frmHeladera.ShowDialog();
            productosStockList = ProductosBDD.Leer();
        }

        private void EntrarComoCliente()
        {
            decimal gastoMaximo;
            Cliente clienteSeleccionado = (Cliente)usuarioSeleccionado;

            frmMontoCliente frmMontoCliente = new frmMontoCliente();
            frmMontoCliente.ShowDialog();

            gastoMaximo = frmMontoCliente.nudMontoCiente.Value;
            if (gastoMaximo > 0)
            {
                clienteSeleccionado.GastoMaximoPropiedad = gastoMaximo;
                frmVenta frmVenta = new frmVenta(null, clienteSeleccionado, productosStockList, usuarios, listaFacturasHistorial);
                frmVenta.ShowDialog();
            }
        }

        /// <summary>
        /// evento de cuando selecciono un usuario del listbox para que se autocomplete sus datos en los textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                usuarioSeleccionado = (Usuario)listBox1.SelectedItem;
                txtMail.Text = usuarioSeleccionado.MailPropiedad;
                txtContrasenia.Text = usuarioSeleccionado.PwdPropiedad;

                txtContrasenia.Enabled = false;
                txtMail.Enabled = false;

            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            txtContrasenia.Enabled = true;
            txtMail.Enabled = true;

            txtMail.Text = null;
            txtContrasenia.Text = null;

            listBox1.SelectedIndex = -1;
        }
    }
}