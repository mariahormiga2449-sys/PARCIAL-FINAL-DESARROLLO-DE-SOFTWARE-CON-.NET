using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using RegistroPeliculasAvalonia.Data;
using RegistroPeliculasAvalonia.Models;

namespace RegistroPeliculasAvalonia;
public partial class MainWindow : Window
{
    private readonly ContenidoDAO contenidoDAO = new ContenidoDAO();
    public MainWindow()
    {
        InitializeComponent();
        CargarContenido();
    }
    private void CargarContenido()
    {
        try
        {
            tablaContenido.ItemsSource = contenidoDAO.ObtenerTodos();
        }
        catch (Exception ex)
        {
            _ = MostrarMensaje("Error", ex.Message);
        }
    }
        private void TablaContenido_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if (tablaContenido.SelectedItem is Contenido contenido)
        {
            txtTitulo.Text = contenido.Titulo;
            cmbTipo.SelectedIndex = contenido.Tipo == "Película" ? 0 : 1;
            txtGenero.Text = contenido.Genero;
            txtAnio.Text = contenido.Anio.ToString();
        }
    }
        private async void BtnGuardar_Click(object? sender, RoutedEventArgs e)
    {
        string titulo = txtTitulo.Text?.Trim() ?? "";
        string tipo = (cmbTipo.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
        string genero = txtGenero.Text?.Trim() ?? "";
        string textoAnio = txtAnio.Text?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(titulo) ||
            string.IsNullOrWhiteSpace(tipo) ||
            string.IsNullOrWhiteSpace(genero) ||
            string.IsNullOrWhiteSpace(textoAnio))
        {
            await MostrarMensaje("Validación", "Todos los campos son obligatorios.");
            return;
        }
        if (!int.TryParse(textoAnio, out int anio) ||
            anio < 1888 || anio > DateTime.Now.Year)
        {
            await MostrarMensaje("Validación", "Ingrese un año válido.");
            return;
        }
        try
        {
            Contenido nuevoContenido = new Contenido
            {
                Titulo = titulo,
                Tipo = tipo,
                Genero = genero,
                Anio = anio
            };
            contenidoDAO.Guardar(nuevoContenido);
            CargarContenido();
            LimpiarCampos();
            await MostrarMensaje("Registro exitoso", "El contenido se guardó correctamente.");
        }
        catch (Exception ex)
        {
            await MostrarMensaje("Error", ex.Message);
        }
    }
    private async void BtnModificar_Click(object? sender, RoutedEventArgs e)
    {
        if (tablaContenido.SelectedItem is not Contenido contenido)
        {
            await MostrarMensaje("Aviso", "Seleccione un registro de la tabla para modificarlo.");
            return;
        }
        string titulo = txtTitulo.Text?.Trim() ?? "";
        string tipo = (cmbTipo.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "";
        string genero = txtGenero.Text?.Trim() ?? "";
        string textoAnio = txtAnio.Text?.Trim() ?? "";
        if (string.IsNullOrWhiteSpace(titulo) ||
            string.IsNullOrWhiteSpace(tipo) ||
            string.IsNullOrWhiteSpace(genero) ||
            string.IsNullOrWhiteSpace(textoAnio))
        {
            await MostrarMensaje("Validación", "Todos los campos son obligatorios.");
            return;
        }
        if (!int.TryParse(textoAnio, out int anio) ||
            anio < 1888 || anio > DateTime.Now.Year)
        {
            await MostrarMensaje("Validación", "Ingrese un año válido.");
            return;
        }
        try
        {
            contenido.Titulo = titulo;
            contenido.Tipo = tipo;
            contenido.Genero = genero;
            contenido.Anio = anio;
            contenidoDAO.Modificar(contenido);

            CargarContenido();
            LimpiarCampos();

            await MostrarMensaje("Modificación exitosa", "El registro se actualizó correctamente.");
        }
        catch (Exception ex)
        {
            await MostrarMensaje("Error", ex.Message);
        }
    }
    private async void BtnEliminar_Click(object? sender, RoutedEventArgs e)
    {
        if (tablaContenido.SelectedItem is not Contenido contenido)
        {
            await MostrarMensaje("Aviso", "Seleccione un registro de la tabla para eliminarlo.");
            return;
        }
        try
        {
            contenidoDAO.Eliminar(contenido.Id);

            CargarContenido();
            LimpiarCampos();

            await MostrarMensaje("Eliminación exitosa", "El registro se eliminó correctamente.");
        }
        catch (Exception ex)
        {
            await MostrarMensaje("Error", ex.Message);
        }
    }
    private void BtnLimpiar_Click(object? sender, RoutedEventArgs e)
    {
        LimpiarCampos();
    }
    private void LimpiarCampos()
    {
        txtTitulo.Text = "";
        cmbTipo.SelectedIndex = 0;
        txtGenero.Text = "";
        txtAnio.Text = "";
    }
    private async System.Threading.Tasks.Task MostrarMensaje(string titulo, string mensaje)
    {
        var ventana = new Window
        {
            Title = titulo,
            Width = 380,
            Height = 180,
            WindowStartupLocation = WindowStartupLocation.CenterOwner,
            Content = new StackPanel
            {
                Margin = new Avalonia.Thickness(15),
                Spacing = 15,
                Children =
                {
                    new TextBlock
                    {
                        Text = mensaje,
                        TextWrapping = Avalonia.Media.TextWrapping.Wrap
                    },
                    new Button
                    {
                        Content = "Aceptar",
                        HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Right
                    }
                }
            }
        };
        var boton = ((StackPanel)ventana.Content!).Children[1] as Button;
        boton!.Click += (_, _) => ventana.Close();
        await ventana.ShowDialog(this);
    }
}