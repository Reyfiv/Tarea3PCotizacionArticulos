using Microsoft.VisualStudio.TestTools.UnitTesting;
using PCotizarArticulos.BLL;
using PCotizarArticulos.DAL;
using PCotizarArticulos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCotizarArticulos.BLL.Tests
{
    [TestClass()]
    public class ArticulosBLLTests
    {

        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 1;
            articulo.FechaVencimiento = DateTime.Now;
            articulo.Descripcion = "Arroz";
            articulo.Precio = 100;
            articulo.Existencia = 20;
            articulo.CantidadCotizada = 10;
            paso = ArticulosBLL.Guardar(articulo);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            Articulos articulo = new Articulos();
            articulo.ArticuloId = 1;
            articulo.FechaVencimiento = DateTime.Now;
            articulo.Descripcion = "Arroz";
            articulo.Precio = 100;
            articulo.Existencia = 20;
            articulo.CantidadCotizada = 10;
            paso = ArticulosBLL.Modificar(articulo);
            Assert.AreEqual(paso, true);
        }

  
    }
}