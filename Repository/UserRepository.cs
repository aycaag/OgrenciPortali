public class UserRepository : IUserRepository
{

    private readonly OgrenciPortaliDbContext _context;

    public UserRepository(OgrenciPortaliDbContext context)
    {
        _context = context;
    }

    public List<UserDMO> Add(List<UserDMO> userDMOs)
    {
        _context.User.AddRange(userDMOs);
        _context.SaveChanges();
        return userDMOs;
    }

    public bool ControlSignUp(List<UserDMO> userDMOs)
    {
        // bool isOk  = _context.User.Any(x => x.Email == userDMOs.Email && x.Password == userDMOs.Password);
        bool isOk = userDMOs.All(x =>
                _context.User.Any(dbUser =>
                    dbUser.Email == x.Email && dbUser.Password == x.Password));

        return isOk;
    }

    public List<UserDMO> GetAll()
    {
        List<UserDMO> userDMOs = _context.User.Select(user => new UserDMO
        {
            ID = user.ID,
            Name = user.Name,
            Surname = user.Surname,
            Email = user.Email,

        }).ToList();

        return userDMOs;
    }

    public bool IsEmailExist(string email)
    {
        if (_context.User.FirstOrDefault(u => u.Email == email) != null)
        {
            return true;
        }
        return false;
    }
}

public interface IUserRepository
{
    List<UserDMO> GetAll();
    List<UserDMO> Add(List<UserDMO> userDMOs);

    bool ControlSignUp(List<UserDMO> userDMOs);
    bool IsEmailExist(string email);


}