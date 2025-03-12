using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CyberPost.Models;
using Microsoft.AspNet.Identity.Owin;

namespace CyberPost.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Admin/Posts
        public ActionResult Index()
        {
            var posts = db.Posts.OrderByDescending(p => p.CreatedDate).ToList();
            return View(posts);
        }

        // GET: /Admin/CreatePost
        public ActionResult CreatePost()
        {
            return View();
        }

        // POST: /Admin/CreatePost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(Post post)
        {
            if (ModelState.IsValid)
            {
                post.CreatedDate = DateTime.Now;
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }
    }
}