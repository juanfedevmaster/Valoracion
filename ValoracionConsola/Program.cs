using System;
using System.Collections.Generic;

namespace FabricaDeVehiculos
{
    public class MotorTesla
    {
        public string Marca = "Tesla";
        public int PotenciaHP = 500;
        public string Tipo = "Eléctrico";

        public void Encender()
        {
            Console.WriteLine("Motor Tesla encendido silenciosamente.");
        }
    }

    public class FrenoBrembo
    {
        public string Marca = "Brembo";
        public string Tipo = "Disco";
        public bool EsAntibloqueo = true;

        public void Frenar()
        {
            Console.WriteLine("Freno Brembo activado con precisión.");
        }
    }

    public class AccesorioGpsGarmin
    {
        public string Marca = "Garmin";
        public string Tipo = "GPS";
        public bool EsOpcional = false;

        public void Activar()
        {
            Console.WriteLine("GPS Garmin listo para navegación.");
        }
    }

    public class AccesorioSonidoBose
    {
        public string Marca = "Bose";
        public string Tipo = "Sistema de Sonido";
        public bool EsOpcional = true;

        public void Activar()
        {
            Console.WriteLine("Sistema de sonido Bose encendido.");
        }
    }

    public class Vehiculo
    {
        public MotorTesla Motor;
        public FrenoBrembo Freno;
        public List<object> Accesorios;

        public Vehiculo(MotorTesla motor, FrenoBrembo freno, List<object> accesorios)
        {
            Motor = motor;
            Freno = freno;
            Accesorios = accesorios;
        }

        public void MostrarConfiguracion()
        {
            Console.WriteLine("=== Vehículo Configurado ===");
            Console.WriteLine($"Motor: {Motor.Marca} - {Motor.Tipo} - {Motor.PotenciaHP} HP");
            Console.WriteLine($"Freno: {Freno.Marca} - {Freno.Tipo} - ABS: {Freno.EsAntibloqueo}");
            Console.WriteLine("Accesorios:");
            foreach (var acc in Accesorios)
            {
                if (acc is AccesorioGpsGarmin gps)
                    Console.WriteLine($" - {gps.Marca} ({gps.Tipo}) - Opcional: {gps.EsOpcional}");
                else if (acc is AccesorioSonidoBose bose)
                    Console.WriteLine(
                        $" - {bose.Marca} ({bose.Tipo}) - Opcional: {bose.EsOpcional}"
                    );
            }
        }

        public void Encender()
        {
            Console.WriteLine("\n--- Encendiendo vehículo ---");
            Motor.Encender();
            foreach (var acc in Accesorios)
            {
                if (acc is AccesorioGpsGarmin gps)
                    gps.Activar();
                else if (acc is AccesorioSonidoBose bose)
                    bose.Activar();
            }
            Freno.Frenar();
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var motor = new MotorTesla();
            var freno = new FrenoBrembo();
            var accesorios = new List<object>
            {
                new AccesorioGpsGarmin(),
                new AccesorioSonidoBose(),
            };

            var vehiculo = new Vehiculo(motor, freno, accesorios);

            vehiculo.MostrarConfiguracion();
            vehiculo.Encender();

            Console.WriteLine("\nVehículo listo para entrega.");
        }
    }
}
