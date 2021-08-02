using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsoleController : ControllerBase
    {
        [HttpGet("clear")]
        public void Clear() => Console.Clear();

        [HttpGet("WriteLine")]
        public void WriteLine(string Message) => Console.WriteLine(Message);
    }
}
