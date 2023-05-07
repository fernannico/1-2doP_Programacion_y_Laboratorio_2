using usuarios;
namespace Inicio
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            List<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Vendedor("vendedor1@gmail.com", "123456"));
            usuarios.Add(new Vendedor("vendedor2@gmail.com", "2583"));
            usuarios.Add(new Vendedor("vendedor3@gmail.com", "1475asasa"));
            usuarios.Add(new Cliente("cliente1@gmail.com", "36955"));
            usuarios.Add(new Cliente("cliente2@gmail.com", "789456"));
            usuarios.Add(new Cliente("cliente3@gmail.com", "1597543"));

            foreach (Usuario usuario in usuarios)
            {
                listBox1.Items.Add(usuario);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem is not null)
            {
                Usuario usuarioSeleccionado = (Usuario)listBox1.SelectedItem;

                if (listBox1.SelectedItem is Cliente && nudMontoCiente.Enabled && nudMontoCiente.Value > 0)
                {
                    frmVenta frmVenta = new frmVenta();
                    frmVenta.ShowDialog();
                }
                else if (listBox1.SelectedItem is Cliente && nudMontoCiente.Value == 0)
                {
                    MessageBox.Show("Si usted es cliente, debe ingresar el monto maximo a gastar antes de comprar", "Error", MessageBoxButtons.OK);
                }

                if (listBox1.SelectedItem is Vendedor)
                {
                    Vendedor vendedorSeleccionado = (Vendedor)usuarioSeleccionado;
                    frmHeladera frmHeladera = new frmHeladera(vendedorSeleccionado);
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