﻿using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        public TodoController(ITodoRepository todoItems)
        {
            TodoItems = todoItems;
        }

        public ITodoRepository TodoItems { get; set; }

        public IEnumerable<Person> GetAll()
        {
            return TodoItems.GetAll();
        }
        [HttpGet]
        [Route("")]
        [Route("{eventName}/{name}/{middleName}/{lastName}/{Address}/{id}")]
        public ActionResult GetById(string eventName, String name, String middleName, String lastName, String Address, String id)
        {
            var item = TodoItems;
            var defaultResponse = new MotherClass();
            if (eventName == "Find")
            {
                var events = item.Find(id);
                if (events == null)
                {
                    return NotFound();
                }
                return new ObjectResult(events);
            }
            else if (eventName == "Remove")
            {
                var events = item.Remove(id);
                if (events == null)
                {
                    return NotFound();
                }
                return new ObjectResult(events);
            }
            else if (eventName == "Update")
            {
                var events = item.Update(name, middleName, lastName, Address,id);
                if (events == null)
                {
                    return NotFound();
                }
                return new ObjectResult(events);
            }
            else if (eventName == "Add")
            {
                var events = item.Add(name,middleName,lastName,Address);
                if (events == null)
                {
                    return NotFound();
                }
                return new ObjectResult(events);
            }
            else
            {
                defaultResponse.responseCode = "124002";
                defaultResponse.responseMessage = "Invalid entry";
            }            
            return new ObjectResult(defaultResponse);
        }

       
    }
}
