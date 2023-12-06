using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prueba2.Models;

namespace prueba2.Controllers
{
    public class TrabajadoresController : Controller
    {

        private readonly TrabajadoresPruebaContext _context;

        public TrabajadoresController(TrabajadoresPruebaContext context)
        {
            _context = context;
        }

        // GET: TrabajadoresController
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Trabajadores.ToListAsync());
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Crear(Trabajadore trabajadore)
        {
            if (ModelState.IsValid)
            {
                _context.Trabajadores.Add(trabajadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var trabajadore = _context.Trabajadores.Find(id);
            if (trabajadore == null)
            {
                return NotFound();
            }
            return View(trabajadore);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Trabajadore trabajadore)
        {
            if (ModelState.IsValid)
            {
                _context.Update(trabajadore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var context = _context.Trabajadores.Find(id);
            if (context == null)
            {
                return NotFound();
            }
            return View(context);
        }
        [HttpPost, ActionName("Borrar")]
        public async Task<IActionResult> BorrarTrabajador(int? id)
        {
            var context = await _context.Trabajadores.FindAsync(id);
            if (context == null)
            {
                return View();
            }

            _context.Trabajadores.Remove(context);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //// GET: TrabajadoresController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: TrabajadoresController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TrabajadoresController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TrabajadoresController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TrabajadoresController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TrabajadoresController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TrabajadoresController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
