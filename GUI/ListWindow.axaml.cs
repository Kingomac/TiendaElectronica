using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using GUI.AddWindowStaged;
using GUI.DatosReparacion;
using TiendaElectronica.Core;
using TiendaElectronica.Core.Reparaciones;

namespace GUI;

public partial class ListWindow : Window
{
    public ListWindow()
    {
        InitializeComponent();
    }

    public required ArchivoReparaciones ArchivoReparaciones { get; init; }

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

    private void MenuPanelBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (SplitView.DisplayMode == SplitViewDisplayMode.Inline)
        {
            SplitView.DisplayMode = SplitViewDisplayMode.CompactInline;
            SplitView.OpenPaneLength = 50;
            SmallMenu.IsVisible = true;
            BigMenu.IsVisible = false;
        }
        else
        {
            SplitView.DisplayMode = SplitViewDisplayMode.Inline;
            SplitView.OpenPaneLength = 300;
            SmallMenu.IsVisible = false;
            BigMenu.IsVisible = true;
        }
    }

    private void DeleteBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        var selected = (Reparacion)AparatosList.SelectedItem;
        ArchivoReparaciones.Remove(selected);
        AparatosList.Items.Remove(selected);
    }
}