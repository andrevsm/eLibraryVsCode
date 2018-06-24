using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using eLibrary1.Models;
using eLibrary1.Models.AccountViewModels;
using eLibrary1.Services;
using eLibrary1.Data;

namespace eLibrary1.Controllers
{
    public class ReservasController : Controller
    {
        public BancoDbContext Banco { get; set; }
        public ApplicationDbContext UserBanco { get; set; }
        

        public ReservasController(BancoDbContext banco)
        {
            this.Banco = banco;
        }

        public IActionResult Reservar(int livroId)
        {
            if (ModelState.IsValid)
            {
                Reserva reserva = new Reserva();   
                var livro = this.Banco.Livros.FirstOrDefault(_ => _.LivroID == livroId);
                
                reserva.LivroID = livro.LivroID;

                this.Banco.Reservas.Add(reserva);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var reserva = this.Banco.Reservas.FirstOrDefault(_ => _.ReservaID == id);
            if (reserva != null)
            {
                this.Banco.Remove(reserva);
                this.Banco.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}