using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using eLibrary1.Models;
using System.ComponentModel.DataAnnotations;

namespace eLibrary1.Models
{
    public class EditViewModel
    {
        public EditViewModel(Livro livro, List<Categoria> categorias, List<Editora> editoras, List<Assunto> assuntos)
        {
            this.Livro = livro;
            this.Categorias = categorias;
            this.Editoras = editoras;
            this.Assuntos = assuntos;
        }

        public Livro Livro { get; set; }

        [Required(ErrorMessage = "Selecione uma categoria da lista")]
        public List<Categoria> Categorias { get; set; }
        public List<Editora> Editoras { get; set; }
        public List<Assunto> Assuntos { get; set; }
    }
}