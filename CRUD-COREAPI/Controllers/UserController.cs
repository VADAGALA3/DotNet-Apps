using CRUD_COREAPI.Interface;
using CRUD_COREAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_COREAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IBaseService<UserDetails> _baseservice;
        public UserController(IBaseService<UserDetails> baseservice)
        {
            _baseservice = baseservice;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var user = _baseservice.GetAll();
            return new OkObjectResult(user);
        }
        [HttpGet, Route("{UserDetailsId}")]
        public IActionResult Get(int id)
        {
            //we want to find the product by id and load the category        
            var products = _baseservice.Get(x => x.UserId == id, null);
            if (!products.Any())
            {
                return new NoContentResult();
            }
            return new OkObjectResult(products.First());
        }
        [HttpPost]
        public IActionResult Post(UserDetails emp)
        {
            _baseservice.Create(emp);
            return new OkResult();
        }

        // PUT: api/Product/5       
        [HttpPut()]
        public IActionResult Put(UserDetails product)
        {
            if (product != null)
            {
                _baseservice.Update(product);
                return new OkResult();
            }
            return new NoContentResult();
        }

        [HttpDelete("{Id}")]
        public IActionResult Delete(int id)
        {
            var user = _baseservice.Get(x => x.UserId == id);
            if (!user.Any())
            {
                return new NoContentResult();
            }
            _baseservice.Delete(user.First());
            return new OkResult();
        }
    }
}
