using System;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class DatosReprDVD : AparatoCreator
{
    public DatosReprDVD()
    {
        InitializeComponent();
        DataContext = this;
    }

    public DatosReprDVD(ReproductorDVD reproductorDvd) : this()
    {
        TiempoGrabacionTxt.Value = (decimal)reproductorDvd.TiempoGrabacion;
        BlueRayCheck.IsChecked = reproductorDvd.BlueRay;
    }

    public DatosReprDVD(ReproductorDVD reproductorDvd, bool isReadOnly) : this(reproductorDvd)
    {
        TiempoGrabacionTxt.IsReadOnly = isReadOnly;
        BlueRayCheck.IsEnabled = !isReadOnly;
    }

    public bool BlueRay { get; set; } = false;

    public override bool Validated => TiempoGrabacionTxt.Value != null && TiempoGrabacionTxt.Value >= 0;

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