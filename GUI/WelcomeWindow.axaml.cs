using Avalonia.Controls;
using Avalonia.Interactivity;
using GUI.AddWindowStaged;
using TiendaElectronica.Core;

namespace GUI;

public partial class WelcomeWindow : Window
{
    private readonly AddWindow _addWindow;

    public WelcomeWindow()
    {
        InitializeComponent();
        _addWindow = new AddWindow(rep =>
        {
            ArchivoReparaciones.Add(rep);
            var listWindow = new ListWindow
            {
                ArchivoReparaciones = ArchivoReparaciones
            };
            listWindow.Show();
            Close();
        });
    }

    public required ArchivoReparaciones ArchivoReparaciones { get; init; }

    private async void AddReparacionBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        await _addWindow.ShowDialog(this);
    }
}