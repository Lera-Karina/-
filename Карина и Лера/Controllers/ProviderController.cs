using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/provider")]
    public class ProviderFromOrderController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.Providers);
        }

        [HttpPost]
        public IActionResult Add(Provider provider)
        {
            var db = new StarBucksContext();
            db.Providers.Add(provider);
            db.SaveChanges();
            return Ok(provider);
        }
        [HttpPut]
        public IActionResult Update(Provider provider)
        {
            var db = new StarBucksContext();
            db.Providers.Update(provider);
            db.SaveChanges();
            return Ok(provider);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var provider = db.Providers.FirstOrDefault(x => x.Id == id);
            if (provider == null) return NotFound();
            db.Providers.Remove(provider);
            db.SaveChanges();
            return Ok();
        }
    }
}
