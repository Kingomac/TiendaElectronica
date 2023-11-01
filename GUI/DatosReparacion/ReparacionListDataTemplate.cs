using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;
using GUI.AddWindowStaged;
using TiendaElectronica.Core.Reparaciones;

namespace GUI.DatosReparacion;

public class ReparacionListDataTemplate : IDataTemplate
{
    public bool HasResources { get; }

    public IReadOnlyList<IStyle> Children { get; }

    public Control? Build(object? param)
    {
        if (param is not Reparacion) return null;
        var rep = (Reparacion)param;
        return new Grid
        {
            ColumnDefinitions = new ColumnDefinitions("25,10,Auto"),
            Margin = new Thickness(0, 0, 10, 0),
            Children =
            {
                new PathIcon
                {
                    Data = AparatoPaths.From(rep.Dispositivo),
                    Width = 30,
                    Height = 30,
                    [Grid.ColumnProperty] = 0
                },
                new TextBlock
                {
                    Text = $"{rep.Dispositivo.NumeroSerie.ToString()} - {rep.Dispositivo.Modelo}",
                    VerticalAlignment = VerticalAlignment.Center,
                    TextAlignment = TextAlignment.Center,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    [Grid.ColumnProperty] = 2
                }
            }
        };
    }

    public bool Match(object? data)
    {
        return data is Reparacion;
    }
}