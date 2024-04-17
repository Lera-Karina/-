using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/order")]
    public class OrderController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.Orders);
        }

        [HttpPost]
        public IActionResult Add(Order order)
        {
            var db = new StarBucksContext();
            db.Orders.Add(order);
            db.SaveChanges();
            return Ok(order);
        }
        [HttpPut]
        public IActionResult Update(Order order)
        {
            var db = new StarBucksContext();
            db.Orders.Update(order);
            db.SaveChanges();
            return Ok(order);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var order = db.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null) return NotFound();
            db.Orders.Remove(order);
            db.SaveChanges();
            return Ok();
        }
    }
}
