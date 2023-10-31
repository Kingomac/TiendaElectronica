using Avalonia.Media;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class DatosRadio : AparatoCreator
{
    public DatosRadio()
    {
        InitializeComponent();
        DataContext = this;
    }

    public DatosRadio(Radio radio) : this()
    {
        switch (radio.BandasSoportadas)
        {
            case BandasRadio.AM:
                RadioBtn_AM.IsChecked = true;
                break;
            case BandasRadio.FM:
                RadioBtn_FM.IsChecked = true;
                break;
            case BandasRadio.AM_FM:
                RadioBtn_AMFM.IsChecked = true;
                break;
        }
    }

    public DatosRadio(Radio radio, bool isReadOnly) : this(radio)
    {
        RadioBtn_AM.IsEnabled = !isReadOnly;
        RadioBtn_FM.IsEnabled = !isReadOnly;
        RadioBtn_AMFM.IsEnabled = !isReadOnly;
    }

    public bool AM { get; set; }
    public bool FM { get; set; }
    public bool AM_FM { get; set; }

    public override bool Validated => AM || FM || AM_FM;

    public override Aparato CreateAparato(uint numeroSerie, string modelo)
    {
        BandasRadio bandasRadio;
        if (AM) bandasRadio = BandasRadio.AM;
        else if (FM) bandasRadio = BandasRadio.FM;
        else bandasRadio = bandasRadio = BandasRadio.AM_FM;
        return new Radio
        {
            Modelo = modelo,
            NumeroSerie = numeroSerie,
            BandasSoportadas = bandasRadio
        };
    }

    public override void HighlightErrors()
    {
        RadioBtn_AM.BorderBrush = Brushes.DarkRed;
        RadioBtn_FM.BorderBrush = Brushes.DarkRed;
        RadioBtn_AMFM.BorderBrush = Brushes.DarkRed;
    }
}