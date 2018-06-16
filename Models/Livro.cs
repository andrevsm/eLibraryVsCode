using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eLibrary1.Models
{
    public class Livro
    {
        [Key]
        public int LivroID { get; set; }
        public string Titulo { get; set; }
        public int ISBN { get; set; }
        public int Paginas { get; set; }
        public int Edicao { get; set; }  
        public string Autor { get; set; }
        public int Ano { get; set; }
        public string Origem { get; set; }
        public string Idioma { get; set; }
        public int CategoriaID { get; set; }
        
        [ForeignKey("CategoriaID")]
        public virtual Categoria _Categoria { get; set; }
        public int EditoraID { get; set; }
        
        [ForeignKey("EditoraID")]
        public virtual Editora _Editora { get; set; }
        public int AssuntoID { get; set; }
        
        [ForeignKey("AssuntoID")]
        public virtual Assunto _Assunto { get; set; }
    }
}