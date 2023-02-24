using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project001.Repo.Models;
using Project001.Repo.Repositories;

namespace Project001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]

        //public ActionResult<List<Person>> Get()
        //{
        //    return new List<Person>()
        //    {
        //        new Person() { id = 1, name = "Bo"}
        //    };
        //}

        public ActionResult<string> Get()
        {
            PersonRepository repo = new PersonRepository();
            return repo.getName();
        }
    }
}
