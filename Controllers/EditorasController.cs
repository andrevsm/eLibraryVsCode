using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eLibrary1.Models;
using Microsoft.EntityFrameworkCore;

namespace eLibrary1.Controllers
{
    public class EditorasController : Controller
    {
        public BancoDbContext Banco { get; set; }

        public EditorasController(BancoDbContext banco)
        {
            this.Banco = banco;
        }

        public IActionResult Index()
        {
            return View(this.Banco.Editoras.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Editora editora)
        {
            if (ModelState.IsValid)
            {
                this.Banco.Editoras.Add(editora);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editora);
        }

        public IActionResult Edit(int id)
        {
            var editora = this.Banco.Editoras.FirstOrDefault(_ => _.EditoraID == id);

            if (editora == null)
            {
                NotFound();
            }
            return View(editora);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Editora editora)
        {
            if (ModelState.IsValid)
            {
                this.Banco.Entry(editora).State = EntityState.Modified;
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(editora);
        }
        public IActionResult Delete(int id)
        {
            var editora = this.Banco.Editoras.FirstOrDefault(_ => _.EditoraID == id);
            if (editora == null)
            {
                return NotFound();
            }

            this.Banco.Remove(editora);
            return View();
        }
    }
}