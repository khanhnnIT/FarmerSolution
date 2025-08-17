using BusinessObject;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class FarmerDAO
    {
        private static readonly object InstanceLock = new object();
        private static FarmerDAO? instance = null;

        public static FarmerDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new FarmerDAO();
                    }
                    return instance;
                }
            }
        }

        public IEnumerable<Farmer> GetFarmerList()
        {
            var listFarmers = new List<Farmer>();
            try
            {
                using (var context = new FarmerContext())
                {
                    listFarmers = context.Farmers.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listFarmers;
        }

        public Farmer? FindFarmerById(Guid farmerId)
        {
            try
            {
                using (var context = new FarmerContext())
                {
                    return context.Farmers.SingleOrDefault(x => x.FarmerId == farmerId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Farmer? FindFarmerByCode(string farmerCode)
        {
            try
            {
                using (var context = new FarmerContext())
                {
                    return context.Farmers.SingleOrDefault(x => x.FarmerCode == farmerCode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void AddFarmer(Farmer farmer)
        {
            try
            {
                using (var context = new FarmerContext())
                {
                    if (FindFarmerByCode(farmer.FarmerCode) == null)
                    {
                        context.Farmers.Add(farmer);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateFarmer(Farmer farmer)
        {
            try
            {
                using (var context = new FarmerContext())
                {
                    var existingFarmer = FindFarmerById(farmer.FarmerId);
                    if (existingFarmer != null)
                    {
                        existingFarmer.FarmerName = farmer.FarmerName;
                        existingFarmer.FarmerNameEN = farmer.FarmerNameEN;
                        existingFarmer.Address = farmer.Address;
                        existingFarmer.Phone1 = farmer.Phone1;
                        existingFarmer.Phone2 = farmer.Phone2;
                        existingFarmer.UpdatedDate = DateTime.Now;

                        context.Entry(existingFarmer).State = EntityState.Modified;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteFarmer(Farmer Farmer)
        {
            try
            {
                using (var context = new FarmerContext())
                {
                    if (FindFarmerById(Farmer.FarmerId) != null)
                    {
                        context.Farmers.Remove(Farmer);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
