using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persona;
using Persona.ADO;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static Personaa persona { get; set; }
        static AdoMySQLEntityCore Ado { get; set; }

        [ClassInitialize]
        public static void IniciarClase(TestContext context)
        {
            Ado = new AdoMySQLEntityCore();
        }

        private static void InstanciarPropiedades()
        {
            Persona = new Persona
        }

        [TestMethod]
        public void TestMethod1()
        {
            
        }
    }
}
