using MedicineShopManagement.DAL.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MdicineShopManagement.ViewModel
{
    public class MedicineDetailViewModel
    {
        public Medicine Medicine { get; set; }
        public MedicineDetailInfo MedicineDetailInfo { get; set; }
    }
}
