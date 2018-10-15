using System.Collections.Generic;
using LabOne.Models;

namespace LabOne.Services
{
    public interface IDealershipManager
    {
        List<Dealership> GetDealerships();

        Dealership GetDealership(int id);

        bool CreateDealership(Dealership dealership);

        bool UpdateDealership(int id, Dealership dealership);

        bool DeleteDealership(int id);
    }
}
