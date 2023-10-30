namespace TiendaElectronica.Core.Reparaciones;

public class ReparacionSimple : Reparacion
{
    public override double Precio => CosteBase + CostePiezas + SegmentosTrabajados * Dispositivo.PrecioReparacionHora;

    public override double HorasTrabajadas
    {
        get => _horasTrabajadas;
        set
        {
            if (value > 1)
                throw new ArgumentOutOfRangeException(nameof(HorasTrabajadas),
                    "Las reparaciones simples requieren que se haya trabajado más de 1 hora");
            _horasTrabajadas = value;
        }
    }

    public override string ToString()
    {
        return $"Reparación simple: {base.ToString()}";
    }
}