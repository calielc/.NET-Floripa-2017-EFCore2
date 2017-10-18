using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Web.Controllers {
    [Route("ping")]
    public class PingController : Controller {
        // GET api/values
        [HttpGet]
        public DateTime Get() {
            return DateTime.Now;
        }
    }
}
