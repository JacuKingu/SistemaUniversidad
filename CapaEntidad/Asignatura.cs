using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Asignatura
    {
        public int CourseID { get; set; }
        public string CodAsignatura { get; set; }
        public string NombAsignatura { get; set; }
        public int? Creditos { get; set; }

        // Relaciones
        public ICollection<Matricula> Matriculas { get; set; }
    }
}
