using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Persona.ADO
{
    public class AdoMySQLEntityCore : DbContext, IADO
    {
        public DbSet<Personaa> Personas { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }

        public void altaPersona(Personaa persona)
        {
            Personas.Add(persona);
            SaveChanges();
        }


        public List<Personaa> GetPersonas() =>  Personas.
                                                Include(p => p.Domicilio).
                                                ToList();
                                                

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Usar los datos usuario y pass del SGBD de la terminal donde se va a usar
            optionsBuilder.UseMySQL("server=localhost;database=Personas;user=root;password=root");
        }
    }
}
