// Software 13. Principio KISS
// Ingeniería de software, desde cero · Alonso Naranjo
//
// KISS, de «Keep It Simple, Stupid»: de dos soluciones que funcionan, gana la que se entiende más fácil.
// Con cuenta 50 y propina de 10 %, las dos dan 5.

using System;

// Simple: una función
// decimal Propina(decimal cuenta, decimal porcentaje) => cuenta * porcentaje / 100;

// «Por si algún día crece»: interfaz, clase, fábrica y calculadora
interface IReglaPropina { decimal Calcular(decimal cuenta); }

class PropinaPorcentaje : IReglaPropina
{
    private readonly decimal _porcentaje;
    public PropinaPorcentaje(decimal porcentaje) => _porcentaje = porcentaje;
    public decimal Calcular(decimal cuenta) => cuenta * _porcentaje / 100;
}

class FabricaDeReglas
{
    public IReglaPropina Crear(string tipo, decimal valor) => new PropinaPorcentaje(valor);
}

class CalculadoraDePropinas
{
    private readonly IReglaPropina _regla;
    public CalculadoraDePropinas(IReglaPropina regla) => _regla = regla;
    public decimal Calcular(decimal cuenta) => _regla.Calcular(cuenta);
}

class Ejemplo
{
    static decimal Propina(decimal cuenta, decimal porcentaje) => cuenta * porcentaje / 100;

    static void Main()
    {
        Console.WriteLine(Propina(50, 10));   // 5
        Console.WriteLine(new CalculadoraDePropinas(new FabricaDeReglas().Crear("porcentaje", 10)).Calcular(50));   // 5
    }
}

// Pregunta antes de agregar una clase o una capa: ¿qué problema de hoy resuelve?
// Si el programa crece, usted lo amplía ese día.
