using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/ingredientFromTheApplication")]
    public class IngredientFromTheApplicationController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.IngredientFromTheApplications);
        }

        [HttpPost]
        public IActionResult Add(IngredientFromTheApplication ingredientFromTheApplication)
        {
            var db = new StarBucksContext();
            db.IngredientFromTheApplications.Add(ingredientFromTheApplication);
            db.SaveChanges();
            return Ok(ingredientFromTheApplication);
        }
        [HttpPut]
        public IActionResult Update(IngredientFromTheApplication ingredientFromTheApplication)
        {
            var db = new StarBucksContext();
            db.IngredientFromTheApplications.Update(ingredientFromTheApplication);
            db.SaveChanges();
            return Ok(ingredientFromTheApplication);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var ingredientFromTheApplication = db.IngredientFromTheApplications.FirstOrDefault(x => x.Id == id);
            if (ingredientFromTheApplication == null) return NotFound();
            db.IngredientFromTheApplications.Remove(ingredientFromTheApplication);
            db.SaveChanges();
            return Ok();
        }
    }
}
