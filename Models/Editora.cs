using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eLibrary1.Models
{
    public class Editora
    {
        [Key]
        public int EditoraID { get; set; }
        public string Nome { get; set; }

    }
}