using Microsoft.AspNetCore.Mvc;
using Карина_и_Лера.Models;

namespace Карина_и_Лера.Controllers
{
    [ApiController]
    [Route("/employee")]
    public class EmployeeController : ControllerBase
    {


        [HttpGet]
        [Route("all")]
        public IActionResult GetAll()
        {
            var db = new StarBucksContext();
            return Ok(db.Employees);
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            var db = new StarBucksContext();
            db.Employees.Add(employee);
            db.SaveChanges();
            return Ok(employee);
        }
        [HttpPut]
        public IActionResult Update(Employee employee)
        {
            var db = new StarBucksContext();
            db.Employees.Update(employee);
            db.SaveChanges();
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            var db = new StarBucksContext();
            var employee = db.Employees.FirstOrDefault(x => x.Id == id);
            if (employee == null) return NotFound();
            db.Employees.Remove(employee);
            db.SaveChanges();
            return Ok();
        }
    }
}
