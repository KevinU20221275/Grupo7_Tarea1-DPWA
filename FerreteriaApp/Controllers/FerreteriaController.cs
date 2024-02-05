using FerreteriaApp.Data;
using FerreteriaApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApp.Controllers
{
    public class FerreteriaController : Controller
    {
        public IActionResult Index()
        {
            FerreteriaData ferreteriaData = new FerreteriaData();

            return View(ferreteriaData.GetAll());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FerreteriaModel ferreteriaModel)
        {
            try
            {
                FerreteriaData ferreteriaData = new FerreteriaData();
                ferreteriaData.Add(ferreteriaModel);

                TempData["SuccessMessage"] = "El registro se creo exitosamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(ferreteriaModel);
            }
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            FerreteriaData ferreteriaData = new FerreteriaData();
            var ferreteria = ferreteriaData.GetById(Id);

            if (ferreteria == null)
            {
                return NotFound();
            }

            return View(ferreteria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FerreteriaModel ferreteriaModel)
        {
            try
            {
                FerreteriaData ferreteriaData = new FerreteriaData();
                ferreteriaData.Edit(ferreteriaModel);

                TempData["SuccessMessage"] = "El registro se edito exitosamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(ferreteriaModel);
            }
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            FerreteriaData ferreteriaData = new FerreteriaData();

            var ferreteria = ferreteriaData.GetById(Id);

            if (ferreteria == null)
            {
                return NotFound();
            }

            return View(ferreteria);
        }

        [HttpPost]
        public IActionResult Delete(FerreteriaModel ferreteriaModel)
        {
            try
            {
                FerreteriaData ferreteriaData = new FerreteriaData();
                ferreteriaData.Delete(ferreteriaModel.Id);

                TempData["SuccessMessage"] = "El registro se elimino exitosamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(ferreteriaModel);
            }
        }
    }
}
