using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/ingredientRequest")]
    public class IngredientRequestController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.IngredientRequests);
        }

        [HttpPost]
        public IActionResult Add(IngredientRequest ingredientRequest)
        {
            var db = new StarBucksContext();
            db.IngredientRequests.Add(ingredientRequest);
            db.SaveChanges();
            return Ok(ingredientRequest);
        }
        [HttpPut]
        public IActionResult Update(IngredientRequest ingredientRequest)
        {
            var db = new StarBucksContext();
            db.IngredientRequests.Update(ingredientRequest);
            db.SaveChanges();
            return Ok(ingredientRequest);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var ingredientRequest = db.IngredientRequests.FirstOrDefault(x => x.Id == id);
            if (ingredientRequest == null) return NotFound();
            db.IngredientRequests.Remove(ingredientRequest);
            db.SaveChanges();
            return Ok();
        }
    }
}
