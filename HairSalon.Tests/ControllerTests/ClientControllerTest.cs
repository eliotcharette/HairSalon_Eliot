using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
  [TestClass]
  public class ClientControllerTest
  {
    [TestMethod]
    public void ClientList_HasCorrectModelType_ClientList()
    {
      //Arrange
      ViewResult ClientListView = new ClientController().ClientList() as ViewResult;

      //Act
      var result = ClientListView.ViewData.Model;

      //Assert
      Assert.IsInstanceOfType(result, typeof(List<Client>));
    }
  }
}
