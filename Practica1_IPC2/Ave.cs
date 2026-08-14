using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_IPC2
{
    internal class Ave: Mascota
    {
        // Atributos propios de Ave
        public double EnvergaduraAlas { get; set; } // en cm
        public bool PuedeVolar { get; set; }

        // Constructor de Ave
        public Ave(string nombre, double peso, string sexo, int edad, string propietario,
                   double envergaduraAlas, bool puedeVolar)
            : base(nombre, peso, sexo, edad, propietario)
        {
            EnvergaduraAlas = envergaduraAlas;
            PuedeVolar = puedeVolar;
        }

        // POLIMORFISMO: factor de ajuste del 50%
        public override double CalcularDosis(double dosisPorKg)
        {
            return Peso * dosisPorKg * 0.50;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Especie     : Ave");
            Console.WriteLine($"Envergadura : {EnvergaduraAlas} cm");
            Console.WriteLine($"¿Puede volar?: {(PuedeVolar ? "Sí" : "No")}");
        }
    }
}

