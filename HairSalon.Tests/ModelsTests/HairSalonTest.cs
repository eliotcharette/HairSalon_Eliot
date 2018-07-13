using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System;
using System.Collections.Generic;

namespace HairSalon.Tests
{
  [TestClass]
  public class HairSalonTests
  {
    public HairSalonTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eliot_charette_test;";
        }
    // [TestMethod]
    // public void RestaurantNameIsTrue()
    // {
    //
    //   string name = "Hardrock";
    //   Restaurant test = new Restaurant(name, "oirahi", 1, 3);
    //   string result = test.GetRestaurant();
    //
    //   Assert.AreEqual(name, result);
    // }
    // [TestMethod]
    // public void Edit_Test_Stylists()
    // {
    //   //Arrange
    //   string firstName = "Applebees";
    //   Restaurant testRestaurant = new Restaurant(firstName, "", 0, 0);
    //   testRestaurant.Save();
    //   string updatedName = "Ghettobees";
    //
    //   //Act
    //   testRestaurant.Edit(updatedName);
    //
    //
    //   string result = Restaurant.Find(testRestaurant.GetId()).GetRestaurant();
    //
    //   Assert.AreEqual(updatedName, result);
    // }
    [TestMethod]
    public void Save_SavesToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Ashley", "");

      //Act
      testStylist.Save();
      List<Stylist> result = Stylist.GetAll();
      List<Stylist> testList = new List<Stylist>{testStylist};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
  }
}
