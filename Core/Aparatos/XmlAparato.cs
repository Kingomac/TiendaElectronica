using System.Xml;
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
        var numeroSerie = Convert.ToUInt32((el.Attribute(nameof(Aparato.NumeroSerie)) ??
                                            throw new XmlException(
                                                "Falta número de serie para el aparato en la etiqueta: " + el.Name))
            .Value);
        var modelo = (el.Attribute(nameof(Aparato.Modelo)) ??
                      throw new XmlException("Falta modelo en la etiqueta " + el.Name)).Value;
        Aparato? ap = null;
        var dic = new Dictionary<string, Action>
        {
            {
                "Radio", () =>
                {
                    BandasRadio bandasRadio;
                    if (!Enum.TryParse(
                            (el.Attribute(nameof(Radio.BandasSoportadas)) ??
                             throw new XmlException("Falta la banda de radio en la etiqueta " + el.Name)).Value,
                            out bandasRadio))
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
                        Pulgadas = double.Parse((el.Attribute(nameof(Televisor.Pulgadas)) ??
                                                 throw new XmlException("Faltan pulgadas para television en etiqueta " +
                                                                        el.Name)).Value)
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
                        BlueRay = bool.Parse((el.Attribute(nameof(ReproductorDVD.BlueRay)) ??
                                              throw new XmlException("Falta blueray para reproductor dvd en etiqueta " +
                                                                     el.Name)).Value),
                        TiempoGrabacion = double.Parse((el.Attribute(nameof(ReproductorDVD.TiempoGrabacion)) ??
                                                        throw new XmlException(
                                                            "Falta tiempo de grabación para reproductor dvd en etiqueta " +
                                                            el.Name)).Value)
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
                            double.Parse((el.Attribute(nameof(AdaptadorTDT.TiempoMaximoGrabacion)) ??
                                          throw new XmlException(
                                              "Falta tiempomáximo de grabación para adaptador tdt en etiqueta " +
                                              el.Name)).Value)
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