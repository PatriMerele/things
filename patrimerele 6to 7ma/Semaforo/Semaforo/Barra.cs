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
        }

        public void clienteEnBarra(Cliente cliente)
        {
            semaforo.WaitOne();
            Console.WriteLine("{0} esta en barra");
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
