using Project2.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    class XMLConector
    {
        public static void WriteXML(Albums albums)
        {
            System.Xml.Serialization.XmlSerializer writer =
                new System.Xml.Serialization.XmlSerializer(typeof(Albums));

            var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//SerializationOverview.xml";
            System.IO.FileStream file = System.IO.File.Create(path);

            writer.Serialize(file, albums);
            file.Close();
        }

        public static void ReadXML(String path)
        {  
            System.Xml.Serialization.XmlSerializer reader =
                new System.Xml.Serialization.XmlSerializer(typeof(Albums));
            System.IO.StreamReader file = new System.IO.StreamReader(path);
            Albums overview = (Albums)reader.Deserialize(file);
            file.Close();

            Console.WriteLine(overview.ToString());

        }
    }
}
