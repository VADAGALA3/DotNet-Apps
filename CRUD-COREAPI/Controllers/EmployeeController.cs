using CRUD_COREAPI.Interface;
using CRUD_COREAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_COREAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IBaseService<Employee> _baseservice;// firts reps sample 
        public EmployeeController(IBaseService<Employee> baseservice)
        {
            _baseservice = baseservice;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var emps = _baseservice.GetAll();
            return new OkObjectResult(emps);
        }
        [HttpGet, Route("{EmployeeId}")]
        public IActionResult Get(int id)
        {
            //we want to find the product by id and load the category        
            var products = _baseservice.Get(x => x.Empno == id, null);
            if (!products.Any())
            {
                return new NoContentResult();
            }
            return new OkObjectResult(products.First());
        }
        [HttpPost]
        public IActionResult Post(Employee emp)
        {
            _baseservice.Create(emp);
            return CreatedAtAction(nameof(Get), new { empid = emp.Empno }, emp);
        }

        // PUT: api/Product/5       
        [HttpPut("{CityId}")]
        public IActionResult Put(int id, [FromBody] Employee product)
        {
            if (product != null)
            {
                _baseservice.Update(product);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{CityId}")]
        public IActionResult Delete(int id)
        {
            var emps = _baseservice.Get(x => x.Empno == id);
            if (!emps.Any())
            {
                return new NoContentResult();
            }
            _baseservice.Delete(emps.First());
            return new OkResult();
        }
    }
}
