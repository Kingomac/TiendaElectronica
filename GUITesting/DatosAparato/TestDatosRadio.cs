using Avalonia.Controls;
using GUI.AddWindowStaged;
using TiendaElectronica.Core.Aparatos;

namespace GUITesting.DatosAparato;

public class TestDatosRadio
{
    private Radio r1, r2, r3;


    [SetUp]
    public void Setup()
    {
        r1 = new Radio
        {
            NumeroSerie = 1001,
            Modelo = "Sony FM/AM Radio",
            BandasSoportadas = BandasRadio.AM_FM
        };

        r2 = new Radio
        {
            NumeroSerie = 1002,
            Modelo = "Bose Wave SoundTouch",
            BandasSoportadas = BandasRadio.AM_FM
        };

        r3 = new Radio
        {
            NumeroSerie = 1003,
            Modelo = "JBL Portable Bluetooth Speaker with Radio",
            BandasSoportadas = BandasRadio.FM
        };
    }

    private (DatosRadio form, RadioButton am, RadioButton fm, RadioButton both) SetupEmpty()
    {
        var form = new DatosRadio();
        var am = form.FindControl<RadioButton>("RadioBtn_AM");
        var fm = form.FindControl<RadioButton>("RadioBtn_FM");
        var both = form.FindControl<RadioButton>("RadioBtn_AMFM");
        Assert.NotNull(am);
        Assert.NotNull(fm);
        Assert.NotNull(both);
        return (form, am, fm, both)!;
    }

    private (DatosRadio form, RadioButton am, RadioButton fm, RadioButton both) SetupRadioReadOnly(Radio radio,
        bool readOnly)
    {
        var form = new DatosRadio(radio, readOnly);
        var am = form.FindControl<RadioButton>("RadioBtn_AM");
        var fm = form.FindControl<RadioButton>("RadioBtn_FM");
        var both = form.FindControl<RadioButton>("RadioBtn_AMFM");
        Assert.NotNull(am);
        Assert.NotNull(fm);
        Assert.NotNull(both);
        Assert.That(am.IsEnabled, Is.EqualTo(!readOnly));
        Assert.That(fm.IsEnabled, Is.EqualTo(!readOnly));
        Assert.That(both.IsEnabled, Is.EqualTo(!readOnly));
        return (form, am, fm, both)!;
    }

    [Test]
    public void HaveInputReadOnly1()
    {
        var (form, am, fm, both) = SetupRadioReadOnly(r1, true);
        Assert.False(am.IsEnabled);
        Assert.False(fm.IsEnabled);
        Assert.False(both.IsEnabled);
        Assert.True(both.IsChecked);
        Assert.False(fm.IsChecked);
        Assert.False(am.IsChecked);
    }

    [Test]
    public void HaveInputReadOnly2()
    {
        var (form, am, fm, both) = SetupRadioReadOnly(r2, true);
        Assert.False(both.IsEnabled);
        Assert.False(fm.IsEnabled);
        Assert.False(am.IsEnabled);
        Assert.True(both.IsChecked);
        Assert.False(fm.IsChecked);
        Assert.False(am.IsChecked);
    }

    [Test]
    public void Validation1()
    {
        var (form, am, fm, both) = SetupEmpty();
        Assert.False(form.Validated);
        am.IsChecked = true;
        Assert.True(form.Validated);
        am.IsChecked = false;
        fm.IsChecked = true;
        Assert.True(form.Validated);
        Assert.True(form.FM);
        Assert.False(form.AM_FM);
        Assert.False(form.AM);
    }
}