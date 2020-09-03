using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public interface ITodoRepository
    {
        Person Find(String key);
        MotherClass Add(String name, String middleName, String LastName, String Address);
        MotherClass Update(String name, String middleName, String LastName, String Address, String id);
        MotherClass Remove(string key);
        IEnumerable<Person> GetAll();
    }
}
