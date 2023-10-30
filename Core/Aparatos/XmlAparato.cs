using System.Xml.Linq;

namespace TiendaElectronica.Core.Aparatos;

public class XmlAparato
{
    public static XElement ToXml(Aparato ap)
    {
        var el = new XElement(ap.GetType().Name);
        el.SetAttributeValue(nameof(ap.NumeroSerie), ap.NumeroSerie);
        el.SetAttributeValue(nameof(ap.Modelo), ap.Modelo);
        AddAttributes(el, ap);
        return el;
    }

    private static void AddAttributes(XElement el, Aparato ap)
    {
        if (ap.GetType() == typeof(Radio)) AddAttributes(el, (Radio)ap);
        else if (ap.GetType() == typeof(Televisor)) AddAttributes(el, (Televisor)ap);
        else if (ap.GetType() == typeof(ReproductorDVD)) AddAttributes(el, (ReproductorDVD)ap);
        else if (ap.GetType() == typeof(AdaptadorTDT)) AddAttributes(el, (AdaptadorTDT)ap);
    }

    private static void AddAttributes(XElement el, Radio rep)
    {
        el.SetAttributeValue(nameof(rep.BandasSoportadas), rep.BandasSoportadas);
    }

    public static Aparato FromXml(XElement el)
    {
        var numeroSerie = Convert.ToUInt32(el.Attribute(nameof(Aparato.NumeroSerie)).Value);
        var modelo = el.Attribute(nameof(Aparato.Modelo)).Value;
        Aparato? ap = null;
        var dic = new Dictionary<string, Action>
        {
            {
                "Radio", () =>
                {
                    BandasRadio bandasRadio;
                    if (!Enum.TryParse(el.Attribute(nameof(Radio.BandasSoportadas)).Value, out bandasRadio))
                        throw new FormatException();
                    ap = new Radio
                    {
                        Modelo = modelo,
                        NumeroSerie = numeroSerie,
                        BandasSoportadas = bandasRadio
                    };
                }
            },
            {
                "Televisor", () =>
                {
                    ap = new Televisor
                    {
                        Modelo = modelo,
                        NumeroSerie = numeroSerie,
                        Pulgadas = double.Parse(el.Attribute(nameof(Televisor.Pulgadas)).Value)
                    };
                }
            },
            {
                "ReproductorDVD", () =>
                {
                    ap = new ReproductorDVD
                    {
                        Modelo = modelo,
                        NumeroSerie = numeroSerie,
                        BlueRay = bool.Parse(el.Attribute(nameof(ReproductorDVD.BlueRay)).Value),
                        TiempoGrabacion = double.Parse(el.Attribute(nameof(ReproductorDVD.TiempoGrabacion)).Value)
                    };
                }
            },
            {
                "AdaptadorTDT", () =>
                {
                    ap = new AdaptadorTDT
                    {
                        Modelo = modelo,
                        NumeroSerie = numeroSerie,
                        TiempoMaximoGrabacion =
                            double.Parse(el.Attribute(nameof(AdaptadorTDT.TiempoMaximoGrabacion)).Value)
                    };
                }
            }
        };

        dic[el.Name.LocalName]();
        if (ap == null) throw new FormatException();
        return ap;
    }

    private static void AddAttributes(XElement el, Televisor rep)
    {
        el.SetAttributeValue(nameof(rep.Pulgadas), rep.Pulgadas);
    }

    private static void AddAttributes(XElement el, ReproductorDVD rep)
    {
        el.SetAttributeValue(nameof(rep.BlueRay), rep.BlueRay);
        el.SetAttributeValue(nameof(rep.TiempoGrabacion), rep.TiempoGrabacion);
    }

    private static void AddAttributes(XElement el, AdaptadorTDT rep)
    {
        el.SetAttributeValue(nameof(rep.TiempoMaximoGrabacion), rep.TiempoMaximoGrabacion);
    }
}