using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolillero
{
    public class Bolilleroo: ICloneable
    {
        public List<byte> bolillasAdentro { get; set; }
        public List<byte> bolillasAfuera { get; set; }
        Random r;

        public Bolilleroo(int cantBolillas)
        {
            r = new Random(DateTime.Now.Millisecond);
            bolillasAdentro = new List<byte>();
            bolillasAfuera = new List<byte>();
            agregarBolillas(cantBolillas);
        }

        private void agregarBolillas(int nro)
        {
            for (byte i = 1; i <= nro; i++)
            {
                bolillasAdentro.Add(i);
            }
        }

        private int indiceAlAzar()
        {
            return r.Next(0, bolillasAdentro.Count);            
        }
        public byte sacarBolilla()
        {
            byte bolilla = bolillasAdentro[indiceAlAzar()];
            sacarBolilla(bolilla);
            return bolilla;
        }
        public void reingresarBolillas()
        {
            bolillasAdentro.AddRange(bolillasAfuera);
            bolillasAfuera.Clear();
        }
        private void sacarBolilla(byte bolilla)
        {
            bolillasAdentro.Remove(bolilla);
            bolillasAfuera.Add(bolilla);
        }
        public bool jugar(List<byte> jugada)
        {
            for (byte i = 0; i < jugada.Count; i++)
            {
                if (jugada[i] != this.sacarBolilla())
                    return false;
            }
            return true;
        }
        public long jugar(List<byte> jugada, long cantSimulaciones)
        {
            long cont = 0;

            for(long i = 0; i < cantSimulaciones; i++)
            {
                reingresarBolillas();
                if(jugar(jugada))
                {
                    cont++;
                }                
            }
            return cont; 
        }

        public object Clone()
        {
            Bolilleroo clon = new Bolilleroo(10);
            clon.bolillasAdentro = new List<byte>(this.bolillasAdentro);
            clon.bolillasAfuera = new List<byte>(this.bolillasAfuera);
            return clon;
        }
    }
}
