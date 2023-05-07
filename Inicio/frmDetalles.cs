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
    public partial class frmDetalles : Form
    {
        public frmDetalles(string detalles)
        {
            InitializeComponent();
            lblDetalles.Text = detalles;
        }
    }
}
