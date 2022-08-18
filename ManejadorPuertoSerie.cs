using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CamProgram
{
    internal class ManejadorPuertoSerie
    {

        private SerialPort Port;
        private Thread ThreadComunicacion;
        public MensajeSalida MensajeSalida;
        public MensajeEntrada MensajeEntrada;
        private int TiempoDelayBucle = 50;

        public ManejadorPuertoSerie(string portName, int baudRate)
        {
            Port = new SerialPort();
            Port.PortName = portName;
            Port.BaudRate = baudRate;
            Port.DtrEnable = true;
            ThreadComunicacion = new Thread(ComenzarBucle);
            MensajeSalida = new MensajeSalida();
            MensajeEntrada = new MensajeEntrada();

            MensajeSalida.x = 0;
            MensajeSalida.y = 0;
        }

        public bool AbrirPuerto()
        {
            if (!Port.IsOpen)
            {
                try
                {
                    Port.Open();
                    Console.WriteLine("Se abrió el puerto: " + Port.PortName);
                    return true;
                }
                catch
                {
                    Console.WriteLine("No se pudo abrir el puerto: " + Port.PortName);
                }
            }
            return false;
        }

        public bool CerrarPuerto()
        {
            if (Port.IsOpen)
            {
                try
                {
                    Port.Close();
                    return true;
                }
                catch { }
            }
            return false;
        }

        public void EscribirPuerto()
        {
            string msg = ManejadorJson.ConvertirAJson(MensajeSalida);
            if(MensajeSalida.x >= 240)
            {
                MensajeSalida.x = 0;
                MensajeSalida.y++;
            }
            else
            {
                MensajeSalida.x++;
            }

            if(MensajeSalida.y >= 240)
            {
                MensajeSalida.y = 0;
            }

            try
            {
                //msg = "0xF800";
                Port.WriteLine(msg);
                //MensajeEntrada.LimpiarValores();

            }
            catch { }

            Console.WriteLine("Output: " + msg);

        }

        public void LeerPuerto()
        {
            string msg = null;
            try
            {
                string input = Port.ReadLine();
                input = input.Trim();
                msg = input;
                MensajeEntrada = ManejadorJson.ConvertirAMensajeEntrada(input);

                //MensajeSalida.LimpiarValores();
                MensajeSalida.Recibido = true;
            }
            catch { }

            Console.WriteLine("Input: " + msg);
            
        }

        public void ComenzarComunicacion()
        {
            ThreadComunicacion.Start();
        }

        private void ComenzarBucle()
        {
            while (Port.IsOpen)
            {

                //if (MensajeEntrada.Recibido)
                //{
                    EscribirPuerto();
                    //Thread.Sleep(TiempoDelayBucle);
                //}
                //else
                //{
                    //Console.WriteLine("Esperando respuesta del puerto serie...");
                //}


                LeerPuerto();
                //Thread.Sleep(TiempoDelayBucle);
            }
        }
    }
}
