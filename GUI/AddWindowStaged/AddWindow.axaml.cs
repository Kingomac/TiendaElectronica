using System;
using Avalonia.Controls;
using Avalonia.Interactivity;
using TiendaElectronica.Core.Reparaciones;

namespace GUI.AddWindowStaged;

public partial class AddWindow : Window
{
    private readonly Action<Reparacion> AddReparacion;
    private AparatoCreator? AparatoCreator;
    private int stage;

    public AddWindow(Action<Reparacion> addReparacion)
    {
        InitializeComponent();
        AddReparacion = addReparacion;
    }

    private void TransitionBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        if (sender == null) return;
        switch (stage)
        {
            case 2:
                AparatoCreator = AddSelecTipo.GetNextStageControl();
                CarouselControl.Items.Add(AparatoCreator);
                TransitionBtn.Content = "Terminar";
                break;
            case 3:
            {
                var creator = AparatoCreator ?? throw new NullReferenceException();
                var modelo = AddDatosAparatoGeneral.ModeloTxt.Text ?? throw new NullReferenceException();
                var numSerie =
                    uint.Parse(AddDatosAparatoGeneral.NumeroSerieTxt.Text ?? throw new NullReferenceException());
                var aparato = creator.CreateAparato(numSerie, modelo);
                var horasTrabajadas = (double)(AddDatosReparacion.HorasTrabajadasTxt.Value ?? 0);
                var costePiezas = (double)(AddDatosReparacion.CostePiezasTxt.Value ?? 0);
                var result = Reparacion.Create(aparato, horasTrabajadas, costePiezas);
                AddReparacion(result);
                Close();
                break;
            }
        }

        CarouselControl.Next();
        stage++;
    }
}