using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Web.Controllers {
    [Route("peoples")]
    public class PeoplesController : Controller {
        private readonly MediaContext _context;

        public PeoplesController(MediaContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<People> List(string name) {
            var peoples = _context.Peoples;
            if (name == null) {
                return peoples.ToArray();
            }
            return peoples.Where(x => EF.Functions.Like(x.Name, $"%{name}%")).ToArray();
        }

        [HttpGet, Route("includeDeleted")]
        public IEnumerable<People> ListIncludeDeleted() {
            return _context.Peoples.IgnoreQueryFilters().ToArray();
        }
    }
}