using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SparesShop2.Data;
using SparesShop2.Models;
using SparesShop2.ViewModels;

namespace SparesShop2.Controllers
{
    public class SparesController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ApplicationDbContext _context;

        public SparesController(IWebHostEnvironment hostingEnvironment, ApplicationDbContext context)
        {
            _hostingEnvironment = hostingEnvironment;
            _context = context;
        }

        // GET: Spares
        public async Task<IActionResult> Index()
        {
            var spares = await _context.Spare.Include(s => s.Character).ToListAsync();
            return View(spares);
        }

        // GET: Spares/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spare = await _context.Spare
                .Include(s => s.Character)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spare == null)
            {
                return NotFound();
            }

            return View(spare);
        }

        // GET: Spares/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["CharacterId"] = new SelectList(_context.Character, "Id", "Name");
            return View();
        }

        // POST: Spares/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpareCreateViewModel spare)
        {
            string uniqueFileName = null;
            if (ModelState.IsValid)
            {
                if(spare.Image != null)
                {
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + spare.Image.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    spare.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                
                Spare newSpare = new Spare
                {
                    Name = spare.Name,
                    Cost = spare.Cost,
                    Character = spare.Character,
                    CharacterId = spare.CharacterId,
                    ImagePath = uniqueFileName
                };


                _context.Add(newSpare);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CharacterId"] = new SelectList(_context.Character, "Id", "Name", spare.CharacterId);
            return View(spare);
        }

        // GET: Spares/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spare = await _context.Spare.FindAsync(id);
            if (spare == null)
            {
                return NotFound();
            }

            ViewData["CharacterId"] = new SelectList(_context.Character, "Id", "Name", spare.CharacterId);
            return View(spare);
        }

        // POST: Spares/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Cost,CharacterId,ImagePath")] Spare spare)
        {
            if (id != spare.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spare);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpareExists(spare.Id))
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
            ViewData["CharacterId"] = new SelectList(_context.Character, "Id", "Name", spare.CharacterId);
            return View(spare);
        }

        // GET: Spares/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spare = await _context.Spare
                .Include(s => s.Character)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spare == null)
            {
                return NotFound();
            }

            return View(spare);
        }

        // POST: Spares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spare = await _context.Spare.FindAsync(id);
            _context.Spare.Remove(spare);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpareExists(int id)
        {
            return _context.Spare.Any(e => e.Id == id);
        }
    }
}
