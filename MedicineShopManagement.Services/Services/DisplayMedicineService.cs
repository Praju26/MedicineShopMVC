using Microsoft.EntityFrameworkCore;
using MedicineShopManagement.DAL.Data;
using MedicineShopManagement.DAL.Data.Model;
using MedicineShopManagement.Services.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineShopManagement.Services.Services
{
    public interface IDisplayMedicineService
    {
        public Task<List<DisplayMedicine>> GetAllMedicines();
        public Task<medDisplayMedicineInfo> GetMedicineById(int? id);
        public Task<DisplayMedicine> GetAdvMedicneById(int? id);
        public Task<bool> CreateMedicine(medDisplayMedicineInfo medDisplayMedicineInfo);
        public Task UpdateMedicine(DisplayMedicine displayMedicine);
        public Task DeleteMedicine(DisplayMedicine displayMedicine);
        public bool MedicineExist(int id);
    }
    public class DisplayMedicineService : IDisplayMedicineService
    {
        public async Task<bool> CreateMedicine(medDisplayMedicineInfo medDisplayMedicineInfo)
        {
            using (var Context = new MEDDbContext())
            {
                try
                {
                    if (medDisplayMedicineInfo.Type != null)
                    {
                        Context.MedicineTypes.Add(new MedicineType
                        {
                            Id = 0,
                            Type = medDisplayMedicineInfo.Type
                        });
                        await Context.SaveChangesAsync();
                        var selectedType = await Context.MedicineTypes.FirstOrDefaultAsync(o => o.Type == medDisplayMedicineInfo.Type);
                        medDisplayMedicineInfo.TypeId = selectedType.Id;
                    }

                    Context.DisplayMedicines.Add(new DisplayMedicine
                    {
                        Id = medDisplayMedicineInfo.Id,
                        TypeId = medDisplayMedicineInfo.TypeId,
                        Name = medDisplayMedicineInfo.Name,
                        Quantity = medDisplayMedicineInfo.Quantity,
                        Price = medDisplayMedicineInfo.Price,
                        Cost_Price = medDisplayMedicineInfo.Cost_Price,
                        MedicineCode_Code = medDisplayMedicineInfo.MedicineCode_Code,
                        CreatedOn = medDisplayMedicineInfo.CreatedOn,
                        UpdatedOn = medDisplayMedicineInfo.UpdatedOn
                    });
                    await Context.SaveChangesAsync();
                }
                catch(Exception)
                {
                    return false;
                }
                return true;
            }
        }

        public async Task DeleteProduct(DisplayMedicine displayMedicine)
        {
            using(var Context = new MEDDbContext())
            {
                Context.DisplayMedicines.Remove(DisplayMedicine);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<DisplayMedicine>> GetAllMedicines()
        {
            using(var Context = new MEDDbContext())
            {
                var joinContext = Context.DisplayMedicines.Include(a => a.MedicineType);
                return await joinContext.ToListAsync();
            }
        }

        public async Task<medDisplayMedicine> Info> GetMedicineById(int? id)
        {
            using(var Context = new MEDDbContext())
            {
                var resultMedicine= await Context.DisplayMedicine > s.FirstOrDefaultAsync(o => o.Id == id);
                var resultType = await Context.MedicineTypes.FirstOrDefaultAsync(o => o.Id == resultMedicine.MedicineId);
                return new medDisplayMedicine> Info()
                {
                    Id = resultMedicine.Id,
                    TypeId = resultMedicine.TypeId,
                    Type = resultType.Type,
                    Cost_Price = resultMedicine.Cost_Price,
                    CreatedOn = resultMedicine.CreatedOn,
                    MedicineCode_Code = resultMedicine.MedicineCode_Code,
                  
                    Name = resultMedicine.Name,
                    Price = resultMedicine.Price,
                    Quantity = resultMedicine.Quantity,
                    UpdatedOn = resultMedicine.UpdatedOn
                };
            }
        }

        public async Task<DisplayMedicine> GetDisplayMedicineById(int? id)
        {
            using (var Context = new MEDDbContext())
            {
                return await Context.DisplayMedicines.FirstOrDefaultAsync(o => o.Id == id);
            }
        }

        public bool MedicineExist(int id)
        {
            using(var Context = new MEDDbContext())
            {
                return Context.DisplayMedicines.Any(e => e.Id == id);
            }
        }

        public async Task UpdateMedicine(DisplayMedicine displayMedicine)
        {
            using(var Context = new MEDDbContext())
            {
                Context.DisplayMedicines.Update(displayMedicine);
                await Context.SaveChangesAsync();
            }
        }
    }
}
