using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShopManagement.DAL.Data.Model
{
    public class MedicineDetailInfo
    {
        public int Id { get; set; }
        public decimal Medicine_Cost_Price { get; set; }
        public string MedicineCode_Code { get; set; }
    }
}
