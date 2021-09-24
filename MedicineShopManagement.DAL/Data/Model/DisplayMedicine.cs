using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace MedicineShopManagement.DAL.Data.Model
{
    public class DisplayMedicine
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Select Type")]
        public int TypeId { get; set; }
        [Required]
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Cost_Price { get; set; }
        [Required]
        public string MedicineCode_Code { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(TypeId))]
        [InverseProperty("DisplayMedicine")]
        public virtual DisplayMedicine DisplayMedicine { get; set; }
    }
}
