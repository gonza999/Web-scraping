using Conexion;
using Datos;
using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    public class ServicioTitles
    {
        private ConexionBD cn;
        RepositorioTitles repositorioTitles;
        public void Guardar(Title title)
        {
            try
            {
                cn = new ConexionBD();
                repositorioTitles = new RepositorioTitles(cn.AbrirConexion());
                repositorioTitles.Guardar(title);
                cn.CerrarConexion();

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
