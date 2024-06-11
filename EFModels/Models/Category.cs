using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModels.Models
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CatagoryId { get; set; }
        [Column("Name")]
        public string CategoryName { get; set; }

        //public int DisplayOrder { get; set; }
    }
}
