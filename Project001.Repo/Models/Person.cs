using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project001.Repo.Models
{
    public class Person // its called a Model
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public List<Car> cars { get; set; }//foreign key til car
        public Person()
        {
            cars = new List<Car>();
        }
    }
}
