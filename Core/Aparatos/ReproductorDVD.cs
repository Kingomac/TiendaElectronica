namespace TiendaElectronica.Core.Aparatos;

public class ReproductorDVD : Aparato
{
    public ReproductorDVD() : base(10)
    {
    }

    public bool BlueRay { get; init; }
    public bool Graba => TiempoGrabacion > 0;
    public double TiempoGrabacion { get; init; }

    public override string ToString()
    {
        var graba = Graba ? $"Puede grabar | Tiempo de grabación: {TiempoGrabacion} " : "No puede grabar";
        return $"Reproductor DVD --> {base.ToString()} | {graba}";
    }
}