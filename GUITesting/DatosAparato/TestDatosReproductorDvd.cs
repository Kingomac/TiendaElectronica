using Avalonia.Controls;
using GUI.AddWindowStaged;
using TiendaElectronica.Core.Aparatos;

namespace GUITesting.DatosAparato;

public class TestDatosReproductorDvd
{
    private ReproductorDVD r1, r2, r3;

    [SetUp]
    public void Setup()
    {
        r1 = new ReproductorDVD
        {
            NumeroSerie = 1001,
            Modelo = "Sony DVD Player",
            BlueRay = true,
            TiempoGrabacion = 2.6
        };
        r2 = new ReproductorDVD
        {
            NumeroSerie = 1002,
            Modelo = "Samsung DVD Player",
            BlueRay = false,
            TiempoGrabacion = 6.5
        };
        r3 = new ReproductorDVD
        {
            NumeroSerie = 1003,
            Modelo = "LG DVD Player",
            BlueRay = true,
            TiempoGrabacion = 0.0
        };
    }

    private (DatosReprDVD form, NumericUpDown tiempo, CheckBox blueRay) SetupEmpty()
    {
        var form = new DatosReprDVD();
        var tiempo = form.FindControl<NumericUpDown>("TiempoGrabacionTxt");
        var blueRay = form.FindControl<CheckBox>("BlueRayCheck");
        Assert.NotNull(tiempo);
        Assert.NotNull(blueRay);
        return (form, tiempo, blueRay)!;
    }

    private (DatosReprDVD form, NumericUpDown tiempo, CheckBox blueRay) SetupReadOnly(ReproductorDVD dvd, bool readOnly)
    {
        var form = new DatosReprDVD(dvd, readOnly);
        var tiempo = form.FindControl<NumericUpDown>("TiempoGrabacionTxt");
        var blueRay = form.FindControl<CheckBox>("BlueRayCheck");
        Assert.NotNull(tiempo);
        Assert.NotNull(blueRay);
        return (form, tiempo, blueRay)!;
    }

    [Test]
    public void TestHaveInputAndReadOnly1()
    {
        var (form, tiempo, blueRay) = SetupReadOnly(r1, true);
        Assert.That(r1.TiempoGrabacion, Is.EqualTo((double)tiempo.Value));
        Assert.That(r1.BlueRay, Is.EqualTo(blueRay.IsChecked));
        Assert.True(form.BlueRay);
        Assert.True(tiempo.IsReadOnly);
        Assert.False(blueRay.IsEnabled);
    }

    [Test]
    public void TestHaveInputAndReadOnly2()
    {
        var (form, tiempo, blueRay) = SetupReadOnly(r2, true);
        Assert.That(r2.TiempoGrabacion, Is.EqualTo((double)tiempo.Value));
        Assert.That(r2.BlueRay, Is.EqualTo(blueRay.IsChecked));
        Assert.False(form.BlueRay);
        Assert.True(tiempo.IsReadOnly);
        Assert.False(blueRay.IsEnabled);
    }

    [Test]
    public void TestValidation1()
    {
        var (form, tiempo, blueRay) = SetupEmpty();
        Assert.False(form.Validated);
    }

    [Test]
    public void TestValidation2()
    {
        var (form, tiempo, blueRay) = SetupEmpty();
        tiempo.Value = (decimal)r3.TiempoGrabacion;
        blueRay.IsChecked = r3.BlueRay;
        Assert.That(r3.TiempoGrabacion, Is.EqualTo((double)tiempo.Value));
        Assert.False(r3.Graba);
        Assert.True(form.BlueRay);
        Assert.True(form.Validated);
    }
}