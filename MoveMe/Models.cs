using System;

namespace MoveMe.Models
{
    public class User
    {
        public string uID { get; set; }
        public string password { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public string email { get; set; }
        public string uCity { get; set; }
        public int uScore { get; set; }
    }

    public class City
    {
        public Guid cID { get; set; }
        public string cName { get; set; }
        public string cCoords { get; set; }
    }

    public class Spot
    {
        public Guid sID { get; set; }
        public string sName { get; set; }
        public string sCity { get; set; }
        public string sCoords { get; set; }
        public string data { get; set; }
        public int sScore { get; set; }
    }
}