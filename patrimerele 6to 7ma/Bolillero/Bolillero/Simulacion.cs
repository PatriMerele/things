using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolillero
{
    public class Simulacion
    {
        public Bolilleroo bolillero { get; set; }
        public long cantSimulaciones { get; set; }
        public Simulacion()
        {

        }

        public long simularSinHilos(List<byte> jugada, long cantSimulaciones)
        {
            return bolillero.jugar(jugada, cantSimulaciones);
        }
        public long simularConHilos(List<byte> jugada, long cantSimulaciones, int cantHilos)
        {
            List<Task<long>> hilos = new List<Task<long>>();
            List<Task<long>> bolilleroo = new List<Task<long>>();
            long cantPorHilo = this.cantSimulaciones / (int)cantHilos;
            for (int i = 0; i < cantHilos; i++)
            {
                Bolilleroo bolilleroClon = (Bolilleroo)bolillero.Clone();
                var tarea = new Task<long>(() => bolilleroClon.jugar(jugada, cantSimulaciones));
                hilos.Add(tarea);
            }

        }

    }
}
