using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MedicineShopManagement.DAL.Data.Model
{
    public class MedicineType
    {
        public MedicineType()
        {
            DisplayMedicine = new HashSet<DisplayMedicine>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        [InverseProperty("MedicineType")]
        public virtual ICollection<DisplayMedicine> DisplayMedicine { get; set; }
    }
}
