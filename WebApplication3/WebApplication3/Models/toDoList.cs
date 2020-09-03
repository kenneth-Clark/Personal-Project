using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class toDoList
    {
        public String Key { get; set; }
        public String Name { get; set; }
        public bool IsComplete { get; set; }
    }
    public class MotherClass
    {
        public String responseCode { get; set; }
        public String responseMessage { get; set; }
    }

    public class Person : MotherClass
    {
        public String name { get; set; }
        public String middleName { get; set; }
        public String lastName { get; set; }
        public String Address { get; set; }
        public String Id { get; set; }
    }
    public class removeData : MotherClass
    { 
        public String id { get; set; }
    }
}
