// Software 12. Principio DRY
// Ingeniería de software, desde cero · Alonso Naranjo
//
// DRY, de «Don't Repeat Yourself»: no repita la misma regla en dos lugares.
// Con subtotal 30 y descuento del 10 %, todo da 27.

using System;

class Ejemplo
{
    // En un solo lugar: si el descuento cambia, se cambia aquí y nada más.
    static double AplicarDescuento(double subtotal) => subtotal - subtotal * 0.10;

    static void Main()
    {
        double subtotal = 30;

        // Repetida: la misma regla escrita tres veces
        var totalCarritoRepetido = subtotal - subtotal * 0.10;
        var totalFacturaRepetido = subtotal - subtotal * 0.10;
        var totalCorreoRepetido  = subtotal - subtotal * 0.10;

        // Una sola vez: los tres sitios llaman a la misma función
        var totalCarrito = AplicarDescuento(subtotal);
        var totalFactura = AplicarDescuento(subtotal);
        var totalCorreo  = AplicarDescuento(subtotal);

        Console.WriteLine(totalCarritoRepetido);  // 27
        Console.WriteLine(totalCarrito);          // 27
    }
}

// Si mañana el descuento pasa al 15 %:
//   - Repetida: hay que cambiar tres líneas; si se olvida una, el carrito y la factura muestran precios distintos.
//   - En un solo lugar: se cambia 0.10 por 0.15 en AplicarDescuento.
//
// Cuándo no juntar: DRY habla de conocimiento repetido, no de líneas que se parecen.
// Dos pedazos que se ven iguales pero cambian por razones distintas se dejan separados.
//
// Dos preguntas para su próximo código:
//   1. Si la regla cambia, ¿en cuántos lugares la toco?
//   2. ¿Estos dos pedazos cambian por la misma razón?
