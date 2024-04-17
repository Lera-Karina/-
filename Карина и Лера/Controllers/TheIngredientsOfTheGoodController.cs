using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/theIngredientsOfTheGood")]
    public class TheIngredientsOfTheGoodController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.TheIngredientsOfTheGoods);
        }

        [HttpPost]
        public IActionResult Add(TheIngredientsOfTheGood theIngredientsOfTheGood)
        {
            var db = new StarBucksContext();
            db.TheIngredientsOfTheGoods.Add(theIngredientsOfTheGood);
            db.SaveChanges();
            return Ok(theIngredientsOfTheGood);
        }
        [HttpPut]
        public IActionResult Update(TheIngredientsOfTheGood theIngredientsOfTheGood)
        {
            var db = new StarBucksContext();
            db.TheIngredientsOfTheGoods.Update(theIngredientsOfTheGood);
            db.SaveChanges();
            return Ok(theIngredientsOfTheGood);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var theIngredientsOfTheGood = db.TheIngredientsOfTheGoods.FirstOrDefault(x => x.Id == id);
            if (theIngredientsOfTheGood == null) return NotFound();
            db.TheIngredientsOfTheGoods.Remove(theIngredientsOfTheGood);
            db.SaveChanges();
            return Ok();
        }
    }
}
