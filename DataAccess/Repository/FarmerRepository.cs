using BusinessObject;
using DataAccess.DAO;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class FarmerRepository : IFarmerRepository
    {
        public void AddFarmer(Farmer Farmer) => FarmerDAO.Instance.AddFarmer(Farmer);

        public void DeleteFarmer(Farmer Farmer) => FarmerDAO.Instance.DeleteFarmer(Farmer);

        public Farmer? FindFarmerByCode(string farmerCode) => FarmerDAO.Instance.FindFarmerByCode(farmerCode);

        public Farmer? FindFarmerById(Guid farmerId) => FarmerDAO.Instance.FindFarmerById(farmerId);

        public IEnumerable<Farmer> GetFarmers() => FarmerDAO.Instance.GetFarmerList();

        public void UpdateFarmer(Farmer Farmer) => FarmerDAO.Instance.UpdateFarmer(Farmer);
    }
}
