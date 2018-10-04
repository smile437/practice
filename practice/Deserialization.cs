namespace practice
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Json;
    using System.Windows.Forms;

    public class Deserialization
    {
        public static List<Figure> Figures = new List<Figure>();

        public static List<Figure> Deserialization_bin()
        {
            try
            {
                using (Stream fileStreamBin = File.Open("Figures.bin", FileMode.Open))
                {
                    BinaryFormatter bin = new BinaryFormatter();
                    Figures = (List<Figure>)bin.Deserialize(fileStreamBin);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Figures;
        }

        public static List<Figure> Deserialization_XML()
        {
            try
            {
                using (Stream fileStreamXml = File.Open("Figures.xml", FileMode.Open))
                {
                    DataContractSerializer xmlSerializer = new DataContractSerializer(typeof(List<Figure>));
                    Figures = (List<Figure>)xmlSerializer.ReadObject(fileStreamXml);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Figures;
        }

        public static List<Figure> Deserialization_Json()
        {
            try
            {
                using (Stream fileStreamJson = File.Open("Figures.json", FileMode.Open))
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(List<Figure>));
                    Figures = (List<Figure>)jsonSerializer.ReadObject(fileStreamJson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return Figures;
        }
    }
}
