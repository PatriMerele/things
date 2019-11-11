using System;
using System.Collections.Generic;
using System.Text;

namespace Semaforo
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente beto = new Cliente()
            {
                nombre = "Beto",
                dinero = 500,
                tiempoBebidaMS = 1500
            };

            Cliente guido = new Cliente()
            {
                nombre = "Guido",
                dinero = 800,
                tiempoBebidaMS = 5000
            };

            Cliente adolfo = new Cliente()
            {
                nombre = "Adolfo",
                dinero = 200,
                tiempoBebidaMS = 3500
            };

            Cliente ivan = new Cliente()
            {
                nombre = "Ivan",
                dinero = 500,
                tiempoBebidaMS = 2000
            };

            Cliente jessica = new Cliente()
            {
                nombre = "Jessica",
                dinero = 300,
                tiempoBebidaMS = 4500
            };


        }
    }
}
