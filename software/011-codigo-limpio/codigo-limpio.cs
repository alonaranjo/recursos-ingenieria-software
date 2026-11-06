// Software 11. Qué es código limpio
// Ingeniería de software, desde cero · Alonso Naranjo
//
// Dos programas que hacen lo mismo. Con precio 10 y cantidad 3, los dos dan 27.

using System;

class Ejemplo
{
    // Versión A: hay que adivinar qué es a, qué es b y qué es 0.1
    static double f(double a, int b) { return a * b - (a * b * 0.1); }

    // Versión B: se lee como una frase
    static double CalcularTotal(double precioUnitario, int cantidad)
    {
        var subtotal = precioUnitario * cantidad;
        var descuento = subtotal * 0.10;
        return subtotal - descuento;
    }

    static void Main()
    {
        Console.WriteLine(f(10, 3));               // 27
        Console.WriteLine(CalcularTotal(10, 3));   // 27
    }
}

// Si mañana el descuento pasa al 15 %:
//   - En la A hay que adivinar cuál de esos números es el descuento.
//   - En la B se cambia una línea: var descuento = subtotal * 0.15;
//
// Dos preguntas para su próximo código:
//   1. ¿Alguien nuevo lo entiende sin preguntarle?
//   2. ¿Sabe dónde tocar si la regla cambia?
