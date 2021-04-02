using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesLibrary
{
    public class BadgeContent
    {
        public int BadgeID { get; set; }
        public string ListOfDoors { get; set; }

        public BadgeContent() { }
        public BadgeContent(int badgeID, string listOfDoors)
        {
            BadgeID = badgeID;
            ListOfDoors = listOfDoors;
        }
    }
}
