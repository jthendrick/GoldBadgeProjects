using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClassLibrary
{
    public class ClaimsRepo
    {
       protected readonly List<ClaimsContent> _claimsDirectory = new List<ClaimsContent>();

        public bool AddClaimToDirectory(ClaimsContent claim)
        {
            int startingCount = _claimsDirectory.Count;
            _claimsDirectory.Add(claim);
            bool wasAdded = (_claimsDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<ClaimsContent> GetContent()
        {
            return _claimsDirectory;
        }

        public bool DeleteClaim(ClaimsContent existingClaim)
        {
            bool deleteResult = _claimsDirectory.Remove(existingClaim);
            return deleteResult;
        }
    }
}
