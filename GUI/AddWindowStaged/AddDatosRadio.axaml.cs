using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GUI.AddWindowStaged;

public partial class AddDatosRadio : ValidableUserControl
{
    public AddDatosRadio()
    {
        InitializeComponent();
        DataContext = this;
    }

    public bool AM { get; set; } = false;
    public bool FM { get; set; } = false;
    public bool AM_FM { get; set; } = false;

    public override bool Validated { get; }

    private void CheckedChanged(object? sender, RoutedEventArgs e)
    {
        if (sender == null) return;
        var btn = (RadioButton)sender;
        Console.WriteLine(btn.Content);
    }

    public override void HighlightErrors()
    {
        throw new NotImplementedException();
    }
}