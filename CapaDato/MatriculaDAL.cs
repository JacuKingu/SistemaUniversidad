using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;
using CapaEntidad; // Importa la capa de entidad

namespace CapaDato
{
    public class MatriculaDAL
    {
        private readonly DatosSQL datos;

        public MatriculaDAL()
        {
            datos = new DatosSQL();
        }

        public void AgregarMatricula(Matricula matricula)
        {
            datos.Ejecutar("sp_AgregarMatricula", matricula.periodo, matricula.promedio, matricula.CourseID, matricula.StudentID);
        }

        public List<Matricula> ObtenerMatriculas()
        {
            DataTable dt = datos.TraerDataTable("sp_ObtenerMatriculas");
            List<Matricula> matriculas = new List<Matricula>();

            foreach (DataRow row in dt.Rows)
            {
                matriculas.Add(new Matricula
                {
                    EnrollmentID = Convert.ToInt32(row["EnrollmentID"]),
                    periodo = row["periodo"].ToString(),
                    promedio = Convert.ToInt32(row["promedio"]),
                    CourseID = Convert.ToInt32(row["CourseID"]),
                    StudentID = Convert.ToInt32(row["StudentID"])
                });
            }

            return matriculas;
        }

        public void ActualizarMatricula(Matricula matricula)
        {
            datos.Ejecutar("sp_ActualizarMatricula", matricula.EnrollmentID, matricula.periodo, matricula.promedio, matricula.CourseID, matricula.StudentID);
        }

        public void EliminarMatricula(int enrollmentID)
        {
            datos.Ejecutar("sp_EliminarMatricula", enrollmentID);
        }
    }
}
