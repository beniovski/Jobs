using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using JobsPortal.ViewModels;
using Microsoft.AspNet.Identity;

namespace JobsPortal.Controllers
{
    public partial class AccountController : Controller
    {
        
        [HttpPost]
        public async Task<ActionResult> AddLogo(HttpPostedFileBase file)
        {
            CompanyViewModel cvm = new CompanyViewModel();
            cvm.ApplicationUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            var fileExt = Path.GetExtension(file.FileName).ToLower();
            var path = "";
            if (file != null && file.ContentLength >0 && fileExt == ".jpg")
            {               

                 path = Path.Combine(Server.MapPath("~/Content/Images/"), file.FileName);
                 file.SaveAs(path);
                 ViewBag.UploadSuccess = true;

                var appUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                appUser.LogoPath = $"~/Content/Images/{file.FileName}";
                await UserManager.UpdateAsync(appUser);

            }     


            return View("CompanyDescription", cvm);
        }

        public async Task<ActionResult> DeleteLogo()
        {
            CompanyViewModel cvm = new CompanyViewModel();
            cvm.ApplicationUser = await UserManager.FindByIdAsync(User.Identity.GetUserId());

            var path = Path.Combine(Server.MapPath(cvm.ApplicationUser.LogoPath));
            FileInfo Fi = new FileInfo(path);
            Fi.Delete();

            cvm.ApplicationUser.LogoPath = @"~\Content\Images\default.jpg";
            UserManager.Update(cvm.ApplicationUser);                 


            return View("CompanyDescription", cvm);
        }
    }
     
}