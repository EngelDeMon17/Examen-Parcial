using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen_Parcial
{
    internal class Taller
    {
        int codigoTaller;
        string nombreTaller;
        int costoTaller;

        public int CodigoTaller { get => codigoTaller; set => codigoTaller = value; }
        public string NombreTaller { get => nombreTaller; set => nombreTaller = value; }
        public int CostoTaller { get => costoTaller; set => costoTaller = value; }
    }
}
