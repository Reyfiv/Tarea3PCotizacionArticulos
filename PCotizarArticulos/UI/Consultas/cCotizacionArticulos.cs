using PCotizarArticulos.BLL;
using PCotizarArticulos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCotizarArticulos.UI.Consultas
{
    public partial class cCotizacionArticulos : Form
    {
        public cCotizacionArticulos()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> Filtro = a => true;

            var listado = new List<Articulos>();

            if (CriteriotextBox.Text.Trim().Length > 0)
            {
                switch (FiltrarComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = ArticulosBLL.GetList(p => true);
                        break;
                    case 1://ArticulosID
                        int id = Convert.ToInt32(CriteriotextBox.Text);
                        listado = ArticulosBLL.GetList(p => p.ArticuloId == id);
                        break;
                    case 2: //FechaVencimiento
                        listado = ArticulosBLL.GetList(p => p.FechaVencimiento.Equals(CriteriotextBox.Text));
                        break;
                    case 3: //Descripcion
                        listado = ArticulosBLL.GetList(p => p.Descripcion.Contains(CriteriotextBox.Text));
                        break;
                    case 4: //Precio
                        listado = ArticulosBLL.GetList(p => p.Precio.Equals(CriteriotextBox.Text));
                        break;
                    case 5: //Precio
                        listado = ArticulosBLL.GetList(p => p.Existencia.Equals(CriteriotextBox.Text));
                        break;
                    case 6: //CantidadCotizada
                        listado = ArticulosBLL.GetList(p => p.CantidadCotizada.Equals(CriteriotextBox.Text));
                        break;
                }

            }
            else
                listado = ArticulosBLL.GetList(p => true);

            ConsultadataGridView.DataSource = null;
            ConsultadataGridView.DataSource = listado;
        }
    }
    
}
