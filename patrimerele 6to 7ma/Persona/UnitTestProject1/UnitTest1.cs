using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persona;
using Persona.ADO;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        static Domicilio d1 { get; set; }
        static Personaa Pedro { get; set; }
        static AdoMySQLEntityCore Ado { get; set; }

        [ClassInitialize]
        public static void IniciarClase(TestContext context)
        {
            Ado = new AdoMySQLEntityCore();
            Ado.Database.EnsureDeleted();
            Ado.Database.EnsureCreated();
            InstanciarPropiedades();
            Ado.altaPersona(Pedro);
        }

        private static void InstanciarPropiedades()
        {
            d1 = new Domicilio()
            {
                Calle = "Avenida Piedrabuena",
                Altura = 120
            };

            Pedro = new Personaa()
            {
                Nombre = "Pedro",
                Apellido = "Picapiedra",
                Dni = 2321421,
                Domicilio = d1
            };
        }

        [TestMethod]
        public void Recuperar()
        {
            Ado = new AdoMySQLEntityCore();
            Personaa p = Ado.GetPersonas()[0];
            Assert.AreEqual(2321421, p.Dni);
            Assert.AreEqual("Pedro", p.Nombre);
            Assert.AreEqual("Picapiedra", p.Apellido);
            Assert.AreEqual(d1.Calle, p.Domicilio.Calle);
        }
    }
}
