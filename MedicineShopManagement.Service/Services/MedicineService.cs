using System.Collections.Generic;
using System.Threading.Tasks;
using MedicineShopManagement.DAL.Data.Model;
using MedicineShopManagement.DAL.Data;

namespace MedicineShopManagement.Service.Services
{
    public interface IMedicineService
    {
        public Task<List<Medicine>> GetAllMedicines();
    }
    class MedicineService : IMedicineService
    {
        public async Task<List<Medicine>> GetAllMedicines()
        {
            using (var Context = new MEDDbContext())
            {
                return
            }
        }
    }
}
