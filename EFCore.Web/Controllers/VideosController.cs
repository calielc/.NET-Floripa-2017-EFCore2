using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EFCore.Data;
using System;
using Microsoft.EntityFrameworkCore;

namespace EFCore.Web.Controllers {
    [Route("videos")]
    public class VideosController : Controller {
        private readonly MediaContext _context;

        public VideosController(MediaContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Video> List() {
            return _context.Videos.ToArray();
        }

        [HttpGet, Route("duration")]
        public IEnumerable<Video> ListWith(TimeSpan greater) {
            return _context.Videos.FromSql($"select * from Videos where duration > {greater}").ToArray();
        }

    }
}