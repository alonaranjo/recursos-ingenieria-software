using Tienda.Precios;
using Xunit;

namespace Tienda.Pruebas;

// Estilo de pruebas del equipo (capítulo 3): nombre Dado_..._Cuando_..._Entonces_...
// y comentarios // Dado, // Cuando, // Entonces.
public class DescuentosTests
{
    [Fact]
    public void Dado_Subtotal49999_Cuando_CalculaDescuento_Entonces_RetornaCero()
    {
        // Dado
        var subtotal = 49_999m;

        // Cuando
        var descuento = Descuentos.CalcularDescuento(subtotal);

        // Entonces
        Assert.Equal(0m, descuento);
    }

    [Fact]
    public void Dado_Subtotal50000_Cuando_CalculaDescuento_Entonces_RetornaCincoPorCiento()
    {
        // Dado
        var subtotal = 50_000m;

        // Cuando
        var descuento = Descuentos.CalcularDescuento(subtotal);

        // Entonces
        Assert.Equal(2_500m, descuento);
    }

    [Fact]
    public void Dado_Subtotal100000_Cuando_CalculaDescuento_Entonces_RetornaDiezPorCiento()
    {
        // Dado
        var subtotal = 100_000m;

        // Cuando
        var descuento = Descuentos.CalcularDescuento(subtotal);

        // Entonces
        Assert.Equal(10_000m, descuento);
    }

    // Esta cuarta prueba la escribe Claude en el capítulo 3, a partir de las tres de arriba.
    // En el ensayo la primera versión usaba `var accion = () => ...` y no compilaba
    // (error CS1503: 'Func<decimal>' a 'Action'); esta es la versión corregida en el capítulo 6.
    [Fact]
    public void Dado_SubtotalNegativo_Cuando_CalculaDescuento_Entonces_LanzaArgumentOutOfRangeException()
    {
        // Dado
        var subtotal = -1m;

        // Cuando
        Action accion = () => Descuentos.CalcularDescuento(subtotal);

        // Entonces
        var excepcion = Assert.Throws<ArgumentOutOfRangeException>(accion);
        Assert.Equal("subtotal", excepcion.ParamName);
    }
}
