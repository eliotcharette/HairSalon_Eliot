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
    [HttpPost("/books/{bookId}/books/new")]
    public ActionResult AddAuthor(int bookId)
    {
      Stylist book = Stylist.Find(bookId);
      Specialty author = Specialty.Find(int.Parse(Request.Form["author-id"]));
      book.AddSpecialty(author);
      return RedirectToAction("Details", new { id = bookId});
    }
  }
}
