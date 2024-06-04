using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;
using System.Configuration;

namespace CapaServicio
{
    /// <summary>
    /// Descripción breve de wsMatricula
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class wsMatricula : System.Web.Services.WebService
    {
        // Cadena de conexión obtenida desde el archivo de configuración
        private static string cadena = ConfigurationManager.ConnectionStrings["cadena"].ConnectionString;

        [WebMethod]
        public DataSet Listar()
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "SELECT * FROM matricula";
                SqlDataAdapter adapter = new SqlDataAdapter(consulta, conexion);
                DataSet tabla = new DataSet();
                adapter.Fill(tabla);
                return tabla;
            }
        }

        [WebMethod]
        public bool Insertar(string periodo, int promedio, int courseID, int studentID)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "INSERT INTO matricula (periodo, promedio, CourseID, StudentID) " +
                                  "VALUES (@Periodo, @Promedio, @CourseID, @StudentID)";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Periodo", periodo);
                comando.Parameters.AddWithValue("@Promedio", promedio);
                comando.Parameters.AddWithValue("@CourseID", courseID);
                comando.Parameters.AddWithValue("@StudentID", studentID);
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                return filasAfectadas > 0;
            }
        }

        [WebMethod]
        public bool Actualizar(int enrollmentID, string periodo, int promedio, int courseID, int studentID)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "UPDATE matricula SET periodo = @Periodo, promedio = @Promedio, " +
                                  "CourseID = @CourseID, StudentID = @StudentID " +
                                  "WHERE EnrollmentID = @EnrollmentID";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@Periodo", periodo);
                comando.Parameters.AddWithValue("@Promedio", promedio);
                comando.Parameters.AddWithValue("@CourseID", courseID);
                comando.Parameters.AddWithValue("@StudentID", studentID);
                comando.Parameters.AddWithValue("@EnrollmentID", enrollmentID);
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                return filasAfectadas > 0;
            }
        }

        [WebMethod]
        public bool Eliminar(int enrollmentID)
        {
            using (SqlConnection conexion = new SqlConnection(cadena))
            {
                string consulta = "DELETE FROM matricula WHERE EnrollmentID = @EnrollmentID";
                SqlCommand comando = new SqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@EnrollmentID", enrollmentID);
                conexion.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                conexion.Close();
                return filasAfectadas > 0;
            }
        }
    }
}
