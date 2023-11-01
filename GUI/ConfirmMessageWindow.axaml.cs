using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GUI;

public partial class ConfirmMessageWindow : Window
{
    public ConfirmMessageWindow()
    {
        InitializeComponent();
        DataContext = this;
    }

    public string TitleText
    {
        get => TitleTxtblk.Text ?? "";
        set => TitleTxtblk.Text = value;
    }

    public string BodyText
    {
        get => BodyTxtblk.Text ?? "";
        set => BodyTxtblk.Text = value;
    }

    public Button Button1 => ButtonCancel;
    public Button Button2 => ButtonConfirm;

    private void CloseBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}