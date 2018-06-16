using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary1.Models
{
    public class Assunto
    {
        [Key]
        public int AssuntoID { get; set; }
        public string Nome { get; set; }
    }
}