using System.Collections.Generic;
using LabOneA.Models;

namespace LabOneA.Services
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
