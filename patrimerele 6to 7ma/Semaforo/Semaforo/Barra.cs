using System;
using System.Collections.Generic;
using System.Text;

namespace Semaforo
{
    public class Barra
    {
        public int cantPersonas { get; set; }
        public Queue<Cliente> clientes { get; set; }
        public List<Bebida> conjuntoBebidas { get; set; }

        public Barra()
        {

        }
    }
}
