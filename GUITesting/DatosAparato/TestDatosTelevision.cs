using Avalonia.Controls;
using GUI.AddWindowStaged;
using TiendaElectronica.Core.Aparatos;

namespace GUITesting.DatosAparato;

public class TestDatosTelevision
{
    // Valid data
    private Televisor t1, t2, t3;

    [SetUp]
    public void Setup()
    {
        t1 = new Televisor
        {
            NumeroSerie = 12345,
            Modelo = "Sony Bravia",
            Pulgadas = 55
        };

        t2 = new Televisor
        {
            NumeroSerie = 67890,
            Modelo = "Samsung QLED",
            Pulgadas = 65
        };

        t3 = new Televisor
        {
            NumeroSerie = 13579,
            Modelo = "LG OLED",
            Pulgadas = 75
        };
    }

    private (DatosTelevision tvform, NumericUpDown pulgadas) SetupEmpty()
    {
        var TvForm = new DatosTelevision();
        var txtbox = TvForm.Find<NumericUpDown>("PulgadasTxt");
        Assert.NotNull(txtbox);
        return (TvForm, txtbox)!;
    }

    private (DatosTelevision tvform, NumericUpDown) SetupReadOnly(Televisor tv, bool readOnly)
    {
        var TvForm = new DatosTelevision(tv, readOnly);
        var txtbox = TvForm.Find<NumericUpDown>("PulgadasTxt");
        Assert.NotNull(txtbox);
        return (TvForm, txtbox)!;
    }

    [Test]
    public void TestHaveInputAndReadOnly1()
    {
        var (tvform, txtbox) = SetupReadOnly(t1, true);
        Assert.That(t1.Pulgadas, Is.EqualTo((double)txtbox.Value));
        Assert.True(txtbox.IsReadOnly);
    }

    [Test]
    public void TestHaveInputAndReadOnly2()
    {
        var (tvform, txtbox) = SetupReadOnly(t2, true);
        Assert.That(t2.Pulgadas, Is.EqualTo((double)txtbox.Value));
        Assert.True(txtbox.IsReadOnly);
    }

    [Test]
    public void TestValidation1()
    {
        var (tvform, pulgadas) = SetupEmpty();
        pulgadas.Value = null;
        Assert.False(tvform.Validated);
    }

    [Test]
    public void TestValidation2()
    {
        var (tvform, pulgadas) = SetupEmpty();
        pulgadas.Value = (decimal)t2.Pulgadas;
        Assert.True(tvform.Validated);
    }
}