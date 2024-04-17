using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    
        [ApiController]
        [Route("/category")]
        public class CategoryController : ControllerBase
        {


            [HttpGet]
            [Route("all")]
            public IActionResult GetAll()
            {
                var db = new StarBucksContext();
                return Ok(db.Categories);
            }

            [HttpPost]
            public IActionResult Add(Category category)
            {
                var db = new StarBucksContext();
                db.Categories.Add(category);
                db.SaveChanges();
                return Ok(category);
            }
            [HttpPut]
            public IActionResult Update(Category category)
            {
                var db = new StarBucksContext();
                db.Categories.Update(category);
                db.SaveChanges();
                return Ok(category);
            }

            [HttpDelete]
            [Route("{id}")]
            public IActionResult Remove(int id)
            {
                var db = new StarBucksContext();
                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                if (category == null) return NotFound();
                db.Categories.Remove(category);
                db.SaveChanges();
                return Ok();
            }
        }
    
}
