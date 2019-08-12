using System.Collections.Generic;

namespace Persona
{
    public interface IADO
    {
        void altaPersona(Personaa persona);
        List<Personaa> GetPersonas();
    }
}