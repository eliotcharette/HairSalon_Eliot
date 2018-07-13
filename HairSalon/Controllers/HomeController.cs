using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}
// [HttpPost("/clients")]
// public ActionResult similarStylist(string clients)
// {
//  List<Client>  sameStyleClients = Client.FindByStylist(clients);
//  return View("ClientList", sameStyleClients);
// }
//
// [HttpPost("/clients")]
// public ActionResult PostClient()
// {
//   Client newClient = new Client(Request.Form["newClient"], int.Parse(Request.Form["stylistId"]));
//   newClient.Save();
//   return View("ClientList", Client.GetAll());
// }
