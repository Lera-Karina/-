using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/ingredientFromInvoise")]
    public class IngredientFromInvoiseController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.IngredientFromInvoices);
        }

        [HttpPost]
        public IActionResult Add(IngredientFromInvoice ingredientFromInvoice)
        {
            var db = new StarBucksContext();
            db.IngredientFromInvoices.Add(ingredientFromInvoice);
            db.SaveChanges();
            return Ok(ingredientFromInvoice);
        }
        [HttpPut]
        public IActionResult Update(IngredientFromInvoice ingredientFromInvoice)
        {
            var db = new StarBucksContext();
            db.IngredientFromInvoices.Update(ingredientFromInvoice);
            db.SaveChanges();
            return Ok(ingredientFromInvoice);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var ingredientFromInvoise = db.IngredientFromInvoices.FirstOrDefault(x => x.Id == id);
            if (ingredientFromInvoise == null) return NotFound();
            db.IngredientFromInvoices.Remove(ingredientFromInvoise);
            db.SaveChanges();
            return Ok();
        }
    }
}
