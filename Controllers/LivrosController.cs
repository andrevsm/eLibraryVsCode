using eLibrary1.Models;
using eLibrary1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace eLibrary1.Controllers
{
    public class LivrosController : Controller
    {
        public BancoDbContext Banco { get; set; }

        public LivrosController(BancoDbContext banco){
            this.Banco = banco;
        }    
        // GET: Livros
        public IActionResult Index()
        {
            return View(this.Banco.Livros.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                this.Banco.Livros.Add(livro);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(livro);
        }
        
        public IActionResult Edit(int id)
          {
        var livro = this.Banco.Livros.FirstOrDefault(_ => _.LivroID == id);

            if (livro == null)
            {
                NotFound();
            }
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Livro liv)
        {
            if (ModelState.IsValid)
            {
                this.Banco.Entry(liv).State = EntityState.Modified;
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(liv);
        }
        public IActionResult Delete(int id)
        {
            var livro = this.Banco.Livros.FirstOrDefault(_ => _.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }

            this.Banco.Remove(livro);
            return View();
        }
    }
}