using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FileShare.Models
{
    public class SharedFile
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public IFormFile File { get; set; }
        [Display(Name = "Upload Date")]
        public DateTime UploadDate { get; set; }
        public string Category { get; set; }
        public float Rating { get; set; }
        [Display(Name = "File Size (bytes)")]
        [DisplayFormat(DataFormatString = "{0:N1}")]
        public long Size { get; set; }
        public string Uploader { get; set; }
    }
}
