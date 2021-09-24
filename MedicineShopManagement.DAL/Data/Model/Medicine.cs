using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicineShopManagement.DAL.Data.Model
{
    public class Medicine
    {
        public int Id { get; set; }

        [Required] //Specifies that this feild is required.
        [StringLength(100)] //Specifies the character limit for the this feild.
        public string Medicine_Name { get; set; }

        [Required]
        [Display(Name = "Type")] //Specifies the display name for this label.
        public string Medicine_Type { get; set; }
        public int Medicine_Quantity { get; set; }
        public decimal Medicine_Price { get; set; }
    }
}
