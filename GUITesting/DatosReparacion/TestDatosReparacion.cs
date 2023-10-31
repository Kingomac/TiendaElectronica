using Avalonia.Controls;
using GUI.DatosReparacion;
using TiendaElectronica.Core.Aparatos;
using TiendaElectronica.Core.Reparaciones;

namespace GUITesting.DatosReparacion;

public class TestDatosReparacion
{
    private Reparacion r1, r2, r3;

    [SetUp]
    public void Setup()
    {
        r1 = Reparacion.Create(new Televisor
        {
            NumeroSerie = 12345,
            Modelo = "Sony Bravia",
            Pulgadas = 55
        }, 0.5, 10.0);
        r2 = Reparacion.Create(new Televisor
        {
            NumeroSerie = 67890,
            Modelo = "Samsung QLED",
            Pulgadas = 65
        }, 5.0, 20.0);
        r3 = Reparacion.Create(new Televisor
        {
            NumeroSerie = 13579,
            Modelo = "LG OLED",
            Pulgadas = 75
        }, 10.0, 30.0);
    }

    [Test]
    public void TestTipoRep()
    {
        Assert.That(r1.GetType(), Is.EqualTo(typeof(ReparacionSimple)));
        Assert.That(r2.GetType(), Is.EqualTo(typeof(ReparacionCompleja)));
        Assert.That(r3.GetType(), Is.EqualTo(typeof(ReparacionCompleja)));
    }

    private (DatosReparacionGeneral form, NumericUpDown horastrabajadas, NumericUpDown costepiezas) SetupEmpty()
    {
        var form = new DatosReparacionGeneral();
        var horastrabajadas = form.FindControl<NumericUpDown>("HorasTrabajadasTxt");
        var costepiezas = form.FindControl<NumericUpDown>("CostePiezasTxt");
        Assert.NotNull(horastrabajadas);
        Assert.NotNull(costepiezas);
        return (form, horastrabajadas, costepiezas)!;
    }

    private (DatosReparacionGeneral form, NumericUpDown horastrabajadas, NumericUpDown costepiezas) SetupReadOnly(
        Reparacion reparacion, bool readOnly)
    {
        var form = new DatosReparacionGeneral(reparacion, readOnly);
        var horastrabajadas = form.FindControl<NumericUpDown>("HorasTrabajadasTxt");
        var costepiezas = form.FindControl<NumericUpDown>("CostePiezasTxt");
        Assert.NotNull(horastrabajadas);
        Assert.NotNull(costepiezas);
        Assert.That(horastrabajadas.IsReadOnly, Is.EqualTo(readOnly));
        Assert.That(costepiezas.IsReadOnly, Is.EqualTo(readOnly));
        return (form, horastrabajadas, costepiezas)!;
    }

    [Test]
    public void TestHaveInputAndReadOnly1()
    {
        var (form, horastrabajadas, costepiezas) = SetupReadOnly(r1, true);
        Assert.That(r1.HorasTrabajadas, Is.EqualTo((double)horastrabajadas.Value));
        Assert.That(r1.CostePiezas, Is.EqualTo((double)costepiezas.Value));
        Assert.True(horastrabajadas.IsReadOnly);
        Assert.True(costepiezas.IsReadOnly);
    }

    [Test]
    public void TestHaveInputAndReadOnly2()
    {
        var (form, horastrabajadas, costepiezas) = SetupReadOnly(r2, true);
        Assert.That(r2.HorasTrabajadas, Is.EqualTo((double)horastrabajadas.Value));
        Assert.That(r2.CostePiezas, Is.EqualTo((double)costepiezas.Value));
        Assert.True(horastrabajadas.IsReadOnly);
        Assert.True(costepiezas.IsReadOnly);
    }

    [Test]
    public void TestHaveInputAndReadOnly3()
    {
        var (form, horastrabajadas, costepiezas) = SetupReadOnly(r3, true);
        Assert.That(r3.HorasTrabajadas, Is.EqualTo((double)horastrabajadas.Value));
        Assert.That(r3.CostePiezas, Is.EqualTo((double)costepiezas.Value));
        Assert.True(horastrabajadas.IsReadOnly);
        Assert.True(costepiezas.IsReadOnly);
    }

    [Test]
    public void Validate1()
    {
        var (form, horastrabajadas, costepiezas) = SetupEmpty();
        Assert.False(form.Validated);
    }

    [Test]
    public void Validate2()
    {
        var (form, horastrabajadas, costepiezas) = SetupEmpty();
        horastrabajadas.Value = (decimal)r3.HorasTrabajadas;
        costepiezas.Value = (decimal)r3.CostePiezas;
        Assert.True(form.Validated);
        Assert.That(r3.HorasTrabajadas, Is.EqualTo((double)horastrabajadas.Value));
        Assert.That(r3.CostePiezas, Is.EqualTo((double)costepiezas.Value));
    }
}