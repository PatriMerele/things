using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolillero
{
    public class Simulacion: Bolilleroo
    {
        public Bolilleroo bolillero { get; set; }

        public Simulacion()
        {

        }

        public long simularSinHilos(List<byte> jugada, long cantSimulaciones)
        {
            return jugar(jugada, cantSimulaciones);
        }
    }
}
