using Microsoft.AspNetCore.Mvc;

public class AuthController : Controller
{
    private readonly IUserService _userService;
    public AuthController(IUserService userService)
    {
        _userService = userService;
    }


    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(UserViewModel model)
    {

        List<UserDTO> userDTOs = new List<UserDTO>();
        try
        {
            if (ModelState.IsValid)
            {
                userDTOs.Add(new UserDTO
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    Password = model.Password,
                }
                );
                _userService.Add(userDTOs);
                // return View("Index","Home");
                return RedirectToAction("Index", "Home");
            }

        }
        catch (InvalidOperationException ex)
        {
            // Hata mesajını TempData'ya ekle
            TempData["Error"] = ex.Message;
            return View(model);
        }
        return View(model);
    }


    public IActionResult SignUp()
    {
        return View();
    }
    [HttpPost]
    public IActionResult SignUp(UserViewModel model)
    {
        List<UserDTO> usersDTO = new List<UserDTO>();
        if (model.Email != null && model.Password != null)
        {

            usersDTO.Add(new UserDTO
            {
                Email = model.Email,
                Password = model.Password,
            });

            model.isConfirm = _userService.ControlSignUp(usersDTO);
        }
        return View(model);
    }

}