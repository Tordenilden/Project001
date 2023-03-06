using Project001.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.Interface
{
    public interface IPersonRepository
    {
        // define methods - CRUD
        public Task<List<Person>> getPersons();
        public Task<Person> getPersonById(int id);
        public Task<Person> getPersonByName(string name);
        public Task<Person> createPerson(Person person);
        public Task<Person> updatePerson(Person person);
        public Task<bool> DeletePerson(int id);
    }
}
