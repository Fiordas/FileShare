using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FileShare.Models
{
    public class FileUpload
    {
        [Required]
        [Display(Name = "Name")]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Select file")]
        public IFormFile UploadPublicFile { get; set; }

    }
}