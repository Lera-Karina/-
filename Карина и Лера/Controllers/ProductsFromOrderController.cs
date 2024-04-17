using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/productsFromOrder")]
    public class ProductsFromOrderController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.ProductsFromOrders);
        }

        [HttpPost]
        public IActionResult Add(ProductsFromOrder productsFromOrder)
        {
            var db = new StarBucksContext();
            db.ProductsFromOrders.Add(productsFromOrder);
            db.SaveChanges();
            return Ok(productsFromOrder);
        }
        [HttpPut]
        public IActionResult Update(ProductsFromOrder productsFromOrder)
        {
            var db = new StarBucksContext();
            db.ProductsFromOrders.Update(productsFromOrder);
            db.SaveChanges();
            return Ok(productsFromOrder);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var productsFromOrder = db.ProductsFromOrders.FirstOrDefault(x => x.Id == id);
            if (productsFromOrder == null) return NotFound();
            db.ProductsFromOrders.Remove(productsFromOrder);
            db.SaveChanges();
            return Ok();
        }
    }
}
