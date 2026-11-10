namespace Tienda.Cobros;

public interface IPasarelaDePago
{
    // Devuelve "OK" si el cobro se aprobó; cualquier otro texto si no.
    string Cobrar(string numeroTarjeta, decimal total);
}
