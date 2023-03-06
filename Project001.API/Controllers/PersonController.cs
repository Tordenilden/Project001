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
        #region Hardcoded example - we cant use in future...
        //[HttpGet]
        //public async Task<ActionResult> Get()
        //{
        //    // We wants to return some statuscodes
        //    PersonRepository repo = new PersonRepository();
        //    var persons = await repo.getPersons();
        //    return Ok(persons); // This is code 200
        //}
        #endregion eee
        
        
        [HttpGet("GetPersons")]
        public async Task<ActionResult> GetPersons()
        {
            try
            {
                var persons = await personRepository.getPersons();
                if (persons == null)
                {
                    // something has gone wrong serverside, return code 500
                    return Problem("Unexpected null returned from service");
                }
                else if (persons.Count == 0)
                {
                    // no data exists, but everything is still ok, return code 204
                    return NoContent();
                }
                // we got data! return with code 200
                return Ok(persons);
            }
            catch (Exception ex)
            {
                // handle any other exeptions raised by sending code 500
                return Problem(ex.Message);
            }
        }

        [HttpGet("GetPersonById")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                var persons = await personRepository.getPersonById(id);
                if(persons == null) { 
                    return NotFound();
                }
                return Ok(persons);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        { // do I need both id and person?? - maybe...
            try
            {
                var editPersons = await personRepository.updatePerson(person);
                if (editPersons == null)
                {
                    return Problem("Edit failed friday afternoon");
                }
                return Ok(editPersons);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // POST: api/Person
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            // Do we know if the data is valid??
            try
            {
                if (person == null)
                {
                    return BadRequest("JSON data is bad...");
                }
                var newPerson = await personRepository.createPerson(person);
                return Created("",newPerson); //201
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeletePerson(int id)
        {
            var person = await personRepository.getPersonById(id);
            if (person == null)
            {
                return NotFound();
            }

            return await personRepository.DeletePerson(id);
        }
        
    }
}
