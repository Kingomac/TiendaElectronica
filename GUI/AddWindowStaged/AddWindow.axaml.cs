using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GUI.AddWindowStaged;

public partial class AddWindow : Window
{
    private int stage;

    public AddWindow()
    {
        InitializeComponent();
    }

    private void TransitionBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender == null) return;
        if (stage == 2) CarouselControl.Items.Add(((AddSelecTipo)sender).GetNextStageControl());

        CarouselControl.Next();
        stage++;
    }
}