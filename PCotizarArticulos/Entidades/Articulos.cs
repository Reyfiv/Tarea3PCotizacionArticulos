using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PCotizarArticulos.Entidades
{
    class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public string Descripcion { get; set; }
        public int Precio { get; set; }
        public int Existencia { get; set; }
        public int CantidadCotizada { get; set; }

        public Articulos()
        {
            ArticuloId = 0;
            FechaVencimiento = DateTime.Now;
            Descripcion = string.Empty;
            Precio = 0;
            Existencia = 0;
            CantidadCotizada = 0;
        }
    }
}
