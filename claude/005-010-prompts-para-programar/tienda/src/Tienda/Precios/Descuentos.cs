namespace Tienda.Precios;

// Capítulo 2: este método lo escribe Claude con el prompt con datos y se pega aquí.
// Reglas de la tienda: menos de ₡50.000, 0 %; de ₡50.000 a menos de ₡100.000, 5 %; desde ₡100.000, 10 %.
public static class Descuentos
{
    public static decimal CalcularDescuento(decimal subtotal)
    {
        if (subtotal < 0m)
        {
            throw new ArgumentOutOfRangeException(
                nameof(subtotal),
                subtotal,
                "El subtotal no puede ser negativo.");
        }

        decimal porcentaje;

        if (subtotal < 50_000m)
        {
            porcentaje = 0m;
        }
        else if (subtotal < 100_000m)
        {
            porcentaje = 0.05m;
        }
        else
        {
            porcentaje = 0.10m;
        }

        return Math.Round(subtotal * porcentaje, 2, MidpointRounding.AwayFromZero);
    }
}
