using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_IPC2
{
    internal class Perro: Mascota
    {
        // Atributos propios de Perro 
        public string Raza { get; set; }
        public string Tamano { get; set; }

        // Constructor de Perro
        public Perro(string nombre, double peso, string sexo, int edad, string propietario,
                     string raza, string tamano)
            : base(nombre, peso, sexo, edad, propietario)
        {
            Raza = raza;
            Tamano = tamano;
        }

        // POLIMORFISMO
        public override double CalcularDosis(double dosisPorKg)
        {
            return Peso * dosisPorKg; // dosis estándar, sin ajuste
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion(); // reutiliza la info general de Mascota
            Console.WriteLine($"Especie     : Perro");
            Console.WriteLine($"Raza        : {Raza}");
            Console.WriteLine($"Tamaño      : {Tamano}");
        }
    }
}

