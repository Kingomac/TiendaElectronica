using System;

namespace GUI.AddWindowStaged;

public partial class AddDatosTelevision : ValidableUserControl
{
    public AddDatosTelevision()
    {
        InitializeComponent();
    }

    public override bool Validated { get; }

    public override void HighlightErrors()
    {
        throw new NotImplementedException();
    }
}