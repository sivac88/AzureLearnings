using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DemoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerQuery
    {
        public EmployeeController(IConfiguration config, ILogger<EmployeeController> logger) : base(config, logger)
        { }

        [HttpGet]
        public IEnumerable<EmployeeInfo> Get()
        {
            List<string> employees =  this.GetEmployeeList();
            return Enumerable.Range(0, employees.Count).Select(index => new EmployeeInfo
            {
                Name = employees[index],
                Designation = (index % 2 == 0) ? "Level1" : "Level2",
                PhoneNumber = (index % 2 != 0) ? "123" : "567"
            }).ToArray();
        }
    }
}
