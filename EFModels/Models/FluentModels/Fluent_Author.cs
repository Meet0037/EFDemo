﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModels.Models.FluentModels
{
    public class Fluent_Author
    {

        //Write this class as per the below requirements
        //Author_Id(int) primary key,
        public int Author_Id { get; set; }

        //FirstName(String) - Required, MaxLength(50)
        public string FirstName { get; set; }

        //LastName(String) - Required,
        public string LastName { get; set; }

        //BirthDate
        public DateTime BirthDate { get; set; }

        //Location(String)
        public string Location { get; set; }

        ///Write a property named FullName as per the below condition
        //-column should not be added to the database 
        //-computed property should return first name and last name with a space in between

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        //public List<Fluent_BookAuthorMap> BookAuthorMap { get; set; }
    }
}
