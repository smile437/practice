namespace practice
{
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Json;

    public class Serialization
    {
        public static List<Figure> Figures = new List<Figure>();

        public static void Serialization_bin(List<Figure> figures)
        {
            using (FileStream fileStreamBin = new FileStream("Figures.bin", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fileStreamBin, figures);
            }
        }

       public static void Serialization_XML(List<Figure> figures)
        {
            using (FileStream fileStreamXml = new FileStream("Figures.xml", FileMode.Create))
            {
                DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(List<Figure>));
                xmlSerializer.WriteObject(fileStreamXml, figures);
            }
        }

        public static void Serialization_Json(List<Figure> figures)
        {
            using (FileStream fileStreamJson = new FileStream("Figures.json", FileMode.Create))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Figure>));
                jsonSerializer.WriteObject(fileStreamJson, figures);
            }
        }
    }
}
