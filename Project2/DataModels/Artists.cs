using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Serialization;

namespace Project2.DataModels
{
    [Serializable()]
    [XmlRoot("ArtistsCollection")]
    public class Artists : IDataModels
    {
        [XmlArray("Artists")]
        [XmlArrayItem("Artist", typeof(Artist))]
        public Artist[] Artist { get; set; }

        public Artists(DataTable dataTable)
        {
            List<Artist> temp = new List<Artist>();
            foreach (DataRow dr in dataTable.Rows)
            {
                temp.Add(new Artist(dr));
            }
            Artist = temp.ToArray();
        }

        public Artists() { }

        public string ReturnDataTableDeffinition()
        {
            return "Artists (ID,Name,Surname,Nick,Date_of_birth,Date_of_death,Description)";
        }

        public string DataToDB()
        {
            String output = "";
            foreach (Artist temp in Artist)
            {
                output = output + temp.DataToDB() + ",";
            }
            output = output.Remove(output.Length - 1) + ";";
            return output;
        }

        public static string ReturnDataTableView()
        {
            return "ArtistView";
        }
    }

    [Serializable()]
    public class Artist
    {
        [XmlElement("Identificator")]
        public int Identificator;
        [XmlElement("Name")]
        public String Name;
        [XmlElement("Surname")]
        public String Surname;
        [XmlElement("Nick")]
        public String Nick;
        [XmlElement("DateOfBirth")]
        public DateTime DateOfBirth;
        [XmlElement("DateOfDeath")]
        public DateTime DateOfDeath;
        [XmlElement("Description")]
        public String Description;

        public Artist(DataRow dataRow)
        {
            this.Identificator = Int32.Parse(dataRow["ID"].ToString());
            this.Name = dataRow["Name"].ToString();
            this.Surname = dataRow["Surname"].ToString();
            this.Nick = dataRow["Nick"].ToString();
            this.DateOfBirth = GetDateTime(dataRow["Date_of_birth"].ToString());
            this.DateOfDeath = GetDateTime(dataRow["Date_of_death"].ToString());
            this.Description = dataRow["Description"].ToString();
        }
        public Artist() { }

        public override String ToString()
        {
            return Identificator + " " + Name + " " + Surname + "\n" + Description;
        }

        public String DataToDB()
        {
            String output = "(" + this.Identificator + "," + this.Name + "," + this.Surname + "," + this.Nick + "," + this.DateOfBirth.ToShortDateString() +
                "," + this.DateOfDeath.ToShortDateString() + "," + this.Description + ")";
            return output;
        }

        private DateTime GetDateTime(String dateString)
        {
            try
            {
                String[] dateTableString = dateString.Split('/');
                dateTableString[2] = dateTableString[2].Substring(0, 4);

                DateTime dateTimeOutput = new DateTime(Int32.Parse(dateTableString[2]), Int32.Parse(dateTableString[1]), Int32.Parse(dateTableString[0]));
                return dateTimeOutput;
            }
            catch(Exception e)
            {
                return default(DateTime);
            }
        }
    }
}
