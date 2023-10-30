using System;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class DatosTelevision : AparatoCreator
{
    public DatosTelevision()
    {
        InitializeComponent();
    }

    public DatosTelevision(Televisor televisor) : this()
    {
        PulgadasTxt.Value = (decimal?)televisor.Pulgadas;
    }

    public DatosTelevision(Televisor televisor, bool isReadOnly) : this(televisor)
    {
        PulgadasTxt.IsReadOnly = isReadOnly;
    }

    public override bool Validated { get; }

    public override Aparato CreateAparato(uint numeroSerie, string modelo)
    {
        return new Televisor
        {
            Modelo = modelo,
            NumeroSerie = numeroSerie,
            Pulgadas = (double)(PulgadasTxt.Value ?? 0)
        };
    }

    public override void HighlightErrors()
    {
        throw new NotImplementedException();
    }
}