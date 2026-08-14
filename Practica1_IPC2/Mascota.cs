using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_IPC2
{
    internal abstract class Mascota
    {
        private static int contador = 0;
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

        //CODIGO
        private string GenerarCodigo()
        {
            contador++; 
            return contador.ToString("D8"); 
        }

        // METODOS

        // VE SI ESTA ENFERMO O SAMO
        public void CambiarEstado()
        {
            enfermo = !enfermo;
        }
        //CALCULO DE DOSIS
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

