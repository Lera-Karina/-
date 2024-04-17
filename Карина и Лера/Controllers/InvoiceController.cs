using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/invoice")]
    public class InvoisceController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.Invoices);
        }

        [HttpPost]
        public IActionResult Add(Invoice invoice)
        {
            var db = new StarBucksContext();
            db.Invoices.Add(invoice);
            db.SaveChanges();
            return Ok(invoice);
        }
        [HttpPut]
        public IActionResult Update(Invoice invoice)
        {
            var db = new StarBucksContext();
            db.Invoices.Update(invoice);
            db.SaveChanges();
            return Ok(invoice);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var invoice = db.Invoices.FirstOrDefault(x => x.Id == id);
            if (invoice == null) return NotFound();
            db.Invoices.Remove(invoice);
            db.SaveChanges();
            return Ok();
        }
    }
}
