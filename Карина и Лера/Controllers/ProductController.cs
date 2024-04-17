using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{

    [ApiController]
    [Route("/product")]
    public class ProductController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.Products);
        }

        [HttpPost]
        public IActionResult Add(Product product)
        {
            var db = new StarBucksContext();
            db.Products.Add(product);
            db.SaveChanges();
            return Ok(product);
        }
        [HttpPut]
        public IActionResult Update(Product product)
        {
            var db = new StarBucksContext();
            db.Products.Update(product);
            db.SaveChanges();
            return Ok(product);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var product = db.Products.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            db.Products.Remove(product);
            db.SaveChanges();
            return Ok();
        }
    }

}
