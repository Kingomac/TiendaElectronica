namespace GUI.AddWindowStaged;

public partial class AddDatosReparacion : ValidableUserControl
{
    public AddDatosReparacion()
    {
        InitializeComponent();
    }

    public override bool Validated => HorasTrabajadasTxt.Value != null && CostePiezasTxt.Value != null;

    public override void HighlightErrors()
    {
    }
}