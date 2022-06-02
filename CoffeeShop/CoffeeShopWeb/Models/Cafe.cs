using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShopWeb.Models
{
    public class Cafe
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }
        [DisplayName("Count Of Personal")]
        [Range(1,60,ErrorMessage = "Count Of Personal must be between 1 and 60!")]
        public int CountOfPersonal { get; set; }
    }
}
