using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Invigulus.Data.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Invigulus.App.Views.UserAuth
{
    public class UserAuthController : Controller
    {
        private readonly InvigulusContext _context;
        private readonly IWebHostEnvironment _environment;

        // GET: UserAuthController
        public ActionResult Index()
        {
          
            return View();
        }

        public UserAuthController(IWebHostEnvironment hostingEnvironment, InvigulusContext context)
        {
            _environment = hostingEnvironment;
            _context = context;
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            var files = HttpContext.Request.Form.Files;
            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        // Getting File name
                        var fileName = file.FileName;
                        //Unique File Name "Guid"
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());
                        //Get extension
                        var fileExtension = Path.GetExtension(fileName);
                        // Concat File name and extension
                        var newFileName = string.Concat(myUniqueFileName, fileExtension);
                        //Generate path to store photo
                        var filepath = Path.Combine(_environment.WebRootPath, "CameraPhotos") + $@"\{newFileName}";


                        if (!string.IsNullOrEmpty(filepath))
                        {
                            StoreInFolder(file, filepath);
                        }

                        var imageBytes = System.IO.File.ReadAllBytes(filepath);
                        if (imageBytes != null)
                        {
                            StoreInDatabase(imageBytes);
                        }
                    }
                }
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }

        ///// <summary>  
        ///// Saving captured image into Folder.  
        ///// </summary>  
        ///// <param name="file"></param>  
        ///// <param name="fileName"></param> 
        private void StoreInFolder(IFormFile file, string fileName)
        {
            using (FileStream fs = System.IO.File.Create(fileName))
            {
                file.CopyTo(fs);
                fs.Flush();
            }
        }

        /// <summary>  
        /// Saving captured image into database.  
        /// </summary>  
        /// <param name="imageBytes"></param>  
        private void StoreInDatabase(byte[] imageBytes)
        {
            try
            {
                if (imageBytes != null)
                {
                    string base64String = Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                    string imageUrl = string.Concat("data:image/jpg;base64,", base64String);

                    //ImageStore imageStore = new ImageStore()
                    //{
                    //    CreateDate = DateTime.Now,
                    //    ImageBase64String = imageUrl,
                    //    ImageId = 0
                    //};

                    UserSession imageStore = new UserSession()
                    {
                        ImageStore = imageUrl
                    };

                    _context.UserSession.Add(imageStore);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
