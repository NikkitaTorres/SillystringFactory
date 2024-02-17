using Microsoft.AspNetCore.Mvc;
using Factory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Factory.Controllers
{
  public class LicensesController : Controller
  {
    private readonly FactoryContext _db;

    public LicensesController(FactoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Licenses.ToList());
    }

    public ActionResult Details(int id)
    {
      License thisLicense = _db.Licenses
      .Include(license => license.JoinEntities)
      .ThenInclude(join => join.Engineer)
      .FirstOrDefault(license => license.LicenseId == id);
      return View(thisLicense);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(License license)
    {
      _db.Licenses.Add(license);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddEngineer(int id)
    {
      License thisLicense = _db.Licenses.FirstOrDefault(licenses => licenses.LicenseId == id);
      ViewBag.EngineerId = new SelectList(_db.Engineers, "EngineerId", "Description");
      return View(thisLicense);
    }

    [HttpPost]
    public ActionResult AddEngineer(License license, int engineerId)
    {
      #nullable enable
      EngineerLicense? joinEntity = _db.EngineerLicenses.FirstOrDefault(join => (join.EngineerId == engineerId && join.LicenseId == license.LicenseId));
      #nullable disable
      if (joinEntity == null && engineerId != 0)
      {
        _db.EngineerLicenses.Add(new EngineerLicense() { EngineerId = engineerId, LicenseId = license.LicenseId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = license.LicenseId });
    }

    public ActionResult Edit(int id)
    {
      License thisLicense = _db.Licenses.FirstOrDefault(licenses => licenses.LicenseId == id);
      return View(thisLicense);
    }

    [HttpPost]
    public ActionResult Edit(License license)
    {
      _db.Licenses.Update(license);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      License thisLicense = _db.Licenses.FirstOrDefault(licenses => licenses.LicenseId == id);
      return View(thisLicense);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      License thisLicense = _db.Licenses.FirstOrDefault(licenses => licenses.LicenseId == id);
      _db.Licenses.Remove(thisLicense);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      EngineerLicense joinEntry = _db.EngineerLicenses.FirstOrDefault(entry => entry.EngineerLicenseId == joinId);
      _db.EngineerLicenses.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}