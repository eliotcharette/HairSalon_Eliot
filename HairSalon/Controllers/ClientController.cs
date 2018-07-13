using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/addclient")]
    public ActionResult ClientForm()
    {
      return View();
    }
    [HttpGet("/clients")]
    public ActionResult ClientList()
    {
      List<Client>  allClient = Client.GetAll();
      return View(allClient);
    }
    [HttpPost("/clients")]
    public ActionResult PostClientList()
    {
      Client newClient = new Client(Request.Form["newClient"], int.Parse(Request.Form["stylistId"]));
      newClient.Save();
      return View("ClientList", Client.GetAll());
    }
    [HttpGet("/clients/{stylistId}")]
    public ActionResult PostClient(int stylistId)
    {
      List<Client> sameStylistClients = Client.FindByStylist(stylistId);
      return View("ClientList", sameStylistClients);
    }
    [HttpPost("/client/delete")]
    public ActionResult DeleteOneClient(int clientId)
    {
      Client.Find(clientId).Delete();
      return RedirectToAction("ClientList");
    }
  }
}
