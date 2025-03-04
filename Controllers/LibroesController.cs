using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BibliotecaWeb.Models;

namespace BibliotecaWeb.Controllers
{
    public class LibroesController : Controller
    {
        private readonly AppDbContext _context;

        public LibroesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Libroes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Libros.Include(l => l.IdAutorNavigation).Include(l => l.IdGeneroNavigation);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Libroes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.IdGeneroNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // GET: Libroes/Create
        public IActionResult Create()
        {
            // Crear una lista de autores con el nombre completo
            var autores = _context.Autors
                .Select(a => new
                {
                    IdAutor = a.IdAutor,
                    NombreCompleto = $"{a.Nombre} {a.Apellido}"
                })
                .ToList();

            ViewData["IdAutor"] = new SelectList(autores, "IdAutor", "NombreCompleto");
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre");
            return View();
        }

        // POST: Libroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLibro,Titulo,Idioma,AñoPublicacion,IdGenero,IdAutor")] Libro libro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(libro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // Crear la lista de autores con el nombre completo
            var autores = _context.Autors
                .Select(a => new
                {
                    IdAutor = a.IdAutor,
                    NombreCompleto = $"{a.Nombre} {a.Apellido}"
                })
                .ToList();

            ViewData["IdAutor"] = new SelectList(autores, "IdAutor", "NombreCompleto", libro.IdAutor);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", libro.IdGenero);
            return View(libro);
        }

        // GET: Libroes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }

            // Crear la lista de autores con el nombre completo
            var autores = _context.Autors
                .Select(a => new
                {
                    IdAutor = a.IdAutor,
                    NombreCompleto = $"{a.Nombre} {a.Apellido}"
                })
                .ToList();

            ViewData["IdAutor"] = new SelectList(autores, "IdAutor", "NombreCompleto", libro.IdAutor);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", libro.IdGenero);
            return View(libro);
        }

        // POST: Libroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLibro,Titulo,Idioma,AñoPublicacion,IdGenero,IdAutor")] Libro libro)
        {
            if (id != libro.IdLibro)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(libro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibroExists(libro.IdLibro))
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

            // Crear la lista de autores con el nombre completo
            var autores = _context.Autors
                .Select(a => new
                {
                    IdAutor = a.IdAutor,
                    NombreCompleto = $"{a.Nombre} {a.Apellido}"
                })
                .ToList();

            ViewData["IdAutor"] = new SelectList(autores, "IdAutor", "NombreCompleto", libro.IdAutor);
            ViewData["IdGenero"] = new SelectList(_context.Generos, "IdGenero", "Nombre", libro.IdGenero);
            return View(libro);
        }

        // GET: Libroes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var libro = await _context.Libros
                .Include(l => l.IdAutorNavigation)
                .Include(l => l.IdGeneroNavigation)
                .FirstOrDefaultAsync(m => m.IdLibro == id);
            if (libro == null)
            {
                return NotFound();
            }

            return View(libro);
        }

        // POST: Libroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro != null)
            {
                _context.Libros.Remove(libro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.IdLibro == id);
        }
    }
}
