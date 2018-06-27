using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using eLibrary1.Models;
using System.ComponentModel.DataAnnotations;

namespace eLibrary1.Models
{
    public class ReservasViewModel
    {
        public ReservasViewModel(List<Livro> livros, List<Reserva> reservas)
        {
            this.Livros = livros;
            this.Reservas = reservas;
            }

        public List<Livro> Livros { get; set; }
        public List<Reserva> Reservas { get; set; }
    }
}