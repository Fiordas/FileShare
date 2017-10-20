using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FileShare.Models;
using FileShare.Utilities;

namespace FileShare.Views.UploadFile
{
    public class IndexModel : PageModel
    {
        private readonly FileShare.Data.ApplicationDbContext _context;

        public IndexModel(FileShare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public FileUpload FileUpload { get; set; }

        public IList<SharedFile> SharedFile { get; private set; }

        public async Task OnGetAsync()
        {
            SharedFile = await _context.SharedFiles.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Perform an initial check to catch FileUpload class
            // attribute violations.
            if (!ModelState.IsValid)
            {
                SharedFile = await _context.SharedFiles.AsNoTracking().ToListAsync();
                return Page();
            }

            var publicFileData =
                await FileHelpers.ProcessFormFile(FileUpload.UploadPublicFile, ModelState);


            // Perform a second check to catch ProcessFormFile method
            // violations.
            if (!ModelState.IsValid)
            {
                SharedFile = await _context.SharedFiles.AsNoTracking().ToListAsync();
                return Page();
            }

            var sharedFile = new SharedFile()
            {
                PublicFile   = publicFileData,
                Size = FileUpload.UploadPublicFile.Length,
                Name = FileUpload.Name,
                UploadDate = DateTime.UtcNow
            };

            _context.SharedFiles.Add(sharedFile);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}