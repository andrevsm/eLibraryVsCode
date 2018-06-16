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
    public class CategoriasController : Controller
    {
        public BancoDbContext Banco { get; set; }

        public CategoriasController(BancoDbContext banco)
        {
            this.Banco = banco;
        }

        public IActionResult Index()
        {
            return View(this.Banco.Categorias.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                this.Banco.Categorias.Add(categoria);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categoria = this.Banco.Categorias.FirstOrDefault(_ => _.CategoriaID == id);

            if (categoria == null)
            {
                NotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public IActionResult Edit(Categoria categoria)
        {
            if (categoria != null)
            {
                this.Banco.Entry(categoria).State = EntityState.Modified;
                this.Banco.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public IActionResult Delete(int id)
        {
            var categoria = this.Banco.Categorias.FirstOrDefault(_ => _.CategoriaID == id);
            if (categoria != null)
            {
                this.Banco.Remove(categoria);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}