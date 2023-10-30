using System;

namespace GUI.AddWindowStaged;

public partial class AddDatosReprDVD : ValidableUserControl
{
    public AddDatosReprDVD()
    {
        InitializeComponent();
    }

    public override bool Validated { get; }

    public override void HighlightErrors()
    {
        throw new NotImplementedException();
    }
}