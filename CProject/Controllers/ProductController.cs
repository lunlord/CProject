using CProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CProject.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly UserContext _context;

        public ProductController(UserContext context)
        {
            _context = context;
        }

        // GET: Product
        public async Task<IActionResult> Index(int? id, int? status, string name)
        {
            IQueryable<Product> products = _context.Products.Include(p => p.Manufacturer).Include(p => p.Status);

            if (id != null && id > 0)
            {
                products = products.Where(p => p.Id == id);
            }
            if (!String.IsNullOrEmpty(name))
            {
                products = products.Where(p => p.Name.Contains(name));
            }
            if (status != null && status != 0)
            {
                products = products.Where(p => p.StatusId == status);
            }
            List<Status> statuses = await _context.Statuses.ToListAsync();

            statuses.Insert(0, new Status { Name = "Все", Id = 0 });
            ViewData["StatusId"] = new SelectList(statuses, "Id", "Name");
            return View(await products.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Authorize(Policy = "Storekeeper")]
        public IActionResult Create()
        {
            ViewData["ManufacturerId"] = new SelectList(_context.Companies, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,SectionNumber,CellNumber,ManufacturerId,StatusId,StatusDate")] Product product)
        {
            if (ModelState.IsValid)
            {
                product.StatusId = 1;
                product.StatusDate = DateTime.Now;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Companies, "Id", "Name", product.ManufacturerId);
            return View(product);
        }


        [Authorize(Policy = "Logistician")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["ManufacturerId"] = new SelectList(_context.Companies, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,SectionNumber,CellNumber,ManufacturerId,StatusId,StatusDate")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["ManufacturerId"] = new SelectList(_context.Companies, "Id", "Name", product.ManufacturerId);
            return View(product);
        }

        [Authorize(Policy = "Logistician")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Manufacturer)
                .Include(p => p.Status)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //[HttpPost]
        //public async Task<IActionResult> AddToShoppingCart(Product product)
        //{
        //        ShoppingCart shoppingcart = new ShoppingCart { IdProduct = product.Id, Name = product.Name, Price = product.Price, SectionNumber = product.SectionNumber, CellNumber = product.CellNumber, ManufacturerId = product.ManufacturerId};
        //        _context.Add(shoppingcart);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //}

        [HttpPost]
        [Authorize(Policy = "Wholesaler")]
        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product.StatusId == 1)
            {
                //int status2 = 2;
                product.StatusId = 2;
                //int query = await _context.Database.ExecuteSqlRawAsync("UPDATE Products SET StatusId = {0}", status2);
                ShoppingCart shoppingcart = new ShoppingCart { IdProduct = product.Id, Name = product.Name, Price = product.Price, SectionNumber = product.SectionNumber, CellNumber = product.CellNumber, ManufacturerId = product.ManufacturerId };
                _context.Add(shoppingcart);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}