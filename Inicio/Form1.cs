using ProductosNs;
using usuarios;
namespace Inicio
{
    public partial class frmLogin : Form
    {
        private List<Usuario> usuarios = new List<Usuario>();
        private List<Productos> productosStockList = new List<Productos>();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            usuarios.Add(new Vendedor("vendedor1@gmail.com", "123456"));
            usuarios.Add(new Vendedor("vendedor2@gmail.com", "2583"));
            usuarios.Add(new Vendedor("vendedor3@gmail.com", "1475asasa"));
            usuarios.Add(new Cliente("cliente1@gmail.com", "36955",100000));
            usuarios.Add(new Cliente("cliente2@gmail.com", "789456",50000));
            usuarios.Add(new Cliente("cliente3@gmail.com", "1597543",10000));

            foreach (Usuario usuario in usuarios)
            {
                listBox1.Items.Add(usuario);
            }

            productosStockList.Add(new Carne(1830f, 10, "res", "asado"));
            productosStockList.Add(new Carne(1900f, 10, "res", "bife"));
            productosStockList.Add(new Carne(2389f, 10, "res", "milanesa"));
            productosStockList.Add(new Carne(2299f, 10, "res", "vacio"));
            productosStockList.Add(new Carne(600f, 10, "pollo", "entero"));
            productosStockList.Add(new Carne(960f, 10, "pollo", "1/4 trasero"));
            productosStockList.Add(new Carne(1865f, 10, "pollo", "suprema"));
            productosStockList.Add(new Embutido(1900f, 10, "chori"));
            productosStockList.Add(new Embutido(1120f, 10, "morcilla"));
            productosStockList.Add(new Embutido(500f, 10, "salchicha"));
            productosStockList.Add(new Embutido(550f, 10, "salchicha parrillera"));
            productosStockList.Add(new Embutido(1600f, 10, "longaniza"));
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is not null)
            {
                Usuario usuarioSeleccionado = (Usuario)listBox1.SelectedItem;

                if (listBox1.SelectedItem is Cliente && nudMontoCiente.Enabled && nudMontoCiente.Value > 0)
                {
                    Cliente clienteSeleccionado = (Cliente)usuarioSeleccionado;
                    clienteSeleccionado.GastoMaximoPropiedad = nudMontoCiente.Value;
                    frmVenta frmVenta = new frmVenta(clienteSeleccionado, productosStockList, usuarios);
                    frmVenta.ShowDialog();
                }
                else if (listBox1.SelectedItem is Cliente && nudMontoCiente.Value == 0)
                {
                    MessageBox.Show("Si usted es cliente, debe ingresar el monto maximo a gastar antes de comprar", "Error", MessageBoxButtons.OK);
                }

                if (listBox1.SelectedItem is Vendedor)
                {
                    Vendedor vendedorSeleccionado = (Vendedor)usuarioSeleccionado;
                    frmHeladera frmHeladera = new frmHeladera(vendedorSeleccionado, productosStockList, usuarios);
                    frmHeladera.ShowDialog();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)listBox1.SelectedItem;
            txtMail.Text = usuarioSeleccionado.MailPropiedad;
            txtContrasenia.Text = usuarioSeleccionado.PwdPropiedad;

            if (listBox1.SelectedItem is not null)
            {
                if (listBox1.SelectedItem is Cliente)
                {
                    nudMontoCiente.Enabled = true;
                }
                else if (listBox1.SelectedItem is Vendedor)
                {
                    nudMontoCiente.Enabled = false;
                }
            }
        }
    }
}