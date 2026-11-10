using Microsoft.Extensions.Logging;
using Tienda.Cobros;
using Tienda.Precios;
using Tienda.Modelos;

// Uso:  dotnet run --project src/Tienda.Demos -- <demo>
//   cobro        capítulo 1: lo que hace CobrarPedido cuando la pasarela rechaza la tarjeta
//   descuentos   capítulo 2: las 7 comprobaciones de CalcularDescuento
//   consulta     capítulo 4: qué imprime Where con un Add después
var demo = args.FirstOrDefault() ?? "";

switch (demo)
{
    case "cobro": DemoCobro(); break;
    case "descuentos": return DemoDescuentos();
    case "consulta": DemoConsulta(); break;
    default:
        Console.WriteLine("Uso: dotnet run --project src/Tienda.Demos -- cobro | descuentos | consulta");
        break;
}
return 0;

static void DemoCobro()
{
    var pedido = new Pedido
    {
        Id = 1,
        Items =
        {
            new ItemPedido { Producto = "Camiseta", Precio = 12_000m, Cantidad = 2 },
            new ItemPedido { Producto = "Gorra", Precio = 6_000m, Cantidad = 1 },
        }
    };
    var servicio = new ServicioDeCobros(new PasarelaQueRechaza(), new RegistroEnConsola(), new BaseSimulada());

    // 4111 1111 1111 1111 es un número de tarjeta de prueba muy conocido, no una tarjeta real.
    var devuelto = servicio.CobrarPedido(pedido, "4111111111111111");

    Console.WriteLine($"La pasarela rechazó el cobro, pero CobrarPedido devolvió {devuelto}.");
    Console.WriteLine($"Estado del pedido: {pedido.Estado}");
}

static int DemoDescuentos()
{
    var fallos = 0;
    void Comprobar(string nombre, decimal esperado, decimal real)
    {
        var ok = esperado == real;
        if (!ok) fallos++;
        Console.WriteLine($"{(ok ? "OK   " : "FALLA")} {nombre}: esperado {esperado}, obtenido {real}");
    }

    Comprobar("0", 0m, Descuentos.CalcularDescuento(0m));
    Comprobar("49.999", 0m, Descuentos.CalcularDescuento(49_999m));
    Comprobar("50.000", 2_500m, Descuentos.CalcularDescuento(50_000m));
    Comprobar("99.999,99", 5_000.00m, Descuentos.CalcularDescuento(99_999.99m));
    Comprobar("100.000", 10_000m, Descuentos.CalcularDescuento(100_000m));
    Comprobar("123.456,78", 12_345.68m, Descuentos.CalcularDescuento(123_456.78m));
    try
    {
        Descuentos.CalcularDescuento(-1m);
        Console.WriteLine("FALLA negativo: no lanzó");
        fallos++;
    }
    catch (ArgumentOutOfRangeException)
    {
        Console.WriteLine("OK    negativo lanza ArgumentOutOfRangeException");
    }

    Console.WriteLine(fallos == 0 ? "TODO PASA" : $"{fallos} fallos");
    return fallos;
}

static void DemoConsulta()
{
    var numeros = new List<int> { 1, 2, 3 };
    var pares = numeros.Where(n => n % 2 == 0);
    numeros.Add(4);
    Console.WriteLine(pares.Count());
}

class PasarelaQueRechaza : IPasarelaDePago
{
    public string Cobrar(string numeroTarjeta, decimal total) => "RECHAZADA";
}

class BaseSimulada : ITiendaDb
{
    public int SaveChanges() => 0;
}

// Un ILogger mínimo que escribe en la consola, para ver el log sin configurar nada más.
class RegistroEnConsola : ILogger<ServicioDeCobros>
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull => null;
    public bool IsEnabled(LogLevel logLevel) => true;
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
        => Console.WriteLine($"[{logLevel}] {formatter(state, exception)}");
}
