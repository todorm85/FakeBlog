using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeBlog.Models;
using Microsoft.AspNet.Identity.Owin;
using System.Data.Entity;

namespace FakeBlog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var posts = db.Posts.OrderByDescending(p => p.CreatedDate).ToList();
            return View(posts);
        }

        public ActionResult Details(int id)
        {
            var post = db.Posts
                .Include(p => p.Comments)
                .FirstOrDefault(p => p.Id == id);

            if (post != null)
            {
                post.Comments = post.Comments.OrderByDescending(c => c.CreatedDate).ToList();
            }
            else
            {
                return HttpNotFound();
            }

            return View(post);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}