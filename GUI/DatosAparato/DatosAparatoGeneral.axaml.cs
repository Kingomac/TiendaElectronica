using Avalonia.Media;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class DatosAparatoGeneral : ValidableUserControl
{
    public DatosAparatoGeneral()
    {
        InitializeComponent();
    }

    public DatosAparatoGeneral(Aparato aparato) : this()
    {
        NumeroSerieTxt.Text = aparato.NumeroSerie.ToString();
        ModeloTxt.Text = aparato.Modelo;
        PrecioPorHoraTxt.IsVisible = PrecioPorHoraLabel.IsVisible = true;
        PrecioPorHoraTxt.Value = (decimal)aparato.PrecioReparacionHora;
    }

    public DatosAparatoGeneral(Aparato aparato, bool isReadOnly) : this(aparato)
    {
        NumeroSerieTxt.IsReadOnly = isReadOnly;
        ModeloTxt.IsReadOnly = isReadOnly;
        PrecioPorHoraTxt.IsReadOnly = isReadOnly;
    }

    public override bool Validated => ValidateNumeroSerie && ValidateModelo;

    private bool ValidateNumeroSerie => NumeroSerieTxt.Text.Length > 0 && double.TryParse(NumeroSerieTxt.Text, out _);
    private bool ValidateModelo => ModeloTxt.Text.Length > 0;

    public override void HighlightErrors()
    {
        if (!ValidateNumeroSerie) NumeroSerieTxt.BorderBrush = Brushes.DarkRed;
        if (!ValidateModelo) ModeloTxt.BorderBrush = Brushes.DarkRed;
    }
}