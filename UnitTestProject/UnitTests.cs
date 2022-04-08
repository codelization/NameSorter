using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void SortNames_WhenCalled_ReturnTrue()
        {
            string[] names = new string[] { "Orson Milka Iddins", "Erna Dorey Battelle", "Flori Chaunce Franzel" };
            var expectedSortedNames = new string[] { "Erna Dorey Battelle", "Flori Chaunce Franzel", "Orson Milka Iddins" };
            var actualSortedNames = NameSorter.Program.sortNames(names);
            CollectionAssert.AreEqual(expectedSortedNames, actualSortedNames);
        }
    }
}
