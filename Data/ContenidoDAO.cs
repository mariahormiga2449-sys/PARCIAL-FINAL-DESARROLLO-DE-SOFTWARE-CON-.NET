using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using RegistroPeliculasAvalonia.Models;
namespace RegistroPeliculasAvalonia.Data;
public class ContenidoDAO
{
    private readonly string cadenaConexion = "Data Source=contenido.db";
    public List<Contenido> ObtenerTodos()
    {
        List<Contenido> contenidos = new List<Contenido>();
        using (var conexion = new SqliteConnection(cadenaConexion))
        {
            conexion.Open();
            string consulta = @"
                SELECT Id, Titulo, Tipo, Genero, Anio
                FROM Contenido
                ORDER BY Id;";
            using (var comando = new SqliteCommand(consulta, conexion))
            using (var lector = comando.ExecuteReader())
            {
                while (lector.Read())
                {
                    Contenido contenido = new Contenido
                    {
                        Id = lector.GetInt32(0),
                        Titulo = lector.GetString(1),
                        Tipo = lector.GetString(2),
                        Genero = lector.GetString(3),
                        Anio = lector.GetInt32(4)
                    };
                    contenidos.Add(contenido);
                }
            }
        }
        return contenidos;
    }
    public void Guardar(Contenido contenido)
    {
        using (var conexion = new SqliteConnection(cadenaConexion))
        {
            conexion.Open();

            string consulta = @"
                INSERT INTO Contenido (Titulo, Tipo, Genero, Anio)
                VALUES (@Titulo, @Tipo, @Genero, @Anio);";

            using (var comando = new SqliteCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@Titulo", contenido.Titulo);
                comando.Parameters.AddWithValue("@Tipo", contenido.Tipo);
                comando.Parameters.AddWithValue("@Genero", contenido.Genero);
                comando.Parameters.AddWithValue("@Anio", contenido.Anio);

                comando.ExecuteNonQuery();
            }
        }
    }
    public void Modificar(Contenido contenido)
    {
        using (var conexion = new SqliteConnection(cadenaConexion))
        {
            conexion.Open();

            string consulta = @"
                UPDATE Contenido
                SET Titulo = @Titulo,
                    Tipo = @Tipo,
                    Genero = @Genero,
                    Anio = @Anio
                WHERE Id = @Id;";

            using (var comando = new SqliteCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@Titulo", contenido.Titulo);
                comando.Parameters.AddWithValue("@Tipo", contenido.Tipo);
                comando.Parameters.AddWithValue("@Genero", contenido.Genero);
                comando.Parameters.AddWithValue("@Anio", contenido.Anio);
                comando.Parameters.AddWithValue("@Id", contenido.Id);

                comando.ExecuteNonQuery();
            }
        }
    }
    public void Eliminar(int id)
    {
        using (var conexion = new SqliteConnection(cadenaConexion))
        {
            conexion.Open();

            string consulta = @"
                DELETE FROM Contenido
                WHERE Id = @Id;";

            using (var comando = new SqliteCommand(consulta, conexion))
            {
                comando.Parameters.AddWithValue("@Id", id);

                comando.ExecuteNonQuery();
            }
        }
    }
}
