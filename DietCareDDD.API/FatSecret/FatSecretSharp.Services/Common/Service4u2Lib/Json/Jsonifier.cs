using System.IO;
using System.Runtime.Serialization.Json;

namespace Service4u2.Json
{
    public static class JsonifierExtensions
    {
        public static string Jsonify<TObject>(this TObject obj)
        {
            return Jsonifier.Jsonify<TObject>(obj);
        }
    }

    public static class Jsonifier
    {
        private static DataContractJsonSerializer serializer;
        private static MemoryStream memStream;

        public static string Jsonify<TObject>(TObject obj)
        {
            serializer = new DataContractJsonSerializer(typeof(TObject));
            memStream = new MemoryStream();
            serializer.WriteObject(memStream, obj);
            var json = new StreamReader(memStream).ReadToEnd();

            return json;
        }
    }
}
