using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MedicineShopManagement.DAL.Data.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string PatientName { get; set; }
        public decimal TotalBill { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
