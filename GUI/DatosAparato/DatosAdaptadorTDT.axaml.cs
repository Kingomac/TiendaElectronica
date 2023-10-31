using System.Threading;
using Avalonia.Media;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public partial class DatosAdaptadorTDT : AparatoCreator
{
    public DatosAdaptadorTDT()
    {
        InitializeComponent();
    }

    public DatosAdaptadorTDT(AdaptadorTDT adaptadorTdt) : this()
    {
        TiempoMaximoGrabacionTxt.Value = (decimal)adaptadorTdt.TiempoMaximoGrabacion;
    }

    public DatosAdaptadorTDT(AdaptadorTDT adaptadorTdt, bool isReadOnly) : this(adaptadorTdt)
    {
        TiempoMaximoGrabacionTxt.IsReadOnly = isReadOnly;
    }

    public override bool Validated => TiempoMaximoGrabacionTxt.Value != null && TiempoMaximoGrabacionTxt.Value >= 0;

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
        TiempoMaximoGrabacionTxt.BorderBrush = Brushes.DarkRed;
        new Timer(_ => { TiempoMaximoGrabacionTxt.BorderBrush = Brushes.LightGray; }, null, 1000, Timeout.Infinite);
    }
}