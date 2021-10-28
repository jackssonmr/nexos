namespace nexos.Models
{
    public class Libro
    {
        public string titulo { get; set; }
        public string anno { get; set; }
        public string genero { get; set; }
        public string numeroPaginas { get; set; }
        public int idAutor { get; set; }
        public int idLibro { get; set; }
    }
}
