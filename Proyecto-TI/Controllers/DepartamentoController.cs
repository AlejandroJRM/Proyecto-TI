﻿using Datos;
using Modelos;
using Datos.Repositorio.IRepositorio;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_TI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly IRepositorioDepartamento _departamentoRepositorio;

        public DepartamentoController(IRepositorioDepartamento departamentoRepositorio)
        {
            _departamentoRepositorio = departamentoRepositorio;
        }

        // GET: Index
        public IActionResult Index()
        {
            IEnumerable<Departamento> lista = _departamentoRepositorio.ObtenerTodos();
            return View(lista);
        }

        // GET: Upsert
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                // Crear nuevo departamento
                return View(new Departamento());
            }
            else
            {
                // Editar departamento existente
                var departamento = _departamentoRepositorio.Obtener(id.GetValueOrDefault());
                if (departamento == null)
                {
                    return NotFound();
                }
                return View(departamento);
            }
        }

        // POST: Upsert
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                // Nuevo registro
                if (departamento.IdDepartamento == 0)
                {
                    _departamentoRepositorio.Agregar(departamento);
                }
                // Actualización
                else
                {
                    _departamentoRepositorio.Actualizar(departamento);
                }

                _departamentoRepositorio.GuardarCambios();
                return RedirectToAction(nameof(Index));
            }

            return View(departamento);
        }

        // GET: Eliminar
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var departamento = _departamentoRepositorio.Obtener(id.GetValueOrDefault());
            if (departamento == null)
            {
                return NotFound();
            }

            return View(departamento);
        }

        // POST: Eliminar
        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarConfirmado(int id)
        {
            var departamento = _departamentoRepositorio.Obtener(id);
            if (departamento == null)
            {
                return NotFound();
            }

            _departamentoRepositorio.Remover(departamento);
            _departamentoRepositorio.GuardarCambios();
            return RedirectToAction(nameof(Index));
        }
    }
}
