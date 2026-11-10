using Microsoft.Extensions.Logging;
using Tienda.Modelos;

namespace Tienda.Cobros;

public class ServicioDeCobros
{
    private readonly IPasarelaDePago _pasarela;
    private readonly ILogger<ServicioDeCobros> _logger;
    private readonly ITiendaDb _db;

    public ServicioDeCobros(IPasarelaDePago pasarela, ILogger<ServicioDeCobros> logger, ITiendaDb db)
    {
        _pasarela = pasarela;
        _logger = logger;
        _db = db;
    }

    // Esta es la función que se le pide a Claude que revise en el capítulo 1.
    // Tiene problemas a propósito: no se corrige aquí.
    public decimal CobrarPedido(Pedido pedido, string numeroTarjeta)
    {
        var total = 0m;
        foreach (var item in pedido.Items)
            total += item.Precio * item.Cantidad;

        var resultado = _pasarela.Cobrar(numeroTarjeta, total);
        _logger.LogInformation("Cobrando " + total + " a la tarjeta " + numeroTarjeta);

        if (resultado == "OK")
        {
            pedido.Estado = "PAGADO";
            _db.SaveChanges();
        }
        return total;
    }
}
