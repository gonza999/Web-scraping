using Conexion;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioTitles
    {
        private SqlConnection sqlConnection;

        public RepositorioTitles(SqlConnection sqlConnection)
        {
            this.sqlConnection = sqlConnection;
        }

        public void Guardar(Title title)
        {
            try
            {
                var cadenaDeComando = "Insert into Titles(Title) values (@title)";
                var comando = new SqlCommand(cadenaDeComando,sqlConnection);
                comando.Parameters.AddWithValue("@title",title.Nombre);
                comando.ExecuteNonQuery();
                cadenaDeComando = "Select @@Identity";
                comando = new SqlCommand(cadenaDeComando,sqlConnection);
                title.Id=(int)(decimal)comando.ExecuteScalar();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
