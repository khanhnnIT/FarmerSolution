using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface IFarmerRepository
    {
        IEnumerable<Farmer> GetFarmers();
        Farmer? FindFarmerByCode(string farmerCode);
        Farmer? FindFarmerById(Guid farmerId);
        void AddFarmer(Farmer Farmer);
        void UpdateFarmer(Farmer Farmer);
        void DeleteFarmer(Farmer Farmer);
    }
}
