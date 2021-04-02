using BadgesLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace BadgesTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddBadgeShouldBeTrue()
        {
            BadgeContent badge = new BadgeContent();
            BadgeRepo badgeRepo = new BadgeRepo();

            bool addResult = badgeRepo.AddBadgeToDataBase(badge);

            Assert.IsTrue(addResult);
        }
        private BadgeRepo _repo;
        private BadgeContent _badge;

        [TestInitialize]
        public void Arrange()
        {
            _repo= new BadgeRepo();
             _badge= new BadgeContent(10, "A5, A10, A99, c2, c10");

            _repo.AddBadgeToDataBase(_badge);

            
        }

        [TestMethod]
        public void UpdateBadgeShouldBeTrue()
        {
            BadgeContent newBadge = new BadgeContent(10, "a1, a2, a3");

            bool updateResult = _repo.EditBadge(10, newBadge);

            Assert.IsTrue(updateResult);
        }
    }

}
