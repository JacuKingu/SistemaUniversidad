using CapaDato;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class EstudianteBL
    {
        private readonly EstudianteDAL estudianteDAL;

        public EstudianteBL()
        {
            estudianteDAL = new EstudianteDAL();
        }

        public void AgregarEstudiante(Estudiante estudiante)
        {
            estudianteDAL.AgregarEstudiante(estudiante);
        }

        public List<Estudiante> ObtenerEstudiantes()
        {
            return estudianteDAL.ObtenerEstudiantes();
        }

        public void ActualizarEstudiante(Estudiante estudiante)
        {
            estudianteDAL.ActualizarEstudiante(estudiante);
        }

        public void EliminarEstudiante(int studentID)
        {
            estudianteDAL.EliminarEstudiante(studentID);
        }
    }
}
