using System;
using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public class DatosPanelFactory
{
    public static ValidableUserControl Create(Aparato aparato, bool isReadOnly = false)
    {
        return aparato switch
        {
            Radio r => new DatosRadio(r, isReadOnly),
            Televisor t => new DatosTelevision(t, isReadOnly),
            AdaptadorTDT t => new DatosAdaptadorTDT(t, isReadOnly),
            ReproductorDVD r => new DatosReprDVD(r, isReadOnly),
            _ => throw new ArgumentException()
        };
    }
}