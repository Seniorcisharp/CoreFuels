using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;


namespace CoreFuels.ModelsEF // Используйте то же пространство имен, что и в ошибке
{
  
    public class Authorization
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string login { get; set; }

        [Required]
        [MinLength(4)]
        public string pass { get; set; }
        public List<Product> Products { get; set; } = new();


    }
}
