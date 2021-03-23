using Serilog;
using System;
using System.Collections.Generic;
using System.Reflection;
namespace HW_11
{
    class Program
    {
        static void Main(string[] args)
        {
            string appsName = Assembly.GetCallingAssembly().GetName().Name;
            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console().WriteTo.File("log.txt",rollingInterval : RollingInterval.Hour).CreateLogger();
            Log.Information($"{appsName} application launched.");

            Motorcycle motorcycle = new Motorcycle("Yamaha", "Yamaha", 50);
            Motorcycle motorcycle1 = new Motorcycle("Java", "350", 30);
            Motorcycle motorcycle2 = new Motorcycle("Minsk", "Korito", 10);
            Motorcycle motorcycle3 = new Motorcycle("Moped", "Dvorovoj", 5);
            Motorcycle motorcycle4 = new Motorcycle("Velik", "Modnij", 69);

            MotorcycleRepository motorepo = new MotorcycleRepository();

            motorepo.Create(motorcycle);
            motorepo.Create(motorcycle1);
            motorepo.Create(motorcycle2);
            motorepo.Create(motorcycle3);
            motorepo.Create(motorcycle4);

            List<Motorcycle> motos = motorepo.GetMotorcycles();
            foreach (Motorcycle item in motos)
                item.GetCharacteristics();

            motorepo.DeleteMotorcycle(5);

            motorepo.UpdateMotorcycle(motorcycle4, "Bycicle", "Fashionable", 37);

            foreach (Motorcycle item in motos)
                item.GetCharacteristics();

            Log.Information($"{appsName} application finished.");
        }
    }
}