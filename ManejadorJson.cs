using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CamProgram
{
    public static class ManejadorJson
    {
        internal static string ConvertirAJson(Object msg)
        {
            return JsonConvert.SerializeObject(msg);
        }

        internal static MensajeEntrada ConvertirAMensajeEntrada(string json)
        {
            return JsonConvert.DeserializeObject<MensajeEntrada>(json);
        }
    }
}
