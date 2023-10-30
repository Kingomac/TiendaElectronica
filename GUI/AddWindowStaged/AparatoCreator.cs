using TiendaElectronica.Core.Aparatos;

namespace GUI.AddWindowStaged;

public abstract class AparatoCreator : ValidableUserControl
{
    public abstract Aparato CreateAparato(uint numeroSerie, string modelo);
}