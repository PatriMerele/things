using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bolillero;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Bolilleroo bolillero = new Bolilleroo(10);
            Simulacion simulacion = new Simulacion();
            
            var jugada = new List<byte>(){10, 7, 9};

            simulacion.bolillero = bolillero;
            simulacion.simularSinHilos(jugada, 1000000);
            simulacion.simularConHilos(jugada, 1000000, 4);

        }
    }
}
