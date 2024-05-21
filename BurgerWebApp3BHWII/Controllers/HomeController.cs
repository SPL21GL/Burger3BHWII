﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BurgerWebApp3BHWII.Models;
using BurgerWebApp3BHWII.Repositories;

namespace BurgerWebApp3BHWII.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        BurgerRepository repo = new BurgerRepository();
        List<Burger> myBurgers = repo.GetAllBurgers();
        
        return View(myBurgers);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}