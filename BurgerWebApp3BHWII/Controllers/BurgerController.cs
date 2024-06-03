using BurgerWebApp3BHWII.Models;
using BurgerWebApp3BHWII.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BurgerWebApp3BHWII.Controllers;

public class BurgerController : Controller
{
    // GET
    public IActionResult Index()
    {
        BurgerRepository repo = new BurgerRepository();
        List<Burger> myBurgers = repo.GetAllBurgers();
        
        return View(myBurgers);
    }

    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SaveBurger(Burger burger)
    {
        //Repository holen
        BurgerRepository repo = new BurgerRepository();

        //burger speichern
        repo.CreateBurger(burger);
        
        //Zurück zur Übersicht
        return Redirect("/Burger");
    }
}