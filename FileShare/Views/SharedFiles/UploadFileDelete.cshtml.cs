using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FileShare.Models;

namespace FileShare.Views.SharedFiles
{
    public class DeleteModel : PageModel
    {
        private readonly FileShare.Data.ApplicationDbContext _context;

        public DeleteModel(FileShare.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SharedFile SharedFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SharedFile = await _context.SharedFiles.SingleOrDefaultAsync(m => m.ID == id);

            if (SharedFile == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SharedFile = await _context.SharedFiles.FindAsync(id);

            if (SharedFile != null)
            {
                _context.SharedFiles.Remove(SharedFile);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./UploadFile");
        }
    }
}