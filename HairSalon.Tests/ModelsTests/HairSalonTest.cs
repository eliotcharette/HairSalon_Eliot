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
      Client.DeleteAll();
      Specialty.DeleteAll();
    }
    public HairSalonTests()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=eliot_charette_test;";
        }
    [TestMethod]
    public void StylistNameIsTrue()
    {

      string name = "Ashley";
      Stylist test = new Stylist(name);
      string result = test.GetStylist();

      Assert.AreEqual(name, result);
    }
    [TestMethod]
    public void Edit_UpdatesStylistNameInDatabase_String()
    {
      //Arrange
      string firstStylist = "sara";
      Stylist testStylist = new Stylist(firstStylist);
      testStylist.Save();
      string secondStylist = "lola";

      //Act
      testStylist.Edit(secondStylist);

      string result = Stylist.Find(testStylist.GetId()).GetStylist();

      //Assert
      Assert.AreEqual(secondStylist, result);
    }
    [TestMethod]
    public void Save_SavesToDatabase_StylistList()
    {
      //Arrange
      Stylist testStylist = new Stylist("Brittany");

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
      Stylist testStylist = new Stylist("testName");
      testStylist.Save();

      // Act
      Stylist.Find(testStylist.GetId()).Delete();
      List<Stylist> resultList = Stylist.GetAll();

      // Assert
      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Stylist_GetAll_Specialties()
    {
      List<Stylist> testList = new List<Stylist> {};
      List<Stylist> resultList = Stylist.GetAll();

      CollectionAssert.AreEqual(testList, resultList);
    }
    //Client tests
    //
    //
    [TestMethod]
    public void ClientNameIsTrue()
    {

      string name = "Ashley";
      Client test = new Client(name, 1);
      string result = test.GetClient();

      Assert.AreEqual(name, result);
    }
    //Specialty Tests
    //
    //
    [TestMethod]
    public void SpecialtyTypeIsTrue()
    {

      string specialty = "curls";
      Specialty test = new Specialty(specialty);
      string result = test.GetSpecialty();

      Assert.AreEqual(specialty, result);
    }
    [TestMethod]
    public void Specialty_GetAll_Specialties()
    {
      List<Specialty> testList = new List<Specialty> {};
      List<Specialty> resultList = Specialty.GetAll();

      CollectionAssert.AreEqual(testList, resultList);
    }
    [TestMethod]
    public void Save_SavesToDatabase_SpecialtyList()
    {
      //Arrange
      Specialty testSpecialty = new Specialty("ombre");

      //Act
      testSpecialty.Save();
      List<Specialty> result = Specialty.GetAll();
      List<Specialty> testList = new List<Specialty>{testSpecialty};

      //Assert
      CollectionAssert.AreEqual(testList, result);
    }
    [TestMethod]
    public void Delete_DeleteSpecialty()
    {
      // Arrange
      List<Specialty> testList = new List<Specialty> {};
      Specialty testSpecialty = new Specialty("mohawk");
      testSpecialty.Save();

      // Act
      Specialty.Find(testSpecialty.GetId()).Delete();
      List<Specialty> resultList = Specialty.GetAll();

      // Assert
      CollectionAssert.AreEqual(testList, resultList);
    }
  }
}
