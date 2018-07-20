using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class ClientController : Controller
  {
    [HttpGet("/client/home")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("/addclient")]
    public ActionResult ClientForm()
    {
      List<Client>  allClient = Client.GetAll();
      return View(allClient);
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
    [HttpGet("/client/new/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylists = Stylist.Find(id);
      List<Client> clients = stylists.GetClients();
      List<Client> allClients = Client.GetAll();
      model.Add("stylists", stylists);
      model.Add("clients", clients);
      model.Add("allClients", allClients);
      return View(model);
    }
    [HttpPost("/client/new/{Id}/new")]
    public ActionResult AddClient(int Id)
    {
      Stylist stylist = Stylist.Find(Id);
      Client client = Client.Find(int.Parse(Request.Form["client-id"]));
      stylist.AddClient(client);
      return RedirectToAction("Details", new { id = Id});
    }
    [HttpPost("/client/delete")]
    public ActionResult DeleteOneClient(int clientId)
    {
      Client.Find(clientId).Delete();
      return RedirectToAction("ClientList");
    }
  }
}
