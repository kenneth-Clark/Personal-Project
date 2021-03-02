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
        public String contactNumber { get; set; }

        public String spouse { get; set; }
        public String mother_name { get; set; }
        public String father_name { get; set; }
        public String age { get; set; }
        public String occupation { get; set; }
    }
    public class User : MotherClass
    {
        public String userName { get; set; }
        public String userPassword { get; set; }
    }
    public class PersonList : MotherClass
    {
        public List<String> name { get; set; }
        public List<String> middleName { get; set; }
        public List<String> lastName { get; set; }
        public List<String> Address { get; set; }
        public List<String> Id { get; set; }
        public List<String> contactNumber { get; set; }

        public List<String> spouse { get; set; }
        public List<String> mother_name { get; set; }
        public List<String> father_name { get; set; }
        public List<String> age { get; set; }
        public List<String> occupation { get; set; }

    }
    public class removeData : MotherClass
    { 
        public String id { get; set; }
    }
}
