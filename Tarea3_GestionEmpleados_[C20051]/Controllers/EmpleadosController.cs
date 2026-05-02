using Microsoft.AspNetCore.Mvc;
using Tarea3_GestionEmpleados__C20051_.Models;
using Tarea3_GestionEmpleados__C20051_.Repositories;

namespace Tarea3_GestionEmpleados__C20051_.Controllers
{
    public class EmpleadosController : Controller
    {
        private readonly IEmpleadoRepo _repo;

        public EmpleadosController(IEmpleadoRepo repo)
        {
            _repo = repo;
        }

        public IActionResult Index(string busqueda = "", int pagina = 1)
        {
            busqueda = busqueda ?? "";

            int tamano = 5;

            var empleados = _repo.ObtenerPaginado(pagina, tamano, busqueda);
            int total = _repo.ContarTotal(busqueda);

            ViewBag.Busqueda = busqueda;
            ViewBag.Pagina = pagina;
            ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamano);
            ViewBag.Total = total;

            return View(empleados);
        }
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                empleado.Activo = true;
                _repo.Agregar(empleado);
                return RedirectToAction("Index");
            }

            return View(empleado);
        }

       
        public IActionResult Edit(int id)
        {
            var empleado = _repo.ObtenerPorId(id);

            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _repo.Actualizar(empleado);
                return RedirectToAction("Index");
            }

            return View(empleado);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleActivo(int id)
        {
            var empleado = _repo.ObtenerPorId(id);

            if (empleado != null)
            {
                empleado.Activo = !empleado.Activo;
                _repo.Actualizar(empleado);
            }

            return RedirectToAction("Index");
        }

      
    }
}
