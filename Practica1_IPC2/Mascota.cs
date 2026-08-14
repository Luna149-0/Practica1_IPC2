using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_IPC2
{
    internal abstract class Mascota
    {
        // ----- Atributos de Mascota -----
        private string nombre;
        private double peso;
        private string sexo;
        private int edad;
        private string propietario;
        private string codigo;
        private bool enfermo;


        // ----- Propiedades -----
        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public double Peso
        {
            get { return peso; }
            set
            {
                if (value > 0)
                    peso = value;
            }
        }

        public string Sexo
        {
            get { return sexo; }
            set { sexo = value; }
        }

        public int Edad
        {
            get { return edad; }
            set
            {
                if (value >= 0)
                    edad = value;
            }
        }

        public string Propietario
        {
            get { return propietario; }
            set { propietario = value; }
        }

        public string Codigo
        {
            get { return codigo; }
        }

        public bool Enfermo
        {
            get { return enfermo; }
        }

        // ----- Constructor -----
        protected Mascota(string nombre, double peso, string sexo, int edad, string propietario)
        {
            this.nombre = nombre;
            this.peso = peso;
            this.sexo = sexo;
            this.edad = edad;
            this.propietario = propietario;
            this.codigo = GenerarCodigo();
            this.enfermo = false; 
        }

        // ----- código único de 8 caracteres alfanuméricos -----
        private string GenerarCodigo()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            char[] resultado = new char[8];

            for (int i = 0; i < 8; i++)
            {
                resultado[i] = caracteres[rnd.Next(caracteres.Length)];
            }

            return new string(resultado);
        }

        // ----- Métodos -----

        // Cambia el estado entre enfermo y sano
        public void CambiarEstado()
        {
            enfermo = !enfermo;
        }

        public abstract double CalcularDosis(double dosisPorKg);


        public virtual void MostrarInformacion()
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine($"Código      : {codigo}");
            Console.WriteLine($"Nombre      : {nombre}");
            Console.WriteLine($"Peso        : {peso} kg");
            Console.WriteLine($"Sexo        : {sexo}");
            Console.WriteLine($"Edad        : {edad} años");
            Console.WriteLine($"Propietario : {propietario}");
            Console.WriteLine($"Estado      : {(enfermo ? "Enfermo" : "Sano")}");
        }
    }


}

