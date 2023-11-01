using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TiendaElectronica.Core;

namespace GUI;

public class App : Application
{
    public ArchivoReparaciones ArchivoReparaciones { get; } = new();

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            if (ArchivoReparaciones.Count > 0)
                desktop.MainWindow = new ListWindow { ArchivoReparaciones = ArchivoReparaciones };
            else
                desktop.MainWindow = new WelcomeWindow { ArchivoReparaciones = ArchivoReparaciones };

        base.OnFrameworkInitializationCompleted();
    }
}