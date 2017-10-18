﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using EFCore.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCore.Web.Controllers {
    [Route("photos")]
    public class PhotosController : Controller {
        private readonly MediaContext _context;

        public PhotosController(MediaContext context) {
            _context = context;
        }

        private Func<MediaContext, IEnumerable<Photo>> _query = EF.CompileQuery((MediaContext db)
            => db.Photos.Include(c => c.Photographer)
        );

        [HttpGet]
        public IEnumerable<Photo> List() {
            return _query(_context);
        }
    }
}