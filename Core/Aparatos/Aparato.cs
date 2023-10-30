namespace TiendaElectronica.Core.Aparatos;

public abstract class Aparato
{
    public Aparato(double precioReparacionHora)
    {
        PrecioReparacionHora = precioReparacionHora;
    }

    public required uint NumeroSerie { get; init; }
    public required string Modelo { get; init; }
    public double PrecioReparacionHora { get; }

    public override string ToString()
    {
        return
            $"Número de serie: {NumeroSerie} | Modelo: {Modelo} | Precio reparación/hora: {PrecioReparacionHora}";
    }
}