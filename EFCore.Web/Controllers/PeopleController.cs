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
        [HttpGet]
        public IEnumerable<People> List(string name) {
            using (var context = new MediaContext()) {
                var peoples = context.Peoples;
                if (name == null) {
                    return peoples.ToArray();
                }
                return peoples.Where(x => EF.Functions.Like(x.Name, $"%{name}%")).ToArray();
            }
        }

        [HttpGet, Route("includeDeleted")]
        public IEnumerable<People> ListIncludeDeleted() {
            using (var context = new MediaContext()) {
                return context.Peoples.IgnoreQueryFilters().ToArray();
            }
        }
    }
}