using System.ComponentModel.DataAnnotations;

namespace E_Web_NET_CORE.Models
{
    //In MVC normarlly models are used to create table in database
    //The table: category, columns are the porperty
    public class Category
    {
        //Annotations are like a lable for columns, primary key or foreign key
        //Usually written as  [annotaion], if the propery is Id, classNameID then the
        //Entity framework automatically thinks its a primary key

        [Key] //optional, since the peoperty name is Id
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
    }
}
