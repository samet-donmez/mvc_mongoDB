using Microsoft.AspNetCore.Mvc;
using mvc_mongodb.Data;
using mvc_mongodb.Models;
using System.Threading.Tasks;

namespace mvc_mongodb.Controllers
{
    public class DepartmanController : Controller
    {
        private readonly AppDbContext _context;

        public DepartmanController(AppDbContext context)
        {
            _context = context;
        }

        // Listeleme
        public IActionResult Index()
        {
            var departmanlar = _context.Departmanlar.ToList();
            return View(departmanlar);
        }

        // Oluşturma sayfası
        public IActionResult Create()
        {
            return View();
        }

        // DepartmanController.cs

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DepartmanAd")] Departman departman)
        {
            // Model doğrulaması
            if (!ModelState.IsValid)
            {
                // Debug için burada ModelState'e neyin hata verdiğini kontrol edin.
                // Hata mesajını konsola yazdırın veya bir breakpoint koyun.
                foreach (var state in ModelState)
                {
                    if (state.Value.Errors.Count > 0)
                    {
                        // state.Key (Hatanın olduğu alan adı)
                        // state.Value.Errors.First().ErrorMessage (Hata mesajı)
                        Console.WriteLine($"Hata Alanı: {state.Key}, Hata Mesajı: {state.Value.Errors.First().ErrorMessage}");
                    }
                }
                return View(departman);
            }

            // ... kaydetme işlemleri ...
            try
            {
                _context.Departmanlar.Add(departman);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // ...
                ModelState.AddModelError("", "Departman kaydedilemedi: " + ex.Message);
                return View(departman);
            }

            return RedirectToAction("Index");
        }

        // Detay sayfası
        public IActionResult Details(string id)
        {
            var departman = _context.Departmanlar.Find(id);
            if (departman == null) return NotFound();
            return View(departman);
        }
    }
}
