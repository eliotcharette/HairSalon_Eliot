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
  }
}
