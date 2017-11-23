using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace Project2.DataModels
{
    [Serializable()]
    [XmlRoot("TracksCollection")]
    public class Tracks : IDataModels
    {
        [XmlArray("Tracks")]
        [XmlArrayItem("Track", typeof(Track))]
        public Track[] Track { get; set; }

        public Tracks(DataTable dataTable)
        {
            List<Track> temp = new List<Track>();
            foreach (DataRow dr in dataTable.Rows)
            {
                temp.Add(new Track(dr));
            }
            Track = temp.ToArray();
        }

        public Tracks() { }

        public string ReturnDataTableDeffinition()
        {
            return "Tracks (ID,Name,length)";
        }

        public string DataToDB()
        {
            String output = "";
            foreach (Track temp in Track)
            {
                output = output + temp.DataToDB() + ",";
            }
            output = output.Remove(output.Length - 1) + ";";
            return output;
        }

        public static string ReturnDataTableView()
        {
            return "TracksView";
        }
    }

    [Serializable()]
    public class Track
    {
        [XmlElement("Identificator")]
        public int Identificator;
        [XmlElement("Name")]
        public String Name;
        [XmlElement("Length")]
        public int Length;
        [XmlElement("Album")]
        public String Album;

        public Track(DataRow dataRow)
        {
            this.Identificator = Int32.Parse(dataRow["ID"].ToString());
            this.Name = dataRow["Name"].ToString();
            this.Length = Int32.Parse(dataRow["Length"].ToString());
            this.Album = dataRow["Album"].ToString();
        }
        public Track() { }

        public override String ToString()
        {
            return Identificator + " " + Name + " " + Length;
        }

        internal string DataToDB()
        {
            String output = "(" + this.Identificator + "," + this.Name + "," + this.Length+ ")";
            return output;
        }
    }
}
