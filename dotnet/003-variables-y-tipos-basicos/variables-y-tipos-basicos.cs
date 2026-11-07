// .NET 3. Variables y tipos básicos en C#
// Ingeniería de software, desde cero · Alonso Naranjo
//
// Una variable es una cajita con un nombre, donde usted guarda un valor.
// Tiene un tipo, que define qué datos caben en ella.

using System;

class Ejemplo
{
    static void Main()
    {
        // Los cinco tipos que más va a usar
        int edad = 30;             // enteros
        double altura = 1.75;      // decimales aproximados
        decimal precio = 1500.50m; // decimales exactos: el de la plata (lleva una m al final)
        string nombre = "Ana";     // texto
        bool activo = true;        // verdadero o falso

        Console.WriteLine($"{edad} {altura} {precio} {nombre} {activo}");

        // C# revisa el tipo antes de correr: guardar texto en un int no compila.
        // edad = "hola";   // error CS0029: no se puede convertir implícitamente 'string' en 'int'

        // La trampa: con dos int, la división pierde el decimal
        Console.WriteLine(7 / 2);     // 3
        Console.WriteLine(7 / 2.0);   // 3,5
    }
}

// Para hacer hoy: declare una variable de cada tipo, imprímalas y pruebe las dos divisiones.
// Si algo falla, pegue el error en Claude y pídale que se lo explique.
//
// La coma decimal de la salida depende de la configuración regional de su máquina.
