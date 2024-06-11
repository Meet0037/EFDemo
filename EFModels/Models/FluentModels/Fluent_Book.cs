using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModels.Models.FluentModels
{
    public class Fluent_Book
    {
        //Suffix is Id so EF core will understand as primary key itself
        public int BookId { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }
        public int PriceRange { get; set; }

        public Fluent_BookDetail BookDetail { get; set; }

        //[ForeignKey("Publisher")]
        //public int Publisher_Id { get; set; }

        //public Fluent_Publisher Publisher { get; set; }

        //public List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
    }
}
