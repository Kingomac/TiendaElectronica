using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using GUI.AddWindowStaged;
using TiendaElectronica.Core;
using TiendaElectronica.Core.Reparaciones;

namespace GUI;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public ArchivoReparaciones ArchivoReparaciones { get; set; } = new();

    private void Control_OnLoaded(object? sender, RoutedEventArgs e)
    {
        foreach (var rep in ArchivoReparaciones) AparatosList.Items.Add(rep);
    }

    private void AparatosList_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var rep = (Reparacion)e.AddedItems[0];
        if (rep == null) Debug.WriteLine("rep is null on selectionChanged");
        HorasTrabajadasTxt.Text = rep.HorasTrabajadas.ToString();
        CostePiezasTxt.Text = rep.CostePiezas.ToString();
        NumeroSerieTxt.Text = rep.Dispositivo.NumeroSerie.ToString();
        ModeloTxt.Text = rep.Dispositivo.Modelo;
        PrecioReparacionHoraTxt.Text = rep.Dispositivo.PrecioReparacionHora.ToString();
    }

    private async void AddBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var addWindow = new AddWindow(rep =>
        {
            ArchivoReparaciones.Add(rep);
            AparatosList.Items.Add(rep);
        });
        await addWindow.ShowDialog(this);
    }
}