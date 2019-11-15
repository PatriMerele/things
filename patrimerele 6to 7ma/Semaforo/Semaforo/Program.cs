using System;
using System.Collections.Generic;
using System.Text;

namespace Semaforo
{
    class Program
    {
        static void Main(string[] args)
        {
            Bebida fernet = new Bebida()
            {
                nombre = "Fernet",
                precio = 110,
                stock = 40
            };
            Bebida ronConCola = new Bebida()
            {
                nombre = "Ron con Cola",
                precio = 100,
                stock = 50
            };
            Bebida pinta = new Bebida()
            {
                nombre = "Pinta de cerveza artesanal",
                precio = 120,
                stock = 100
            };
            Bebida daikiri = new Bebida()
            {
                nombre = "Daikiri",
                precio = 120,
                stock = 50
            };

            Cliente beto = new Cliente()
            {
                nombre = "Beto",
                dinero = 500,
                tiempoBebidaMS = 1500
            };
            beto.agregarBebida(pinta);
            beto.agregarBebida(pinta);
            beto.agregarBebida(pinta);
            beto.agregarBebida(pinta);
            beto.agregarBebida(pinta);

            Cliente guido = new Cliente()
            {
                nombre = "Guido",
                dinero = 800,
                tiempoBebidaMS = 5000
            };
            guido.agregarBebida(daikiri);
            guido.agregarBebida(daikiri);

            Cliente adolfo = new Cliente()
            {
                nombre = "Adolfo",
                dinero = 200,
                tiempoBebidaMS = 3500
            };
            adolfo.agregarBebida(fernet);
            adolfo.agregarBebida(ronConCola);
            adolfo.agregarBebida(pinta);

            Cliente ivan = new Cliente()
            {
                nombre = "Ivan",
                dinero = 500,
                tiempoBebidaMS = 2000
            };
            ivan.agregarBebida(pinta);
            ivan.agregarBebida(pinta);
            ivan.agregarBebida(pinta);

            Cliente jessica = new Cliente()
            {
                nombre = "Jessica",
                dinero = 300,
                tiempoBebidaMS = 4500
            };
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);
            jessica.agregarBebida(pinta);

            Barra barra = new Barra();
            barra.conjuntoBebidas.Add(pinta);
            barra.conjuntoBebidas.Add(fernet);
            barra.conjuntoBebidas.Add(ronConCola);
            barra.conjuntoBebidas.Add(daikiri);

            barra.agregarCliente(beto);
            barra.agregarCliente(guido);
            barra.agregarCliente(adolfo);
            barra.agregarCliente(ivan);
            barra.agregarCliente(jessica);

            barra.clientesAHilo();

            Console.ReadKey();
        }
    }
}