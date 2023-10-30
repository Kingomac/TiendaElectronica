using TiendaElectronica.Core.Aparatos;

namespace TiendaElectronica.Core.Reparaciones;

public abstract class Reparacion
{
    protected const double CosteBase = 10.0;

    protected double _horasTrabajadas;

    public Aparato Dispositivo { get; init; }

    public abstract double HorasTrabajadas { get; set; }

    public double CostePiezas { get; set; }

    public abstract double Precio { get; }

    public uint SegmentosTrabajados => Convert.ToUInt32(HorasTrabajadas * 2);

    public static Reparacion Create(Aparato aparato, double horasTrabajadas, double costePiezas)
    {
        try
        {
            return new ReparacionSimple
            {
                Dispositivo = aparato,
                CostePiezas = costePiezas,
                HorasTrabajadas = horasTrabajadas
            };
        }
        catch (ArgumentOutOfRangeException e)
        {
            return new ReparacionCompleja
            {
                Dispositivo = aparato,
                CostePiezas = costePiezas,
                HorasTrabajadas = horasTrabajadas
            };
        }
    }

    public override string ToString()
    {
        return Dispositivo.ToString();
    }
}