using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChefsNDishes.Models
{
  public class Chef 
  {
    [Key]
    public int ChefId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime Birthday {get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public List<Dish> CreatedDishes { get; set; }
  }
}