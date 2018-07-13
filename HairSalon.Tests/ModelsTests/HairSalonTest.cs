using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class HairSalonTests : IDisposable
  {
    public void Dispose()
    {
      Stylist.DeleteAll();
    }
    public HairSalonTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eliot_charette_test;";
        }
    [TestMethod]
    public void RestaurantNameIsTrue()
    {

      string name = "Ashley";
      Stylist test = new Stylist(name, "");
      string result = test.GetStylist();

      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void Save_SavesToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Brittany", "");

      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void Delete_DeleteStylist()
    {
      // Arrange
      List<Stylist> testList = new List<Stylist> {};
      Stylist testStylist = new Stylist("testName", "testSpecialty");
      testStylist.Save();

      // Act
      Stylist.Find(testStylist.GetId()).Delete();
      List<Stylist> resultList = Stylist.GetAll();

      // Assert
      CollectionAssert.AreEqual(testList, resultList);
    }
  }
}
