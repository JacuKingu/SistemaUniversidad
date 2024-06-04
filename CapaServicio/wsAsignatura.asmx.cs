using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace CapaServicio
{
    /// <summary>
    /// Descripción breve de wsAsignatura
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsAsignatura : System.Web.Services.WebService
    {

        // cadena de conexion
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        [WebMethod]
        public DataSet Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena)) {
                // EN REALIDAD DEBERIA IR UNA REFERENCIA A CAPA NEGOCIO DONDE SE LISTAN LAS CLASES

                string consulta = "SELECT * FROM asignatura";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataSet tabla = new DataSet();
                adapter.Fill(tabla);
                return tabla;
            }

        }
        [WebMethod]
        public bool Insertar(string codAsignatura, string nombre, int creditos) {

            // REALIZAR REFERENCIA A CAPA NEGOCIO DONDE SE INSERTA AL CRUD
            using (SqlConnection conexion = new SqlConnection(cadena)) {
                string consulta = "INSERT INTO asignatura values (@CodAsignatura,@Nombre,@Creditos)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", codAsignatura);
                comando.Parameters.AddWithValue("@Nombre", nombre);
                comando.Parameters.AddWithValue("@Creditos", creditos);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        [WebMethod]
        public bool Actualizar(string codAsignatura, string nombre, int creditos)
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    string consulta = "UPDATE asignatura SET nomb_asignatura = @Nombre,creditos = @Creditos WHERE cod_asignatura = @Creditos";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@CodAsignatura", codAsignatura);
                    comando.Parameters.AddWithValue("@Nombre", nombre);
                    comando.Parameters.AddWithValue("@Creditos", creditos);
                    conexion.Open();
                    byte i = Convert.ToByte(comando.ExecuteNonQuery());
                    conexion.Close();
                    if (i == 1) return true;
                    else return false;
                }
            }

        [WebMethod]
        public bool Eliminar(string codAsignatura)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "DELETE FROM asignatura WHERE cod_asignatura = @CodAsignatura";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodAsignatura", codAsignatura);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }
    }
}
