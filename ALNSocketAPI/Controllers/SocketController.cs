using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocketClient;

namespace ALNSocketAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocketController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "API ON" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> SocketRunning(int id)
        {
            SocketClient.SocketClient client = new SocketClient.SocketClient();
            //呼叫WebSocker Server Side
            client.SocketRun(id);
            return  "Socket Running";
        }
    }
}