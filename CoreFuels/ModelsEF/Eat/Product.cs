using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CoreFuels.ModelsEF;
namespace CoreFuels.ModelsEF
{
    public class Product
    {

        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
        public virtual ICollection<Authorization> Users { get; set; } = new List<Authorization>();

    }

}

