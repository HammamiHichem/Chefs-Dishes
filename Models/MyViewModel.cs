#pragma warning disable CS8618
namespace ChefsNDishes.Models;

public class MyViewModel
{
    public Chef? Chef { get; set; }
    public List<Chef>? AllChefs { get; set; }
    public Dishe? Dishe { get; set; }
    public List<Dishe>? AllDishes { get; set; }
}