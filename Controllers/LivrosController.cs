using eLibrary1.Models;
using eLibrary1.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var livros = this.Banco.Livros.ToList();
            var editoras = this.Banco.Editoras.ToList();
            var assuntos = this.Banco.Assuntos.ToList();
            var categorias = this.Banco.Categorias.ToList();

            var model = new LivroViewModel(livros, categorias, editoras, assuntos);

            return View(model);
        }
        public IActionResult Create()
        {
            ViewBag.EditoraID = new SelectList (
                this.Banco.Editoras.ToList(),
                "EditoraID",
                "Nome"
                );

                ViewBag.CategoriaID = new SelectList (
                this.Banco.Categorias.ToList(),
                "CategoriaID",
                "Nome"
                );

                ViewBag.AssuntoID = new SelectList (
                this.Banco.Assuntos.ToList(),
                "AssuntoID",
                "Nome"
                );
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Livro livro, string editoraId, string categoriaId, string assuntoId)
        {
            if (ModelState.IsValid)
            {
                this.Banco.Livros.Add(livro);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
             ViewBag.EditoraID = new SelectList (
                this.Banco.Editoras.ToList(),
                "EditoraID",
                "Nome",
                editoraId
                );

                ViewBag.CategoriaID = new SelectList (
                this.Banco.Categorias.ToList(),
                "CategoriaID",
                "Nome",
                categoriaId
                );

                ViewBag.AssuntoID = new SelectList (
                this.Banco.Assuntos.ToList(),
                "AssuntoID",
                "Nome",
                assuntoId
                );
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