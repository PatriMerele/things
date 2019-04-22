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
        public void boli()
        {
            Bolilleroo bolillero = new Bolilleroo(1);
            var jugada = new List<byte>() { 1 };
            Assert.IsTrue(bolillero.jugar(jugada));
            Assert.AreEqual(500, bolillero.jugar(jugada, 500));
        }

        [TestMethod]
        public void simularConHilos()
        {
            Bolilleroo bolillero = new Bolilleroo(1);
            Simulacion simulacion = new Simulacion();
            
            var jugada = new List<byte>(){1};

            simulacion.bolillero = bolillero;
            simulacion.simularConHilos(jugada, 10000000, 10);

            Assert.AreEqual((long)10000000, simulacion.cantAciertos);
        }

        [TestMethod]
        public void simularSinHilos()
        {
            Bolilleroo bolillero = new Bolilleroo(1);
            Simulacion simulacion = new Simulacion();

            var jugada = new List<byte>() { 1 };

            simulacion.bolillero = bolillero;
            simulacion.simularSinHilos(jugada, 10000000);

            Assert.AreEqual(10000000, (int)simulacion.cantAciertos);
        }
    }
}
