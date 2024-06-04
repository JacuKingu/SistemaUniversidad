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
    internal class IEstudiante
    {
        DataTable Listar();
        bool Agregar(Estudiante estudiante);
        bool Eliminar(string StudenID);
        bool Actualizar(Estudiante estudiante);
        DataTable Buscar(string StudenID);
    }
}
