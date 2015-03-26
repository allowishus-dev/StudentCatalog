using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentCatalogFresh.Models
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "Must fill in Firstname")]
        public String Firstname { get; set; }

        [Required]
        public String Lastname { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        [Required]
        [Display(Name = "Mobile Phone")]
        [MinLength(8, ErrorMessage = "The {0} must have a {1} digits")]
        [MaxLength(8, ErrorMessage = "The {0} must have a {1} digits")]
        public String MobilePhone { get; set; }

        public string ProfileImagePath { get; set; }

        public void SaveImage(HttpPostedFileBase image, string serverPath, string pathToFile)
        {
            if (image == null)
            {
                ProfileImagePath = "UserUploads\\profile.png";
            }
            else
            {
                Guid guid = Guid.NewGuid();
                ImageModel.ResizeAndSave(serverPath + pathToFile, guid.ToString(), image.InputStream, 200);

                ProfileImagePath = pathToFile + guid.ToString() + ".jpg";
                
            }
        }
    }
}