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
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column("dni")]
        [Key]
        public int Dni { get; set; }


    }
}
