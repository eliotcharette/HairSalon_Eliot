using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
  public class SpecialtyController : Controller
  {
    [HttpGet("/specialty")]
    public ActionResult Index()
    {
      return View();
    }
    [HttpGet("/specialty/add")]
    public ActionResult CreateForm()
    {
      List<Specialty> allSpecialties = Specialty.GetAll();
      return View(allSpecialties);
    }
    [HttpPost("/specialty/add")]
    public ActionResult PostSpecialty()
    {
      Specialty newSpecialty = new Specialty(Request.Form["newSpecialty"]);
      newSpecialty.Save();
      return RedirectToAction("CreateForm", Specialty.GetAll());
    }
    [HttpGet("/stylist/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      return View(thisStylist);
    }

    [HttpPost("/stylist/{id}/update")]
    public ActionResult Update(int id)
    {
      Stylist thisStylist = Stylist.Find(id);
      thisStylist.Edit(Request.Form["newName"]);
      return RedirectToAction("Stylists");
    }
    [HttpGet("/specialty/stylist")]
    public ActionResult Stylists()
    {
      List<Stylist> allStylists = Stylist.GetAll();
      return View(allStylists);
    }
    [HttpGet("/specialty/stylist/{id}")]
    public ActionResult Details(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Stylist stylists = Stylist.Find(id);
      List<Specialty> specialties = stylists.GetSpecialties();
      List<Specialty> allSpecialties = Specialty.GetAll();
      model.Add("stylists", stylists);
      model.Add("specialties", specialties);
      model.Add("allSpecialties", allSpecialties);
      return View(model);
    }
    [HttpPost("/specialty/stylist/{Id}/new")]
    public ActionResult AddSpecialty(int Id)
    {
      Stylist stylist = Stylist.Find(Id);
      Specialty specialty = Specialty.Find(int.Parse(Request.Form["specialty-id"]));
      stylist.AddSpecialty(specialty);
      return RedirectToAction("Details", new { id = Id});
    }
  }
}
