using System;
using System.Xml;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using TiendaElectronica.Core;

namespace GUI;

public class App : Application
{
    private readonly Exception? _xmlException;

    public App()
    {
        try
        {
            ArchivoReparaciones = new ArchivoReparaciones();
        }
        catch (XmlException e)
        {
            ArchivoReparaciones = null;
            _xmlException = e;
        }
    }

    public ArchivoReparaciones? ArchivoReparaciones { get; }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            if (ArchivoReparaciones is null)
                desktop.MainWindow = new XmlError(_xmlException!);
            else if (ArchivoReparaciones.Count > 0)
                desktop.MainWindow = new ListWindow { ArchivoReparaciones = ArchivoReparaciones };
            else
                desktop.MainWindow = new WelcomeWindow { ArchivoReparaciones = ArchivoReparaciones };
        }

        base.OnFrameworkInitializationCompleted();
    }
}