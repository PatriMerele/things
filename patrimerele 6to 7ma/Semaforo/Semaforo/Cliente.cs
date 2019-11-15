using System;
using System.Collections.Generic;
using System.Text;

namespace Semaforo
{
    public class Cliente
    {
        public Queue<Bebida> bebidasDeseadas { get; set; }
        public int dinero { get; set; }
        public string nombre { get; set; }
        public int tiempoBebidaMS { get; set; }

        public Cliente()
        {
            bebidasDeseadas = new Queue<Bebida>();
        }

        public void agregarBebida(Bebida bebida)
        {
            bebidasDeseadas.Enqueue(bebida);
        }
        public bool alcanzaParaBebida()
        {
            if (getBebida().precio <= dinero)
            {
                return true;
            }
            return false;
        }
        public void tomarBebida()
        {
            pagar(getBebida());
            bebidasDeseadas.Dequeue();
        }
        public void pagar(Bebida bebida) => dinero -= bebida.precio;
        public bool quedanBebidasParaTomar => bebidasDeseadas.Count != 0;
        public Bebida getBebida() => bebidasDeseadas.Peek();
    }
}
