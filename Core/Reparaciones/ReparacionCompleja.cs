namespace TiendaElectronica.Core.Reparaciones;

public class ReparacionCompleja : Reparacion
{
    public override double Precio =>
        CosteBase + CostePiezas + SegmentosTrabajados * Dispositivo.PrecioReparacionHora * 1.25;

    public override double HorasTrabajadas
    {
        get => _horasTrabajadas;
        set
        {
            if (value <= 1)
                throw new ArgumentOutOfRangeException(nameof(HorasTrabajadas),
                    "Una reparación compleja debe durar más de 1 hora");
            _horasTrabajadas = value;
        }
    }

    public override string ToString()
    {
        return $"Reparación compleja: {base.ToString()}";
    }
}