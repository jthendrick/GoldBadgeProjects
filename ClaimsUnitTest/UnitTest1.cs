using ClaimsClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace ClaimsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddClaim()
        {
            ClaimsContent claim = new ClaimsContent();
            ClaimsRepo repo = new ClaimsRepo();

            bool addClaim = repo.AddClaimToDirectory(claim);
            Assert.IsTrue(addClaim);
        }
        [TestMethod]
        public void GetDirectory()
        {
            ClaimsContent claim = new ClaimsContent();
            ClaimsRepo repo = new ClaimsRepo();
            repo.AddClaimToDirectory(claim);
            List<ClaimsContent> claims = repo.GetContent();
            bool directoryHasContent = claims.Contains(claim);
            Assert.IsTrue(directoryHasContent);
        }
        private ClaimsRepo _claimsRepo;
        private ClaimsContent _claimsContent;

        [TestInitialize]
        public void Arrange()

        {
            DateTime incidentOne = new DateTime(18, 04 / 25);
            DateTime claimOne = new DateTime(18, 04, 27);
            _claimsRepo = new ClaimsRepo();
            _claimsContent = new ClaimsContent(1, ClaimType.Car, "Car accident on 465", 400d, incidentOne, claimOne);

            _claimsRepo.AddClaimToDirectory(_claimsContent);
            
        }
    }
}
