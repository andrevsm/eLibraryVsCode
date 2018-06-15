using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eLibrary1.Models
{
    public class Livro
    {
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
        public Categoria _Categoria { get; set; }
        public int EditoraID { get; set; }
        public Editora _Editora { get; set; }
        public int AssuntoID { get; set; }
        public Assunto _Assunto { get; set; }
    }
}