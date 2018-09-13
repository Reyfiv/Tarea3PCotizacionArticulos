using PCotizarArticulos.Entidades;
using System.Data.Entity;

namespace PCotizarArticulos.DAL
{
    public class contexto : DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }

        public contexto() : base("ConStr")
        { }
    }
}
