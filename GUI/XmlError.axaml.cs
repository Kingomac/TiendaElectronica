using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace GUI;

public partial class XmlError : Window
{
    public XmlError(Exception e)
    {
        InitializeComponent();
        TextoExcepcion.Text = e.Message;
        TextoStacktrace.Content = e.StackTrace;
    }

    private void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}