using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModels.Models.FluentModels
{
    public class Fluent_Publisher
    {
        //Publisher_Id(int) - it should be primary key data annotation
        public int Publisher_Id { get; set; }

        //Name should be string and it is required property
        public string Name { get; set; }

        //Add Location property with type string. do not add required attribute for this property
        public string Location { get; set; }

        public List<Fluent_Book> Books { get; set; }
    }
}
