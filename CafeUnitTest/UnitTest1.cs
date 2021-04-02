using CafeClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace CafeUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddToMenu()
        {
            CafeContent item = new CafeContent();
            CafeContentRepo repo = new CafeContentRepo();

            bool addResult = repo.AddItemToMenu(item);

            Assert.IsTrue(addResult);
        }

        [TestMethod]
        public void GetMenu()
        {
            CafeContent item = new CafeContent();
            CafeContentRepo repo = new CafeContentRepo();

            repo.AddItemToMenu(item);

            List<CafeContent> items = repo.GetContent();
            bool directoryHasContent = items.Contains(item);

            Assert.IsTrue(directoryHasContent);
        }

        private CafeContentRepo _repo;
        private CafeContent _item;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new CafeContentRepo();
            _item = new CafeContent("Double Angus Thicc Burger", "Made with Angus Black Beef, your food will melt in your mouth!", "Bread, Beef, Cheese, Thiccness", 10.99d, 1);

            _repo.AddItemToMenu(_item);
        }

        [TestMethod]
        public void GetMealByName()
        {
            CafeContent searchItem = _repo.GetContentByName("Double Angus Thicc Burger");

            Assert.AreEqual(_item, searchItem);
        }

        [TestMethod]
        public void DeleteExistingItem()
        {
            CafeContent item = _repo.GetContentByName("Double Angus Thicc Burger");

            bool removeResult = _repo.DeleteMealFromMenu(item);

            Assert.IsTrue(removeResult);
        }

    }
}
