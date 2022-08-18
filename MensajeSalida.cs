using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamProgram
{
    internal class MensajeSalida
    {
        public bool Recibido;

        public bool ServoArriba;
        public bool ServoAbajo;
        public bool ServoIzq;
        public bool ServoDer;
        public short r, g, b, x, y;

        public void LimpiarValores()
        {
            Recibido = false;
            
        }
    }
}
