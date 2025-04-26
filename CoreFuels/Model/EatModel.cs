using System.ComponentModel.DataAnnotations;

namespace CoreFuels.Model
{
    public class EatModel
    {
        
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrates { get; set; }
    }
}
