using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Persona
{
    [Table ("Persona")]
    public class Personaa
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key, Column("dni")]
        public int Dni { get; set; }

        [Column("nombre"), StringLength(45)]
        public string Nombre { get; set; }

        [Column("apellido"), StringLength(45)]
        public string Apellido { get; set; }

        public Personaa(string nombre, string apellido)
        {
            Nombre = nombre;
            Apellido = apellido;
        }
    }
}
