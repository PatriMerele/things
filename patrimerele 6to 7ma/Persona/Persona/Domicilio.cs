using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Persona
{
    [Table ("Domicilio")]
    public class Domicilio
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column("idDomicilio")]
        public byte IdDomicilio { get; set; }

        [Column("calle"), StringLength(45), Required]
        public string Calle { get; set; }

        [Column("altura"), Required]
        public short Altura { get; set; }
    }
}
