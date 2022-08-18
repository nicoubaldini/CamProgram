using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamProgram
{
    internal class ManejadorRectangulos
    {

        public Tuple<bool, bool, bool, bool> GetRango(int wSource, int hSource, Rectangle rectangle)
        {

            int wLimitLeft = wSource / 4;
            int hLimitTop = hSource / 4;
            int wLimitRight = wSource - wLimitLeft;
            int hLimitBottom = hSource - hLimitTop;

            bool izq = false;
            bool der = false;
            bool arriba = false;
            bool abajo = false;

            if (rectangle.Left < wLimitLeft)
            {
                //Console.WriteLine("p1.X Fuera de rango " + rectangle.Left + " - " + wLimitLeft);
                //Console.WriteLine("FUERA IZQ");
                izq = true;
            }

            if (rectangle.Top < hLimitTop)
            {
                //Console.WriteLine("p1.Y Fuera de rango " + rectangle.Top + " - " + hLimitTop);
                //Console.WriteLine("FUERA ARRIBA");
                arriba = true;
            }

            if (rectangle.Right > wLimitRight)
            {
                //Console.WriteLine("p2.X Fuera de rango " + rectangle.Right + " - " + wLimitRight);
                //Console.WriteLine("FUERA DER");
                der = true;
            }

            if (rectangle.Bottom > hLimitBottom)
            {
                //Console.WriteLine("p2.Y Fuera de rango " + rectangle.Bottom + " - "+ hLimitBottom);
                //Console.WriteLine("FUERA ABAJO");
                abajo = true;
            }
            return new Tuple<bool, bool, bool, bool>(izq, der, arriba, abajo);

        }

        public Rectangle ObtenerRectanguloCorrecto(Rectangle[] rectangulos)
        {
            int areaMasGrande = 0;
            Rectangle rCorrecto = new Rectangle();

            foreach (var rectangulo in rectangulos)
            {
                int area = rectangulo.Width * rectangulo.Height;
                if (area > areaMasGrande)
                {
                    areaMasGrande = area;
                    rCorrecto = rectangulo;
                }
            }

            return rCorrecto;
        }
    }
}
