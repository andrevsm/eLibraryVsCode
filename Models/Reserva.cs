using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eLibrary1.Models
{
    public class Reserva
    {
        [Key]
        public int ReservaID { get; set; }
        public int LivroID { get; set; }
        public virtual Livro _Livro { get; set; }
        public string UserID { get; set; }
        public DateTime Data { get; set; }
    }
}