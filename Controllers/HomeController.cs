using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers;

public class HomeController : Controller
{    
    private readonly ILogger<HomeController> _logger;
    // Add a private variable of type MyContext (or whatever you named your context file)
    private MyContext _context;         
    // Here we can "inject" our context service into the constructor 
    // The "logger" was something that was already in our code, we're just adding around it   
    public HomeController(ILogger<HomeController> logger, MyContext context)    
    {        
        _logger = logger;
        // When our HomeController is instantiated, it will fill in _context with context
        // Remember that when context is initialized, it brings in everything we need from DbContext
        // which comes from Entity Framework Core
        _context = context;    
    }         
    public IActionResult Index()
    {
        MyViewModel MyModel = new MyViewModel
        {
            AllChefs =_context.Chefs.Include(dishe => dishe.Dishesmaked).ToList()
        };
        
        return View(MyModel);
    }

        [HttpPost("chef/add")]
    public IActionResult AddChef (Chef newChef)
    {
        if(ModelState.IsValid)
        {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        else
        {
            MyViewModel MyModel = new MyViewModel
            {
                AllChefs = _context.Chefs.ToList()
            };
            return View("Index", MyModel);
        }
    }

    public IActionResult Privacy()
    {
         MyViewModel MyModel = new MyViewModel
        {
            AllDishes =_context.Dishes.ToList()
        };
        // Fetch all chefs and populate ViewBag
        ViewBag.AllChefs = _context.Chefs.ToList();
        return View(MyModel);
    }

    [HttpPost("dishe/add")]
    public IActionResult AddDishe (Dishe newDishe)
    {
         ViewBag.AllChefs = _context.Chefs.ToList();
        if(ModelState.IsValid)
        {
            _context.Add(newDishe);
            _context.SaveChanges();
            return RedirectToAction("Privacy");
        }
        else
        {
            MyViewModel MyModel = new MyViewModel
            {
                AllDishes = _context.Dishes.Include(chef => chef.Chef).ToList()
            };
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("Privacy", MyModel);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
