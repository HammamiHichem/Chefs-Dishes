#pragma warning disable CS8618
namespace ChefsNDishes.Models;
using System.ComponentModel.DataAnnotations;
public class Chef
{    
    [Key]    
    [Required]
    public int ChefId { get; set; }       
    [Required]
    public string FirstName { get; set; }

    [Required]
    public string LastName { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateOfBirth { get; set; }

    // Navigation proprety that lets us connecte with Pet Model
    public List<Dishe> Dishesmaked { get; set; } = new List<Dishe>();
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

}
