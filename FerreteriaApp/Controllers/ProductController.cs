using FerreteriaApp.Data;
using FerreteriaApp.Models;
using FerreteriaApp.Validations;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FerreteriaApp.Controllers
{
    public class ProductController : Controller
    {
        private IValidator<ProductModel> _productValidator;

        public ProductController(IValidator<ProductModel> productValidator)
        {
            _productValidator = productValidator;
        }

        public IActionResult Index()
        {
            ProductData productData = new ProductData();
            return View(productData.GetAllProducts());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductModel productModel)
        {
            ValidationResult validationResult = _productValidator.Validate(productModel);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);

                return View(productModel);
            }

             ProductData productData = new ProductData();
             productData.Add(productModel);

            TempData["SuccessMessage"] = "El registro se creo exitosamente.";

            return RedirectToAction(nameof(Index));
            
        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ProductData productData = new ProductData();
            var product = productData.GetById(Id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ProductModel productModel)
        {
            ValidationResult validationResult = _productValidator.Validate(productModel);

            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(this.ModelState);

                return View(productModel);
            }

            ProductData productData = new ProductData();
            productData.Edit(productModel);

            TempData["SuccessMessage"] = "El registro se edito exitosamente.";

            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            ProductData productData = new ProductData();

            var product = productData.GetById(Id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(ProductModel productModel)
        {
            try
            {
                ProductData productData = new ProductData();
                productData.Delete(productModel.Id);

                TempData["SuccessMessage"] = "El registro se elimino exitosamente.";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

                return View(productModel);
            }
        }
    }
}
