using Serilog;
using System.Collections.Generic;

namespace HW_11
{
    class MotorcycleRepository : IMotorcycleRepository
    {
        private static List<Motorcycle> _motorcycles = new List<Motorcycle>();
        public void Create(Motorcycle motorcycle)
        {
            Log.Information("Trying to add motorcycle to list:");
            if (motorcycle != null)
            {
                _motorcycles.Add(motorcycle);
                Log.Information($"Motorcycle with Id{motorcycle.Id} added to list.");
            }
            else
                Log.Error("Motorcycle does not exist!");
        }

        public void DeleteMotorcycle(int Id)
        {
            Log.Information($"Trying to delet motorcycle with Id{Id}");
            Motorcycle moto = _motorcycles.Find(motorcycle => motorcycle.Id == Id);
            _motorcycles.Remove(moto);
            if (moto == null)
                Log.Error($"Motorcycle with Id{Id} does not exist!");
            else
                Log.Information($"Motorcycle with Id{Id} deleted successfully.");
        }

        public Motorcycle GetMotorcycle(int Id)
        {
            Log.Information($"Trying to get motorycle with Id{Id}:");
            Motorcycle moto = _motorcycles.Find(motorcycle => motorcycle.Id == Id);
            if (moto == null)
                Log.Error("Motorcycle does not exist, returned null!");
            else
                Log.Information($"Motorcycle with Id{Id} getted succesfuly.");
            return moto;
        }

        public List<Motorcycle> GetMotorcycles()
        {
            Log.Information("Trying to get list of motorcycles:");
            if (_motorcycles == null)
                Log.Error("List is empty, returned null!");
            else
                Log.Information("List getted succesfuly.");
            return _motorcycles;
        }

        public void UpdateMotorcycle(Motorcycle motorcycle)
        {
            Log.Information($"Started update of motorcycle {motorcycle.Id} " +
            $"{motorcycle.Manufacturer} {motorcycle.Model} {motorcycle.Odometr}");
            if (motorcycle != null)
            {
                motorcycle.Manufacturer = Motorcycle.ValidateManufacturer();
                motorcycle.Model = Motorcycle.ValidateModel();
                motorcycle.Odometr = Motorcycle.ValidateOdometr();
                Log.Information($"Update finished! Updated motorcycle is {motorcycle.Id} " +
                    $"{motorcycle.Manufacturer} {motorcycle.Model} {motorcycle.Odometr} .");
            }
            else
                Log.Error("Motorcycle does not exist!");
        }

        public void UpdateMotorcycle(Motorcycle motorcycle, string newManufacturer, string newModel, int newOdometr)
        {
            Log.Information($"Started update of motorcycle {motorcycle.Id} " +
            $"{motorcycle.Manufacturer} {motorcycle.Model} {motorcycle.Odometr}");
            if (motorcycle != null)
            {
                motorcycle.Manufacturer = newManufacturer;
                motorcycle.Model = newModel;
                if (newOdometr > 100)
                    motorcycle.Odometr = 100;
                else if (newOdometr < 0)
                    motorcycle.Odometr = 0;
                else
                    motorcycle.Odometr = newOdometr;
                Log.Information($"Update finished! Updated motorcycle is {motorcycle.Id} " +
                    $"{motorcycle.Manufacturer} {motorcycle.Model} {motorcycle.Odometr} .");
            }
            else
                Log.Error("Motorcycle does not exist!");
        }
    }
}