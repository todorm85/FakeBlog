using System;
using System.Web.Mvc;
using CyberPost.Models;

namespace CyberPost.Controllers
{
    public class CommentController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Comment comment)
        {
            if (ModelState.IsValid)
            {
                comment.CreatedDate = DateTime.Now;
                db.Comments.Add(comment);
                
                try
                {
                    db.SaveChanges();
                    TempData["CommentSuccess"] = "Your comment has been posted successfully.";
                }
                catch (Exception)
                {
                    TempData["CommentError"] = "An error occurred while posting your comment.";
                }
                
                return RedirectToAction("Details", "Home", new { id = comment.PostId });
            }
            
            // If we got this far, something failed
            TempData["CommentError"] = "Please correct the errors and try again.";
            return RedirectToAction("Details", "Home", new { id = comment.PostId });
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
