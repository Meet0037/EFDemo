using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModels.Models
{
    public class SubCategory
    {
        //Add property SubCategory_Id(int) with primary key
        [Key]
        public int SubCategory_Id { get; set; }

        //Add property "Name" with required attribute and the meximum allowed length is 50.
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
