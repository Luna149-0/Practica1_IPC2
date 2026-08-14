using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1_IPC2 
{ 
 internal class Program
{
    // Lista para guardar las mascotas que estan registradasLista
    static List<Mascota> mascotas = new List<Mascota>();
    static void Main(string[] args)
    {
        bool salir = false;
        while (!salir)
        {
            MostrarMenuPrincipal();
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RegistrarMascota();
                    break;
                case "2":
                    ListarMascotas();
                    break;
                case "3":
                    GestionarMascota();
                    break;
                case "4":
                    salir = true;
                    Console.WriteLine("¡Hasta luego!");
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }

    static void MostrarMenuPrincipal()
    {
        Console.WriteLine();
        Console.WriteLine("===== BIENVENID@S AL SISTEMA DE VETERINARIA =====");
        Console.WriteLine("1. Registrar nueva mascota");
        Console.WriteLine("2. Listar mascotas registradas");
        Console.WriteLine("3. Gestionar una mascota ");
        Console.WriteLine("4. Salir");
        Console.Write("Seleccione una opción: ");
    }

    //ESTA PARTE REGISTRA UNA NUEVA MASCOTA
    static void RegistrarMascota()
    {
        Console.WriteLine();
        Console.WriteLine("--- REGISTRAR UNA NUEVA MASCOTA ---");
        Console.WriteLine("1. Perro");
        Console.WriteLine("2. Gato");
        Console.WriteLine("3. Ave");
        Console.WriteLine("4. Tortuga");
        Console.Write("Tipo de mascota: ");
        string tipo = Console.ReadLine();

        // Datos 
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();

        Console.Write("Peso (kg): ");
        double peso = LeerDouble();

        Console.Write("Sexo (M/H): ");
        string sexo = Console.ReadLine();

        Console.Write("Edad (años): ");
        int edad = LeerEntero();

        Console.Write("Propietario: ");
        string propietario = Console.ReadLine();

        Mascota nuevaMascota = null;

        switch (tipo)
        {
                //CUANDO ES PERRO
            case "1": 
                Console.Write("Raza: ");
                string razaPerro = Console.ReadLine();
                Console.Write("Tamaño (pequeño-mediano-grande): ");
                string tamano = Console.ReadLine();
                nuevaMascota = new Perro(nombre, peso, sexo, edad, propietario, razaPerro, tamano);
                break;
                //CUANDO ES GATO
            case "2": 
                Console.Write("Raza: ");
                string razaGato = Console.ReadLine();
                Console.Write("¿Esterilizado? (s/n): ");
                bool esterilizado = Console.ReadLine().Trim().ToLower() == "s";
                nuevaMascota = new Gato(nombre, peso, sexo, edad, propietario, razaGato, esterilizado);
                break;

                //CUANDO ES AVE
            case "3": 
                Console.Write("Envergadura de alas (cm): ");
                double envergadura = LeerDouble();
                Console.Write("¿Puede volar? (s/n): ");
                bool puedeVolar = Console.ReadLine().Trim().ToLower() == "s";
                nuevaMascota = new Ave(nombre, peso, sexo, edad, propietario, envergadura, puedeVolar);
                break;

                //CUANDO ES TORTUGA
            case "4": 
                Console.Write("Tipo de caparazón: ");
                string caparazon = Console.ReadLine();
                Console.Write("¿Es acuática? (s/n): ");
                bool esAcuatica = Console.ReadLine().Trim().ToLower() == "s";
                nuevaMascota = new Tortuga(nombre, peso, sexo, edad, propietario, caparazon, esAcuatica);
                break;

            default:
                Console.WriteLine("Tipo de mascota inválido.");
                return;
        }

        mascotas.Add(nuevaMascota);
        Console.WriteLine("\n✔ Mascota registrada con éxito. Código asignado: " + nuevaMascota.Codigo);
    }

        // ESTA PARTE ES PARA LISTAR TODAS LAS MASCOTAS REGISTRADAS
        static void ListarMascotas()
    {
        Console.WriteLine();
        Console.WriteLine("--- Mascotas registradas ---");

        if (mascotas.Count == 0)
        {
            Console.WriteLine("No hay mascotas registradas todavía.");
            return;
        }

        foreach (var m in mascotas)
        {
            string tipo = m.GetType().Name; 
            Console.WriteLine("Código: " + m.Codigo + " | Nombre: " + m.Nombre +
                " | Tipo: " + tipo + " | Estado: " + (m.Enfermo ? "Enfermo" : "Sano"));
        }
    }

    // PARA GESTIONAR LAS MASCOTAS
    static void GestionarMascota()
    {
        if (mascotas.Count == 0)
        {
            Console.WriteLine("No hay mascotas registradas todavía.");
            return;
        }

        Console.Write("\nIngrese el código de la mascota: ");
        string codigo = Console.ReadLine().Trim().ToUpper();

        Mascota mascota = mascotas.FirstOrDefault(m => m.Codigo == codigo);

        if (mascota == null)
        {
            Console.WriteLine("No se encontró ninguna mascota con ese código.");
            return;
        }

        bool volver = false;
        while (!volver)
        {
            Console.WriteLine("\n--- Gestionando a " + mascota.Nombre + " (" + mascota.Codigo + ") ---");
            Console.WriteLine("1. Mostrar información completa");
            Console.WriteLine("2. Cambiar estado (enfermo/sano)");
            Console.WriteLine("3. Calcular dosis de medicamento");
            Console.WriteLine("4. Eliminar (retirar de la clínica)");
            Console.WriteLine("5. Volver al menú principal");
            Console.Write("Opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.WriteLine();
                    mascota.MostrarInformacion(); 
                    break;

                case "2":
                    mascota.CambiarEstado();
                    Console.WriteLine("Nuevo estado: " + (mascota.Enfermo ? "Enfermo" : "Sano"));
                    break;

                case "3":
                    Console.Write("Ingrese la dosis por kg del medicamento (mg/kg): ");
                    double dosisPorKg = LeerDouble();
                    double dosisFinal = mascota.CalcularDosis(dosisPorKg);
                    Console.WriteLine("Dosis calculada para " + mascota.Nombre + ": " + dosisFinal.ToString("F2") + " mg");
                    break;

                case "4":
                    mascotas.Remove(mascota);
                    Console.WriteLine("Mascota retirada del sistema.");
                    volver = true;
                    break;

                case "5":
                    volver = true;
                    break;

                default:
                    Console.WriteLine("Opción inválida.");
                    break;
            }
        }
    }

    // CUANDO SE INGRESAN UN VALOR QUE NO ES VALIDO
    static double LeerDouble()
    {
        double valor;
        while (!double.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Valor inválido, ingrese un número: ");
        }
        return valor;
    }

    static int LeerEntero()
    {
        int valor;
        while (!int.TryParse(Console.ReadLine(), out valor))
        {
            Console.Write("Valor inválido, ingrese un número entero: ");
        }
        return valor;
    }
}
}