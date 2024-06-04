using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;
using CapaEntidad; // Importa la capa de entidad

namespace CapaDato
{
    public class AsignaturaDAL
    {
        private readonly DatosSQL datos;

        public AsignaturaDAL()
        {
            datos = new DatosSQL();
        }

        public void AgregarAsignatura(Asignatura asignatura)
        {
            datos.Ejecutar("sp_AgregarAsignatura", asignatura.cod_asignatura, asignatura.nomb_asignatura, asignatura.creditos);
        }

        public List<Asignatura> ObtenerAsignaturas()
        {
            DataTable dt = datos.TraerDataTable("sp_ObtenerAsignaturas");
            List<Asignatura> asignaturas = new List<Asignatura>();

            foreach (DataRow row in dt.Rows)
            {
                asignaturas.Add(new Asignatura
                {
                    CourseID = Convert.ToInt32(row["CourseID"]),
                    cod_asignatura = row["cod_asignatura"].ToString(),
                    nomb_asignatura = row["nomb_asignatura"].ToString(),
                    creditos = Convert.ToInt32(row["creditos"])
                });
            }

            return asignaturas;
        }

        public void ActualizarAsignatura(Asignatura asignatura)
        {
            datos.Ejecutar("sp_ActualizarAsignatura", asignatura.CourseID, asignatura.cod_asignatura, asignatura.nomb_asignatura, asignatura.creditos);
        }

        public void EliminarAsignatura(int courseID)
        {
            datos.Ejecutar("sp_EliminarAsignatura", courseID);
        }
    }
}
