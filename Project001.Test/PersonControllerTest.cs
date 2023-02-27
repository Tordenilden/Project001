using Microsoft.AspNetCore.Mvc.Infrastructure;
using Moq;
using Project001.API.Controllers;
using Project001.Repo.Interface;
using Project001.Repo.Models;
using Project001.Repo.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Project001.Test
{
    public class PersonControllerTest
    {
        // Simulate our PersonController...
        // Cause, we dont use it.

        private readonly PersonController personController;// = new PersonController()
        // using Moq
        // repo is defined and Initialized
        private readonly Mock<IPersonRepository> repo = new(); // I skal prøve med en class her
        public PersonControllerTest()
        {
           // this.repo = repo;
            //this.personController = controller; // måske er det ikke rigtigt!!
            this.personController = new PersonController(repo.Object);
        }
        // ? er om vores objekter skal initialiseres...

        // Method getPersons
        [Fact]
        public async void GetPersonsShouldReturn200()
        {
            //Arrange  - Data, initialize objects etc.
            List<Person> persons = new List<Person>
            {
                new Person { id = 1, name = "Casper"},
                new Person { id = 2, name = "Hans"},
                new Person { id=3, name = "Ulla"}
            };

            // we need to Mock our data !! how??
            // repo is an object, "that is started" with the Method
            // Setup(). ReturnsAsync - returns an obj, when getPersons() is invoked
            repo.Setup(s => s.getPersons()).ReturnsAsync(persons);

            //Act      - Invoke our methods
            var result = await personController.GetPersons();

            //Assert   - call Assert, basicly a bool
            // Tjeck the result and then Assert
            var statuscode = (IStatusCodeActionResult)result; // get type eller typeof mm.
            Assert.Equal(200, statuscode.StatusCode);
        }
    }
}
