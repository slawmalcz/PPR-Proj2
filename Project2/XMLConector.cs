using System;
using System.IO;
using System.Xml.Serialization;


class XMLConector
{
    public static T ReadXML<T>(String path) where T : class
    {
        T objects = default(T);
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        StreamReader reader = new StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + path + ".xml");
        objects = (T)serializer.Deserialize(reader);
        reader.Close();
        return objects;
    }
    public static void WriteXML<T>(T objects, String fileName) where T : class
    {
        XmlSerializer writer = new XmlSerializer(typeof(T));
        var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "//" + fileName + ".xml";
        FileStream file = File.Create(path);
        writer.Serialize(file, objects);
        file.Close();
    }
}
