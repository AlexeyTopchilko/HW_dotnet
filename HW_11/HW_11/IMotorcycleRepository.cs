using System;
using System.Collections.Generic;
using System.Text;

namespace HW_11
{
    interface IMotorcycleRepository
    {
        List<Motorcycle> GetMotorcycles();

        void Create(Motorcycle motorcycle);

        Motorcycle GetMotorcycle(int Id);

        void UpdateMotorcycle(Motorcycle motorcycle);

        void DeleteMotorcycle(int Id);
    }
}