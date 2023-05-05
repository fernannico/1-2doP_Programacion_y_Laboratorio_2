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

            listBox1.Items.Add(new Vendedor("vendedor1@gmail.com", "12345"));
            listBox1.Items.Add(new Vendedor("vendedor2@gmail.com", "12345"));
            listBox1.Items.Add(new Vendedor("vendedor3@gmail.com", "12345"));
            listBox1.Items.Add(new Cliente("cliente1@gmail.com", "12345"));
            listBox1.Items.Add(new Cliente("cliente2@gmail.com", "12345"));
            listBox1.Items.Add(new Cliente("cliente3@gmail.com", "12345"));


        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            //if(listBox1.SelectedItems.Count > 0 && listBox1.SelectedItems ) { }
            if (listBox1.SelectedItem != null)
            {
                Usuario selectedItem = (Usuario)listBox1.SelectedItem;
                Type selectedType = selectedItem.GetType();

                if (selectedType == typeof(Cliente))
                {
                    //MessageBox.Show($"{selectedType} seleccionado");
                    frmVenta frmVenta = new frmVenta();
                    frmVenta.ShowDialog();
                }

                if (selectedType == typeof(Vendedor))
                {
                    //MessageBox.Show("Vendedor seleccionado");
                    frmHeladera frmHeladera = new frmHeladera();
                    frmHeladera.ShowDialog();
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void label1_Click(object sender, EventArgs e)
        //{

        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{

        //}
    }
}