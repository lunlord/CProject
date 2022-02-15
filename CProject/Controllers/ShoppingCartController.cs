using CProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CProject.Controllers
{
    [Authorize(Roles = "Wholesaler, Director")]
    public class ShoppingCartController : Controller
    {
        private readonly UserContext _context;

        public ShoppingCartController(UserContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ShoppingCarts.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCarts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoppingCart = await _context.ShoppingCarts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return View(shoppingCart);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoppingCart = await _context.ShoppingCarts.FindAsync(id);
            int idProdSc = shoppingCart.IdProduct;

            var product = await _context.Products.FindAsync(idProdSc);
            int idProduct = product.Id;

            if (idProduct == idProdSc)
            {
                product.StatusId = 1;
                _context.ShoppingCarts.Remove(shoppingCart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> СonfirmPurchase()
        {
            int queryId = await _context.Database.ExecuteSqlRawAsync("SELECT Id FROM Products");
            int queryIdProducts = await _context.Database.ExecuteSqlRawAsync("SELECT IdProduct FROM ShoppingCarts");
            int status2 = 2;
            int status3 = 3;

            int query1 = await _context.Database.ExecuteSqlRawAsync("UPDATE Products SET StatusId={0} WHERE {1} = {2} AND StatusId={3} ", status3, queryId, queryIdProducts, status2);

            string query2 = "DELETE FROM ShoppingCarts";
            var rowCount2 = await _context.Database.ExecuteSqlRawAsync(query2);
            return RedirectToAction(nameof(Index));
        }

        private bool ShoppingCartExists(int id)
        {
            return _context.ShoppingCarts.Any(e => e.Id == id);
        }
    }
}