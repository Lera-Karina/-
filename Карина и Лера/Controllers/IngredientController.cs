using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/ingredient")]
    public class IngredientController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.Ingredients);
        }

        [HttpPost]
        public IActionResult Add(Ingredient ingredient)
        {
            var db = new StarBucksContext();
            db.Ingredients.Add(ingredient);
            db.SaveChanges();
            return Ok(ingredient);
        }
        [HttpPut]
        public IActionResult Update(Ingredient ingredient)
        {
            var db = new StarBucksContext();
            db.Ingredients.Update(ingredient);
            db.SaveChanges();
            return Ok(ingredient);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var ingredient = db.Ingredients.FirstOrDefault(x => x.Id == id);
            if (ingredient == null) return NotFound();
            db.Ingredients.Remove(ingredient);
            db.SaveChanges();
            return Ok();
        }
    }
}
