namespace RegistroPeliculasAvalonia.Models;
public class Contenido
{
    public int Id { get; set; }
    public string Titulo { get; set; } = "";
    public string Tipo { get; set; } = "";
    public string Genero { get; set; } = "";
    public int Anio { get; set; }
    public Contenido()
    {
    }
    public Contenido(int id, string titulo, string tipo, string genero, int anio)
    {
        Id = id;
        Titulo = titulo;
        Tipo = tipo;
        Genero = genero;
        Anio = anio;
    }
}
