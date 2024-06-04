using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntidad;
using System.Data;

namespace CapaNegocio.Interface
{
    internal class IAsignatura
    {
        DataTable Listar();
        bool Agregar(Asignatura asignatura);
        bool Eliminar(string CourseId);
        bool Actualizar(Asignatura asignatura);
        DataTable Buscar(string CourseID);
    }
}
