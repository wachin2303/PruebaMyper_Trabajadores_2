using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public async Task<IActionResult> Index(string genero)
        {
            if(genero==null)
            {
                genero = "";
            }
            List<SelectListItem> gen = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "-Seleccionar Genero-", Value=string.Empty
                },
                new SelectListItem
                {
                    Text="Masculino", Value="M"
                },
                new SelectListItem
                {
                    Text="Femenino", Value="F"
                },
            };
            ViewBag.Listgener = new SelectList(gen, "Value", "Text", genero); ;
            ViewBag.gener = genero;



            var resultados = await _context.SP_Trabajadores.FromSqlRaw("dbo.Selec_trabajador @p0",genero).ToListAsync();
            //return View(await _context.Trabajadores.ToListAsync());
            return View(resultados);
        }

        

        [HttpGet]
        public IActionResult Crear()
        {
            List<SelectListItem> tipodoc = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "-Seleccionar Tipo-", Value=string.Empty
                },
                new SelectListItem
                {
                    Text="DNI", Value="DNI"
                },
                new SelectListItem
                {
                    Text="Carné de Extranjearía", Value="CXE"
                },
                new SelectListItem
                {
                    Text="Pasaporte", Value="PAS"
                }
            };
            ViewBag.typedoc = tipodoc;

            //Departamento

            var departamento = _context.Departamentos.ToList();
            
            var _depList = new List<SelectListItem>();
            _depList.Add(new SelectListItem
            {
                Text = "-Seleccionar Departamento-",
                Value = string.Empty
            });
            foreach (var item in departamento)
            {
                _depList.Add(new SelectListItem
                {
                    Text = item.NombreDepartamento,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.depList = _depList;

            //Provincia

            var provincia = _context.Provincia.ToList();

            var _proList = new List<SelectListItem>();
            _proList.Add(new SelectListItem
            {
                Text = "-Primero Seleccione Departamento-",
                Value = string.Empty
            });
            foreach (var item in provincia)
            {
                _proList.Add(new SelectListItem
                {
                    Text = item.NombreProvincia,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.proList = _proList;

            //Distrito

            var distrito = _context.Distritos.ToList();

            var _disList = new List<SelectListItem>();
            _disList.Add(new SelectListItem
            {
                Text = "-Seleccionar Primero la Provincia-",
                Value = string.Empty
            });
            foreach (var item in distrito)
            {
                _disList.Add(new SelectListItem
                {
                    Text = item.NombreDistrito,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.disList = _disList;

            return View();
        }

        public JsonResult ListProvincia(int IdDep)
        {
            var prov = _context.Provincia.Where(x=>x.IdDepartamento==IdDep).ToList();
            return Json(prov);
        }

        public JsonResult ListDistrito(int IdPro)
        {
            var dist = _context.Distritos.Where(x => x.IdProvincia == IdPro).ToList();
            return Json(dist);
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
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var context = await _context.Trabajadores.FindAsync(id);
            if (context == null)
            {
                return NotFound();
            }
         
            List<SelectListItem> tipodoc = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Text = "-Seleccionar Tipo-", Value=string.Empty
                },
                new SelectListItem
                {
                    Text="DNI", Value="DNI"
                },
                new SelectListItem
                {
                    Text="Carné de Extranjearía", Value="CXE"
                },
                new SelectListItem
                {
                    Text="Pasaporte", Value="PAS"
                }
            };
            ViewBag.typedoc = tipodoc;

            //Departamento

            var departamento = _context.Departamentos.ToList();

            var _depList = new List<SelectListItem>();
            _depList.Add(new SelectListItem
            {
                Text = "-Seleccionar Departamento-",
                Value = string.Empty
            });
            foreach (var item in departamento)
            {
                _depList.Add(new SelectListItem
                {
                    Text = item.NombreDepartamento,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.depList = _depList;

            //Provincia

            var provincia = _context.Provincia.Where(x=>x.IdDepartamento==context.IdDepartamento).ToList();

            var _proList = new List<SelectListItem>();
            _proList.Add(new SelectListItem
            {
                Text = "-Primero Seleccione Departamento-",
                Value = string.Empty
            });
            foreach (var item in provincia)
            {
                _proList.Add(new SelectListItem
                {
                    Text = item.NombreProvincia,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.proList = _proList;

            //Distrito

            var distrito = _context.Distritos.Where(x => x.IdProvincia == context.IdProvincia).ToList();

            var _disList = new List<SelectListItem>();
            _disList.Add(new SelectListItem
            {
                Text = "-Seleccionar Primero la Provincia-",
                Value = string.Empty
            });
            foreach (var item in distrito)
            {
                _disList.Add(new SelectListItem
                {
                    Text = item.NombreDistrito,
                    Value = item.Id.ToString()
                });
            }
            ViewBag.disList = _disList;

            return View(context);
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
