using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Semaforo
{
    public class Barra
    {
        const int capacidad = 2;
        const int cantHilos = 5;
        private static Semaphore semaforo = new Semaphore(0, capacidad);
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
                cliente.getBebida().decrementarStock();
                cliente.tomarBebida();
                Thread.Sleep(cliente.tiempoBebidaMS);
            } while (cliente.quedanBebidasParaTomar);
            Console.WriteLine("Se fue del bar");
            semaforo.Release();
        }

        public bool stockBebidaPara(Cliente cliente) => cliente.getBebida().stock > 0;
    }
}
