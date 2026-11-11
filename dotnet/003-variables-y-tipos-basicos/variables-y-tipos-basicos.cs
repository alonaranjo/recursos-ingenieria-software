// .NET 3. Por qué 7 entre 2 da 3 en C# y cómo obtener 3,5
// Ingeniería de software, desde cero · Alonso Naranjo
//
// Con dos int, el resultado es un int y el decimal se pierde.
// Con un número decimal (2.0 o 2m), se conserva.

using System;

class Ejemplo
{
    static void Main()
    {
        // La trampa y el arreglo
        Console.WriteLine(7 / 2);     // 3    (dos int: pierde el decimal)
        Console.WriteLine(7 / 2.0);   // 3,5  (2.0 es un double)
        Console.WriteLine(7 / 2m);    // 3,5  (con la plata, ponga la m: decimal)

        // Los cinco tipos que más va a usar
        int edad = 30;             // enteros
        double altura = 1.75;      // decimales aproximados
        decimal precio = 1500.50m; // decimales exactos: el de la plata (lleva una m al final)
        string nombre = "Ana";     // texto
        bool activo = true;        // verdadero o falso

        Console.WriteLine($"{edad} {altura} {precio} {nombre} {activo}");

        // C# revisa el tipo antes de correr: guardar texto en un int no compila.
        // edad = "hola";   // error CS0029: no se puede convertir implícitamente 'string' en 'int'
    }
}

// Para hacer hoy: declare una variable de cada tipo, imprímalas y pruebe las dos divisiones.
// Si algo falla, pegue el error en Claude y pídale que se lo explique.
//
// La coma decimal de la salida depende de la configuración regional de su máquina.
