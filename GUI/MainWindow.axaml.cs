using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using GUI.AddWindowStaged;
using GUI.DatosReparacion;
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
        var rep = (Reparacion)(e.AddedItems[0] ?? throw new Exception());
        BorderDatosReparacion.Child = new DatosReparacionGeneral(rep, true);
        BorderDatosAparatoGeneral.Child = new DatosAparatoGeneral(rep.Dispositivo, true);
        BorderDatosAparatoEspecifico.Child = DatosPanelFactory.Create(rep.Dispositivo, true);
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

    private void MainWindow_OnClosed(object? sender, EventArgs e)
    {
        ArchivoReparaciones.GuardarFichero();
    }
}