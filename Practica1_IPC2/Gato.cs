using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_IPC2
{
    internal class Gato:Mascota
    {
        // Atributos propios de Gato
        public string Raza { get; set; }
        public bool Esterilizado { get; set; }

        // Constructor de Gato
        public Gato(string nombre, double peso, string sexo, int edad, string propietario,
                    string raza, bool esterilizado)
            : base(nombre, peso, sexo, edad, propietario)
        {
            Raza = raza;
            Esterilizado = esterilizado;
        }

        // POLIMORFISMO: factor de ajuste del 90%
        public override double CalcularDosis(double dosisPorKg)
        {
            return Peso * dosisPorKg * 0.90;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Especie     : Gato");
            Console.WriteLine($"Raza        : {Raza}");
            Console.WriteLine($"Esterilizado: {(Esterilizado ? "Sí" : "No")}");
        }
    }
}

