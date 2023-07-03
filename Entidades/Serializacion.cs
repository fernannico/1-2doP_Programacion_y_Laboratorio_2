using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;

namespace Entidades
{
    public static class Serializacion
    {
        static string archivoAXml = "Productos.xml";

        public static void SerializarAXml<T>(T objeto)
        {
            using(StreamWriter streamWriter = new StreamWriter(archivoAXml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(streamWriter, objeto);
            }
        }

        public static void SerializarAJson<T>(T objeto, string ruta)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented = true;
            try
            {
                string objetoJson = JsonSerializer.Serialize(objeto, jsonSerializerOptions);
                
                using (StreamWriter streamWriter = new StreamWriter(ruta, true))
                {
                    streamWriter.WriteLine(objetoJson);  
                }
            }
            catch(Exception )
            {
                throw;
            }
        }
    }
}
