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
        public long cantAciertos { get; private set; }
        public Simulacion()
        {

        }

        public void simularSinHilos(List<byte> jugada, long cantSimulaciones)
        {
            cantAciertos = bolillero.jugar(jugada, cantSimulaciones);
        }
        public void simularConHilos(List<byte> jugada, long cantSimulaciones, int cantHilos)
        {
            var hilos = new List<Task<long>>();
            var bolilleros = new List<Bolilleroo>();
            long cantPorHilo = cantSimulaciones / (int)cantHilos;

            crearHilos(jugada, cantSimulaciones, cantHilos, hilos, bolilleros, cantPorHilo);

            hilos.ForEach(hilo => hilo.Start());

            Task<long>.WaitAll(hilos.ToArray());

            cantAciertos = hilos.Sum(task => task.Result);
        }

        private void crearHilos(List<byte> jugada, long cantSimulaciones, int cantHilos, List<Task<long>> hilos, List<Bolilleroo> bolilleros, long unaCantPorHilo)
        {
            for (int i = 0; i < cantHilos; i++)
            {
                var bolilleroClon = (Bolilleroo)bolillero.Clone();
                bolilleros.Add(bolilleroClon);
                var tarea = new Task<long>(() => bolilleroClon.jugar(jugada, unaCantPorHilo));
                hilos.Add(tarea);
            }
        }

        
    }
}
