using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public interface ITodoRepository
    {
        User Login(String uname, String upassword);
        Person Find(String key);
        MotherClass Add(String name, String middleName, String lastName, String Address, String id, String ContactNumber, String Spouse, String Mother, String Father, String Age, String Occupation);
        MotherClass Update(String name, String middleName, String lastName, String Address, String id, String ContactNumber, String Spouse, String Mother, String Father, String Age, String Occupation);
        MotherClass Remove(string key);
        PersonList FindAll();
        IEnumerable<Person> GetAll();
    }
}
