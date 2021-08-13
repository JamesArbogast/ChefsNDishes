using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
  public class Dish 
  {
    [Key]
    public int DishId { get; set; }
    public string DishName { get; set; }
    public int Calories { get; set; }
    public int Tastiness {get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public int ChefId { get; set; }
    public Chef DishChef { get; set; }
  }
}