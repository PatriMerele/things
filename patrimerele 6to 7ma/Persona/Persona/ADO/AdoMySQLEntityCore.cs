using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Persona.ADO
{
    public class AdoMySQLEntityCore: DbContext, IADO
    {
        public DbSet<Personaa> Personas { get; set; }

        public void altaPersona(Personaa persona)
        {
            Personas.Add(persona);
            SaveChanges();
        }

        public List<Personaa> GetPersonas() => Personas.ToList();
    }
}
