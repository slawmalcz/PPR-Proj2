using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2.DataModels
{
    [Serializable()]
    public class Albums
    {
        public int Identificator;
        public String Name;
        public DateTime DateOfCreation;
        public String Band;
        public String Description;

        public Albums (DataRow dataRow)
        {
            this.Identificator = Int32.Parse(dataRow["ID"].ToString());
            this.Name = dataRow["Name"].ToString();
            this.DateOfCreation = GetDateTime(dataRow["Date_of_creation"].ToString());
            this.Band = dataRow["Band"].ToString();
            this.Description = dataRow["Description"].ToString();
        }
        public Albums()
        {

        }

        public override String ToString()
        {
            return Identificator + " " + Name + " " + Band + "\n" + Description;
        }

        private DateTime GetDateTime(String dateString)
        {
            String[] dateTableString = dateString.Split('/');
            dateTableString[2] = dateTableString[2].Substring(0,4);

            DateTime dateTimeOutput = new DateTime(Int32.Parse(dateTableString[2]), Int32.Parse(dateTableString[1]), Int32.Parse(dateTableString[0]));
            return dateTimeOutput;
        }
    }
}
