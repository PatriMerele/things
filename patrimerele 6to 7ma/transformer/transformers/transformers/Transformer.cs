using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transformers
{
    public class Transformer
    {
        public int peso { get; set; }
        public int poderDestructivo { get; set; }
        public bool transformado { get; set; }
        public int velocidad { get; set; }

        public Transformer()
        {
            
        }

        public void destransformar()
        {
            if (transformado)
            {
                transformado = false;
            }
            else
            {
                throw new Exception("No se puede destransformar.");
            }
        }
        public bool esTransformado()
        {
            if (transformado)
            {
                return true;
            }
            else
            {
                throw new Exception("No esta transformado.");
            }
        }
        public int getPeso()
        {
            return peso;
        }
        public int getPoderDestructivo()
        {
            return poderDestructivo;
        }
        public int getVelocidad()
        {
            return velocidad;
        }
        public void transformar()
        {
            if (transformado == false)
            {
                transformado = true;
            }
            else
            {
                throw new Exception("No se puede transformar.");
            }
        }
    }
}
