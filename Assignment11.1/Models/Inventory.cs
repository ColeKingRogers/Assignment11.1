using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Assignment11._1.Models
{
    public class Inventory
    {
        [Key] // Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Summary { get; set; }
    }
}
