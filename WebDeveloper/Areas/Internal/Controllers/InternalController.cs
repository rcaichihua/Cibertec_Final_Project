using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebDeveloper.Controllers;
using WebDeveloper.Models;

namespace WebDeveloper.Areas.Internal.Controllers
{
    [Authorize(Roles ="Admin")]
    public class InternalController : BaseAccountController
    {
        public ActionResult Index()
        {
            return View(UserManager.Users.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(RegisterViewModel model)
        {
            var user = new WebDeveloperUser { UserName = model.Email, Email = model.Email };
            var result= UserManager.Create(user, model.Password);
            if(result.Succeeded)
                return RedirectToAction("Index");
            AddErrors(result);
            return View(model);
        }

        public ActionResult Edit(string id)
        {
            var identity = UserManager.FindById(id);
            if (identity == null) return RedirectToAction("Index");
            var model = new EditLoginViewModel
            {
                UserName=identity.Email                
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identity = UserManager.FindByName(model.UserName);
                if (identity == null) return View(model);
                string resetToken = UserManager.GeneratePasswordResetToken(identity.Id);
                UserManager.ResetPassword(identity.Id, resetToken, model.NewPassword);
                identity.UserName = model.UserName;
                UserManager.Update(identity);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public ActionResult Delete(string id)
        {
            var identity = UserManager.FindById(id);
            if (identity == null) return RedirectToAction("Index");
            var model = new DeleteViewModel
            {
                UserName = identity.Email
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(DeleteViewModel model)
        {
            var identity = UserManager.FindByName(model.UserName);
            if (identity == null) return View(model);
            UserManager.Delete(identity);
            return RedirectToAction("Index");
        }
    }
}