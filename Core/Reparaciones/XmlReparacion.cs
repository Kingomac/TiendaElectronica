using System.Xml.Linq;
using TiendaElectronica.Core.Aparatos;

namespace TiendaElectronica.Core.Reparaciones;

public class XmlReparacion
{
    public static XElement ToXml(Reparacion rep)
    {
        var result = new XElement(rep.GetType().Name);
        result.SetAttributeValue(nameof(rep.HorasTrabajadas), rep.HorasTrabajadas);
        result.SetAttributeValue(nameof(rep.CostePiezas), rep.CostePiezas);
        result.Add(XmlAparato.ToXml(rep.Dispositivo));
        return result;
    }

    public static Reparacion FromXml(XElement el)
    {
        var horasTrabajadas = Convert.ToDouble(el.Attribute(nameof(Reparacion.HorasTrabajadas)).Value);
        var costePiezas = Convert.ToDouble(el.Attribute(nameof(Reparacion.CostePiezas)).Value);
        var elDispositivo = el.Elements().First();
        var dispositivo = XmlAparato.FromXml(elDispositivo);
        return Reparacion.Create(dispositivo, horasTrabajadas, costePiezas);
    }
}