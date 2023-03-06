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
        #region initial
        // how do I use the Database? // ORM
        // new(); THIS IS ON Compile Time
        private DatabaseContext context { get; set; } //= new();

        public PersonRepository(DatabaseContext d)
        {
            context = d; //runtime
            //context = new DatabaseContext();//compiletime
        }

        // make a method that can be called
        public string getName() { return "I am the Jedi"; }

        #endregion initial

        public async Task<Person> createPerson(Person person)
        {
                context.Person.Add(person);
                await context.SaveChangesAsync();
                return person;
        }
        public async Task<bool> DeletePerson(int id)
        {
            var person = await context.Person.FirstOrDefaultAsync(p => p.id == id);
            bool deleted = false;
            if (person != null)
            {
                context.Person.Remove(person);
                await context.SaveChangesAsync();
                deleted = true;
            }
            return deleted;
        }
        public async Task<Person> getPersonById(int id)
        {
            return await context.Person
                .FirstOrDefaultAsync(obj => obj.id == id);
        }
        public async Task<Person> getPersonByName(string name)
        {
            return await context.Person
            .FirstOrDefaultAsync(obj => obj.name == name);
        }
        public async Task<List<Person>> getPersons()
        {
            return await context.Person.ToListAsync();
        }
        public async Task<Person> updatePerson(Person person)
        {
            Person updatePerson = await getPersonById(person.id);
            if (updatePerson != null)
            {
                updatePerson.age = person.age;
                updatePerson.name = person.name;
                updatePerson.cars = person.cars;
            }
            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // return // her skulle der være en fejlkode....
            }
            return updatePerson;
        }


    }
}
