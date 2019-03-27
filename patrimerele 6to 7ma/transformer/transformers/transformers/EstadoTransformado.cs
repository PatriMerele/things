using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace transformers
{
    abstract class EstadoTransformado: EstadoBase
    {
        public void destranformar()
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

    }
}
