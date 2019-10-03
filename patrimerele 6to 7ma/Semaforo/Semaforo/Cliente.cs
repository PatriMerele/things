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

        public Cliente()
        {

        }
        public void agregarBebida(Bebida bebida)
        {
            bebidas.Enqueue(bebida);
        }
        private bool alcanzaParaBebida(Bebida bebida)
        {
            if (bebida.precio <= dinero)
            {
                return false;
            }
            return true;
        }
        public void tomarBebida(Bebida bebida)
        {
            alcanzaParaBebida(bebida);
            
            bebidas.Dequeue();
            DineroTotal(bebida);
        }
        public void DineroTotal(Bebida bebida)
        {
            dinero -= bebida.precio;
        }
        public void stockBebida(Bebida bebida)
        {
            bebida.stock
        }
        public void getBebida()
        {
            bebidas.Peek();
        }
    }
}
