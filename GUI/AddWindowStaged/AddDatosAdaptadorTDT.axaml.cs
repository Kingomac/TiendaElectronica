using System;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class AddDatosAdaptadorTDT : AparatoCreator
{
    public AddDatosAdaptadorTDT()
    {
        InitializeComponent();
    }

    public override bool Validated { get; }

    public override Aparato CreateAparato(uint numeroSerie, string modelo)
    {
        return new AdaptadorTDT
        {
            Modelo = modelo,
            NumeroSerie = numeroSerie,
            TiempoMaximoGrabacion = (double)(TiempoMaximoGrabacionTxt.Value ?? 0)
        };
    }

    public override void HighlightErrors()
    {
        throw new NotImplementedException();
    }
}