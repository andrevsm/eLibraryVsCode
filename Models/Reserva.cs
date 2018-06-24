using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using eLibrary1.Models;

namespace eLibrary1.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; }
        public int LivroID { get; set; }
        public virtual Livro _Livro { get; set; }
        public string UserID { get; set; }
        public virtual ApplicationUser _ApplicationUser { get; set; }
    }
}