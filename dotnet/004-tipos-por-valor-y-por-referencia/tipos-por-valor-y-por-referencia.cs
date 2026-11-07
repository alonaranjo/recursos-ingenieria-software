// .NET 4. Tipos por valor y por referencia en C#
// Ingeniería de software, desde cero · Alonso Naranjo
//
// Algunas variables guardan el dato, y otras solo guardan el enlace.

using System;

class Cliente { public string Nombre = ""; }

class Ejemplo
{
    static void Main()
    {
        // Por valor (números, bool, char): al copiar, queda otro dato
        int a = 5;
        int b = a;     // b recibe una copia
        b = 9;         // a sigue en 5

        // Por referencia (clases): al copiar, dos variables apuntan al mismo objeto
        var c1 = new Cliente { Nombre = "Ana" };
        var c2 = c1;           // c2 recibe el enlace
        c2.Nombre = "Luis";    // c1 también se llama Luis

        Console.WriteLine($"{a} {c1.Nombre}");   // 5 Luis
    }
}

// Para hacer hoy: copie una variable int y una de un objeto suyo, cambie la copia
// y mire cuál original cambió. Si algo falla, pegue el error en Claude y pídale que se lo explique.
