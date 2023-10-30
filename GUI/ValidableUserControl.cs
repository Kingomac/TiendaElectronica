using Avalonia.Controls;

namespace GUI;

public abstract class ValidableUserControl : UserControl
{
    public abstract bool Validated { get; }

    public abstract void HighlightErrors();
}