using Avalonia.Controls;
using GUI.AddWindowStaged;
using TiendaElectronica.Core.Aparatos;

namespace GUITesting.DatosAparato;

public class TestDatosAdaptadorTdt
{
    private AdaptadorTDT a1, a2, a3;

    [SetUp]
    public void Setup()
    {
        a1 = new AdaptadorTDT
        {
            NumeroSerie = 1001,
            Modelo = "Sony TDT Adapter",
            TiempoMaximoGrabacion = 2.6
        };
        a2 = new AdaptadorTDT
        {
            NumeroSerie = 1002,
            Modelo = "Samsung TDT Adapter",
            TiempoMaximoGrabacion = 6.5
        };
        a3 = new AdaptadorTDT
        {
            NumeroSerie = 1003,
            Modelo = "LG TDT Adapter",
            TiempoMaximoGrabacion = 0.0
        };
    }

    private (DatosAdaptadorTDT form, NumericUpDown tiempoMaximoGrabacion) SetupEmpty()
    {
        var form = new DatosAdaptadorTDT();
        var tiempo = form.FindControl<NumericUpDown>("TiempoMaximoGrabacionTxt");
        Assert.NotNull(tiempo);
        return (form, tiempo)!;
    }

    private (DatosAdaptadorTDT form, NumericUpDown tiempoMaximoGrabacion) SetupReadOnly(AdaptadorTDT adaptadorTdt,
        bool readOnly)
    {
        var form = new DatosAdaptadorTDT(adaptadorTdt, readOnly);
        var tiempoMaximoGrabacion = form.FindControl<NumericUpDown>("TiempoMaximoGrabacionTxt");
        Assert.NotNull(tiempoMaximoGrabacion);
        return (form, tiempoMaximoGrabacion)!;
    }

    [Test]
    public void TestHaveInputAndReadOnly1()
    {
        var (form, tiempoMaximoGrabacion) = SetupReadOnly(a1, true);
        Assert.That(a1.TiempoMaximoGrabacion, Is.EqualTo(double.Parse(tiempoMaximoGrabacion.Text)));
        Assert.True(tiempoMaximoGrabacion.IsReadOnly);
    }

    [Test]
    public void TestHaveInputAndReadOnly2()
    {
        var (form, tiempoMaximoGrabacion) = SetupReadOnly(a2, true);
        Assert.That(a2.TiempoMaximoGrabacion, Is.EqualTo(double.Parse(tiempoMaximoGrabacion.Text)));
        Assert.True(tiempoMaximoGrabacion.IsReadOnly);
    }

    [Test]
    public void Validated1()
    {
        var (form, tiempoMaximoGrabacion) = SetupEmpty();
        tiempoMaximoGrabacion.Value = null;
        Assert.False(form.Validated);
    }

    [Test]
    public void Validated2()
    {
        var (form, tiempoMaximoGrabacion) = SetupEmpty();
        tiempoMaximoGrabacion.Value = (decimal)a3.TiempoMaximoGrabacion;
        Assert.True(form.Validated);
        Assert.That(a3.TiempoMaximoGrabacion, Is.EqualTo((double)tiempoMaximoGrabacion.Value));
    }

    [Test]
    public void Validated3()
    {
        var (form, tiempoMaximoGrabacion) = SetupEmpty();
        tiempoMaximoGrabacion.Value = (decimal)a2.TiempoMaximoGrabacion;
        Assert.True(form.Validated);
        Assert.That(a2.TiempoMaximoGrabacion, Is.EqualTo((double)tiempoMaximoGrabacion.Value));
    }
}