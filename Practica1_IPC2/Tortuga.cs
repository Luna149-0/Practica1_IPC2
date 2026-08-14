using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_IPC2
{
    internal class Tortuga: Mascota
    {
        // Atributos propios de Tortuga
        public string TipoCaparazon { get; set; }
        public bool EsAcuatica { get; set; }

        // Constructor de Tortuga
        public Tortuga(string nombre, double peso, string sexo, int edad, string propietario,
                       string tipoCaparazon, bool esAcuatica)
            : base(nombre, peso, sexo, edad, propietario)
        {
            TipoCaparazon = tipoCaparazon;
            EsAcuatica = esAcuatica;
        }

        // POLIMORFISMO: factor de ajuste del 80%
        public override double CalcularDosis(double dosisPorKg)
        {
            return Peso * dosisPorKg * 0.80;
        }

        public override void MostrarInformacion()
        {
            base.MostrarInformacion();
            Console.WriteLine($"Especie     : Tortuga");
            Console.WriteLine($"Caparazón   : {TipoCaparazon}");
            Console.WriteLine($"¿Es acuática?: {(EsAcuatica ? "Sí" : "No")}");
        }
    }
}

