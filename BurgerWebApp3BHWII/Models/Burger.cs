namespace BurgerWebApp3BHWII.Models;

public class Burger
{
    public int BurgerId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime InventedDate { get; set; }
    public double Price { get; set; }
}