using System.Reflection.Metadata.Ecma335;

public class UserService : IUserService
{
    public IUserRepository _userRepository;  

    public UserService(IUserRepository repository)
    {
        _userRepository = repository;
    }
    
    public List<UserDMO> Add(List<UserDTO> userDTO)
    {
        List<UserDMO> userDMOs = new List<UserDMO>();

        try{

        
        foreach (var item in userDTO)   
        {
            if (_userRepository.IsEmailExist(item.Email) )
            {
                throw new InvalidOperationException ("Email ile bir kullanıcı var !!! ");
            }           

            userDMOs.Add(new UserDMO{
                Name = item.Name,
                Surname = item.Surname,
                Email = item.Email, 
                Password=item.Password,
            });
        } 
        _userRepository.Add(userDMOs);
        }
        catch(InvalidOperationException ex) 
        { 
            throw ;

        }
        return userDMOs;
    }

    public bool ControlSignUp(List<UserDTO> userDTO)
    {
         List<UserDMO> userDMOs = new List<UserDMO>();
       
        foreach (var item in userDTO)   
        {
            userDMOs.Add(new UserDMO{
                Email = item.Email, 
                Password=item.Password,
            });
        } 
        bool isOK = _userRepository.ControlSignUp(userDMOs);
        
        return isOK;
    }

    public List<UserDTO> GetAll()
    {
        List<UserDMO> userDMOs = _userRepository.GetAll();
        List<UserDTO> userDTOs = new List<UserDTO>();
        
            foreach (var item in userDMOs)
            {
                userDTOs.Add(
                    new UserDTO
                        {
                            ID = item.ID,
                            Name = item.Name,
                            Surname = item.Surname,
                            Email = item.Email, 
                            Password = item.Password,
                        });           
            }
        

        return userDTOs;    
        
    }
}

public interface IUserService
{
    public List<UserDTO> GetAll();
    public List<UserDMO> Add(List<UserDTO> userDTO);

    public bool ControlSignUp (List<UserDTO> userDTO);
    
}