using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using CapaDato;
using CapaEntidad;
using CapaNegocio.Interface;

namespace CapaNegocio
{
    internal class EstudianteBL: Interface.IEstudiante
    {
        private Datos datos = new DatosSQL();
        public string Mensaje {  get; set; }

        public DataTable Listar()
        {
            return datos.TraerDataTable("spListarEstudiante");
        }
        public bool Agregar(Estudiante estudiante)
        {
            DataRow fila = datos.TraerDataRow("spAgregarEstudiante", estudiante.cod_est, estudiante.nomb_est);
            //Traer el mensaje de Stored Procedures, para traer al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else { return false; }
        }

        public bool Eliminar(string StudentID)
        {
            DataRow fila = datos.TraerDataRow("spEliminarEstudiante", StudentID);
            //Traer el mensaje de Stored Procedures, para traer al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else { return false; }
        }

        public bool Actualizar(Estudiante estudiante)
        {
            DataRow fila = datos.TraerDataRow("spActualizarEstudiante", estudiante.cod_est, estudiante.nomb_est);
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else return false;
        }

        public DataTable Buscar(string StudentID)
        { return datos.TraerDataTable("spBuscarEstudiante", StudentID); }
    }
}
