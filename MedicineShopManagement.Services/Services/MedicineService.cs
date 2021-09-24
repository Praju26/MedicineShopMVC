using Microsoft.EntityFrameworkCore;
using MedicineShopManagement.DAL.Data;
using MedicineShopManagement.DAL.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineShopManagement.Services.Services
{
    public interface IMedicineService
    {
        public Task<List<Medicine>> GetAllMedicines();
        public Task<Medicine> GetMedicineById(int? id);
        public Task<MedicineDetailInfo> GetMedicineInfoById(int? id);
        public Task<bool> CreateMedicine(Medicine medicine, MedicineDetailInfo medicineDtailInfo);
        public Task UpdateMedicine(Medicine medicine, MedicineDetailInfo medicineDetailInfo);
        public Task DeleteMedicine(int id);
        public bool MedicineExist(int id);
    }
    public class MedicineService : IMedicineService
    {
        public async Task<List<Medicine>> GetAllMedicines()
        {
            using (var Context = new MEDDbContext())
            {
                return await Context.Medicines.ToListAsync();
            }
        }

        public async Task<Medicine> GetMedicineById(int? id)
        {
            using (var Context = new MEDDbContext())
            {
                return await Context.Medicines.FirstOrDefaultAsync(m => m.Id == id);
            }
        }
        public async Task<MedicineDetailInfo> GetMedicineInfoById(int? id)
        {
            using (var Context = new MEDDbContext())
            {
                return await Context.MedicineDetailInfos.FirstOrDefaultAsync(m => m.Id == id);
            }
        }

        public async Task<bool> CreateMedicine(Medicine medicine, MedicineDetailInfo medicineDetailInfo)
        {
            using (var Context = new MEDDbContext())
            {
                try
                {
                    Context.Add(Medicine);
                    Context.Add(medicineDetailInfo);
                    await Context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task UpdateMedicine(Medicine medicine, MedicineDetailInfo medicineDetailInfo)
        {
            using (var Context = new MEDDbContext())
            {
                Context.Update(medicine);
                Context.Update(medicineDetailInfo);
                await Context.SaveChangesAsync();
            }
        }

        public async Task DeleteMedicine(int id)
        {
            var medicine = await GetMedicineById(id);
            using (var Context = new MEDDbContext())
            {
                Context.Medicines.Remove(medicine);
                await Context.SaveChangesAsync();
            }
        }

        public bool MedicineExist(int id)
        {
            using (var Context = new MEDDbContext())
            {
                return Context.Medicines.Any(e => e.Id == id);
            }
        }
    }
}
