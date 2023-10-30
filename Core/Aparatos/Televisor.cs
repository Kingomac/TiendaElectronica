namespace TiendaElectronica.Core.Aparatos;

public class Televisor : Aparato
{
    public Televisor() : base(10)
    {
    }

    public double Pulgadas { get; init; }

    public override string ToString()
    {
        return $"Televisor --> {base.ToString()} | Pulgadas: {Pulgadas}";
    }
}