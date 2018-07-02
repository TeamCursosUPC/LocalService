using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WCFServices.Dominio;

namespace WCFServices.Persistencia
{
    public class LocalDAO
    {
        private string CadenaConexion = "Server=tcp:licoreria.database.windows.net,1433;Initial Catalog=licoreria;Persist Security Info=False;User ID=acornejo;Password=Distribuidos%17;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public List<Local> Listar()
        {
            List<Local> localesEncontrados = new List<Local>();
            Local localEncontrado = null;
            string sql = "SELECT * from local";
            using (SqlConnection conexion = new SqlConnection(CadenaConexion))
            {
                conexion.Open();
                using (SqlCommand comando = new SqlCommand(sql, conexion))
                {
                    using (SqlDataReader resultado = comando.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            localEncontrado = new Local()
                            {
                                nombre = (string)resultado["nombre"],
                                nombre_contacto = (string)resultado["nombre_contacto"],
                                telefono_contacto = (string)resultado["telefono_contacto"],
                                distrito = (string)resultado["distrito"],
                                direccion = (string)resultado["direccion"]
                            };
                            localesEncontrados.Add(localEncontrado);
                        }
                    }
                }
            }
            return localesEncontrados;
        }
    }
}