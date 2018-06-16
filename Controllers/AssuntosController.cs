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
    public class AssuntosController : Controller
    {
        public BancoDbContext Banco { get; set; }

        public AssuntosController(BancoDbContext banco)
        {
            this.Banco = banco;
        }

        public IActionResult Index()
        {
            return View(this.Banco.Assuntos.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                this.Banco.Assuntos.Add(assunto);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assunto);
        }

        public IActionResult Edit(int id)
        {
            var assunto = this.Banco.Assuntos.FirstOrDefault(_ => _.AssuntoID == id);

            if (assunto == null)
            {
                NotFound();
            }
            return View(assunto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                this.Banco.Entry(assunto).State = EntityState.Modified;
                this.Banco.SaveChanges();
                return RedirectToAction("/Assuntos/Index");
            }
            return View(assunto);
        }
        public IActionResult Delete(int id)
        {
            var assunto = this.Banco.Assuntos.FirstOrDefault(_ => _.AssuntoID == id);
            if (assunto != null)
            {
                this.Banco.Remove(assunto);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}