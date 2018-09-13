using PCotizarArticulos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using PCotizarArticulos.DAL;
using System.Data.Entity;
using System.Linq.Expressions;

namespace PCotizarArticulos.BLL
{
    public class ArticulosBLL
    {
        /// <summary>
        /// Permite Guardar una entidad en la base datos
        /// </summary>
        /// <param name="articulos"></param>
        /// <returns></returns>
        public static bool Guardar(Articulos articulos)
        {
            bool paso = false;
            contexto contexto = new contexto();
            try
            {
                if (contexto.Articulos.Add(articulos) != null)
                {
                    contexto.SaveChanges();
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }


        /// <summary>
        /// permite Modificar una entidad en la base de datos
        /// </summary>
        /// <param name="articulos"></param>
        /// <returns></returns>
        public static bool Modificar(Articulos articulos)
        {
            bool paso = false;
            contexto contexto = new contexto();
            try
            {
                contexto.Entry(articulos).State = EntityState.Modified;
                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Eliminar una entidad de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool Eliminar(int id)
        {
            bool paso = false;
            contexto contexto = new contexto();
            try
            {
                Articulos articulos = contexto.Articulos.Find(id);

                contexto.Articulos.Remove(articulos);

                if (contexto.SaveChanges() > 0)
                {
                    paso = true;
                }
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        /// <summary>
        /// Permite Buscar una entidad en la base de datos 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Articulos Buscar(int id)
        {
            contexto contexto = new contexto();
            Articulos articulos = new Articulos();

            try
            {
                articulos = contexto.Articulos.Find(id);
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return articulos;
        }

        public static List<Articulos> GetList(Expression<Func<Articulos, bool>> expression)
        {
            List<Articulos> Libros = new List<Articulos>();
            contexto contexto = new contexto();
            try
            {
                Libros = contexto.Articulos.Where(expression).ToList();
                contexto.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
            return Libros;
        }
    }
}

