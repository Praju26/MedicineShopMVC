using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicineShopManagement.Services.ViewModel
{
    public class medDisplayMedicineInfo
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost_Price { get; set; }
        public string MedicineCode_Code { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
