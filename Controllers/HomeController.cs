using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlogsSampleApp.Models;
using Microsoft.AspNet.Identity.Owin;

namespace BlogsSampleApp.Controllers
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
            var post = db.Posts.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return HttpNotFound();
            }

            return View(post);
        }
    }
}