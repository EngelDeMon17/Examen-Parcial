using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Parcial
{
    internal class Inscripciones
    {
        int dpiEstudiante;
        string codigoTaller;
        DateTime fechaInscripcion;

        public int DpiEstudiante { get => dpiEstudiante; set => dpiEstudiante = value; }
        public string CodigoTaller { get => codigoTaller; set => codigoTaller = value; }
        public DateTime FechaInscripcion { get => fechaInscripcion; set => fechaInscripcion = value; }
    }
}
