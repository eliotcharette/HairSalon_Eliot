using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class StylistControllerTest
  {
    [TestMethod]
    public void StylistList_HasCorrectModelType_StylistList()
    {
      //Arrange
      ViewResult StylistListView = new StylistController().StylistList() as ViewResult;

      //Act
      var result = StylistListView.ViewData.Model;

      //Assert
      Assert.IsInstanceOfType(result, typeof(List<Stylist>));
    }
  }
}
