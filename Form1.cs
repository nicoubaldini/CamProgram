using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CamProgram
{
    public partial class Form1 : Form
    {
        FilterInfoCollection filter;
        VideoCaptureDevice device;

        List<AlgoritmoDeteccion> algoritmos;

        ManejadorPuertoSerie puertoSerie;

        ManejadorRectangulos mr;

        public Form1()
        {
            InitializeComponent();

            algoritmos = new List<AlgoritmoDeteccion>();
            algoritmos.Add(new AlgoritmoDeteccion("haarcascade\\haarcascade_frontalface_alt.xml", Color.Aqua));
            //algoritmos.Add(new AlgoritmoDeteccion("haarcascade\\haarcascade_hand.xml", Color.Red));
            //algoritmos.Add(new AlgoritmoDeteccion("haarcascade\\haarcascade_smile.xml", Color.Yellow));

            puertoSerie = new ManejadorPuertoSerie("COM4", 57600);

            puertoSerie.AbrirPuerto();
            puertoSerie.ComenzarComunicacion();

            puertoSerie.MensajeSalida.r = 255;
            puertoSerie.MensajeSalida.g = 255;
            puertoSerie.MensajeSalida.b = 255;

            mr = new ManejadorRectangulos();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            filter = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo device in filter)
                cbDevice.Items.Add(device.Name);
            cbDevice.SelectedIndex = 0;
            device = new VideoCaptureDevice();
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            device = new VideoCaptureDevice(filter[cbDevice.SelectedIndex].MonikerString);
            device.NewFrame += Device_NewFrame;
            device.Start();
        }

        private void Device_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Image<Bgr, byte> grayImage = new Image<Bgr, byte>(bitmap);

            foreach (var algoritmo in algoritmos)
            {
                Rectangle[] rectangles = algoritmo.cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1, new Size(50, 50), new Size(1000, 1000));

                //Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaa  " + rectangles.Length);

                var rCorrecto = mr.ObtenerRectanguloCorrecto(rectangles);

                //foreach (Rectangle rectangle in rectangles)
                //{
                int width = bitmap.Size.Width;
                int height = bitmap.Size.Height;

                //item1 = izq
                //item2 = der
                //item3 = arriba
                //item4 = derecha
                if (rectangles.Length > 0)
                { 
                    Tuple<bool, bool, bool, bool> rangos = mr.GetRango(width, height, rCorrecto);
                    if (rangos.Item1 && !rangos.Item2)
                    {
                        //Gira a la izquierda
                        puertoSerie.MensajeSalida.ServoIzq = true;
                    }
                    else if (!rangos.Item1 && rangos.Item2)
                    {
                        //Gira a la derecha
                        puertoSerie.MensajeSalida.ServoDer = true;
                    }
                    else
                    {
                        puertoSerie.MensajeSalida.ServoDer = false;
                        puertoSerie.MensajeSalida.ServoIzq = false;
                    }

                    if (rangos.Item3 && !rangos.Item4)
                    {
                        //Gira hacia arriba
                        puertoSerie.MensajeSalida.ServoArriba = true;
                    }
                    else if (!rangos.Item3 && rangos.Item4)
                    {
                        //Gira hacia abajo
                        puertoSerie.MensajeSalida.ServoAbajo = true;
                    }
                    else
                    {
                        puertoSerie.MensajeSalida.ServoArriba = false;
                        puertoSerie.MensajeSalida.ServoAbajo = false;
                    }
                }
                else
                {
                    puertoSerie.MensajeSalida.ServoDer = false;
                    puertoSerie.MensajeSalida.ServoIzq = false;
                    puertoSerie.MensajeSalida.ServoArriba = false;
                    puertoSerie.MensajeSalida.ServoAbajo = false;
                }

                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    using (Pen pen = new Pen(algoritmo.rectangleColor, 2))
                    {
                        graphics.DrawRectangle(pen, rCorrecto);
                    }
                }
                //}
            }

            pbMedia.Image = bitmap;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (device.IsRunning)
                device.Stop();

            puertoSerie.CerrarPuerto();
        }
    }
}
