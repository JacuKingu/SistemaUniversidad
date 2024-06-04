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
    internal class MatriculaBL: Interface.IMatricula
    {
        private Datos datos = new DatosSQL();
        public string Mensaje { get; set; }

        public DataTable Listar()
        {
            return datos.TraerDataTable("spListarMatricula");
        }
        public bool Agregar(Matricula matricula)
        {
            DataRow fila = datos.TraerDataRow("spAgregarMatricula", matricula.periodo, matricula.promedio, matricula.CouseID, matricula.StudentID);
            //Traer el mensaje de Stored Procedures, para traer al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else { return false; }
        }

        public bool Eliminar(string EnrollmentID)
        {
            DataRow fila = datos.TraerDataRow("spEliminarMatricula", EnrollmentID);
            //Traer el mensaje de Stored Procedures, para traer al formulario
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else { return false; }
        }

        public bool Actualizar(Matricula matricula)
        {
            DataRow fila = datos.TraerDataRow("spActualizarMatricula", matricula.periodo, matricula.promedio, matricula.CouseID, matricula.StudentID);
            Mensaje = fila["Mensaje"].ToString();
            byte codError = Convert.ToByte(fila["CodError"]);
            if (codError == 0) { return true; }
            else return false;
        }

        public DataTable Buscar(string EnrollmentID)
        { return datos.TraerDataTable("spBuscarMatricula", EnrollmentID); }
    }
}
