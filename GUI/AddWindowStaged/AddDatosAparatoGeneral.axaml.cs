namespace GUI.AddWindowStaged;

public partial class AddDatosAparatoGeneral : ValidableUserControl
{
    public AddDatosAparatoGeneral()
    {
        InitializeComponent();
    }

    public override bool Validated => NumeroSerieTxt.Text.Length > 0 && ModeloTxt.Text.Length > 0;

    public override void HighlightErrors()
    {
    }
}