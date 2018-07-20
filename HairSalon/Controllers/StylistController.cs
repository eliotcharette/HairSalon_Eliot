using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class StylistController : Controller
  {
    [HttpGet("/hirestylist")]
    public ActionResult HireStylist()
    {
      return View();
    }
    [HttpGet("/stylists")]
    public ActionResult StylistList()
    {
      List<Stylist> allStylists= Stylist.GetAll();
      return View(allStylists);
    }
    [HttpPost("/stylists")]
    public ActionResult PostStylist()
    {
      Stylist newStylist = new Stylist(Request.Form["newStylist"]);
      newStylist.Save();
      return View("StylistList", Stylist.GetAll());
    }
    [HttpPost("/stylist/delete")]
    public ActionResult DeleteOneStylist(int stylistId)
    {
      Stylist.Find(stylistId).Delete();
      return RedirectToAction("StylistList");
    }
  }
}
