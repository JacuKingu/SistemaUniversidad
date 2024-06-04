using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;
using CapaEntidad; // Importa la capa de entidad

namespace CapaDato
{
    public class EstudianteDAL
    {
        private readonly DatosSQL datos;

        public EstudianteDAL()
        {
            datos = new DatosSQL();
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            datos.Ejecutar("sp_AgregarEstudiante", estudiante.cod_est, estudiante.nomb_est);
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            DataTable dt = datos.TraerDataTable("sp_ObtenerEstudiantes");
            List<Estudiante> estudiantes = new List<Estudiante>();

            foreach (DataRow row in dt.Rows)
            {
                estudiantes.Add(new Estudiante
                {
                    StudentID = Convert.ToInt32(row["StudentID"]),
                    cod_est = row["cod_est"].ToString(),
                    nomb_est = row["nomb_est"].ToString()
                });
            }

            return estudiantes;
        }

        public void ActualizarEstudiante(Estudiante estudiante)
        {
            datos.Ejecutar("sp_ActualizarEstudiante", estudiante.StudentID, estudiante.cod_est, estudiante.nomb_est);
        }

        public void EliminarEstudiante(int studentID)
        {
            datos.Ejecutar("sp_EliminarEstudiante", studentID);
        }
    }
}
