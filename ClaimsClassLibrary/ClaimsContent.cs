using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimsClassLibrary

{
    
    public enum ClaimType { Car =1, Home, Theft}
    public class ClaimsContent
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double ClaimAmmount { get; set; }
        public DateTime DateOfIncident { get; set; }
        public DateTime DateOfClaim { get; set; }
        
        
        
        public bool IsValid
        {
            
            get
            {
                return (DateOfClaim - DateOfIncident).TotalDays <= 30;
               
            }
            
            
          
        }
        public ClaimsContent() { }

        public ClaimsContent(int claimID, ClaimType claimType, string description, double claimAmmount, DateTime dateOfIncident, DateTime dateOfClaim)
        {
            ClaimID = claimID;
            ClaimType = claimType;
            Description = description;
            ClaimAmmount = claimAmmount;
            DateOfIncident = dateOfIncident;
            DateOfClaim = dateOfClaim;
            
            
        }



    }
}
