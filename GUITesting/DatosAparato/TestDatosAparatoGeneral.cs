using Avalonia.Controls;
using GUI.AddWindowStaged;
using TiendaElectronica.Core.Aparatos;

namespace GUITesting.DatosAparato;

public class TestDatosAparatoGeneral
{
    private Aparato a1, a2, a3;

    [SetUp]
    public void Setup()
    {
        a1 = new Radio
        {
            NumeroSerie = 1001,
            Modelo = "Sony FM/AM Radio",
            BandasSoportadas = BandasRadio.AM_FM
        };
        a2 = new Televisor
        {
            NumeroSerie = 67890,
            Modelo = "Samsung QLED",
            Pulgadas = 65
        };
        a3 = new ReproductorDVD
        {
            NumeroSerie = 1001,
            Modelo = "Sony DVD Player",
            BlueRay = true,
            TiempoGrabacion = 2.6
        };
    }

    private (DatosAparatoGeneral form, TextBox numeroSerie, TextBox modelo, NumericUpDown precioPorHora) SetupEmpty()
    {
        var form = new DatosAparatoGeneral();
        var numeroSerie = form.FindControl<TextBox>("NumeroSerieTxt");
        var modelo = form.FindControl<TextBox>("ModeloTxt");
        var precioPorHora = form.FindControl<NumericUpDown>("PrecioPorHoraTxt");
        Assert.NotNull(numeroSerie);
        Assert.NotNull(modelo);
        Assert.NotNull(precioPorHora);
        Assert.True(precioPorHora.IsReadOnly);
        return (form, numeroSerie, modelo, precioPorHora)!;
    }

    private (DatosAparatoGeneral form, TextBox numeroSerie, TextBox modelo, NumericUpDown precioPorHora) SetupReadOnly(
        Aparato aparato, bool readOnly)
    {
        var form = new DatosAparatoGeneral(aparato, readOnly);
        var numeroSerie = form.FindControl<TextBox>("NumeroSerieTxt");
        var modelo = form.FindControl<TextBox>("ModeloTxt");
        var precioPorHora = form.FindControl<NumericUpDown>("PrecioPorHoraTxt");
        Assert.NotNull(numeroSerie);
        Assert.NotNull(modelo);
        Assert.NotNull(precioPorHora);
        Assert.True(precioPorHora.IsReadOnly);
        Assert.That(numeroSerie.IsReadOnly, Is.EqualTo(readOnly));
        Assert.That(modelo.IsReadOnly, Is.EqualTo(readOnly));
        return (form, numeroSerie, modelo, precioPorHora)!;
    }

    [Test]
    public void TestHaveInputAndReadOnly1()
    {
        var (form, numeroSerie, modelo, precioPorHora) = SetupReadOnly(a1, true);
        Assert.That(a1.NumeroSerie, Is.EqualTo(uint.Parse(numeroSerie.Text)));
        Assert.That(a1.Modelo, Is.EqualTo(modelo.Text));
        Assert.That(a1.PrecioReparacionHora, Is.EqualTo((double)precioPorHora.Value));
    }

    [Test]
    public void TestHaveInputAndReadOnly2()
    {
        var (form, numeroSerie, modelo, precioPorHora) = SetupReadOnly(a2, true);
        Assert.That(a2.NumeroSerie, Is.EqualTo(uint.Parse(numeroSerie.Text)));
        Assert.That(a2.Modelo, Is.EqualTo(modelo.Text));
        Assert.That(a2.PrecioReparacionHora, Is.EqualTo((double)precioPorHora.Value));
    }

    [Test]
    public void TestHaveInputAndReadOnly3()
    {
        var (form, numeroSerie, modelo, precioPorHora) = SetupReadOnly(a3, true);
        Assert.That(a3.NumeroSerie, Is.EqualTo(uint.Parse(numeroSerie.Text)));
        Assert.That(a3.Modelo, Is.EqualTo(modelo.Text));
        Assert.That(a3.PrecioReparacionHora, Is.EqualTo((double)precioPorHora.Value));
    }

    [Test]
    public void Validate1()
    {
        var (form, numeroSerie, modelo, precioPorHora) = SetupEmpty();
        numeroSerie.Text = "";
        modelo.Text = "";
        Assert.False(form.Validated);
    }

    [Test]
    public void Validate2()
    {
        var (form, numeroSerie, modelo, precioPorHora) = SetupEmpty();
        numeroSerie.Text = "akjdshkjasd";
        modelo.Text = a1.Modelo;
        Assert.False(form.Validated);
    }

    [Test]
    public void Validate3()
    {
        var (form, numeroSerie, modelo, precioPorHora) = SetupEmpty();
        numeroSerie.Text = a1.NumeroSerie.ToString();
        modelo.Text = "";
        Assert.False(form.Validated);
    }

    [Test]
    public void Validate4()
    {
        var (form, numeroSerie, modelo, precioPorHora) = SetupEmpty();
        numeroSerie.Text = a1.NumeroSerie.ToString();
        modelo.Text = a1.Modelo;
        Assert.True(form.Validated);
        Assert.That(a1.NumeroSerie, Is.EqualTo(uint.Parse(numeroSerie.Text)));
        Assert.That(a1.Modelo, Is.EqualTo(modelo.Text));
    }
}