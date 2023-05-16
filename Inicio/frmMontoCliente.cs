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
    public partial class frmMontoCliente : Form
    {
        public frmMontoCliente()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(nudMontoCiente.Value > 0)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Ingrese un valor mayor a 0", "Tiene dinero?", MessageBoxButtons.OK);
            }
        }
    }
}
