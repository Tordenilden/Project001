using Microsoft.EntityFrameworkCore;
using Project001.Repo.Interface;
using Project001.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        // how do I use the Database? // ORM
        private DatabaseContext context { get; set; } = new();

        #region start
        public Task<Person> createPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Task DeletePerson(int id)
        {
            throw new NotImplementedException();
        }


        // make a method that can be called
        public string getName() { return "I am the Jedi"; }

        public Task<Person> getPersonById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person> getPersonByName(string name)
        {
            throw new NotImplementedException();
        }

        #endregion start
        public async Task<List<Person>> getPersons()
        {
            //Jeg skal benytte EF
            // til at skrive noget LINQ som returnerer alle
            // personer tilbage til en var variabel
            // og dernæst returnerer denne...

            return await context.Person.ToListAsync();
        }

        public Task<Person> updatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
