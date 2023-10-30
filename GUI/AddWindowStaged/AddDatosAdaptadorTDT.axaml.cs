using System;

namespace GUI.AddWindowStaged;

public partial class AddDatosAdaptadorTDT : ValidableUserControl
{
    public AddDatosAdaptadorTDT()
    {
        InitializeComponent();
    }

    public override bool Validated { get; }

    public override void HighlightErrors()
    {
        throw new NotImplementedException();
    }
}