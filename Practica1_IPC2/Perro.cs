using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_IPC2
{
    internal class Perro: Mascota
    {
        // Atributos  de Perro 
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

        public override double CalcularDosis(double dosisPorKg)
        {
            return Peso * dosisPorKg; // dosis 
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion(); 
            Console.WriteLine($"Especie     : Perro");
            Console.WriteLine($"Raza        : {Raza}");
            Console.WriteLine($"Tamaño      : {Tamano}");
        }
    }
}

