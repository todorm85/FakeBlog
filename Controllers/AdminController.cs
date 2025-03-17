using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeBlog.Models;
using Microsoft.AspNet.Identity.Owin;

namespace FakeBlog.Controllers
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
            ViewBag.Title = "Create Post";
            return View("EditPost");
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

        // GET: /Admin/EditPost/5
        public ActionResult EditPost(int id)
        {
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }

            ViewBag.Title = "Edit Post";
            return View(post);
        }

        // POST: /Admin/EditPost/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = System.Data.Entity.EntityState.Modified;
                // Preserve the original creation date
                db.Entry(post).Property(p => p.CreatedDate).IsModified = false;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }
    }
}