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

    private (DatosTelevision tvform, TextBox pulgadas) SetupEmpty()
    {
        var TvForm = new DatosTelevision();
        var txtbox = TvForm.Find<TextBox>("PulgadasTxt");
        Assert.NotNull(txtbox);
        return (TvForm, txtbox)!;
    }

    [Test]
    public void TestHaveInputAndReadOnly1()
    {
        var TvForm = new DatosTelevision(t1, true);
        var txtbox = TvForm.Find<TextBox>("PulgadasTxt");
        Assert.NotNull(txtbox);
        Assert.That(t1.Pulgadas, Is.EqualTo(double.Parse(txtbox.Text)));
        Assert.True(txtbox.IsReadOnly);
    }

    [Test]
    public void TestHaveInputAndReadOnly2()
    {
        var TvForm = new DatosTelevision(t2, true);
        var txtbox = TvForm.Find<TextBox>("PulgadasTxt");
        Assert.NotNull(txtbox);
        Assert.That(t2.Pulgadas, Is.EqualTo(double.Parse(txtbox.Text)));
        Assert.True(txtbox.IsReadOnly);
    }

    [Test]
    public void TestValidation1()
    {
        var (tvform, pulgadas) = SetupEmpty();
        pulgadas.Text = "";
        Assert.False(tvform.Validated);
    }

    [Test]
    public void TestValidation2()
    {
        var (tvform, pulgadas) = SetupEmpty();
        pulgadas.Text = "jslkjfsl";
        Assert.False(tvform.Validated);
    }

    [Test]
    public void TestValidation3()
    {
        var (tvform, pulgadas) = SetupEmpty();
        pulgadas.Text = t2.Pulgadas.ToString();
        Assert.True(tvform.Validated);
    }
}