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
    }

    public DatosReparacionGeneral(Reparacion rep, bool isReadOnly) : this(rep)
    {
        HorasTrabajadasTxt.IsReadOnly = isReadOnly;
        CostePiezasTxt.IsReadOnly = isReadOnly;
    }

    public override bool Validated => HorasTrabajadasTxt.Value != null && CostePiezasTxt.Value != null;

    public override void HighlightErrors()
    {
    }
}