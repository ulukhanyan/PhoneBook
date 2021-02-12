using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Data;
using PhoneBook.Models;

namespace PhoneBook.Controllers
{
    public class EmailController : Controller
    {
        private readonly PhoneBookContext _context;

        public EmailController(PhoneBookContext context)
        {
            _context = context;
        }

        // // GET: Email
        // public async Task<IActionResult> Index()
        // {
        //     var phoneBookContext = _context.Emails.Include(e => e.Person);
        //     return View(await phoneBookContext.ToListAsync());
        // }


        // GET: Email/5
        public async Task<IActionResult> Index(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
           
           var phoneBookContext = await _context.Emails.Include(e => e.Person).Where(m => m.PersonEmile == id).ToListAsync();

            return View(phoneBookContext);
        }


        // GET: Email/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Emails
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // GET: Email/Create
        public IActionResult Create()
        {
            ViewData["PersonEmile"] = new SelectList(_context.Persons, "PersonId", "Name");
            return View();
        }

        // POST: Email/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailId,PersonEmile,EmailAddress")] Email email)
        {
            if (ModelState.IsValid)
            {
                _context.Add(email);
                await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
                return RedirectToRoute(new { controller="Person", action="Index"});
               
            }
            ViewData["PersonEmile"] = new SelectList(_context.Persons, "PersonId", "PersonId", email.PersonEmile);
            return View(email);
        }

        // GET: Email/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Emails.FindAsync(id);
            if (email == null)
            {
                return NotFound();
            }
            ViewData["PersonEmile"] = new SelectList(_context.Persons, "PersonId", "Name", email.PersonEmile);
            return View(email);
        }

        // POST: Email/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmailId,PersonEmile,EmailAddress")] Email email)
        {
            if (id != email.EmailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(email);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmailExists(email.EmailId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                //return RedirectToAction(nameof(Index));
                return RedirectToRoute(new { controller="Person", action="Index"});
               
            }
            ViewData["PersonEmile"] = new SelectList(_context.Persons, "PersonId", "PersonId", email.PersonEmile);
            return View(email);
        }

        // GET: Email/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var email = await _context.Emails
                .Include(e => e.Person)
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (email == null)
            {
                return NotFound();
            }

            return View(email);
        }

        // POST: Email/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var email = await _context.Emails.FindAsync(id);
            _context.Emails.Remove(email);
            await _context.SaveChangesAsync();
            //return RedirectToAction(nameof(Index));
            return RedirectToRoute(new { controller="Person", action="Index"});
               
        }

        private bool EmailExists(int id)
        {
            return _context.Emails.Any(e => e.EmailId == id);
        }
    }
}
