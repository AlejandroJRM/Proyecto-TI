﻿using Datos;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using System.Collections.Generic;

namespace Proyecto_TI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public DepartamentoController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Departamento> lista = _db.Departamento;
            return View();
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _db.Departamento.Add(departamento);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Departamento.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                _db.Departamento.Update(departamento);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(departamento);
        }

        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Departamento.Find(id);

            if (obj == null) { return NotFound(); }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Eliminar(Departamento departamento)
        {

            if (departamento == null)
            {
                return NotFound();
            }

            _db.Departamento.Remove(departamento);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }


    }
}
