using PCotizarArticulos.BLL;
using PCotizarArticulos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PCotizarArticulos.UI.Registros
{
    public partial class RCotizacionArticulos : Form
    {
        public RCotizacionArticulos()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            IdNumericUpDown.Value = 0;
            FechaDateTimePicker.Value = DateTime.Now;
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
            ExistenciaTextBox.Clear();
            CantidadCotizadaTextBox.Clear();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private Articulos LlenaClase()
        {
            Articulos articulos = new Articulos();
            articulos.ArticuloId = Convert.ToInt32(IdNumericUpDown.Value);
            articulos.Descripcion = DescripcionTextBox.Text;
            articulos.FechaVencimiento = FechaDateTimePicker.Value;
            articulos.Precio = Convert.ToInt32(PrecioTextBox.Text);
            articulos.Existencia = Convert.ToInt32(ExistenciaTextBox.Text);
            articulos.CantidadCotizada = Convert.ToInt32(CantidadCotizadaTextBox.Text);
            return articulos;
        }

        public bool Validar()
        {
            bool validar = false;
            if (String.IsNullOrEmpty(DescripcionTextBox.Text))
            {
                errorProvider1.SetError(DescripcionTextBox, "Descipcion esta vacia");
                validar = true;
            }
            if (String.IsNullOrEmpty(PrecioTextBox.Text))
            {
                errorProvider1.SetError(PrecioTextBox, "Precio vacio");
                validar = true;
            }
            if (String.IsNullOrEmpty(ExistenciaTextBox.Text))
            {
                errorProvider1.SetError(ExistenciaTextBox, "Existencia vacia");
                validar = true;
            }
            if (String.IsNullOrEmpty(CantidadCotizadaTextBox.Text))
            {
                errorProvider1.SetError(CantidadCotizadaTextBox, "Cantidad cotizada vacia");
                validar = true;
            }
            return validar;
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Articulos articulos = ArticulosBLL.Buscar((int)IdNumericUpDown.Value);
            return (articulos != null);
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            Articulos articulos;
            bool paso = false;
            if (Validar())
            {
                MessageBox.Show("Favor revisar todos los campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            articulos = LlenaClase();

            if (IdNumericUpDown.Value == 0)
                paso = ArticulosBLL.Guardar(articulos);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("El Articulo no existe", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = ArticulosBLL.Guardar(articulos);
            }
            Limpiar();

            if (paso)
                MessageBox.Show("Guardado", "Con Exito!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("No se pudo Guardar", "Error!!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdNumericUpDown.Value);
            if (BLL.ArticulosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado", "Exito!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo eliminar", "Fallido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(IdNumericUpDown.Value);
            Articulos articulosProducto = BLL.ArticulosBLL.Buscar(id);
            if (articulosProducto != null)
            {
                DescripcionTextBox.Text = articulosProducto.Descripcion;
                PrecioTextBox.Text = articulosProducto.Precio.ToString();
                FechaDateTimePicker.Value = articulosProducto.FechaVencimiento;
                ExistenciaTextBox.Text = articulosProducto.Existencia.ToString();
                CantidadCotizadaTextBox.Text = articulosProducto.CantidadCotizada.ToString();
            }
        }
    }
}
