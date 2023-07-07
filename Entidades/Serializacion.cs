using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Text.Json;
using ProductosNs;
using System.Text.Encodings.Web;
using System.Security;
using System.IO;
using System.Xml;

namespace Entidades
{
    public static class Serializacion
    {
        //internal static string archivoXml = "Productos.xml";

        public static void SerializarAXml<T>(T objeto, string ruta)
        {
            try
            {
                using(StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(streamWriter, objeto);
                }

            }catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is XmlException || ex is UnauthorizedAccessException || ex is DirectoryNotFoundException ||
                    ex is PathTooLongException || ex is SecurityException || ex is IOException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al guardar el archivo", innerExceptions);
            }
        }

        public static void SerializarAJson<T>(T objeto, string ruta)
        {
            JsonSerializerOptions jsonSerializerOptions = new JsonSerializerOptions();
            jsonSerializerOptions.WriteIndented = true;
            try
            {
                string objetoJson = JsonSerializer.Serialize(objeto, jsonSerializerOptions);
                
                using (StreamWriter streamWriter = new StreamWriter(ruta))
                {
                    streamWriter.WriteLine(objetoJson);  
                }
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is JsonException || ex is UnauthorizedAccessException || ex is DirectoryNotFoundException ||
                    ex is PathTooLongException || ex is SecurityException || ex is IOException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al guardar el archivo", innerExceptions);
            }
        }

        public static T DeserializarDesdeXml<T>(string ruta) where T : class
        {
            try
            {
                using(StreamReader streamReader = new StreamReader(ruta))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                    T objeto = xmlSerializer.Deserialize(streamReader) as T;
                    return objeto;
                }
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is XmlException || ex is UnauthorizedAccessException || ex is DirectoryNotFoundException ||
                    ex is FileNotFoundException || ex is IOException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al abrir el archivo", innerExceptions);
            }
        }

        public static T DeserializarDesdeJson<T>(string ruta) where T : class
        {
            try
            {
                string objetoJson = File.ReadAllText(ruta);

                T objeto = JsonSerializer.Deserialize<T>(objetoJson);

                return objeto;
            }
            catch (Exception ex)
            {
                List<Exception> innerExceptions = new List<Exception>();
                if (ex is JsonException || ex is UnauthorizedAccessException || ex is DirectoryNotFoundException ||
                    ex is FileNotFoundException || ex is IOException)
                {
                    innerExceptions.Add(ex);
                }
                throw new ExcepcionesPropias("Error al abrir el archivo", innerExceptions);
            }
        }
    }
}
