using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class AddSelecTipo : ValidableUserControl
{
    private readonly List<Button> botones = new();

    private readonly ImmutableDictionary<string, Type> tipos = new Dictionary<string, Type>
    {
        { "Adaptador TDT", typeof(AdaptadorTDT) },
        { "Radio", typeof(Radio) },
        { "Reproductor DVD", typeof(ReproductorDVD) },
        { "Televisor", typeof(Televisor) }
    }.ToImmutableDictionary();

    public AddSelecTipo()
    {
        InitializeComponent();
        //AparatoTipoSelect.ItemsSource = tipos.Keys;
        botones.Add(RadioBtn);
        botones.Add(TelevisionBtn);
        botones.Add(AdaptadorTDTBtn);
        botones.Add(ReproductorDVDBtn);
    }

    public Button? Selected { get; private set; }

    public override bool Validated => Selected == null;

    public ValidableUserControl GetNextStageControl()
    {
        if (Selected == RadioBtn) return new AddDatosRadio();
        if (Selected == TelevisionBtn) return new AddDatosTelevision();
        if (Selected == AdaptadorTDTBtn) return new AddDatosAdaptadorTDT();
        if (Selected == ReproductorDVDBtn) return new AddDatosReprDVD();
        throw new InvalidSelectedButton();
    }

    public void SelectTipo(object? sender, RoutedEventArgs e)
    {
        if (sender == null) return;
        var btnSender = (Button)sender;
        if (Selected != null) Selected.Background = Brushes.LightGray;
        Selected = btnSender;
        btnSender.Background = Brushes.NavajoWhite;
    }

    public override void HighlightErrors()
    {
        foreach (var boton in botones)
        {
            boton.Background = Brushes.NavajoWhite;
            var _ = new Timer(obj =>
            {
                foreach (var btn in (List<Button>)obj) btn.Background = Brushes.LightGray;
            }, botones, 0, 1000);
        }
    }

    public class InvalidSelectedButton : ApplicationException
    {
    }
}