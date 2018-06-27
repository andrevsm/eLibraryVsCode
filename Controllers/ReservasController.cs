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
using eLibrary1.Controllers;
using System.Text;
using System.Text.Encodings.Web;
using eLibrary1.Models.ManageViewModels;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Index() {
            var livros = this.Banco.Livros.ToList();                    
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            List<Reserva> reservas = this.Banco.Reservas.Where(r => r.UserID == userId).ToList();
            
            List<Reserva> reservasUser = new List<Reserva>();
            for (int i = 0; i < reservas.Count; i++) {
                if(reservas[i].UserID.Equals(userId)) {
                    reservasUser.Add(reservas[i]);
                }
            }

            var model = new ReservasViewModel(livros, reservasUser);

            return View(model);
        }

        public IActionResult Reservar(int livroId)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                var livro = this.Banco.Livros.FirstOrDefault(_ => _.LivroID == livroId);
                
                Reserva reserva = new Reserva();   
                
                reserva.LivroID = livroId;
                reserva.UserID = userId;
                reserva.Data = System.DateTime.Now;
                
                this.Banco.Entry(livro).State = EntityState.Modified;
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

        public IActionResult HistoricoReservas(){
            var livros = this.Banco.Livros.ToList();
            var reservas = this.Banco.Reservas.ToList();
            var model = new ReservasViewModel(livros, reservas);
            return View(model);
        }
    }
}