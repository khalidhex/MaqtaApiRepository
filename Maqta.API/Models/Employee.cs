using System.ComponentModel.DataAnnotations;

namespace Maqta.API.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }
     
        
    }
}
