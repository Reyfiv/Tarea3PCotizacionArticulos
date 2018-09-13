using PCotizarArticulos.UI.Consultas;
using PCotizarArticulos.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PCotizarArticulos
{
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RCotizacionArticulos rArticulos = new RCotizacionArticulos();
            rArticulos.Show();
        }

        private void articulosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cCotizacionArticulos rArticulos = new cCotizacionArticulos();
            rArticulos.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
