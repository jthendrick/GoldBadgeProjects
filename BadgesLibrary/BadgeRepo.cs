using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesLibrary
{
    public class BadgeRepo
    {
        
        private readonly Dictionary<int, BadgeContent> _badgeDatabase = new Dictionary<int, BadgeContent>();
        int _count = 0;

        public bool AddBadgeToDataBase(BadgeContent badge)
        {
            //_count++;
            //badge.BadgeID = _count;
            _badgeDatabase.Add(badge.BadgeID, badge);
            return true;
        }
        public Dictionary<int, BadgeContent> GetBadge()
        {
            return _badgeDatabase;
        }
        public BadgeContent GetBadgeByKey(int key)
        {
            foreach (var badge in _badgeDatabase)
            {
                if (badge.Key==key)
                {
                    return badge.Value;
                }
            }
            return null;
        }

        public bool EditBadge(int oldBadge, BadgeContent newBadgeData)
        {
            BadgeContent oldBadges = GetBadgeByKey(oldBadge);
            if (oldBadges == null)
            {
                return false;
            }
            else
            {
                
                oldBadges.ListOfDoors = newBadgeData.ListOfDoors;
                return true;
            }
        }
    }
}
