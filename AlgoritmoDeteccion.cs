using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamProgram
{
    internal class AlgoritmoDeteccion
    {
        public CascadeClassifier cascadeClassifier;
        public Color rectangleColor = new Color();

        public AlgoritmoDeteccion(string path, Color rectangleColor)
        {
            this.cascadeClassifier = new CascadeClassifier(path);
            this.rectangleColor = rectangleColor;
        }
    }
}
