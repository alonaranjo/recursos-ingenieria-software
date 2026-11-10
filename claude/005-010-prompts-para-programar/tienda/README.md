# tienda: el proyecto de C# del video «Prompts para programar con Claude»

Una tienda en línea mínima, en C# (.NET 7), para probar los ejemplos del video. Se probó con el SDK de .NET 7.0.302; si usa otra versión, cambie `net7.0` en los archivos `.csproj`.

## Qué tiene

```
Tienda.sln
src/
  Tienda/                      biblioteca de clases
    Modelos/                   Pedido, ItemPedido
    Cobros/                    ServicioDeCobros.CobrarPedido: la función que se le pide revisar a Claude (tiene problemas a propósito)
    Precios/Descuentos.cs      CalcularDescuento: el método que escribe Claude con el prompt con datos
  Tienda.Demos/                consola con tres demos
tests/
  Tienda.Pruebas/              pruebas de xUnit con el estilo Dado / Cuando / Entonces
```

## Cómo correrlo

Desde esta carpeta:

```bash
dotnet run --project src/Tienda.Demos -- cobro        # qué hace CobrarPedido cuando la pasarela rechaza la tarjeta
dotnet run --project src/Tienda.Demos -- descuentos   # 7 comprobaciones de CalcularDescuento (termina en TODO PASA)
dotnet run --project src/Tienda.Demos -- consulta     # qué imprime un Where con un Add después (imprime 2)
dotnet test                                           # las 4 pruebas de xUnit
```

## Notas

- `ServicioDeCobros.CobrarPedido` se deja con sus problemas: es el código que el video le pide revisar a Claude. No lo use en un proyecto real.
- El número `4111111111111111` de la demo es un número de tarjeta de prueba muy conocido, no una tarjeta real.
- `IPasarelaDePago` e `ITiendaDb` son interfaces mínimas para que el ejemplo compile sin pasarela ni base de datos reales.
- Los textos de los prompts del video van en la hoja de apoyo (`../prompts-para-programar.pdf`) y en `../plantillas-de-prompt.txt`.
