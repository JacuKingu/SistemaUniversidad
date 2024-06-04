using CapaDato;
using CapaEntidad;
using System.Collections.Generic;

namespace CapaNegocio
{
    public class MatriculaBL
    {
        private readonly MatriculaDAL matriculaDAL;

        public MatriculaBL()
        {
            matriculaDAL = new MatriculaDAL();
        }

        public void AgregarMatricula(Matricula matricula)
        {
            matriculaDAL.AgregarMatricula(matricula);
        }

        public List<Matricula> ObtenerMatriculas()
        {
            return matriculaDAL.ObtenerMatriculas();
        }

        public void ActualizarMatricula(Matricula matricula)
        {
            matriculaDAL.ActualizarMatricula(matricula);
        }

        public void EliminarMatricula(int enrollmentID)
        {
            matriculaDAL.EliminarMatricula(enrollmentID);
        }
    }
}
