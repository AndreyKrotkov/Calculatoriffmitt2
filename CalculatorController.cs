using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            var model = new CalculatorModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(CalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                if (int.TryParse(model.Number1, out int number1) && int.TryParse(model.Number2, out int number2))
                {
                    model.Result = number1 + number2;
                    // ViewBag.Result = $"{number1} + {number2} = {model.Result}";
                    return View("Index", model);
                }
                else
                {
                    ViewBag.ErrorMessage = "Недійсні введені дані.";
                }
            }
            return View("Index", model);
        }

    }
}
