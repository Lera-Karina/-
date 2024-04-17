using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/buyer")]
    public class BuyerController : ControllerBase
    {
        

        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.Buyers);
        }

        [HttpPost]
        public IActionResult Add(Buyer buyer)
        {
            var db = new StarBucksContext();
            db.Buyers.Add(buyer);
            db.SaveChanges();
            return Ok(buyer);
        }
        [HttpPut]
        public IActionResult Update(Buyer buyer)
        {
            var db = new StarBucksContext();
            db.Buyers.Update(buyer);
            db.SaveChanges();
            return Ok(buyer);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var buyer = db.Buyers.FirstOrDefault(x => x.Id == id);
            if (buyer == null) return NotFound();
            db.Buyers.Remove(buyer);
            db.SaveChanges();
            return Ok();
        }
    }
}
