using System;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class AddDatosTelevision : AparatoCreator
{
    public AddDatosTelevision()
    {
        InitializeComponent();
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