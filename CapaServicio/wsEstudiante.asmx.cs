using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

using CapaNegocio;
using CapaDato;
using CapaEntidad;

namespace CapaServicio
{
    /// <summary>
    /// Descripción breve de wsEstudiante
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class wsEstudiante : System.Web.Services.WebService
    {
        // cadena de conexion
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;


        [WebMethod]
        public DataSet Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena)) {
                // EN REALIDAD DEBERIA IR UNA REFERENCIA A CAPA NEGOCIO DONDE SE LISTAN LAS CLASES

                string consulta = "SELECT * FROM estudiante";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataSet tabla = new DataSet();
                adapter.Fill(tabla);
                return tabla;
            }
            // EstudianteBL estudianteBl = new EstudianteBL();
            // return estudianteBl.Listar()
        }
        [WebMethod]
        public bool Insertar(string codEstudiante, string nombres) {

            // REALIZAR REFERENCIA A CAPA NEGOCIO DONDE SE INSERTA AL CRUD
            using (SqlConnection conexion = new SqlConnection(cadena)) {
                string consulta = "INSERT INTO estudiante values (@CodEstudiante,@Nombres)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodEstudiante", codEstudiante);
                comando.Parameters.AddWithValue("@Nombres", nombres);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

        [WebMethod]
        public bool Actualizar(string codEstudiante, string nombres)
            {
                using (SqlConnection conexion = new SqlConnection(cadena))
                {
                    string consulta = "UPDATE estudiante SET nomb_est = @Nombres WHERE cod_est = @CodEstudiante";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.Parameters.AddWithValue("@CodEstudiante", codEstudiante);
                    comando.Parameters.AddWithValue("@Nombres", nombres);
                    conexion.Open();
                    byte i = Convert.ToByte(comando.ExecuteNonQuery());
                    conexion.Close();
                    if (i == 1) return true;
                    else return false;
                }
            }

        [WebMethod]
        public bool Eliminar(string codEstudiante)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "DELETE FROM estudiante WHERE cod_est = @CodEstudiante";

                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@CodEstudiante", codEstudiante);
                conexion.Open();
                byte i = Convert.ToByte(comando.ExecuteNonQuery());
                conexion.Close();
                if (i == 1) return true;
                else return false;
            }
        }

    }
}
