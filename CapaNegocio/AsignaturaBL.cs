using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDato;
using CapaEntidad;
using CapaNegocio.Interface;

namespace CapaNegocio
{
    internal class AsignaturaBL: Interface.IAsignatura
    {
        private Datos datos = new DatosSQL();
        public string Mensaje { get; set; }

        public DataTable Listar()
        {
            return datos.TraerDataTable("spListarEstudiante");
        }
        public bool Agregar(Asignatura asignatura)
        {
            DataRow fila = datos.TraerDataRow("spAgregarAsignatura", asignatura.cod_asignatura, asignatura.nomb_asignatura, asignatura.creditos);
            //Traer el mensaje de Stored Procedures, para traer al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else { return false; }
        }

        public bool Eliminar(string CourseID)
        {
            DataRow fila = datos.TraerDataRow("spEliminarAsignatura", CourseID);
            //Traer el mensaje de Stored Procedures, para traer al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else { return false; }
        }

        public bool Actualizar(Asignatura asignatura)
        {
            DataRow fila = datos.TraerDataRow("spActualizarAsignatura", asignatura.cod_asignatura, asignatura.nomb_asignatura, asignatura.creditos);
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else return false;
        }

        public DataTable Buscar(string CourseID)
        { return datos.TraerDataTable("spBuscarAsignatura", CourseID); }
    }
}
