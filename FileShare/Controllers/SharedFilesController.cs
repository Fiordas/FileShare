using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FileShare.Data;
using FileShare.Models;

namespace FileShare.Controllers
{
    public class SharedFilesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SharedFilesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SharedFiles
        public async Task<IActionResult> Index()
        {
            return View(await _context.SharedFiles.ToListAsync());
        }

        // GET: SharedFiles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharedFile = await _context.SharedFiles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sharedFile == null)
            {
                return NotFound();
            }

            return View(sharedFile);
        }

        // GET: SharedFiles/Create
        public IActionResult UploadFile()
        {
            return View();
        }

        // GET: SharedFiles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SharedFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,UploadDate,Category,Rating,Size,Uploader")] SharedFile sharedFile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sharedFile);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sharedFile);
        }

        // GET: SharedFiles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharedFile = await _context.SharedFiles.SingleOrDefaultAsync(m => m.ID == id);
            if (sharedFile == null)
            {
                return NotFound();
            }
            return View(sharedFile);
        }

        // POST: SharedFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,UploadDate,Category,Rating,Size,Uploader")] SharedFile sharedFile)
        {
            if (id != sharedFile.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sharedFile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SharedFileExists(sharedFile.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(sharedFile);
        }

        // GET: SharedFiles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sharedFile = await _context.SharedFiles
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sharedFile == null)
            {
                return NotFound();
            }

            return View(sharedFile);
        }

        // POST: SharedFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sharedFile = await _context.SharedFiles.SingleOrDefaultAsync(m => m.ID == id);
            _context.SharedFiles.Remove(sharedFile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SharedFileExists(int id)
        {
            return _context.SharedFiles.Any(e => e.ID == id);
        }
    }
}
