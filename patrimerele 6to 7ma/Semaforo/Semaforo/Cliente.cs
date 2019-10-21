using System;
using System.Collections.Generic;
using System.Text;

namespace Semaforo
{
    public class Cliente
    {
        public Queue<Bebida> bebidas { get; set; }
        public int cantidad { get; set; }
        public int dinero { get; set; }
        public string nombre { get; set; }
        public int tiempoBebidaMS { get; set; }

        public Cliente() {}

        public void agregarBebida(Bebida bebida)
        {
            bebidas.Enqueue(bebida);
        }
        private bool alcanzaParaBebida()
        {
            if (getBebida().precio <= dinero)
            {
                return false;
            }
            return true;
        }
        public void tomarBebida()
        {
            pagar(getBebida());
            bebidas.Dequeue();
        }
        public void pagar(Bebida bebida) => dinero -= bebida.precio;
        public void quedanBebidasParaTomar()
        {

        }
        public Bebida getBebida() => bebidas.Peek();
    }
}
