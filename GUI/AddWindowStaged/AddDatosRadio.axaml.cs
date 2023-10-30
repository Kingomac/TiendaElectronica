using System;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class AddDatosRadio : AparatoCreator
{
    public AddDatosRadio()
    {
        InitializeComponent();
        DataContext = this;
    }

    public bool AM { get; set; } = false;
    public bool FM { get; set; } = false;
    public bool AM_FM { get; set; } = false;

    public override bool Validated { get; }

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
        throw new NotImplementedException();
    }
}