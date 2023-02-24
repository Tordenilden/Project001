using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project001.Repo.Interface;
using Project001.Repo.Models;
using Project001.Repo.Repositories;

namespace Project001.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IPersonRepository personRepository;
        public PersonController(IPersonRepository temp)
        {
            personRepository = temp;    
        }
        #region aaa

        //public ActionResult<List<Person>> Get()
        //{
        //    return new List<Person>()
        //    {
        //        new Person() { id = 1, name = "Bo"}
        //    };
        //}
        [HttpGet]
        public async Task<ActionResult<List<Person>>> Get()
        {
            PersonRepository repo = new PersonRepository();
            return await repo.getPersons();
        }
        #endregion eee
        [HttpGet("GetPersons")]
        public async Task<ActionResult<List<Person>>> GetPersons()
        {
            return await personRepository.getPersons();
        }

    }
}
