using CapaDato;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class AsignaturaBL
    {
        private readonly AsignaturaDAL asignaturaDAL;

        public AsignaturaBL()
        {
            asignaturaDAL = new AsignaturaDAL();
        }

        public void AgregarAsignatura(Asignatura asignatura)
        {
            asignaturaDAL.AgregarAsignatura(asignatura);
        }

        public List<Asignatura> ObtenerAsignaturas()
        {
            return asignaturaDAL.ObtenerAsignaturas();
        }

        public void ActualizarAsignatura(Asignatura asignatura)
        {
            asignaturaDAL.ActualizarAsignatura(asignatura);
        }

        public void EliminarAsignatura(int courseID)
        {
            asignaturaDAL.EliminarAsignatura(courseID);
        }
    }
}
