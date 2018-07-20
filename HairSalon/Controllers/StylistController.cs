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
    [HttpGet("/specialty/list")]
    public ActionResult Specialties()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }
    [HttpGet("/specialty/list/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Specialty specialties = Specialty.Find(id);
      List<Stylist> stylists = specialties.GetStylists();
      List<Stylist> allStylists = Stylist.GetAll();
      model.Add("specialties", specialties);
      model.Add("stylists", stylists);
      model.Add("allStylists", allStylists);
      return View(model);
    }
    [HttpPost("/specialty/list/{Id}/new")]
    public ActionResult AddStylist(int Id)
    {
      Specialty specialty = Specialty.Find(Id);
      Stylist stylist = Stylist.Find(int.Parse(Request.Form["stylist-id"]));
      specialty.AddStylist(stylist);
      return RedirectToAction("Details", new { id = Id});
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
