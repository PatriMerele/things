using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Semaforo
{
    public class Barra
    {
        public int capacidad { get; set; }
        public int cantPersonas { get; set; }
        public Queue<Cliente> clientes { get; set; }
        public List<Bebida> conjuntoBebidas { get; set; }

        public Barra() {}

        public void clienteEnBarra(Cliente cliente)
        {
            do
            {
                if (!stockBebidaPara(cliente))
                {
                    Console.WriteLine("No posee la bebida deseada");
                    break;
                }
                if (!cliente.alcanzaParaBebida())
                {
                    Console.WriteLine("No posee la plata necesaria");
                    break;
                }
                Console.WriteLine($"{cliente.nombre} se compro {cliente.getBebida().nombre}");
                Thread.Sleep(cliente.tiempoBebidaMS);
            } while (cliente.quedanBebidasParaTomar);
        }
        public bool stockBebidaPara(Cliente cliente) => cliente.getBebida().stock > 0;
    }
}
