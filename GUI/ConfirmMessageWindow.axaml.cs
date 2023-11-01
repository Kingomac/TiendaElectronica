using System;
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

    public string TitleText { get; set; } = "title";
    public string BodyText { get; set; } = "body";

    public Button Button1 => ButtonCancel;
    public Button Button2 => ButtonConfirm;

    private void CloseBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}