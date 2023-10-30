namespace TiendaElectronica.Core.Aparatos;

public class AdaptadorTDT : Aparato
{
    public AdaptadorTDT() : base(5)
    {
    }

    public double TiempoMaximoGrabacion { get; init; }
    public bool PuedeGrabar => TiempoMaximoGrabacion > 0;

    public override string ToString()
    {
        var graba = PuedeGrabar ? $"Puede grabar | Tiempo máximo de grabación: {TiempoMaximoGrabacion}" : "";
        return $"Adaptador TDT --> {base.ToString()} | {graba}";
    }
}