using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Web.Controllers {
    [Route("photos")]
    public class PhotosController : Controller {
        private readonly MediaContext _context;

        public PhotosController(MediaContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Photo> List() {
            return _context.Photos.Include(x => x.Photographer).ToArray();
        }
    }
}