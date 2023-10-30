using System;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class AddDatosReprDVD : AparatoCreator
{
    public AddDatosReprDVD()
    {
        InitializeComponent();
        DataContext = this;
    }

    public bool BlueRay { get; set; } = false;

    public override bool Validated { get; }

    public override Aparato CreateAparato(uint numeroSerie, string modelo)
    {
        return new ReproductorDVD
        {
            Modelo = modelo,
            NumeroSerie = numeroSerie,
            TiempoGrabacion = (double)(TiempoGrabacionTxt.Value ?? 0),
            BlueRay = BlueRay
        };
    }

    public override void HighlightErrors()
    {
        throw new NotImplementedException();
    }
}