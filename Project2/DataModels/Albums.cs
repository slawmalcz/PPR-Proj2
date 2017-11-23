using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace Project2.DataModels
{
    [Serializable()]
    [XmlRoot("AlbumsCollection")]
    public class Albums : IDataModels
    {
        [XmlArray("Albums")]
        [XmlArrayItem("Album", typeof(Album))]
        public Album [] Album { get; set; }

        public Albums(DataTable dataTable)
        {
            List<Album> temp = new List<Album>();
            foreach (DataRow dr in dataTable.Rows)
            {
                temp.Add(new Album(dr));
            }
            Album = temp.ToArray();
        }

        public Albums() {}

        public string DataToDB()
        {
            String output = "";
            foreach (Album temp in Album)
            {
                output = output + temp.DataToDB() + ",";
            }
            output = output.Remove(output.Length - 1) + ";";
            return output;
        }

        public string ReturnDataTableDeffinition()
        {
            return "Albums (ID, Name, Date_of_creation, Band, Description)";
        }
        public static string ReturnDataTableView()
        {
            return "AlbumsView";
        }
    }

    [Serializable()]
    public class Album
    {
        [XmlElement("Identificator")]
        public int Identificator;
        [XmlElement("Name")]
        public String Name;
        [XmlElement("DateOfCreation")]
        public DateTime DateOfCreation;
        [XmlElement("Band")]
        public String Band;
        [XmlElement("BandID")]
        public int BandID;
        [XmlElement("Description")]
        public String Description;

        public Album(DataRow dataRow)
        {
            this.Identificator = Int32.Parse(dataRow["ID"].ToString());
            this.Name = dataRow["Name"].ToString();
            this.DateOfCreation = GetDateTime(dataRow["Date_of_creation"].ToString());
            this.BandID = Int32.Parse(dataRow["BandID"].ToString());
            this.Band = dataRow["Band"].ToString();
            this.Description = dataRow["Description"].ToString();
        }
        public Album() { }


        private DateTime GetDateTime(String dateString)
        {
            String[] dateTableString = dateString.Split('/');
            dateTableString[2] = dateTableString[2].Substring(0, 4);

            DateTime dateTimeOutput = new DateTime(Int32.Parse(dateTableString[2]), Int32.Parse(dateTableString[1]), Int32.Parse(dateTableString[0]));
            return dateTimeOutput;
        }

        internal string DataToDB()
        {
            String output = "(" + this.Identificator + "," + this.Name + "," + this.DateOfCreation.ToShortDateString() + "," + this.BandID + "," + this.Description + ")";
            return output;
        }

        public override String ToString()
        {
            return Identificator + " " + Name + " " + Band + "\n" + Description;
        }
    }
}
