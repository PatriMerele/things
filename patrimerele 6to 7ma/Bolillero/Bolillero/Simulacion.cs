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
            var hilos = new List<Task<long>>();
            var bolilleros = new List<Bolilleroo>();
            long cantPorHilo = this.cantSimulaciones / (int)cantHilos;

            crearHilos(jugada, cantSimulaciones, cantHilos, hilos, bolilleros);

            hilos.ForEach(hilo => hilo.Start());

            Task<long>.WaitAll(hilos.ToArray());

            return hilos.Sum(task => task.Result);

        }

        private void crearHilos(List<byte> jugada, long cantSimulaciones, int cantHilos, List<Task<long>> hilos, List<Bolilleroo> bolilleros)
        {
            for (int i = 0; i < cantHilos; i++)
            {
                var bolilleroClon = (Bolilleroo)bolillero.Clone();
                bolilleros.Add(bolilleroClon);
                var tarea = new Task<long>(() => bolilleroClon.jugar(jugada, cantSimulaciones));
                hilos.Add(tarea);
            }
        }

        
    }
}
