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
    public ActionResult PostClient(int stylistId)
    {
      Client newClient = new Client(Request.Form["newClient"], int.Parse(Request.Form["stylistId"]));
      newClient.Save();
      return View("ClientList", Client.FindByStylist(stylistId));
    }
    // [HttpPost("/clients")]
    // public ActionResult SimilarStylist(int stylistId)
    // {
    //  List<Client>  sameStyleClients = Client.FindByStylist(stylistId);
    //  return View("ClientList", sameStyleClients);
    // }
    [HttpPost("/client/delete")]
    public ActionResult DeleteOneClient(int clientId)
    {
      Client.Find(clientId).Delete();
      return RedirectToAction("ClientList");
    }
  }
}
