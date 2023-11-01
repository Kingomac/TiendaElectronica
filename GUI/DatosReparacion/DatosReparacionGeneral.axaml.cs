using Avalonia.Media;
using TiendaElectronica.Core.Reparaciones;

namespace GUI.DatosReparacion;

public partial class DatosReparacionGeneral : ValidableUserControl
{
    public DatosReparacionGeneral()
    {
        InitializeComponent();
    }

    public DatosReparacionGeneral(Reparacion rep) : this()
    {
        HorasTrabajadasTxt.Value = (decimal)rep.HorasTrabajadas;
        CostePiezasTxt.Value = (decimal)rep.CostePiezas;
        TipoReparacionTextBlock.Text = rep switch
        {
            ReparacionSimple _ => "simple",
            ReparacionCompleja _ => "compleja"
        };
        TipoReparacionTextBlock.IsVisible = true;
    }

    public DatosReparacionGeneral(Reparacion rep, bool isReadOnly) : this(rep)
    {
        HorasTrabajadasTxt.IsReadOnly = isReadOnly;
        CostePiezasTxt.IsReadOnly = isReadOnly;
    }

    public override bool Validated => ValidateHorasTrabajadas && ValidateCostePiezas;

    private bool ValidateHorasTrabajadas => HorasTrabajadasTxt.Value != null && HorasTrabajadasTxt.Value >= 0;
    private bool ValidateCostePiezas => CostePiezasTxt.Value != null && CostePiezasTxt.Value >= 0;

    public override void HighlightErrors()
    {
        if (!ValidateHorasTrabajadas) HorasTrabajadasTxt.BorderBrush = Brushes.DarkRed;

        if (!ValidateCostePiezas) CostePiezasTxt.BorderBrush = Brushes.DarkRed;
    }
}