namespace TiendaElectronica.Core.Aparatos;

public class Radio : Aparato
{
    public Radio() : base(5)
    {
    }

    public BandasRadio BandasSoportadas { get; init; }

    public override string ToString()
    {
        return $"Radio --> {base.ToString()} | Bandas de radio soportadas: {BandasSoportadas}";
    }
}