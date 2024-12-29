﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Razor_E_Web_Net_Core_Temp.Model
{
    public class Category
    {
        //Annotations are like a lable for columns, primary key or foreign key
        //Usually written as  [annotaion], if the propery is Id, classNameID then the
        //Entity framework automatically thinks its a primary key

        [Key] //optional, since the peoperty name is Id
        public int Id { get; set; }

        [Required] //Sets the propety rule to not null when run in sql script
        [DisplayName("Category Name")]
        [MaxLength(25)]
        public string Name { get; set; }

        [DisplayName("Display Order")] //Display Name is used to show the property Name differently
        [Range(1, 100, ErrorMessage = "The Input must be between 1 and 100")]
        public int DisplayOrder { get; set; }
    }
}
