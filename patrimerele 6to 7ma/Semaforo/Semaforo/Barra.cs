using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

        public Barra()
        {
            conjuntoBebidas = new List<Bebida>();
            clientes = new Queue<Cliente>();
        }

        public void clienteEnBarra(Cliente cliente)
        {
            semaforo.WaitOne();
            Console.WriteLine("{0} esta en barra", cliente.nombre);
            do
            {
                if (!stockBebidaPara(cliente))
                {
                    Console.WriteLine($"{cliente.nombre}No posee la bebida deseada");
                    break;
                }
                if (!cliente.alcanzaParaBebida())
                {
                    Console.WriteLine($"{cliente.nombre} no posee la plata necesaria");
                    break;
                }
                Console.WriteLine($"{cliente.nombre} se compro {cliente.getBebida().nombre}");
                cliente.getBebida().decrementarStock();
                cliente.tomarBebida();
                Console.WriteLine($"{cliente.nombre} descansa {cliente.tiempoBebidaMS} MS");
                Thread.Sleep(cliente.tiempoBebidaMS);
            } while (cliente.quedanBebidasParaTomar);
            Console.WriteLine($"{cliente.nombre} se fue del bar");
            semaforo.Release();
        }

        public void agregarCliente(Cliente cliente)
        {
            clientes.Enqueue(cliente);
        }

        public bool stockBebidaPara(Cliente cliente) => cliente.getBebida().stock > 0;
        public void clientesAHilo()
        {
            var tareas = new List<Task>();
            while (clientes.Count != 0)
            {
                var cliente = clientes.Dequeue();
                tareas.Add(new Task(() => clienteEnBarra(cliente)));
            }
            tareas.ForEach(t => t.Start());
            semaforo.Release(capacidad);
            Task.WaitAll(tareas.ToArray());
        }

    }
}
