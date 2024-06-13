using System.ComponentModel.DataAnnotations;

namespace EFModels.Models
{
    public class Publisher
    {
        //Publisher_Id(int) - it should be primary key data annotation
        [Key]
        public int Publisher_Id { get; set; }

        //Name should be string and it is required property
        [Required]
        public string Name { get; set; }

        //Add Location property with type string. do not add required attribute for this property
        public string Location { get; set; }

        public List<Book> Books { get; set; }

    }
}
