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
        //private List<Carne> carnesStockList = new List<Carne>();
        //private List<Embutido> embutidosStockList = new List<Embutido>();
        private List<Factura> listaFacturasHistorial = new List<Factura>();
        //private VendedorBDD vendedor;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            usuarios.Add(new Vendedor(1,"vendedor1@gmail.com", "123456"));
            usuarios.Add(new Vendedor(2,"vendedor2@gmail.com", "2583"));
            usuarios.Add(new Vendedor(3,"vendedor3@gmail.com", "1475asasa"));
            usuarios.Add(new Cliente(1,"cliente1@gmail.com", "36955", 100000));
            usuarios.Add(new Cliente(2,"cliente2@gmail.com", "789456", 50000));
            usuarios.Add(new Cliente(3,"cliente3@gmail.com", "1597543", 10000));
            usuarios.Add(new Cliente(4,"cliente5@gmail.com", "1597543", 10000));

            foreach (Usuario usuario in usuarios)
            {
                listBox1.Items.Add(usuario);
            }

            productosStockList = ProductosBDD.Leer();

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is not null)
            {
                Usuario usuarioSeleccionado = (Usuario)listBox1.SelectedItem;

                if (listBox1.SelectedItem is Cliente)
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

                if (listBox1.SelectedItem is Vendedor)
                {
                    Vendedor vendedorSeleccionado = (Vendedor)usuarioSeleccionado;
                    frmHeladera frmHeladera = new frmHeladera(vendedorSeleccionado, productosStockList, usuarios, listaFacturasHistorial);
                    frmHeladera.ShowDialog();
                }

            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)listBox1.SelectedItem;
            txtMail.Text = usuarioSeleccionado.MailPropiedad;
            txtContrasenia.Text = usuarioSeleccionado.PwdPropiedad;
        }
    }
}