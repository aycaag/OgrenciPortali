using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OgrenciPortali.Models;

namespace OgrenciPortali.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IUserService _userService;

    public HomeController(ILogger<HomeController> logger, IUserService userService )
    {
        _logger = logger;
        _userService = userService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }


    public IActionResult User ()
    {

        List<UserDTO> userDTOs = _userService.GetAll();
        // userDTO'yu UserViewModel'a maple

        List<UserViewModel> result = new List<UserViewModel>();

      
        foreach (var item in userDTOs)
        {
            result.Add(new UserViewModel{
                ID = item.ID,
                Name = item.Name,
                Surname = item.Surname,
                Email = item.Email,
                Password = item.Password,
            });
            ;
        }
        return View(result);  

        


    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
