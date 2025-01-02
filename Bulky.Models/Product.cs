using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.Models
{
    //In MVC normarlly models are used to create table in database
    //The table: category, columns are the porperty
    internal class Product
    {
        [Key] //optional, since the peoperty name is Id
        public int Id { get; set; }

        //Annotations are like a lable for columns, primary key or foreign key
        //Usually written as  [annotaion], if the propery is Id, classNameID then the
        //Entity framework automatically thinks its a primary key
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }

        [Required]
        public int ISBN { get; set; }

        [Required]
        public string Author { get; set; }
    }
}
