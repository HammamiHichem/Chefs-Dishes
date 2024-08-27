#pragma warning disable CS8618
namespace ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations;
public class Dishe
{    
    [Key]    
    public int DisheId { get; set; }       
    [Required]
    public string DisheName { get; set; }
    [Required]
    public string Calories { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string Tostiness { get; set; }
    [Required]
     public int ChefId { get; set; }

    // Navigation proprety that lets us connecte with Dish Model
    public Chef? Chef { get; set; }
   
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}
